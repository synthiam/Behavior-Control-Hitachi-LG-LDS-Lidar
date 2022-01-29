using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using EZ_B;

namespace Hitachi_LG_LDS_Lidar {

  public class LidarServiceUART : DisposableBase {

    /// <summary>
    /// Event raised when the lidar packet is ready.
    /// </summary>
    public event EventHandler<byte[]> OnLidarDataReady;

    /// <summary>
    /// Event raised when the service has started
    /// </summary>
    public event OnStartHandler OnStart;
    public delegate void OnStartHandler();

    /// <summary>
    /// Event raised when the service has stopped
    /// </summary>
    public event OnStopHandler OnStop;
    public delegate void OnStopHandler();

    public event EventHandler<string> OnLog;

    EZTaskScheduler _ts = null;

    int    _BAUD = 230400;
    string _PORT = string.Empty;

    readonly int    _BUFFER_SIZE = 64000;

    /// <summary>
    /// Returns the status of the camera streaming
    /// </summary>
    public bool IsRunning {
      get;
      private set;
    }

    public LidarServiceUART() {

      _ts = new EZTaskScheduler("Lidar UART", true);
      _ts.OnEventToRun += imageThreadWorker;
      _ts.OnEventError += _ts_OnEventError;
    }

    private void _ts_OnEventError(EZTaskScheduler sender, int taskId, object o, Exception ex) {

      OnLog?.Invoke(this, ex.ToString());
    }

    public static string[] GetPorts() {

      return SerialPort.GetPortNames();
    }

    /// <summary>
    /// Connect and begin receiving the camera stream
    /// </summary>
    public void Start(string port, int baud) {

      _BAUD = baud;

      _PORT = port;

      stopWorker();

      _ts.StartNew();
    }

    /// <summary>
    /// Dispose of this object
    /// </summary>
    protected override void DisposeOverride() {

      stopWorker();

      _ts.Dispose();

      _ts = null;
    }

    private void stopWorker() {

      _ts.CancelCurrentTask();
    }

    /// <summary>
    /// Stop the service
    /// </summary>
    public void Stop() {

      stopWorker();
    }

    void imageThreadWorker(EZTaskScheduler sender, int taskId, object o) {

      if (sender.IsCancelRequested(taskId))
        return;

      List<byte> dataBuffer = new List<byte>();
      byte[] bufferTmp = new byte[_BUFFER_SIZE];

      using (var serialPort = new SerialPort(_PORT))
        try {

          IsRunning = true;

          serialPort.BaudRate = _BAUD;
          serialPort.ReadBufferSize = _BUFFER_SIZE;
          serialPort.ReadTimeout = 5000;
          serialPort.DtrEnable = true;
          serialPort.RtsEnable = true;

          serialPort.Open();

          serialPort.Write("b");

          if (sender.IsCancelRequested(taskId))
            return;

          OnStart?.Invoke();

          int zeroCount = 0;

          while (!sender.IsCancelRequested(taskId) && serialPort.IsOpen) {

            if (serialPort.BytesToRead == 0) {

              if (zeroCount > 100)
                throw new Exception("No data received by lidar. Giving up");

              System.Threading.Thread.Sleep(100);

              zeroCount++;

              continue;
            }

            zeroCount = 0;

            int read = serialPort.Read(bufferTmp, 0, _BUFFER_SIZE);

            dataBuffer.AddRange(bufferTmp.Take(read));

            if (dataBuffer.Count > LidarSensorParser.PACKET_SIZE * 20)
              throw new Exception(string.Format("Lidar data is piling up and not being processed. We stopped the collection at {0:###,###} Bytes. Post on the forum so we can better understand what is happening and fix it.", dataBuffer.Count));

            int foundStart = -1;

            if (dataBuffer.Count < LidarSensorParser.PACKET_SIZE)
              continue;

            for (int i = 0; i < dataBuffer.Count - LidarSensorParser.PACKET_SIZE; i++)
              if (dataBuffer[i] == 0xfa && dataBuffer[i + 1] == 0xa0) {

                foundStart = i;

                break;
              }

            if (foundStart == -1)
              continue;

            if (foundStart > 0)
              dataBuffer.RemoveRange(0, foundStart);

            if (dataBuffer.Count < LidarSensorParser.PACKET_SIZE)
              continue;

            OnLidarDataReady?.Invoke(this, dataBuffer.GetRange(0, LidarSensorParser.PACKET_SIZE).ToArray());

            dataBuffer.RemoveRange(0, LidarSensorParser.PACKET_SIZE);
          }
        } catch (Exception ex) {

          throw new Exception(string.Format("Lidar service parse error: {0}", ex));
        } finally {

          if (serialPort != null && serialPort.IsOpen)
            serialPort.Write("e");

          IsRunning = false;

          OnStop?.Invoke();
        }
    }
  }
}
