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
        public static string SourceComputer;
        public static string DestinationComputer;
        public static string[] SelectedSIDs = new string[0];
        public static ListSource CurrentListSource = ListSource.Unknown;
        private static string[] CurrentListSIDs = new string[0];
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
            UpdateFormRestrictions();
        }
        private async void BtStartStop_Click(object sender, EventArgs e)
        {
            tblMainLayout.Enabled = false;
            await CopyUSMT.Do();
            await USMT.Do(USMTMode.ScanState, SelectedSIDs[0]);
            tblMainLayout.Enabled = true;
        }
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            tblMainLayout.Enabled = false;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Source Computer Users";
            Dictionary<string, string> results = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            if (results != null)
            {
                lbxUsers.Items.AddRange(results.Values.ToArray());
                CurrentListSIDs = results.Keys.ToArray();
                CurrentListSource = ListSource.SourceComputer;
                Logger.Success("Done!");
            }
            else
            {
                Logger.Error("Failed to list users from the source computer.");
            }
            tblMainLayout.Enabled = true;
            UpdateFormRestrictions();
        }
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            tblMainLayout.Enabled = false;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Migration Store Users";
            Dictionary<string, string> results = await Misc.GetUsersFromStore(Config.MigrationStorePath);
            if(results != null)
            {
                lbxUsers.Items.AddRange(results.Values.ToArray());
                CurrentListSIDs = results.Keys.ToArray();
                CurrentListSource = ListSource.MigrationStore;
            }
            else
            {
                Logger.Error("Failed to list users from the migration store.");
            }
            tblMainLayout.Enabled = true;
            UpdateFormRestrictions();
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
        private void UpdateFormRestrictions(object sender = null, EventArgs e = null)
        {
            if (lbxUsers.SelectedIndices.Count == 0 || (tbDestinationComputer.Text == "" && CurrentListSource == ListSource.MigrationStore))
            {
                btStartStop.Enabled = false;
            }
            else
            {
                btStartStop.Enabled = true;
            }
            if (lbxUsers.SelectedIndices.Count != 0 && CurrentListSource == ListSource.MigrationStore)
            {
                tbSourceComputer.Enabled = false;
                btnDelete.Enabled = true;
            }
            else
            {
                tbSourceComputer.Enabled = true;
                btnDelete.Enabled = false;
            }
            if(tbSourceComputer.Text == "")
            {
                btnListSource.Enabled = false;
            }
            else
            {
                btnListSource.Enabled = true;
            }
        }
        private void LbxUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> SIDs = new List<string>();
            foreach(int index in lbxUsers.SelectedIndices)
            {
                SIDs.Add(CurrentListSIDs[index]);
            }
            SelectedSIDs = SIDs.ToArray();
            UpdateFormRestrictions();
        }
        private void TbSourceComputer_TextChanged(object sender, EventArgs e)
        {
            SourceComputer = tbSourceComputer.Text;
            UpdateFormRestrictions();
        }
    }
    public enum ListSource
    {
        Unknown = -1,
        SourceComputer = 1,
        MigrationStore = 2
    }
}
