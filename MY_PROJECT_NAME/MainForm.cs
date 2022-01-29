using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ARC;

namespace Hitachi_LG_LDS_Lidar {

  public partial class MainForm : ARC.UCForms.FormPluginMaster {

    readonly int IMAGE_WIDTH = 350;
    readonly int IMAGE_HEIGHT = 350;

    LidarServiceUART        _lidarService;
    Stopwatch               _stopWatch;
    LidarSensorParser       _lidarParser;
    bool                    _debugging;

    public MainForm() {

      InitializeComponent();

      ConfigButton = true;

      _stopWatch = new Stopwatch();

      updatePortList();

      _lidarParser = new LidarSensorParser();
      _lidarParser.OnWarning += _lidarParser_OnWarning;

      _lidarService = new LidarServiceUART();
      _lidarService.OnLidarDataReady += _lidarService_OnLidarDataReady1;
      _lidarService.OnStart += _lidarService_OnStart;
      _lidarService.OnStop += _lidarService_OnStop;
      _lidarService.OnLog += _lidarService_OnLog;

      pbRealtime.Image = new Bitmap(400, 400);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {

      stop();

      _lidarService.Dispose();
      _lidarService = null;
    }

    /// <summary>
    /// Set the configuration from the project file when loaded.
    /// We'll extract the _config class that's from the project file.
    /// </summary>
    public override void SetConfiguration(ARC.Config.Sub.PluginV1 cf) {

      cf.STORAGE.AddIfNotExist(ConfigTitles.NEAREST_DEGREE_VAR, "$LidarNearestDegree");
      cf.STORAGE.AddIfNotExist(ConfigTitles.NEAREST_DISTANCE_VAR, "$LidarNearestDistance");
      cf.STORAGE.AddIfNotExist(ConfigTitles.FURTHEST_DEGREE_VAR, "$LidarFurthestDegree");
      cf.STORAGE.AddIfNotExist(ConfigTitles.FURTHEST_DISTANCE_VAR, "$LidarFurthestDistance");
      cf.STORAGE.AddIfNotExist(ConfigTitles.IS_LIDAR_RUNNING_VARIABLE, "$LidarIsRunning");
      cf.STORAGE.AddIfNotExist(ConfigTitles.BAUD_RATE, 230400);
      cf.STORAGE.AddIfNotExist(ConfigTitles.OFFSET_DEGREES, 0);
      cf.STORAGE.AddIfNotExist(ConfigTitles.ENABLE_DEBUGGING, false);

      ARC.Scripting.VariableManager.SetVariable(cf.STORAGE[ConfigTitles.NEAREST_DISTANCE_VAR].ToString(), 0);
      ARC.Scripting.VariableManager.SetVariable(cf.STORAGE[ConfigTitles.NEAREST_DEGREE_VAR].ToString(), 0);
      ARC.Scripting.VariableManager.SetVariable(cf.STORAGE[ConfigTitles.FURTHEST_DISTANCE_VAR].ToString(), 0);
      ARC.Scripting.VariableManager.SetVariable(cf.STORAGE[ConfigTitles.FURTHEST_DEGREE_VAR].ToString(), 0);

      ARC.Scripting.VariableManager.SetVariable(cf.STORAGE[ConfigTitles.IS_LIDAR_RUNNING_VARIABLE].ToString(), false);

      _debugging = Convert.ToBoolean(cf.STORAGE[ConfigTitles.ENABLE_DEBUGGING]);

      base.SetConfiguration(cf);
    }

    /// <summary>
    /// The user pressed the config button in the title bar. Show the config menu and handle the changes to the config.
    /// </summary>
    public override void ConfigPressed() {

      if (_lidarService.IsRunning)
        _lidarService.Stop();

      using (var form = new ConfigForm()) {

        form.SetConfiguration(_cf);

        if (form.ShowDialog() != DialogResult.OK)
          return;

        _cf = form.GetConfiguration();
      }
    }

    public override object[] GetSupportedControlCommands() {

      return new string[] {

        Common.Quote(ControlCommands.START),
        Common.Quote(ControlCommands.STOP),
        };
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals(ControlCommands.START, StringComparison.InvariantCultureIgnoreCase))
        start();
      else if (windowCommand.Equals(ControlCommands.STOP, StringComparison.InvariantCultureIgnoreCase))
        stop();
      else
        base.SendCommand(windowCommand, values);
    }

    void updatePortList() {

      cbPort.Items.Clear();
      cbPort.Items.AddRange(LidarServiceUART.GetPorts());

      if (cbPort.Items.Count > 0)
        cbPort.SelectedIndex = 0;
    }

    void start() {

      if (_lidarService.IsRunning)
        _lidarService.Stop();

      _lidarService.Start(
        cbPort.SelectedItem.ToString(),
        Convert.ToInt32(_cf.STORAGE[ConfigTitles.BAUD_RATE]));
    }

    void stop() {

      if (_lidarService.IsRunning)
        _lidarService.Stop();
    }

    private void _lidarService_OnStop() {

      if (IsClosing)
        return;

      Invokers.SetText(btnConnect, "Start");
      Invokers.SetBackColor(btnConnect, Color.Lime);
      Invokers.SetForeColor(btnConnect, Color.Black);
      Invokers.SetEnabled(groupBox3, true);

      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.IS_LIDAR_RUNNING_VARIABLE].ToString(), false);

