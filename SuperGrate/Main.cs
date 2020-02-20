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
        private UserRows CurrentUserRows = null;
        private Dictionary<ListSources, ULSortDirection> CurrentSortDirection = new Dictionary<ListSources, ULSortDirection>() {
            { ListSources.MigrationStore, ULSortDirection.Descending },
            { ListSources.SourceComputer, ULSortDirection.Descending }
        };
        private Dictionary<ListSources, ULColumnType> CurrentSortColumn = new Dictionary<ListSources, ULColumnType>() {
            { ListSources.MigrationStore, ULColumnType.NTAccount },
            { ListSources.SourceComputer, ULColumnType.NTAccount }
        };
        /// <summary>
        /// The main form entry point.
        /// </summary>
        /// <param name="parameters">A list of parameters to override XML settings.</param>
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
            btnDelete.SetSystemIcon(Properties.Resources.x);
            miDocumentation.SetMenuItemIcon(Properties.Resources.link);
            miIssues.SetMenuItemIcon(Properties.Resources.link);
            miAddRemoveCol.SetMenuItemIcon(Properties.Resources.columns);
            miAboutSG.SetMenuItemIcon(Properties.Resources.info);
            miSettings.SetMenuItemIcon(Properties.Resources.settings);
            miSaveLog.SetMenuItemIcon(Properties.Resources.save);
            miExitButton.SetMenuItemIcon(Properties.Resources.x);
            miNewInstance.SetMenuItemIcon(Properties.Resources.move);
            listUsers.SmallImageList = new ImageList();
            listUsers.SmallImageList.Images.Add("user", Properties.Resources.user.ToBitmap());
            listUsers.LargeImageList = new ImageList();
            listUsers.LargeImageList.ImageSize = new Size(32, 32);
            listUsers.LargeImageList.Images.Add("user", Properties.Resources.user_32.ToBitmap());
            miConDelete.SetMenuItemIcon(Properties.Resources.x);
            miConProperties.SetMenuItemIcon(Properties.Resources.user);
            miConStart.SetMenuItemIcon(Properties.Resources.go);



        }
        /// <summary>
        /// This event will fire when the main form has loaded.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            Config.LoadConfig(MainParameters);
            Logger.Success("Welcome to " + Application.ProductName + "! v" + Application.ProductVersion);
            Logger.Information("Enter some information to get started!");
            UpdateFormRestrictions();
            BindHelp(this);
        }
        /// <summary>
        /// This method will loop through all child controls of a control and apply the Control_Hover event to the MouseEnter event.
        /// </summary>
        /// <param name="control">Parent control.</param>
        private void BindHelp(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                childControl.MouseEnter += Control_Hover;
                if(childControl.HasChildren)
                {
                    BindHelp(childControl);
                }
            }
        }
        /// <summary>
        /// This event will fire whenever any control on the main form is hovered. And will show a help box if requested.
        /// </summary>
        private void Control_Hover(object sender, EventArgs e)
        {
            if (Cursor == Cursors.Help)
            {
                Point mouse = MousePosition;
                mouse.Offset(50, 50);
                Help.ShowPopup(this, helpProvider.GetHelpString((Control)sender), mouse);
            }
        }
        /// <summary>
        /// This getter/setter will attempt to cancel a running task if set true.
        /// </summary>
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
        /// <summary>
        /// This getter/setter will update various controls and variables whenever changed in regards to a running task.
        /// </summary>
        private RunningTask Running {
            get {
                return storeRunningTask;
            }
            set {
                Logger.UpdateProgress(0);
                if (value != RunningTask.None)
                {
                    btnStartStop.Text = " &Stop";
                    btnStartStop.SetSystemIcon(Properties.Resources.cancel);
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
        /// <summary>
        /// This event will fire whenever the btStartStop button is clicked, starting or stopping whatever task is queued to happen.
        /// </summary>
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
        /// <summary>
        /// This event will fire whenever the btnListSource is clicked. This will refresh or re-list the listUsers control with users from the source computer.
        /// </summary>
        private async void BtnListSource_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            miAddRemoveCol.Enabled = true;
            listUsers.SetViewMode(Config.Settings["ULViewMode"]);
            listUsers.SetColumns(ULControl.HeaderRowComputerSource, Config.Settings["ULSourceColumns"]);
            lblUserList.Text = "Users on Source Computer:";
            CurrentUserRows = await Misc.GetUsersFromHost(tbSourceComputer.Text);
            listUsers.SetRows(CurrentUserRows, CurrentSortColumn[ListSources.SourceComputer], CurrentSortDirection[ListSources.SourceComputer]);
            CurrentListSource = ListSources.SourceComputer;
            Running = RunningTask.None;
        }
        /// <summary>
        /// This event will fire whenever the btnListStore is clicked. This will refresh or re-list the listUsers control with users from the store.
        /// </summary>
        private async void BtnListStore_Click(object sender, EventArgs e)
        {
            Running = RunningTask.Unknown;
            miAddRemoveCol.Enabled = true;
            lblUserList.Text = "Users in Migration Store:";
            listUsers.SetViewMode(Config.Settings["ULViewMode"]);
            listUsers.SetColumns(ULControl.HeaderRowStoreSource, Config.Settings["ULStoreColumns"]);
            CurrentUserRows = await Misc.GetUsersFromStore();
            listUsers.SetRows(CurrentUserRows, CurrentSortColumn[ListSources.MigrationStore], CurrentSortDirection[ListSources.MigrationStore]);
            CurrentListSource = ListSources.MigrationStore;
            Running = RunningTask.None;
        }
        /// <summary>
        /// This event will fire if the logBox text box is double clicked, and will toggle VerboseMode (Which allows the logger class to output more).
        /// </summary>
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
        /// <summary>
        /// This method will enable or disable different controls on the main form depending on conditions in the form to prevent invalid inputs.
        /// </summary>
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
        /// <summary>
        /// This event will fire whenever the tbSourceComputer text box receives new text, and will clear the users from the list, and call UpdateFormRestrictions().
        /// </summary>
        private void TbSourceComputer_TextChanged(object sender, EventArgs e)
        {
            SourceComputer = tbSourceComputer.Text;
            if(CurrentListSource == ListSources.SourceComputer)
            {
                listUsers.Items.Clear();
            }
            UpdateFormRestrictions();
        }
        /// <summary>
        /// This event will fire when the tbDestinationComputer text box recieves new text, and will call the UpdateFormRestrictions() method.
        /// </summary>
        private void TbDestinationComputer_TextChanged(object sender, EventArgs e)
        {
            DestinationComputer = tbDestinationComputer.Text;
            UpdateFormRestrictions();
        }
        /// <summary>
        /// This event will fire when the btnDelete button is clicked, and will start the deletion process for the selected users.
        /// </summary>
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedCount = listUsers.SelectedItems.Count;
            ConfirmDialog confirm = null;
            if (selectedCount == 1)
            {
                confirm = new ConfirmDialog("Delete User", "Are you sure you want to delete this user?", Properties.Resources.trash_16_32);
            }
            else
            {
                confirm = new ConfirmDialog("Delete Users", "Are you sure you want to delete these " + selectedCount + " users?", Properties.Resources.trash_16_32);
            }
            confirm.ShowDialog();
            if (confirm.DialogResult != DialogResult.OK) return;
            Running = RunningTask.RemoteProfileDelete;
            List<string> IDs = new List<string>();
            foreach (int index in listUsers.SelectedIndices)
            {
                IDs.Add((string)listUsers.Items[index].Tag);
            }
            if(CurrentListSource == ListSources.MigrationStore)
            {
                await Misc.DeleteFromStore(IDs.ToArray());
                Running = RunningTask.None;
                btnListStore.PerformClick();
            }
            else if(CurrentListSource == ListSources.SourceComputer)
            {
                await Misc.DeleteFromSource(SourceComputer, IDs.ToArray());
                Running = RunningTask.None;
                btnListSource.PerformClick();
            }
            else
            {
                Running = RunningTask.None;
            }
        }
        /// <summary>
        /// This event will fire when the tbSourceComputer text box recieves an enter key, then will simulate a click on the btnListSource button.
        /// </summary>
        private void TbSourceComputer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnListSource.PerformClick();
            }
        }
        /// <summary>
        /// This event will fire when the btnBFillDest button is clicked, this will fill the ajacent text box with the current PC name.
        /// </summary>
        private void BtnAFillSrc_Click(object sender, EventArgs e)
        {
            tbSourceComputer.Text = Environment.MachineName;
        }
        /// <summary>
        /// This event will fire when the btnAFillDest button is clicked, this will fill the ajacent text box with the current PC name.
        /// </summary>
        private void BtnAFillDest_Click(object sender, EventArgs e)
        {
            tbDestinationComputer.Text = Environment.MachineName;
        }
        /// <summary>
        /// This event will fire if the miExitButton is clicked, and will attempt to close the main form.
        /// </summary>
        private void MiExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// This event will fire when the menu item miSaveLog is clicked, and will open the save log dialog window.
        /// </summary>
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
        /// <summary>
        /// This event will fire when the main window is about to close, and will block the closure if a task is running, otherwise it will allow the window to close after writing a log if instrucuted.
        /// </summary>
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
        /// <summary>
        /// This event will fire when the miAbout menu item is clicked, and will open the about dialog box.
        /// </summary>
        private void MiAboutSG_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
        /// <summary>
        /// This event will fire when the miDocumentation menu item is clicked, and will open the docs page on github.
        /// </summary>
        private void MiDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/wiki");
        }
        /// <summary>
        /// This event will fire when the miIssues menu item is clicked, and will open the issues page on github.
        /// </summary>
        private void MiIssues_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/belowaverage-org/SuperGrate/issues");
        }
        /// <summary>
        /// This event fires when the tbSourceDestComputer text box recieves an enter key, this will simulate a click on the button btnListSource.
        /// </summary>
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
        /// <summary>
        /// This event will fire when the lbxUsers registers an enter key, this simulates a click on the button btnStartStop.
        /// </summary>
        private void lbxUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStartStop.PerformClick();
            }
        }
        /// <summary>
        /// This event will fire when the miHelpButton menu item is clicked, and will toggle the help on hover function in the main window.
        /// </summary>
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
        /// <summary>
        /// This event will fire when the miNewInstance menu item is clicked and will start a new instance of Super Grate.
        /// </summary>
        private void miNewInstance_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }
        /// <summary>
        /// This event fires when the miAddRemoveCol menu item is clicked, and will display the column selection dialog box.
        /// </summary>
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
        /// <summary>
        /// This event will open the User Properties dialog box.
        /// </summary>
        private async void OpenUserProperties_Event(object sender, EventArgs e)
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
        /// <summary>
        /// This event fires when the menu item miSettings is clicked. It will show the settings menu dialog box.
        /// </summary>
        private void miSettings_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }
        /// <summary>
        /// This event fires when view mode menu items are clicked. It will apply the settings and the new view mode the list box "listUsers". 
        /// </summary>
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
        /// <summary>
        /// This event fires before the miView menu is shown, and determines what menu items are checked based on current settings.
        /// </summary>
        private void miView_Popup(object sender, EventArgs e)
        {
            View ViewMode = ULControl.ParseViewMode(Config.Settings["ULViewMode"]);
            foreach (MenuItem mi in miView.MenuItems) mi.Checked = false;
            if (ViewMode == View.Details) miViewDetail.Checked = true;
            if (ViewMode == View.List) miViewList.Checked = true;
            if (ViewMode == View.LargeIcon) miViewLarge.Checked = true;
            if (ViewMode == View.SmallIcon) miViewSmall.Checked = true;
            if (ViewMode == View.Tile) miViewTile.Checked = true;
        }
        /// <summary>
        /// Event fired when a user clicks a column button (Sort Button) in the listUsers control.
        /// This method toggles the sort direction for each column in each list mode.
        /// </summary>
        private void listUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ULColumnType selColumn = (ULColumnType)listUsers.Columns[e.Column].Tag;
            if (CurrentSortDirection[CurrentListSource] == ULSortDirection.Ascending)
            {
                CurrentSortDirection[CurrentListSource] = ULSortDirection.Descending;
            }
            else if(CurrentSortDirection[CurrentListSource] == ULSortDirection.Descending)
            {
                CurrentSortDirection[CurrentListSource] = ULSortDirection.Ascending;
            }
            if (CurrentSortColumn[CurrentListSource] != selColumn)
            {
                CurrentSortDirection[CurrentListSource] = ULSortDirection.Descending;
            }
            CurrentSortColumn[CurrentListSource] = selColumn;
            listUsers.SetRows(CurrentUserRows, CurrentSortColumn[CurrentListSource], CurrentSortDirection[CurrentListSource]);
        }
        /// <summary>
        /// Event fired when user right clicks the listUsers control.
        /// The method will display a context menu at the user's mouse.
        /// </summary>
        private void listUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (listUsers.SelectedItems.Count == 1)
                {
                    miConProperties.Enabled = true;
                }
                else
                {
                    miConProperties.Enabled = false;
                }
                miConUser.Show((Control)sender, e.Location);
            }
        }
    }
    /// <summary>
    /// Enum of user sources that can be displayed in Super Grate.
    /// </summary>
    public enum ListSources
    {
        Unknown = -1,
        SourceComputer = 1,
        MigrationStore = 2
    }
    /// <summary>
    /// Enum of tasks that can be running in Super Grate.
    /// </summary>
    public enum RunningTask
    {
        Unknown = -2,
        None = -1,
        USMT = 1,
        RemoteProfileDelete = 2
    }
}
