using System;
using System.Collections.Generic;
using System.Linq;
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
        public static ListSources CurrentListSource = ListSources.Unknown;
        private static bool isRunning = false;
        public Main()
        {
            InitializeComponent();
            Form = this;
            LoggerBox = LogBox;
            Progress = pbMain;
            lbxUsers.Tag = new string[0];
            Icon = Properties.Resources.supergrate;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Config.LoadConfig();
            Logger.Success("Welcome to Super Grate!");
            Logger.Information("Enter some information to get started!");
            UpdateFormRestrictions();
        }
        private bool Running {
            get {
                return isRunning;
            }
            set {
                Progress.Value = 0;
                if (value)
                {
                    imgLoadLogo.Enabled = true;
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    lbxUsers.Enabled =
                    false;
                }
                else
                {
                    imgLoadLogo.Enabled = false;
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    lbxUsers.Enabled =
                    true;
                    UpdateFormRestrictions();
                }
                isRunning = value;
            }
        }
        private async void BtStartStop_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                USMT.Cancel();
            }
            else
            {
                Running = true;
                btStartStop.Text = "Stop";
                int count = 0;
                string[] SIDs = new string[lbxUsers.SelectedIndices.Count];
                foreach (int index in lbxUsers.SelectedIndices)
                {
                    SIDs[count++] = ((string[])lbxUsers.Tag)[index];
                }
                if (CurrentListSource == ListSources.SourceComputer)
                {
                    await USMT.Do(USMTMode.ScanState, SIDs);
                }
                if (tbDestinationComputer.Text != "" && Running)
                {
                    await USMT.Do(USMTMode.LoadState, SIDs);
                }
                btStartStop.Text = "Start";
                Running = false;
                Logger.Information("Done.");
            }
        }
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            Running = true;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Users on Source Computer:";
            Dictionary<string, string> results = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            if (results != null)
            {
                lbxUsers.Tag = results.Keys.ToArray();
                lbxUsers.Items.AddRange(results.Values.ToArray());
                CurrentListSource = ListSources.SourceComputer;
                Logger.Success("Done!");
            }
            else
            {
                Logger.Error("Failed to list users from the source computer.");
            }
            Running = false;
        }
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            Running = true;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Users in Migration Store:";
            Dictionary<string, string> results = await Misc.GetUsersFromStore(Config.MigrationStorePath);
            if(results != null)
            {
                lbxUsers.Tag = results.Keys.ToArray();
                lbxUsers.Items.AddRange(results.Values.ToArray());
                CurrentListSource = ListSources.MigrationStore;
            }
            else
            {
                Logger.Error("Failed to list users from the migration store.");
            }
            Running = false;
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
            if (lbxUsers.SelectedIndices.Count == 0 || (tbDestinationComputer.Text == "" && CurrentListSource == ListSources.MigrationStore))
            {
                btStartStop.Enabled = false;
            }
            else
            {
                btStartStop.Enabled = true;
            }
            if (lbxUsers.SelectedIndices.Count != 0 && CurrentListSource == ListSources.MigrationStore)
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
        private void TbSourceComputer_TextChanged(object sender, EventArgs e)
        {
            SourceComputer = tbSourceComputer.Text;
            if(CurrentListSource == ListSources.SourceComputer)
            {
                lbxUsers.Items.Clear();
            }
            UpdateFormRestrictions();
        }
        private void TbDestinationComputer_TextChanged(object sender, EventArgs e)
        {
            DestinationComputer = tbDestinationComputer.Text;
            UpdateFormRestrictions();
        }
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            Running = true;
            foreach (int index in lbxUsers.SelectedIndices)
            {
                await Misc.DeleteFromStore(((string[])lbxUsers.Tag)[index]);
            }
            Running = false;
            btnListStore.PerformClick();
        }
    }
    public enum ListSources
    {
        Unknown = -1,
        SourceComputer = 1,
        MigrationStore = 2
    }
}
