namespace Hitachi_LG_LDS_Lidar {
  partial class MainForm {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
      this.cbPort = new System.Windows.Forms.ComboBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblMinDistance = new System.Windows.Forms.Label();
      this.lblMinRPM = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lblMaxDegree = new System.Windows.Forms.Label();
      this.lblMinDegree = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lblMaxDistance = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.btnRefreshPortList = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      this.tbLog = new System.Windows.Forms.TextBox();
      this.pbRealtime = new System.Windows.Forms.PictureBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbRealtime)).BeginInit();
      this.SuspendLayout();
      // 
      // cbPort
      // 
      this.cbPort.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbPort.FormattingEnabled = true;
      this.cbPort.Location = new System.Drawing.Point(3, 16);
      this.cbPort.Name = "cbPort";
      this.cbPort.Size = new System.Drawing.Size(163, 21);
      this.cbPort.TabIndex = 11;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(203, 286);
      this.panel1.TabIndex = 12;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblMinDistance);
      this.groupBox1.Controls.Add(this.lblMinRPM);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.lblMaxDegree);
      this.groupBox1.Controls.Add(this.lblMinDegree);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.lblMaxDistance);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 96);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(203, 167);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Realtime Values";
      // 
      // lblMinDistance
      // 
      this.lblMinDistance.Location = new System.Drawing.Point(150, 19);
      this.lblMinDistance.Name = "lblMinDistance";
      this.lblMinDistance.Size = new System.Drawing.Size(50, 23);
      this.lblMinDistance.TabIndex = 2;
      this.lblMinDistance.Text = "4,000";
      this.lblMinDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblMinRPM
      // 
      this.lblMinRPM.Location = new System.Drawing.Point(150, 128);
      this.lblMinRPM.Name = "lblMinRPM";
      this.lblMinRPM.Size = new System.Drawing.Size(50, 23);
      this.lblMinRPM.TabIndex = 10;
      this.lblMinRPM.Text = "4,000";
      this.lblMinRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(128, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Mininum Distance:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(19, 128);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(125, 23);
      this.label10.TabIndex = 9;
      this.label10.Text = "RPM:";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(19, 42);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(125, 23);
      this.label4.TabIndex = 3;
      this.label4.Text = "Degree:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblMaxDegree
      // 
      this.lblMaxDegree.Location = new System.Drawing.Point(150, 99);
      this.lblMaxDegree.Name = "lblMaxDegree";
      this.lblMaxDegree.Size = new System.Drawing.Size(50, 23);
      this.lblMaxDegree.TabIndex = 8;
      this.lblMaxDegree.Text = "4,000";
      this.lblMaxDegree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblMinDegree
      // 
      this.lblMinDegree.Location = new System.Drawing.Point(150, 42);
      this.lblMinDegree.Name = "lblMinDegree";
      this.lblMinDegree.Size = new System.Drawing.Size(50, 23);
      this.lblMinDegree.TabIndex = 4;
      this.lblMinDegree.Text = "4,000";
      this.lblMinDegree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(19, 99);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(125, 23);
      this.label8.TabIndex = 7;
      this.label8.Text = "Degree:";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(19, 76);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(125, 23);
      this.label6.TabIndex = 5;
      this.label6.Text = "Maximum Distance:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblMaxDistance
      // 
      this.lblMaxDistance.Location = new System.Drawing.Point(150, 76);
      this.lblMaxDistance.Name = "lblMaxDistance";
      this.lblMaxDistance.Size = new System.Drawing.Size(50, 23);
      this.lblMaxDistance.TabIndex = 6;
      this.lblMaxDistance.Text = "4,000";
      this.lblMaxDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.groupBox3);
      this.groupBox2.Controls.Add(this.btnConnect);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(203, 96);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Connection";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.cbPort);
      this.groupBox3.Controls.Add(this.btnRefreshPortList);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(3, 45);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(197, 45);
      this.groupBox3.TabIndex = 13;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Port";
      // 
      // btnRefreshPortList
      // 
      this.btnRefreshPortList.BackgroundImage = global::Hitachi_LG_LDS_Lidar.Properties.Resources.reload;
      this.btnRefreshPortList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnRefreshPortList.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnRefreshPortList.Location = new System.Drawing.Point(166, 16);
      this.btnRefreshPortList.Name = "btnRefreshPortList";
      this.btnRefreshPortList.Size = new System.Drawing.Size(28, 26);
      this.btnRefreshPortList.TabIndex = 12;
      this.btnRefreshPortList.UseVisualStyleBackColor = true;
      this.btnRefreshPortList.Click += new System.EventHandler(this.btnRefreshPortList_Click);
      // 
      // btnConnect
      // 
      this.btnConnect.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnConnect.Location = new System.Drawing.Point(3, 16);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(197, 29);
      this.btnConnect.TabIndex = 12;
      this.btnConnect.Text = "&Start";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // tbLog
      // 
      this.tbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tbLog.Location = new System.Drawing.Point(203, 210);
      this.tbLog.Multiline = true;
      this.tbLog.Name = "tbLog";
      this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbLog.Size = new System.Drawing.Size(275, 76);
      this.tbLog.TabIndex = 13;
      // 
      // pbRealtime
      // 
      this.pbRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pbRealtime.Location = new System.Drawing.Point(203, 0);
      this.pbRealtime.Name = "pbRealtime";
      this.pbRealtime.Size = new System.Drawing.Size(275, 210);
      this.pbRealtime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbRealtime.TabIndex = 14;
      this.pbRealtime.TabStop = false;
      // 
      // MainForm
      // 
      this.ClientSize = new System.Drawing.Size(478, 286);
      this.Controls.Add(this.pbRealtime);
      this.Controls.Add(this.tbLog);
      this.Controls.Add(this.panel1);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbRealtime)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.ComboBox cbPort;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.TextBox tbLog;
  private System.Windows.Forms.Button btnConnect;
  private System.Windows.Forms.PictureBox pbRealtime;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblMinDistance;
    private System.Windows.Forms.Label lblMinRPM;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblMaxDegree;
    private System.Windows.Forms.Label lblMinDegree;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblMaxDistance;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button btnRefreshPortList;
  }
}