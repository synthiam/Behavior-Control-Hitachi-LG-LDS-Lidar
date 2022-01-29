namespace Hitachi_LG_LDS_Lidar {

  partial class ConfigForm {
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tbBaud = new System.Windows.Forms.TextBox();
      this.ucHelpHover1 = new ARC.UCForms.UC.UCHelpHover();
      this.ucHelpHover2 = new ARC.UCForms.UC.UCHelpHover();
      this.tbDegreesOffset = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbEnableDebugging = new System.Windows.Forms.CheckBox();
      this.ucHelpHover3 = new ARC.UCForms.UC.UCHelpHover();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 212);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(508, 62);
      this.panel1.TabIndex = 0;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(100, 0);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(99, 62);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnSave
      // 
      this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Location = new System.Drawing.Point(0, 0);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(100, 62);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(13, 25);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(130, 22);
      this.label1.TabIndex = 1;
      this.label1.Text = "Baud Rate:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tbBaud
      // 
      this.tbBaud.Location = new System.Drawing.Point(150, 25);
      this.tbBaud.Name = "tbBaud";
      this.tbBaud.Size = new System.Drawing.Size(255, 22);
      this.tbBaud.TabIndex = 2;
      // 
      // ucHelpHover1
      // 
      this.ucHelpHover1.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover1.Location = new System.Drawing.Point(408, 25);
      this.ucHelpHover1.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover1.Name = "ucHelpHover1";
      this.ucHelpHover1.SetHelpText = "The baud rate for connecting to the USB UART device that the LG LDS is connected " +
    "to. By default it is 230400.";
      this.ucHelpHover1.Size = new System.Drawing.Size(22, 22);
      this.ucHelpHover1.TabIndex = 3;
      // 
      // ucHelpHover2
      // 
      this.ucHelpHover2.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover2.Location = new System.Drawing.Point(408, 53);
      this.ucHelpHover2.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover2.Name = "ucHelpHover2";
      this.ucHelpHover2.SetHelpText = "The number of degrees to offset the rotation of the sensor. Usually the pulley is" +
    " facing 0 degrees, but if it is mounted in reverse then you\'d want to set this v" +
    "alue to 180.";
      this.ucHelpHover2.Size = new System.Drawing.Size(22, 22);
      this.ucHelpHover2.TabIndex = 6;
      // 
      // tbDegreesOffset
      // 
      this.tbDegreesOffset.Location = new System.Drawing.Point(150, 53);
      this.tbDegreesOffset.Name = "tbDegreesOffset";
      this.tbDegreesOffset.Size = new System.Drawing.Size(255, 22);
      this.tbDegreesOffset.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(13, 53);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(130, 22);
      this.label2.TabIndex = 4;
      this.label2.Text = "Offset Degrees:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbEnableDebugging
      // 
      this.cbEnableDebugging.AutoSize = true;
      this.cbEnableDebugging.Location = new System.Drawing.Point(150, 81);
      this.cbEnableDebugging.Name = "cbEnableDebugging";
      this.cbEnableDebugging.Size = new System.Drawing.Size(280, 20);
      this.cbEnableDebugging.TabIndex = 7;
      this.cbEnableDebugging.Text = "Advanced communication/parse debuging";
      this.cbEnableDebugging.UseVisualStyleBackColor = true;
      // 
      // ucHelpHover3
      // 
      this.ucHelpHover3.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover3.Location = new System.Drawing.Point(121, 79);
      this.ucHelpHover3.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover3.Name = "ucHelpHover3";
      this.ucHelpHover3.SetHelpText = "Displays debug warnings from the parser if checked";
      this.ucHelpHover3.Size = new System.Drawing.Size(22, 22);
      this.ucHelpHover3.TabIndex = 8;
      // 
      // ConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(508, 274);
      this.Controls.Add(this.ucHelpHover3);
      this.Controls.Add(this.cbEnableDebugging);
      this.Controls.Add(this.ucHelpHover2);
      this.Controls.Add(this.tbDegreesOffset);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ucHelpHover1);
      this.Controls.Add(this.tbBaud);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "ConfigForm";
      this.ShowIcon = false;
      this.Text = "Configuration";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBaud;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover1;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover2;
    private System.Windows.Forms.TextBox tbDegreesOffset;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox cbEnableDebugging;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover3;
  }
}