using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrate
{
    public partial class Main : Form
    {
        public static Form Form;
        public static RichTextBox LoggerBox;
        public static ProgressBar Progress;
        public Main()
        {
            InitializeComponent();
            Form = this;
            LoggerBox = LogBox;
            Progress = pbMain;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Config.LoadConfig();
            Logger.Success("Welcome to Super Grate!");
            Logger.Information("Enter some information to get started!");
        }
        private async void BtStart_Click(object sender, EventArgs e)
        {
            tblMainLayout.Enabled = false;
            await CopyUSMT.Do(tbSourceComputer.Text);
            tblMainLayout.Enabled = true;
        }
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            tbSourceComputer.Enabled = true;
            tblMainLayout.Enabled = false;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Source Computer Users";
            Dictionary<string, string> results = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            if (results != null)
            {
                lbxUsers.Items.AddRange(results.Values.ToArray());
                Logger.Success("Done!");
            }
            else
            {
                Logger.Error("Failed to list users from the source computer.");
            }
            tblMainLayout.Enabled = true;
        }
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            tbSourceComputer.Enabled = false;
            tblMainLayout.Enabled = false;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Migration Store Users";
            Dictionary<string, string> results = await Misc.GetUsersFromStore(tbMigrationStore.Text);
            if(results != null)
            {
                lbxUsers.Items.AddRange(results.Values.ToArray());
            }
            else
            {
                Logger.Error("Failed to list users from the migration store.");
            }
            tblMainLayout.Enabled = true;
        }
        private void LogBox_DoubleClick(object sender, EventArgs e)
        {
            if(Logger.VerboseEnabled)
            {
                Logger.VerboseEnabled = false;
                Logger.Information("Verbose mode disabled.");
            }
            else
            {
                Logger.VerboseEnabled = true;
                Logger.Information("Verbose mode enabled.");
            }
        }
        private void OnFormChange(object sender, EventArgs e)
        {
            if (
                lbxUsers.SelectedIndices.Count == 0
            )
            {
                btStartStop.Enabled = false;
            }
            else
            {
                btStartStop.Enabled = true;
            }
        }
    }
}
