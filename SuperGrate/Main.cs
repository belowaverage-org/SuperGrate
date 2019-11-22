using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;

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
        private static RunningTask storeRunningTask = RunningTask.None;
        private string[] MainParameters = null;
        private bool CloseRequested = false;
        private int CloseAttempts = 0;
        public Main(string[] parameters)
        {
            MainParameters = parameters;
            InitializeComponent();
            Form = this;
            LoggerBox = LogBox;
            Progress = pbMain;
            lbxUsers.Tag = new string[0];
            Icon = Properties.Resources.supergrate;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Config.LoadConfig(MainParameters);
            Logger.Success("Welcome to Super Grate! v" + Application.ProductVersion);
            Logger.Information("Enter some information to get started!");
            UpdateFormRestrictions();
            BindHelp(this);
        }
        private void BindHelp(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                childControl.MouseEnter += Control_Click;
                if(childControl.HasChildren)
                {
                    BindHelp(childControl);
                }
            }
        }
        private void Control_Click(object sender, EventArgs e)
        {
            if (Cursor == Cursors.Help)
            {
                Point mouse = MousePosition;
                mouse.Offset(50, 50);
                Help.ShowPopup(this, helpProvider.GetHelpString((Control)sender), mouse);
            }
        }
        private RunningTask Running {
            get {
                return storeRunningTask;
            }
            set {
                Logger.UpdateProgress(0);
                if (value != RunningTask.None)
                {
                    btStartStop.Text = "Stop";
                    storeRunningTask = value;
                    imgLoadLogo.Enabled = true;
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnAFillSrc.Enabled =
                    btnAFillDest.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    lbxUsers.Enabled =
                    false;
                }
                else
                {
                    btStartStop.Text = "Start";
                    storeRunningTask = value;
                    imgLoadLogo.Enabled = false;
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnAFillSrc.Enabled =
                    btnAFillDest.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    lbxUsers.Enabled =
                    true;
                    UpdateFormRestrictions();
                    if (CloseRequested) Close();
                    if (!ContainsFocus && !IsDisposed) FlashWindow.Start(Handle, FlashWindow.FlashWindowStyle.FLASHW_ALL | FlashWindow.FlashWindowStyle.FLASHW_TIMERNOFG);
                }
            }
        }
        private async void BtStartStop_Click(object sender, EventArgs e)
        {
            if (Running == RunningTask.USMT)
            {
                USMT.Cancel();
            }
            else if(Running == RunningTask.RemoteProfileDelete)
            {
                Misc.CancelRemoteProfileDelete(SourceComputer);
            }
            else if(Running == RunningTask.None)
            {
                Running = RunningTask.USMT;
                int count = 0;
                string[] SIDs = new string[lbxUsers.SelectedIndices.Count];
                foreach (int index in lbxUsers.SelectedIndices)
                {
                    SIDs[count++] = ((string[])lbxUsers.Tag)[index];
                }
                bool setting;
                bool success;
                if (CurrentListSource == ListSources.SourceComputer)
                {
                    success = await USMT.Do(USMTMode.ScanState, SIDs);
                    if (bool.TryParse(Config.Settings["AutoDeleteFromSource"], out setting) && setting && success)
                    {
                        await Misc.DeleteFromSource(SourceComputer, SIDs);
                    }
                }
                if (tbDestinationComputer.Text != "" && Running == RunningTask.USMT)
                {
                    success = await USMT.Do(USMTMode.LoadState, SIDs);
                    if (bool.TryParse(Config.Settings["AutoDeleteFromStore"], out setting) && setting && success)
                    {
                        await Misc.DeleteFromStore(SIDs);
                    }
                }
                Running = RunningTask.None;
                Logger.Information("Done.");
            }
        }
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Users on Source Computer:";
            Dictionary<string, string> users = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            List<string> tags = new List<string>();
            if (users != null)
            {
                bool setting;
                foreach (KeyValuePair<string, string> user in users)
                {
                    if (bool.TryParse(Config.Settings["HideBuiltInAccounts"], out setting) && setting && (user.Value.Contains("NT AUTHORITY") || user.Value.Contains("NT SERVICE")))
                    {
                        Logger.Verbose("Skipped: " + user.Key + ": " + user.Value + ".");
                        continue;
                    }
                    if (bool.TryParse(Config.Settings["HideUnknownSIDs"], out setting) && setting && user.Key == user.Value)
                    {
                        Logger.Verbose("Skipped unknown SID: " + user.Key + ".");
                        continue;
                    }
                    lbxUsers.Items.Add(user.Value);
                    tags.Add(user.Key);
                }
                lbxUsers.Tag = tags.ToArray();
                CurrentListSource = ListSources.SourceComputer;
                Logger.Success("Done!");
            }
            Running = RunningTask.None;
        }
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            lbxUsers.Items.Clear();
            lblUserList.Text = "Users in Migration Store:";
            Dictionary<string, string> results = await Misc.GetUsersFromStore(Config.Settings["MigrationStorePath"]);
            if(results != null)
            {
                lbxUsers.Tag = results.Keys.ToArray();
                lbxUsers.Items.AddRange(results.Values.ToArray());
                CurrentListSource = ListSources.MigrationStore;
            }
            Running = RunningTask.None;
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
            if (lbxUsers.SelectedIndices.Count != 0)
            {
                tbSourceComputer.Enabled = btnAFillSrc.Enabled = false;
                btnDelete.Enabled = true;
            }
            else
            {
                tbSourceComputer.Enabled = btnAFillSrc.Enabled = true;
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
            Running = RunningTask.RemoteProfileDelete;
            List<string> SIDs = new List<string>();
            foreach (int index in lbxUsers.SelectedIndices)
            {
                SIDs.Add(((string[])lbxUsers.Tag)[index]);
            }
            if(CurrentListSource == ListSources.MigrationStore)
            {
                btStartStop.Enabled = false;
                await Misc.DeleteFromStore(SIDs.ToArray());
                btStartStop.Enabled = true;
                Running = RunningTask.None;
                btnListStore.PerformClick();
            }
            else if(CurrentListSource == ListSources.SourceComputer)
            {
                await Misc.DeleteFromSource(SourceComputer, SIDs.ToArray());
                Running = RunningTask.None;
                btnListSource.PerformClick();
            }
            Running = RunningTask.None;
        }
        private void TbSourceComputer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnListSource.PerformClick();
            }
        }
        private void BtnAFillSrc_Click(object sender, EventArgs e)
        {
            tbSourceComputer.Text = Environment.MachineName;
        }
        private void BtnAFillDest_Click(object sender, EventArgs e)
        {
            tbDestinationComputer.Text = Environment.MachineName;
        }
        private void MiExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void MiSaveLog_Click(object sender, EventArgs e)
        {
            dialogSaveLog.FileName = 
            "SuperGrate_" +
            DateTime.Now.ToShortDateString().Replace('/', '-') + "_" +
            DateTime.Now.ToLongTimeString().Replace(':', '-');
            if (dialogSaveLog.ShowDialog() == DialogResult.OK)
            {
                await Logger.WriteLogToFile(dialogSaveLog.OpenFile());
            }
        }
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(++CloseAttempts >= 3) return;
            if (Running != RunningTask.None)
            {
                e.Cancel = true;
                CloseRequested = true;
                BtStartStop_Click(null, null);
            }
            else if(Config.Settings["DumpLogHereOnExit"] != "")
            {
                string fileName =
                "SuperGrate_" +
                Environment.UserName + "_" +
                new Random().Next(11111, 99999) + "_" +
                DateTime.Now.ToShortDateString().Replace('/', '-') + "_" +
                DateTime.Now.ToLongTimeString().Replace(':', '-') + ".log";
                try
                {
                    if (!Directory.Exists(Config.Settings["DumpLogHereOnExit"]))
                    {
                        Directory.CreateDirectory(Config.Settings["DumpLogHereOnExit"]);
                    }
                    await Logger.WriteLogToFile(File.OpenWrite(Path.Combine(Config.Settings["DumpLogHereOnExit"], fileName)));
                }
                catch(Exception exc)
                {
                    e.Cancel = true;
                    Logger.Exception(exc, "Failed to write log file to disk.");
                }
            }
            Logger.Warning("Super Grate is exiting. Attempt: " + CloseAttempts + "/3.");
        }
        private void MiAboutSG_Click(object sender, EventArgs e)
        {
            new Controls.About().ShowDialog();
        }
        private void MiDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/wiki");
        }
        private void MiIssues_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/issues");
        }
        private void MiSetup_Click(object sender, EventArgs e)
        {
            new Controls.Settings().ShowDialog();
        }
        private void tbSourceDestComputer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (sender == tbSourceComputer)
                {
                    btnListSource.PerformClick();
                }
            }
        }
        private void lbxUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btStartStop.PerformClick();
            }
        }
        private void miHelpButton_Click(object sender, EventArgs e)
        {
            if (Cursor == Cursors.Help)
            {
                miHelpButton.Checked = false;
                Cursor = Cursors.Default;
            }
            else
            {
                miHelpButton.Checked = true;
                Cursor = Cursors.Help;
            }
        }
        private void miNewInstance_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }
    }
    public enum ListSources
    {
        Unknown = -1,
        SourceComputer = 1,
        MigrationStore = 2
    }
    public enum RunningTask
    {
        Unknown = -2,
        None = -1,
        USMT = 1,
        RemoteProfileDelete = 2
    }
}
