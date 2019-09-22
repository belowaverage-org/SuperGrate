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
            this.btStartStop = new System.Windows.Forms.Button();
            this.tbleListUsersButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnListSource = new System.Windows.Forms.Button();
            this.btnListStore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.pnlLogoBorder = new System.Windows.Forms.Panel();
            this.imgLoadLogo = new System.Windows.Forms.PictureBox();
            this.destCompTabl = new System.Windows.Forms.TableLayoutPanel();
            this.btnAFillDest = new System.Windows.Forms.Button();
            this.tbDestinationComputer = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miSaveLog = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.miExitButton = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.miDocumentation = new System.Windows.Forms.MenuItem();
            this.miIssues = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.miAboutSG = new System.Windows.Forms.MenuItem();
            this.dialogSaveLog = new System.Windows.Forms.SaveFileDialog();
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
            this.LogBox.Location = new System.Drawing.Point(3, 4);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(311, 272);
            this.LogBox.TabIndex = 100;
            this.LogBox.Text = "";
            this.LogBox.DoubleClick += new System.EventHandler(this.LogBox_DoubleClick);
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.ForeColor = System.Drawing.Color.Black;
            this.pbMain.Location = new System.Drawing.Point(3, 284);
            this.pbMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(311, 22);
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
            this.logTable.Size = new System.Drawing.Size(317, 310);
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
            this.spltContainer.Size = new System.Drawing.Size(670, 310);
            this.spltContainer.SplitterDistance = 349;
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
            this.tblMainLayout.Controls.Add(this.btStartStop, 0, 5);
            this.tblMainLayout.Controls.Add(this.tbleListUsersButtons, 1, 2);
            this.tblMainLayout.Controls.Add(this.lbxUsers, 1, 3);
            this.tblMainLayout.Controls.Add(this.pnlLogoBorder, 0, 4);
            this.tblMainLayout.Controls.Add(this.destCompTabl, 1, 1);
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
            this.tblMainLayout.Size = new System.Drawing.Size(349, 310);
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
            this.sourCompTabl.Size = new System.Drawing.Size(219, 30);
            this.sourCompTabl.TabIndex = 101;
            // 
            // tbSourceComputer
            // 
            this.tbSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourceComputer.Location = new System.Drawing.Point(3, 4);
            this.tbSourceComputer.Margin = new System.Windows.Forms.Padding(3, 4, 6, 4);
            this.tbSourceComputer.Name = "tbSourceComputer";
            this.tbSourceComputer.Size = new System.Drawing.Size(185, 22);
            this.tbSourceComputer.TabIndex = 101;
            this.tbSourceComputer.TextChanged += new System.EventHandler(this.TbSourceComputer_TextChanged);
            // 
            // btnAFillSrc
            // 
            this.btnAFillSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAFillSrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAFillSrc.Location = new System.Drawing.Point(194, 3);
            this.btnAFillSrc.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnAFillSrc.Name = "btnAFillSrc";
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
            this.lblUserList.Location = new System.Drawing.Point(3, 90);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(124, 80);
            this.lblUserList.TabIndex = 100;
            this.lblUserList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btStartStop
            // 
            this.tblMainLayout.SetColumnSpan(this.btStartStop, 2);
            this.btStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btStartStop.Enabled = false;
            this.btStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btStartStop.Location = new System.Drawing.Point(3, 283);
            this.btStartStop.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btStartStop.Name = "btStartStop";
            this.btStartStop.Size = new System.Drawing.Size(344, 24);
            this.btStartStop.TabIndex = 100;
            this.btStartStop.Text = "Start";
            this.btStartStop.UseVisualStyleBackColor = true;
            this.btStartStop.Click += new System.EventHandler(this.BtStartStop_Click);
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
            this.tbleListUsersButtons.Size = new System.Drawing.Size(219, 30);
            this.tbleListUsersButtons.TabIndex = 100;
            // 
            // btnListSource
            // 
            this.btnListSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnListSource.Location = new System.Drawing.Point(2, 3);
            this.btnListSource.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnListSource.Name = "btnListSource";
            this.btnListSource.Size = new System.Drawing.Size(68, 25);
            this.btnListSource.TabIndex = 100;
            this.btnListSource.Text = "List Source";
            this.btnListSource.UseVisualStyleBackColor = true;
            this.btnListSource.Click += new System.EventHandler(this.BtnListSource_Click);
            // 
            // btnListStore
            // 
            this.btnListStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListStore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnListStore.Location = new System.Drawing.Point(76, 3);
            this.btnListStore.Name = "btnListStore";
            this.btnListStore.Size = new System.Drawing.Size(67, 25);
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
            this.btnDelete.Location = new System.Drawing.Point(149, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 25);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lbxUsers
            // 
            this.lbxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxUsers.FormattingEnabled = true;
            this.lbxUsers.IntegralHeight = false;
            this.lbxUsers.Location = new System.Drawing.Point(133, 94);
            this.lbxUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbxUsers.Name = "lbxUsers";
            this.tblMainLayout.SetRowSpan(this.lbxUsers, 2);
            this.lbxUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxUsers.Size = new System.Drawing.Size(213, 182);
            this.lbxUsers.TabIndex = 100;
            this.lbxUsers.SelectedIndexChanged += new System.EventHandler(this.UpdateFormRestrictions);
            // 
            // pnlLogoBorder
            // 
            this.pnlLogoBorder.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLogoBorder.Controls.Add(this.imgLoadLogo);
            this.pnlLogoBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoBorder.Location = new System.Drawing.Point(4, 170);
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
            this.imgLoadLogo.Image = global::SuperGrate.Properties.Resources.working;
            this.imgLoadLogo.Location = new System.Drawing.Point(1, 1);
            this.imgLoadLogo.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadLogo.Name = "imgLoadLogo";
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
            this.destCompTabl.Size = new System.Drawing.Size(219, 30);
            this.destCompTabl.TabIndex = 102;
            // 
            // btnAFillDest
            // 
            this.btnAFillDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAFillDest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAFillDest.Location = new System.Drawing.Point(194, 3);
            this.btnAFillDest.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnAFillDest.Name = "btnAFillDest";
            this.btnAFillDest.Size = new System.Drawing.Size(23, 24);
            this.btnAFillDest.TabIndex = 103;
            this.btnAFillDest.Text = "<";
            this.btnAFillDest.UseVisualStyleBackColor = true;
            this.btnAFillDest.Click += new System.EventHandler(this.BtnAFillDest_Click);
            // 
            // tbDestinationComputer
            // 
            this.tbDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDestinationComputer.Location = new System.Drawing.Point(3, 4);
            this.tbDestinationComputer.Margin = new System.Windows.Forms.Padding(3, 4, 6, 4);
            this.tbDestinationComputer.Name = "tbDestinationComputer";
            this.tbDestinationComputer.Size = new System.Drawing.Size(185, 22);
            this.tbDestinationComputer.TabIndex = 102;
            this.tbDestinationComputer.TextChanged += new System.EventHandler(this.TbDestinationComputer_TextChanged);
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem5,
            this.menuItem12});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSaveLog,
            this.menuItem4,
            this.miExitButton});
            this.menuItem1.Text = "&File";
            // 
            // miSaveLog
            // 
            this.miSaveLog.Index = 0;
            this.miSaveLog.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.miSaveLog.Text = "Save Log...";
            this.miSaveLog.Click += new System.EventHandler(this.MiSaveLog_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // miExitButton
            // 
            this.miExitButton.Index = 2;
            this.miExitButton.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.miExitButton.Text = "Exit";
            this.miExitButton.Click += new System.EventHandler(this.MiExitButton_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem11});
            this.menuItem5.Text = "&Setup";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8});
            this.menuItem6.Text = "Edit Configuration";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "Super Grate...";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem10});
            this.menuItem8.Text = "USMT";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "x86...";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "x64...";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "Settings...";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDocumentation,
            this.miIssues,
            this.menuItem13,
            this.miAboutSG});
            this.menuItem12.Text = "&Help";
            // 
            // miDocumentation
            // 
            this.miDocumentation.Index = 0;
            this.miDocumentation.Text = "Documentation";
            this.miDocumentation.Click += new System.EventHandler(this.MiDocumentation_Click);
            // 
            // miIssues
            // 
            this.miIssues.Index = 1;
            this.miIssues.Text = "Issues";
            this.miIssues.Click += new System.EventHandler(this.MiIssues_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "-";
            // 
            // miAboutSG
            // 
            this.miAboutSG.Index = 3;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 320);
            this.Controls.Add(this.spltContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Menu = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(680, 320);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Grate - Remote User Migration & Backup";
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
        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.Button btStartStop;
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
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miExitButton;
        private System.Windows.Forms.MenuItem miSaveLog;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem miDocumentation;
        private System.Windows.Forms.MenuItem miIssues;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem miAboutSG;
        private System.Windows.Forms.SaveFileDialog dialogSaveLog;
    }
}

