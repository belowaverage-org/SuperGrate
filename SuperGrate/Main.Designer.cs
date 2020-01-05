namespace SuperGrate
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.logTable = new System.Windows.Forms.TableLayoutPanel();
            this.spltContainer = new System.Windows.Forms.SplitContainer();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sourCompTabl = new System.Windows.Forms.TableLayoutPanel();
            this.tbSourceComputer = new System.Windows.Forms.TextBox();
            this.btnAFillSrc = new System.Windows.Forms.Button();
            this.lblSourceComputer = new System.Windows.Forms.Label();
            this.lblDestinationComputer = new System.Windows.Forms.Label();
            this.lblUserList = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tbleListUsersButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnListSource = new System.Windows.Forms.Button();
            this.btnListStore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlLogoBorder = new System.Windows.Forms.Panel();
            this.imgLoadLogo = new System.Windows.Forms.PictureBox();
            this.destCompTabl = new System.Windows.Forms.TableLayoutPanel();
            this.btnAFillDest = new System.Windows.Forms.Button();
            this.tbDestinationComputer = new System.Windows.Forms.TextBox();
            this.listUsers = new System.Windows.Forms.ListView();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miNewInstance = new System.Windows.Forms.MenuItem();
            this.miSpacer0 = new System.Windows.Forms.MenuItem();
            this.miSaveLog = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miExitButton = new System.Windows.Forms.MenuItem();
            this.miSetup = new System.Windows.Forms.MenuItem();
            this.miView = new System.Windows.Forms.MenuItem();
            this.miAddRemoveCol = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.miDocumentation = new System.Windows.Forms.MenuItem();
            this.miIssues = new System.Windows.Forms.MenuItem();
            this.miSpacer1 = new System.Windows.Forms.MenuItem();
            this.miHelpButton = new System.Windows.Forms.MenuItem();
            this.miSpacer2 = new System.Windows.Forms.MenuItem();
            this.miAboutSG = new System.Windows.Forms.MenuItem();
            this.dialogSaveLog = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.logTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).BeginInit();
            this.spltContainer.Panel1.SuspendLayout();
            this.spltContainer.Panel2.SuspendLayout();
            this.spltContainer.SuspendLayout();
            this.tblMainLayout.SuspendLayout();
            this.sourCompTabl.SuspendLayout();
            this.tbleListUsersButtons.SuspendLayout();
            this.pnlLogoBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadLogo)).BeginInit();
            this.destCompTabl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.Black;
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.ForeColor = System.Drawing.Color.White;
            this.helpProvider.SetHelpString(this.LogBox, "This console is updated live with information regarding the progress of Super Gra" +
        "te. (Double click the console to toggle verbose mode)");
            this.LogBox.Location = new System.Drawing.Point(3, 4);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.helpProvider.SetShowHelp(this.LogBox, true);
            this.LogBox.Size = new System.Drawing.Size(303, 394);
            this.LogBox.TabIndex = 100;
            this.LogBox.Text = "";
            this.LogBox.DoubleClick += new System.EventHandler(this.LogBox_DoubleClick);
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.ForeColor = System.Drawing.Color.Black;
            this.pbMain.Location = new System.Drawing.Point(3, 406);
            this.pbMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(303, 22);
            this.pbMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMain.TabIndex = 100;
            // 
            // logTable
            // 
            this.logTable.ColumnCount = 1;
            this.logTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logTable.Controls.Add(this.LogBox, 0, 0);
            this.logTable.Controls.Add(this.pbMain, 0, 1);
            this.logTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTable.Location = new System.Drawing.Point(0, 0);
            this.logTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logTable.Name = "logTable";
            this.logTable.RowCount = 2;
            this.logTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.logTable.Size = new System.Drawing.Size(309, 432);
            this.logTable.TabIndex = 100;
            // 
            // spltContainer
            // 
            this.spltContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltContainer.Location = new System.Drawing.Point(5, 5);
            this.spltContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spltContainer.Name = "spltContainer";
            // 
            // spltContainer.Panel1
            // 
            this.spltContainer.Panel1.Controls.Add(this.tblMainLayout);
            this.spltContainer.Panel1MinSize = 340;
            // 
            // spltContainer.Panel2
            // 
            this.spltContainer.Panel2.Controls.Add(this.logTable);
            this.spltContainer.Panel2MinSize = 300;
            this.spltContainer.Size = new System.Drawing.Size(981, 432);
            this.spltContainer.SplitterDistance = 668;
            this.spltContainer.TabIndex = 100;
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 2;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Controls.Add(this.sourCompTabl, 1, 0);
            this.tblMainLayout.Controls.Add(this.lblSourceComputer, 0, 0);
            this.tblMainLayout.Controls.Add(this.lblDestinationComputer, 0, 1);
            this.tblMainLayout.Controls.Add(this.lblUserList, 0, 3);
            this.tblMainLayout.Controls.Add(this.btnStartStop, 0, 5);
            this.tblMainLayout.Controls.Add(this.tbleListUsersButtons, 1, 2);
            this.tblMainLayout.Controls.Add(this.pnlLogoBorder, 0, 4);
            this.tblMainLayout.Controls.Add(this.destCompTabl, 1, 1);
            this.tblMainLayout.Controls.Add(this.listUsers, 1, 3);
            this.tblMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainLayout.Location = new System.Drawing.Point(0, 0);
            this.tblMainLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 2;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainLayout.Size = new System.Drawing.Size(668, 432);
            this.tblMainLayout.TabIndex = 100;
            // 
            // sourCompTabl
            // 
            this.sourCompTabl.ColumnCount = 2;
            this.sourCompTabl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sourCompTabl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.sourCompTabl.Controls.Add(this.tbSourceComputer, 0, 0);
            this.sourCompTabl.Controls.Add(this.btnAFillSrc, 1, 0);
            this.sourCompTabl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourCompTabl.Location = new System.Drawing.Point(130, 0);
            this.sourCompTabl.Margin = new System.Windows.Forms.Padding(0);
            this.sourCompTabl.Name = "sourCompTabl";
            this.sourCompTabl.RowCount = 1;
            this.sourCompTabl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sourCompTabl.Size = new System.Drawing.Size(538, 30);
            this.sourCompTabl.TabIndex = 101;
            // 
            // tbSourceComputer
            // 
            this.tbSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider.SetHelpString(this.tbSourceComputer, "Enter the source computer hostname. This is where the user profiles to be migrate" +
        "d / backed up will come from.");
            this.tbSourceComputer.Location = new System.Drawing.Point(3, 4);
            this.tbSourceComputer.Margin = new System.Windows.Forms.Padding(3, 4, 6, 4);
            this.tbSourceComputer.Name = "tbSourceComputer";
            this.helpProvider.SetShowHelp(this.tbSourceComputer, true);
            this.tbSourceComputer.Size = new System.Drawing.Size(504, 22);
            this.tbSourceComputer.TabIndex = 101;
            this.tbSourceComputer.TextChanged += new System.EventHandler(this.TbSourceComputer_TextChanged);
            this.tbSourceComputer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSourceDestComputer_KeyDown);
            // 
            // btnAFillSrc
            // 
            this.btnAFillSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAFillSrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnAFillSrc, "This button will auto-fill the current computer\'s hostname.");
            this.btnAFillSrc.Location = new System.Drawing.Point(513, 3);
            this.btnAFillSrc.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnAFillSrc.Name = "btnAFillSrc";
            this.helpProvider.SetShowHelp(this.btnAFillSrc, true);
            this.btnAFillSrc.Size = new System.Drawing.Size(23, 24);
            this.btnAFillSrc.TabIndex = 102;
            this.btnAFillSrc.Text = "<";
            this.btnAFillSrc.UseVisualStyleBackColor = true;
            this.btnAFillSrc.Click += new System.EventHandler(this.BtnAFillSrc_Click);
            // 
            // lblSourceComputer
            // 
            this.lblSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSourceComputer.Location = new System.Drawing.Point(3, 0);
            this.lblSourceComputer.Name = "lblSourceComputer";
            this.lblSourceComputer.Size = new System.Drawing.Size(124, 30);
            this.lblSourceComputer.TabIndex = 100;
            this.lblSourceComputer.Text = "Source Computer";
            this.lblSourceComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDestinationComputer
            // 
            this.lblDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationComputer.Location = new System.Drawing.Point(3, 30);
            this.lblDestinationComputer.Name = "lblDestinationComputer";
            this.lblDestinationComputer.Size = new System.Drawing.Size(124, 30);
            this.lblDestinationComputer.TabIndex = 100;
            this.lblDestinationComputer.Text = "Destination Computer";
            this.lblDestinationComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserList
            // 
            this.lblUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider.SetHelpString(this.lblUserList, "This label displays where the list of user profiles to the right originated from." +
        "");
            this.lblUserList.Location = new System.Drawing.Point(3, 90);
            this.lblUserList.Name = "lblUserList";
            this.helpProvider.SetShowHelp(this.lblUserList, true);
            this.lblUserList.Size = new System.Drawing.Size(124, 202);
            this.lblUserList.TabIndex = 100;
            this.lblUserList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartStop
            // 
            this.tblMainLayout.SetColumnSpan(this.btnStartStop, 2);
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartStop.Enabled = false;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnStartStop, "This button will start a migration, backup, or restoration and stop any other Sup" +
        "er Grate process.");
            this.btnStartStop.Location = new System.Drawing.Point(3, 405);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btnStartStop.Name = "btnStartStop";
            this.helpProvider.SetShowHelp(this.btnStartStop, true);
            this.btnStartStop.Size = new System.Drawing.Size(663, 24);
            this.btnStartStop.TabIndex = 100;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtStartStop_Click);
            // 
            // tbleListUsersButtons
            // 
            this.tbleListUsersButtons.ColumnCount = 3;
            this.tbleListUsersButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbleListUsersButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbleListUsersButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbleListUsersButtons.Controls.Add(this.btnListSource, 0, 0);
            this.tbleListUsersButtons.Controls.Add(this.btnListStore, 1, 0);
            this.tbleListUsersButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tbleListUsersButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbleListUsersButtons.Location = new System.Drawing.Point(130, 60);
            this.tbleListUsersButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tbleListUsersButtons.Name = "tbleListUsersButtons";
            this.tbleListUsersButtons.RowCount = 1;
            this.tbleListUsersButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbleListUsersButtons.Size = new System.Drawing.Size(538, 30);
            this.tbleListUsersButtons.TabIndex = 100;
            // 
            // btnListSource
            // 
            this.btnListSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnListSource, "This button will retrieve the list of user profiles from the source computer.");
            this.btnListSource.Location = new System.Drawing.Point(2, 3);
            this.btnListSource.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnListSource.Name = "btnListSource";
            this.helpProvider.SetShowHelp(this.btnListSource, true);
            this.btnListSource.Size = new System.Drawing.Size(174, 25);
            this.btnListSource.TabIndex = 100;
            this.btnListSource.Text = "List Source";
            this.btnListSource.UseVisualStyleBackColor = true;
            this.btnListSource.Click += new System.EventHandler(this.BtnListSource_Click);
            // 
            // btnListStore
            // 
            this.btnListStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListStore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnListStore, "This button will list the user profiles that have already been backed up to the s" +
        "tore.");
            this.btnListStore.Location = new System.Drawing.Point(182, 3);
            this.btnListStore.Name = "btnListStore";
            this.helpProvider.SetShowHelp(this.btnListStore, true);
            this.btnListStore.Size = new System.Drawing.Size(173, 25);
            this.btnListStore.TabIndex = 100;
            this.btnListStore.Text = "List Store";
            this.btnListStore.UseVisualStyleBackColor = true;
            this.btnListStore.Click += new System.EventHandler(this.BtnListStore_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnDelete, "This button will delete user profiles from either the source computer or the stor" +
        "e.");
            this.btnDelete.Location = new System.Drawing.Point(361, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btnDelete.Name = "btnDelete";
            this.helpProvider.SetShowHelp(this.btnDelete, true);
            this.btnDelete.Size = new System.Drawing.Size(175, 25);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // pnlLogoBorder
            // 
            this.pnlLogoBorder.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLogoBorder.Controls.Add(this.imgLoadLogo);
            this.pnlLogoBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoBorder.Location = new System.Drawing.Point(4, 292);
            this.pnlLogoBorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pnlLogoBorder.Name = "pnlLogoBorder";
            this.pnlLogoBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLogoBorder.Size = new System.Drawing.Size(122, 106);
            this.pnlLogoBorder.TabIndex = 100;
            // 
            // imgLoadLogo
            // 
            this.imgLoadLogo.BackColor = System.Drawing.Color.White;
            this.imgLoadLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLoadLogo.Enabled = false;
            this.helpProvider.SetHelpString(this.imgLoadLogo, "This picture illustrates the inner workings of Super Grate. Presented here is an " +
        "acturate representation of the currently running Super Grate processes.");
            this.imgLoadLogo.Image = global::SuperGrate.Properties.Resources.working;
            this.imgLoadLogo.Location = new System.Drawing.Point(1, 1);
            this.imgLoadLogo.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadLogo.Name = "imgLoadLogo";
            this.helpProvider.SetShowHelp(this.imgLoadLogo, true);
            this.imgLoadLogo.Size = new System.Drawing.Size(120, 104);
            this.imgLoadLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoadLogo.TabIndex = 100;
            this.imgLoadLogo.TabStop = false;
            // 
            // destCompTabl
            // 
            this.destCompTabl.ColumnCount = 2;
            this.destCompTabl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.destCompTabl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.destCompTabl.Controls.Add(this.btnAFillDest, 0, 0);
            this.destCompTabl.Controls.Add(this.tbDestinationComputer, 0, 0);
            this.destCompTabl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destCompTabl.Location = new System.Drawing.Point(130, 30);
            this.destCompTabl.Margin = new System.Windows.Forms.Padding(0);
            this.destCompTabl.Name = "destCompTabl";
            this.destCompTabl.RowCount = 1;
            this.destCompTabl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.destCompTabl.Size = new System.Drawing.Size(538, 30);
            this.destCompTabl.TabIndex = 102;
            // 
            // btnAFillDest
            // 
            this.btnAFillDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAFillDest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnAFillDest, "This button will auto-fill the current computer\'s hostname.");
            this.btnAFillDest.Location = new System.Drawing.Point(513, 3);
            this.btnAFillDest.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnAFillDest.Name = "btnAFillDest";
            this.helpProvider.SetShowHelp(this.btnAFillDest, true);
            this.btnAFillDest.Size = new System.Drawing.Size(23, 24);
            this.btnAFillDest.TabIndex = 103;
            this.btnAFillDest.Text = "<";
            this.btnAFillDest.UseVisualStyleBackColor = true;
            this.btnAFillDest.Click += new System.EventHandler(this.BtnAFillDest_Click);
            // 
            // tbDestinationComputer
            // 
            this.tbDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider.SetHelpString(this.tbDestinationComputer, "Enter the source computer hostname. This is where the user profiles will be migra" +
        "ted / restored to.");
            this.tbDestinationComputer.Location = new System.Drawing.Point(3, 4);
            this.tbDestinationComputer.Margin = new System.Windows.Forms.Padding(3, 4, 6, 4);
            this.tbDestinationComputer.Name = "tbDestinationComputer";
            this.helpProvider.SetShowHelp(this.tbDestinationComputer, true);
            this.tbDestinationComputer.Size = new System.Drawing.Size(504, 22);
            this.tbDestinationComputer.TabIndex = 102;
            this.tbDestinationComputer.TextChanged += new System.EventHandler(this.TbDestinationComputer_TextChanged);
            this.tbDestinationComputer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSourceDestComputer_KeyDown);
            // 
            // listUsers
            // 
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.FullRowSelect = true;
            this.listUsers.HideSelection = false;
            this.listUsers.Location = new System.Drawing.Point(133, 93);
            this.listUsers.Name = "listUsers";
            this.tblMainLayout.SetRowSpan(this.listUsers, 2);
            this.listUsers.ShowGroups = false;
            this.listUsers.Size = new System.Drawing.Size(532, 306);
            this.listUsers.TabIndex = 103;
            this.listUsers.UseCompatibleStateImageBehavior = false;
            this.listUsers.View = System.Windows.Forms.View.Details;
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.UpdateFormRestrictions);
            this.listUsers.DoubleClick += new System.EventHandler(this.listUsers_DoubleClick);
            this.listUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxUsers_KeyDown);
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFile,
            this.miSetup,
            this.miView,
            this.miHelp});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miNewInstance,
            this.miSpacer0,
            this.miSaveLog,
            this.menuItem2,
            this.miExitButton});
            this.miFile.Text = "&File";
            // 
            // miNewInstance
            // 
            this.miNewInstance.Index = 0;
            this.miNewInstance.Text = "New Instance";
            this.miNewInstance.Click += new System.EventHandler(this.miNewInstance_Click);
            // 
            // miSpacer0
            // 
            this.miSpacer0.Index = 1;
            this.miSpacer0.Text = "-";
            // 
            // miSaveLog
            // 
            this.miSaveLog.Index = 2;
            this.miSaveLog.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.miSaveLog.Text = "Save Log...";
            this.miSaveLog.Click += new System.EventHandler(this.MiSaveLog_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // miExitButton
            // 
            this.miExitButton.Index = 4;
            this.miExitButton.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miExitButton.Text = "Exit";
            this.miExitButton.Click += new System.EventHandler(this.MiExitButton_Click);
            // 
            // miSetup
            // 
            this.miSetup.Index = 1;
            this.miSetup.Text = "&Settings";
            this.miSetup.Click += new System.EventHandler(this.MiSetup_Click);
            // 
            // miView
            // 
            this.miView.Index = 2;
            this.miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAddRemoveCol});
            this.miView.Text = "&View";
            // 
            // miAddRemoveCol
            // 
            this.miAddRemoveCol.Index = 0;
            this.miAddRemoveCol.Text = "&Add/Remove Columns...";
            this.miAddRemoveCol.Click += new System.EventHandler(this.miAddRemoveCol_Click);
            // 
            // miHelp
            // 
            this.miHelp.Index = 3;
            this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDocumentation,
            this.miIssues,
            this.miSpacer1,
            this.miHelpButton,
            this.miSpacer2,
            this.miAboutSG});
            this.miHelp.Text = "&Help";
            // 
            // miDocumentation
            // 
            this.miDocumentation.Index = 0;
            this.miDocumentation.Text = "Online Documentation";
            this.miDocumentation.Click += new System.EventHandler(this.MiDocumentation_Click);
            // 
            // miIssues
            // 
            this.miIssues.Index = 1;
            this.miIssues.Text = "Online Issues";
            this.miIssues.Click += new System.EventHandler(this.MiIssues_Click);
            // 
            // miSpacer1
            // 
            this.miSpacer1.Index = 2;
            this.miSpacer1.Text = "-";
            // 
            // miHelpButton
            // 
            this.miHelpButton.Index = 3;
            this.miHelpButton.Text = "Help";
            this.miHelpButton.Click += new System.EventHandler(this.miHelpButton_Click);
            // 
            // miSpacer2
            // 
            this.miSpacer2.Index = 4;
            this.miSpacer2.Text = "-";
            // 
            // miAboutSG
            // 
            this.miAboutSG.Index = 5;
            this.miAboutSG.Text = "About Super Grate";
            this.miAboutSG.Click += new System.EventHandler(this.MiAboutSG_Click);
            // 
            // dialogSaveLog
            // 
            this.dialogSaveLog.Filter = "Text File|*.txt|Log File|*.log";
            this.dialogSaveLog.FilterIndex = 2;
            this.dialogSaveLog.Title = "Save Super Grate Log...";
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 442);
            this.Controls.Add(this.spltContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Menu = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(680, 320);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Grate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.logTable.ResumeLayout(false);
            this.spltContainer.Panel1.ResumeLayout(false);
            this.spltContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).EndInit();
            this.spltContainer.ResumeLayout(false);
            this.tblMainLayout.ResumeLayout(false);
            this.sourCompTabl.ResumeLayout(false);
            this.sourCompTabl.PerformLayout();
            this.tbleListUsersButtons.ResumeLayout(false);
            this.pnlLogoBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadLogo)).EndInit();
            this.destCompTabl.ResumeLayout(false);
            this.destCompTabl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.TableLayoutPanel logTable;
        private System.Windows.Forms.SplitContainer spltContainer;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Label lblSourceComputer;
        private System.Windows.Forms.Label lblDestinationComputer;
        private System.Windows.Forms.Label lblUserList;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnListSource;
        private System.Windows.Forms.Button btnListStore;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlLogoBorder;
        private System.Windows.Forms.TableLayoutPanel tbleListUsersButtons;
        private System.Windows.Forms.TableLayoutPanel sourCompTabl;
        private System.Windows.Forms.TextBox tbSourceComputer;
        private System.Windows.Forms.Button btnAFillSrc;
        private System.Windows.Forms.TableLayoutPanel destCompTabl;
        private System.Windows.Forms.Button btnAFillDest;
        private System.Windows.Forms.TextBox tbDestinationComputer;
        private System.Windows.Forms.PictureBox imgLoadLogo;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem miFile;
        private System.Windows.Forms.MenuItem miExitButton;
        private System.Windows.Forms.MenuItem miSaveLog;
        private System.Windows.Forms.MenuItem miSpacer0;
        private System.Windows.Forms.MenuItem miSetup;
        private System.Windows.Forms.MenuItem miHelp;
        private System.Windows.Forms.MenuItem miDocumentation;
        private System.Windows.Forms.MenuItem miIssues;
        private System.Windows.Forms.MenuItem miAboutSG;
        private System.Windows.Forms.SaveFileDialog dialogSaveLog;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.MenuItem miSpacer1;
        private System.Windows.Forms.MenuItem miHelpButton;
        private System.Windows.Forms.MenuItem miSpacer2;
        private System.Windows.Forms.MenuItem miNewInstance;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ListView listUsers;
        private System.Windows.Forms.MenuItem miView;
        private System.Windows.Forms.MenuItem miAddRemoveCol;
    }
}

