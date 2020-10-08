using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ChangeSetting : Form
    {
        private readonly string Setting = "";
        /// <summary>
        /// Entry point for the ChangeSetting class. This method will display a form with the selected setting and allow the user to change it's value.
        /// </summary>
        /// <param name="SettingToChange">The key name of the Config.Settings[] dictionary to change.</param>
        public ChangeSetting(string SettingToChange)
        {
            InitializeComponent();
            Icon = Properties.Resources.settings_ico;
            btnCancel.SetSystemIcon(Properties.Resources.cancel_ico);
            btnSave.SetSystemIcon(Properties.Resources.check_ico);
            btnRestoreDefault.SetSystemIcon(Properties.Resources.reload_ico);
            Setting = SettingToChange;
        }
        /// <summary>
        /// This event will fire when the changeSetting form has loaded. The method will fill in the selected information into the form's controls.
        /// </summary>
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
        /// <summary>
        /// This event will fire when the btnSave button is clicked. The method will apply the setting to the session.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Config.Settings[Setting] = tbValue.Text;
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// This event will fire when the tbValue text box gets an input. The method will simulate a click for the btnSave button if the enter key is pressed.
        /// </summary>
        private void TbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }
        /// <summary>
        /// This event will fire when the btnRestoreDefault button is clicked. The method will restore the default value for the setting.
        /// </summary>
        private void BtnRestoreDefault_Click(object sender, EventArgs e)
        {
            tbValue.Text = Config.DefaultSettings[Setting];
        }
    }
}
