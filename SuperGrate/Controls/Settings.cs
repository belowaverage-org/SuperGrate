using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Icon = Properties.Resources.settings;
            btnSave.SetSystemIcon(Properties.Resources.save);
            btnRevert.SetSystemIcon(Properties.Resources.reload);
            btnApply.SetSystemIcon(Properties.Resources.x);
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            RefreshSettings();
        }
        private void RefreshSettings()
        {
            settingsList.Items.Clear();
            settingsList.Groups.Clear();
            ListViewGroup lastGroup = null;
            foreach (KeyValuePair<string, string> setting in Config.Settings)
            {
                if (setting.Key.Contains("XComment"))
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
        private async void BtnCancel_Click(object sender, EventArgs e)
        {
            btnRevert.Enabled = false;
            Config.LoadConfig();
            RefreshSettings();
            string text = btnRevert.Text;
            btnRevert.SetSystemIcon(Properties.Resources.check);
            btnRevert.Text = " Loaded!";
            await Task.Delay(1000);
            btnRevert.SetSystemIcon(Properties.Resources.reload);
            btnRevert.Text = text;
            btnRevert.Enabled = true;
        }
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
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Config.SaveConfig();
            string text = btnSave.Text;
            btnSave.SetSystemIcon(Properties.Resources.check);
            btnSave.Text = " Saved!";
            await Task.Delay(1000);
            btnSave.SetSystemIcon(Properties.Resources.save);
            btnSave.Text = text;
            btnSave.Enabled = true;
        }
    }
}