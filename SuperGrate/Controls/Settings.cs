using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class Settings : Form
    {
        /// <summary>
        /// This method is the entrypoint for the settings class.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            Icon = Properties.Resources.settings_ico;
            btnSave.SetSystemIcon(Properties.Resources.save_ico);
            btnRevert.SetSystemIcon(Properties.Resources.reload_ico);
            btnApply.SetSystemIcon(Properties.Resources.x_ico);
        }
        /// <summary>
        /// This event fires when the settings form loads. The method calls RefreshSettings.
        /// </summary>
        private void Settings_Load(object sender, EventArgs e)
        {
            RefreshSettings();
            btnSave.Enabled = Config.CanSaveConfig();
        }
        /// <summary>
        /// This method loads the Config.Settings dictionary into the settingsList.
        /// </summary>
        private void RefreshSettings()
        {
            settingsList.Items.Clear();
            settingsList.Groups.Clear();
            ListViewGroup lastGroup = null;
            foreach (KeyValuePair<string, string> setting in Config.Settings)
            {
                if (setting.Key.Contains("Config/Comment"))
                {
                    lastGroup = new ListViewGroup(setting.Value);
                    settingsList.Groups.Add(lastGroup);
                }
                else
                {
                    ListViewItem item = settingsList.Items.Add(setting.Key);
                    item.SubItems.Add(setting.Value);
                    if (lastGroup != null) item.Group = lastGroup;
                }
            }
            settingsList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        /// <summary>
        /// This event fires when the btnRevert button is clicked. The method re-loads the configuration on disk back into the settingsList control.
        /// </summary>
        private async void btnRevert_Click(object sender, EventArgs e)
        {
            btnRevert.Enabled = false;
            Config.LoadConfig();
            RefreshSettings();
            string text = btnRevert.Text;
            btnRevert.SetSystemIcon(Properties.Resources.check_ico);
            btnRevert.Text = " Loaded!";
            await Task.Delay(1000);
            btnRevert.SetSystemIcon(Properties.Resources.reload_ico);
            btnRevert.Text = text;
            btnRevert.Enabled = true;
        }
        /// <summary>
        /// This event fires when the settingsList list is double clicked. The method opens the selected setting for editing.
        /// </summary>
        private void SettingsList_DoubleClick(object sender, EventArgs e)
        {
            if (settingsList.SelectedItems.Count != 0)
            {
                DialogResult result = new ChangeSetting(settingsList.SelectedItems[0].Text).ShowDialog();
                if (result == DialogResult.OK)
                {
                    int selectedIndex = settingsList.SelectedItems[0].Index;
                    RefreshSettings();
                    settingsList.Items[selectedIndex].Selected = true;
                    settingsList.Items[selectedIndex].EnsureVisible();
                }
                btnApply.Focus();
            }
        }
        /// <summary>
        /// This event fires when the btnSave button is clicked. The method will attempt to save the configuration to disk.
        /// </summary>
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Config.SaveConfig();
            string text = btnSave.Text;
            btnSave.SetSystemIcon(Properties.Resources.check_ico);
            btnSave.Text = " Saved!";
            await Task.Delay(1000);
            btnSave.SetSystemIcon(Properties.Resources.save_ico);
            btnSave.Text = text;
            btnSave.Enabled = true;
        }
    }
}