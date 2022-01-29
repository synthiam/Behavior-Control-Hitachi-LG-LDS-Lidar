using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitachi_LG_LDS_Lidar {

  public partial class ConfigForm : Form {

    private ARC.Config.Sub.PluginV1 _cf;

    public ConfigForm() {

      InitializeComponent();
    }

    public void SetConfiguration(ARC.Config.Sub.PluginV1 config) {

      try {

        _cf = config;

        tbBaud.Text = _cf.STORAGE[ConfigTitles.BAUD_RATE].ToString();

        tbDegreesOffset.Text = _cf.STORAGE[ConfigTitles.OFFSET_DEGREES].ToString();

        cbEnableDebugging.Checked = Convert.ToBoolean(_cf.STORAGE[ConfigTitles.ENABLE_DEBUGGING]);

      } catch (Exception ex) {

        MessageBox.Show(ex.Message, "Error loading configuration");
      }
    }

    public ARC.Config.Sub.PluginV1 GetConfiguration() {
    
      return _cf;
    }

    private void btnSave_Click(object sender, EventArgs e) {

      try {

        _cf.STORAGE[ConfigTitles.BAUD_RATE] = Convert.ToInt32(tbBaud.Text);

        _cf.STORAGE[ConfigTitles.OFFSET_DEGREES] = Convert.ToInt32(tbDegreesOffset.Text);

        _cf.STORAGE[ConfigTitles.ENABLE_DEBUGGING] = cbEnableDebugging.Checked;
      } catch (Exception ex) {

        MessageBox.Show(ex.Message, "Error saving configuration");

        return;
      }

      DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) {

      DialogResult = DialogResult.Cancel;
    }
  }
}
