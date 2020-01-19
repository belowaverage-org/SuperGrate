using SuperGrate.Controls;
using SuperGrate.UserList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private static bool storeCanceled = false;
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
            listUsers.Tag = new string[0];
            Icon = Properties.Resources.supergrate;
            Text = About.AssemblyTitle;
            btnListSource.SetSystemIcon(Properties.Resources.users);
            btnListStore.SetSystemIcon(Properties.Resources.usercheck);
            btnDelete.SetSystemIcon(Properties.Resources.stop);
            miDocumentation.SetMenuItemIcon(Properties.Resources.link);
            miIssues.SetMenuItemIcon(Properties.Resources.link);
            miAddRemoveCol.SetMenuItemIcon(Properties.Resources.columns);
            miAboutSG.SetMenuItemIcon(Properties.Resources.info);
            miSettings.SetMenuItemIcon(Properties.Resources.settings);
            miSaveLog.SetMenuItemIcon(Properties.Resources.save);
            miExitButton.SetMenuItemIcon(Properties.Resources.stop);
            miNewInstance.SetMenuItemIcon(Properties.Resources.move);
            listUsers.SmallImageList = new ImageList();
            listUsers.SmallImageList.Images.Add("user", Properties.Resources.user.ToBitmap());
            listUsers.LargeImageList = new ImageList();
            listUsers.LargeImageList.ImageSize = new Size(32, 32);
            listUsers.LargeImageList.Images.Add("user", Properties.Resources.user_32.ToBitmap());
            new ConfirmDialog("Enter Super Grate?").ShowDialog();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Config.LoadConfig(MainParameters);
            Logger.Success("Welcome to " + Application.ProductName + "! v" + Application.ProductVersion);
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
        public static bool Canceled
        {
            get
            {
                return storeCanceled;
            }
            set
            {
                storeCanceled = value;
                if (value)
                {
                    if (storeRunningTask != RunningTask.None) Logger.Warning("Canceling current task...");
                    if (storeRunningTask == RunningTask.USMT) USMT.Cancel();
                    if (storeRunningTask == RunningTask.RemoteProfileDelete) Misc.CancelRemoteProfileDelete(SourceComputer);
                }
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
                    btnStartStop.Text = " &Stop";
                    btnStartStop.SetSystemIcon(Properties.Resources.stop);
                    Cursor = Cursors.AppStarting;
                    Logger.UpdateProgress(true);
                    Misc.MainMenuSetState(MainMenu, false, new string[] { "&View" });
                    storeRunningTask = value;
                    imgLoadLogo.Enabled = 
                    btnStartStop.Enabled =
                    true;
                    Canceled =
                    miSettings.Enabled =
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnAFillSrc.Enabled =
                    btnAFillDest.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    listUsers.Enabled =
                    false;
                }
                else
                {
                    btnStartStop.Text = " &Start";
                    btnStartStop.SetSystemIcon(Properties.Resources.go);
                    Cursor = Cursors.Default;
                    Logger.UpdateProgress(false);
                    Misc.MainMenuSetState(MainMenu, true);
                    storeRunningTask = value;
                    imgLoadLogo.Enabled = false;
                    Canceled =
                    miSettings.Enabled =
                    tbSourceComputer.Enabled =
                    tbDestinationComputer.Enabled =
                    btnAFillSrc.Enabled =
                    btnAFillDest.Enabled =
                    btnListSource.Enabled =
                    btnListStore.Enabled =
                    btnDelete.Enabled =
                    listUsers.Enabled =
                    true;
                    UpdateFormRestrictions();
                    if (CloseRequested) Close();
                    if (!ContainsFocus && !IsDisposed) FlashWindow.Start(Handle, FlashWindow.FlashWindowStyle.FLASHW_ALL | FlashWindow.FlashWindowStyle.FLASHW_TIMERNOFG);
                }
            }
        }
        private async void BtStartStop_Click(object sender, EventArgs e)
        {
            if (Running != RunningTask.None)
            {
                Canceled = true;
            }
            else
            {
                Running = RunningTask.USMT;
                List<string> IDs = new List<string>();
                foreach (int index in listUsers.SelectedIndices)
                {
                    IDs.Add((string)listUsers.Items[index].Tag);
                }
                bool setting;
                bool success;
                if (CurrentListSource == ListSources.SourceComputer)
                {
                    success = await USMT.Do(USMTMode.ScanState, IDs.ToArray());
                    if (bool.TryParse(Config.Settings["AutoDeleteFromSource"], out setting) && setting && success)
                    {
                        await Misc.DeleteFromSource(SourceComputer, IDs.ToArray());
                    }
                }
                if (tbDestinationComputer.Text != "" && Running == RunningTask.USMT)
                {
                    success = await USMT.Do(USMTMode.LoadState, IDs.ToArray());
                    if (bool.TryParse(Config.Settings["AutoDeleteFromStore"], out setting) && setting && success)
                    {
                        await Misc.DeleteFromStore(IDs.ToArray());
                    }
                }
                Running = RunningTask.None;
                Logger.Information("Done.");
            }
        }
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            miAddRemoveCol.Enabled = true;
            listUsers.SetColumns(ULControl.HeaderRowComputerSource, Config.Settings["ULSourceColumns"]);
            lblUserList.Text = "Users on Source Computer:";
            UserRows rows = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            listUsers.SetRows(rows);
            CurrentListSource = ListSources.SourceComputer;
            Running = RunningTask.None;
        }
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            miAddRemoveCol.Enabled = true;
            lblUserList.Text = "Users in Migration Store:";
            listUsers.SetColumns(ULControl.HeaderRowStoreSource, Config.Settings["ULStoreColumns"]);
            UserRows rows = await Misc.GetUsersFromStore();
            listUsers.SetRows(rows);
            CurrentListSource = ListSources.MigrationStore;
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
            if (listUsers.SelectedIndices.Count == 0 || (tbDestinationComputer.Text == "" && CurrentListSource == ListSources.MigrationStore))
            {
                btnStartStop.Enabled = false;
            }
            else
            {
                btnStartStop.Enabled = true;
            }
            if (listUsers.SelectedIndices.Count != 0)
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
                listUsers.Items.Clear();
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
            List<string> IDs = new List<string>();
            foreach (int index in listUsers.SelectedIndices)
            {
                IDs.Add((string)listUsers.Items[index].Tag);
            }
            if(CurrentListSource == ListSources.MigrationStore)
            {
                btnStartStop.Enabled = false;
                await Misc.DeleteFromStore(IDs.ToArray());
                btnStartStop.Enabled = true;
                Running = RunningTask.None;
                btnListStore.PerformClick();
            }
            else if(CurrentListSource == ListSources.SourceComputer)
            {
                await Misc.DeleteFromSource(SourceComputer, IDs.ToArray());
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
                btnStartStop.PerformClick();
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
            new About().ShowDialog();
        }
        private void MiDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/wiki");
        }
        private void MiIssues_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/issues");
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
                btnStartStop.PerformClick();
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
        private void miAddRemoveCol_Click(object sender, EventArgs e)
        {
            string SettingKey = "";
            UserRow AllAvailableColumns = null;
            if (CurrentListSource == ListSources.MigrationStore)
            {
                SettingKey = "ULStoreColumns";
                AllAvailableColumns = ULControl.HeaderRowStoreSource;
            }
            else if (CurrentListSource == ListSources.SourceComputer)
            {
                SettingKey = "ULSourceColumns";
                AllAvailableColumns = ULControl.HeaderRowComputerSource;
            }
            else
            {
                return;
            }
            ChangeColumns ColDialog = new ChangeColumns();
            Dictionary<string, object> AvailableColumns = new Dictionary<string, object>();
            Dictionary<string, object> DisplayedColumns = new Dictionary<string, object>();
            foreach (KeyValuePair<ULColumnType, string> Column in AllAvailableColumns)
            {
                if (!ULControl.CurrentHeaderRow.ContainsKey(Column.Key))
                {
                    AvailableColumns.Add(Column.Value, Column.Key);
                }
            }
            foreach (KeyValuePair<ULColumnType, string> Column in ULControl.CurrentHeaderRow)
            {
                if (Column.Value != null)
                {
                    DisplayedColumns.Add(Column.Value, Column.Key);
                }
            }
            ColDialog.AvailableColumns = AvailableColumns;
            ColDialog.DisplayedColumns = DisplayedColumns;
            DialogResult result = ColDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string Setting = "";
                foreach(ULColumnType Column in ColDialog.DisplayedColumns.Values)
                {
                    Setting += ((int)Column).ToString() + ',';
                }
                Config.Settings[SettingKey] = Setting.TrimEnd(',');
                if (CurrentListSource == ListSources.MigrationStore)
                {
                    btnListStore.PerformClick();
                }
                if (CurrentListSource == ListSources.SourceComputer)
                {
                    btnListSource.PerformClick();
                }
            }
        }
        private async void listUsers_DoubleClick(object sender, EventArgs e)
        {
            if(listUsers.SelectedItems.Count == 1)
            {
                Running = RunningTask.Unknown;
                Logger.Information("Retrieving user properties...");
                UserRow row = null;
                UserRow template = null;
                if (CurrentListSource == ListSources.MigrationStore)
                {
                    template = ULControl.HeaderRowStoreSource;
                    row = await Misc.GetUserFromStore(template, (string)listUsers.SelectedItems[0].Tag);
                }
                if (CurrentListSource == ListSources.SourceComputer)
                {
                    template = ULControl.HeaderRowComputerSource;
                    row = await Misc.GetUserFromHost(template, tbSourceComputer.Text, (string)listUsers.SelectedItems[0].Tag);
                }
                if (Canceled)
                {
                    Running = RunningTask.None;
                    Logger.Information("Canceled.");
                    return;
                }
                Running = RunningTask.None;
                Logger.Success("Done!");
                new UserProperties(template, row).ShowDialog();
            }
        }
        private void miSettings_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }
        private void miViewMode_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            View view = View.Details;
            if (mi == miViewDetail) view = View.Details;
            if (mi == miViewList) view = View.List;
            if (mi == miViewLarge) view = View.LargeIcon;
            if (mi == miViewSmall) view = View.SmallIcon;
            if (mi == miViewTile) view = View.Tile;
            Config.Settings["ULViewMode"] = ((int)view).ToString();
            listUsers.View = view;
            if (view == View.Details)
            {
                listUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void miView_Popup(object sender, EventArgs e)
        {
            int ViewMode = -1;
            int.TryParse(Config.Settings["ULViewMode"], out ViewMode);
            foreach (MenuItem mi in miView.MenuItems) mi.Checked = false;
            if ((View)ViewMode == View.Details) miViewDetail.Checked = true;
            if ((View)ViewMode == View.List) miViewList.Checked = true;
            if ((View)ViewMode == View.LargeIcon) miViewLarge.Checked = true;
            if ((View)ViewMode == View.SmallIcon) miViewSmall.Checked = true;
            if ((View)ViewMode == View.Tile) miViewTile.Checked = true;
        }
        private void listUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Logger.Information(e.Column.ToString());
            //listUsers.Columns[e.Column].Text += "  ▼";
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
