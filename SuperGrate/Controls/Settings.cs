using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.supergrate;

            ListViewGroup lastGroup = null;

            foreach(KeyValuePair<string, string> setting in Config.Settings)
            {
                if(setting.Key.Contains("XComment"))
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
    }
}