      _stopWatch.Stop();
    }

    private void _lidarService_OnStart() {

      if (IsClosing)
        return;

      Invokers.SetText(btnConnect, "Stop");
      Invokers.SetBackColor(btnConnect, Color.Red);
      Invokers.SetForeColor(btnConnect, Color.White);
      Invokers.SetEnabled(groupBox3, false);

      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.IS_LIDAR_RUNNING_VARIABLE].ToString(), true);

      _stopWatch.Restart();
    }

    private void btnConnect_Click(object sender, EventArgs e) {

      try {

        if (_lidarService.IsRunning)
          stop();
        else
          start();
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    private void _lidarParser_OnWarning(object sender, string e) {

      if (IsClosing || !_debugging)
        return;

      Invokers.SetAppendText(tbLog, true, $"Parser: {e}");
    }

    private void _lidarService_OnLog(object sender, string e) {

      if (IsClosing)
        return;

      Invokers.SetAppendText(tbLog, true, e);
    }

    private void _lidarService_OnLidarDataReady1(object sender, byte[] lidarData) {

      if (IsClosing)
        return;

      var scanPoints = _lidarParser.ParseRawSensorPacket(lidarData);

      if (scanPoints.Length != 360) {

        if (_debugging)
          Invokers.SetAppendText(tbLog, true, $"Expecting 360 degrees, received {scanPoints.Length} degrees");

        return;
      }

      ARC.MessagingService.Navigation2DV1.Messenger.UpdateScan(scanPoints);

      List<PointF> points = new List<PointF>();

      var sensorMin = new ARC.MessagingService.Navigation2DV1.ScanPoint(999999, 0, 0);
      var sensorMax = new ARC.MessagingService.Navigation2DV1.ScanPoint(0, 0, 0);

      int[] distanceArray = new int[scanPoints.Length];

      int degreesOffset = Convert.ToInt32(_cf.STORAGE[ConfigTitles.OFFSET_DEGREES]);

      for (int x = 0; x < scanPoints.Length; x++) {

        var sensorValue = scanPoints[x];

        sensorValue.Degree = sensorValue.Degree + degreesOffset % 360;

        if (sensorValue.Distance > 0 && sensorValue.Distance < sensorMin.Distance)
          sensorMin = sensorValue;

        if (sensorValue.Distance > sensorMax.Distance)
          sensorMax = sensorValue;

        if (sensorValue.Distance > 0)
          points.Add(new PointF(
            (float)((IMAGE_WIDTH / 2) + EZ_B.Functions.DegX2(sensorValue.Degree, sensorValue.Distance / 4)),
            (float)((IMAGE_HEIGHT / 2) + EZ_B.Functions.DegY2(sensorValue.Degree, sensorValue.Distance / 4))));

        distanceArray[x] = sensorValue.Distance;
      }

      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.NEAREST_DISTANCE_VAR].ToString(), sensorMin.Distance);
      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.NEAREST_DEGREE_VAR].ToString(), sensorMin.Degree);

      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.FURTHEST_DISTANCE_VAR].ToString(), sensorMax.Distance);
      ARC.Scripting.VariableManager.SetVariable(_cf.STORAGE[ConfigTitles.FURTHEST_DEGREE_VAR].ToString(), sensorMax.Degree);

      // Update image twice a second
      if (_stopWatch.ElapsedMilliseconds > 500) {

        _stopWatch.Restart();

        using (Bitmap bmRealtime = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT)) {

          using (Graphics gRealtime = Graphics.FromImage(bmRealtime)) {

            gRealtime.Clear(Color.Black);

            Pen p = new Pen(Color.Red, 7);

            gRealtime.FillPolygon(Brushes.Silver, points.ToArray());
            gRealtime.DrawLines(p, points.ToArray());

            List<Point> triangle = new List<Point>();
            triangle.Add(new Point((IMAGE_WIDTH / 2) - 5, (IMAGE_HEIGHT / 2) + 5));
            triangle.Add(new Point((IMAGE_WIDTH / 2) + 5, (IMAGE_HEIGHT / 2) + 5));
            triangle.Add(new Point((IMAGE_WIDTH / 2), (IMAGE_HEIGHT / 2) - 10));

            gRealtime.FillPolygon(Brushes.Green, triangle.ToArray());
            gRealtime.DrawPolygon(Pens.Black, triangle.ToArray());
          }

          this.Invoke(new Action(() => {

            using (Graphics gRealTime = Graphics.FromImage(pbRealtime.Image))
              gRealTime.DrawImage(bmRealtime, 0, 0, pbRealtime.Image.Width, pbRealtime.Image.Height);

            pbRealtime.Refresh();

            lblMinDistance.Text = sensorMin.Distance.ToString();
            lblMinDegree.Text = sensorMin.Degree.ToString();

            lblMaxDistance.Text = sensorMax.Distance.ToString();
            lblMaxDegree.Text = sensorMax.Degree.ToString();

          }));
        }
      }
    }

    private void btnRefreshPortList_Click(object sender, EventArgs e) {

      updatePortList();
    }
  }
}
