using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ChangeSetting : Form
    {
        private string Setting = "";
        public ChangeSetting(string SettingToChange)
        {
            InitializeComponent();
            Setting = SettingToChange;
        }
        private void ChangeSetting_Load(object sender, EventArgs e)
        {
            Text += Setting;
            string lastComment = "";
            foreach (KeyValuePair<string, string> setting in Config.Settings)
            {
                if (setting.Key.Contains("XComment")) lastComment = setting.Value;
                if (setting.Key == Setting)
                {
                    tbValue.Text = setting.Value;
                    break;
                };
            }
            tbComment.Text = lastComment + "\r\n\r\n" + "Default Value: " + Config.DefaultSettings[Setting];
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Config.Settings[Setting] = tbValue.Text;
            Close();
        }
        private void TbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }
        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            tbValue.Text = Config.DefaultSettings[Setting];
        }
    }
}
