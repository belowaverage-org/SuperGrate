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
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.logTable = new System.Windows.Forms.TableLayoutPanel();
            this.spltContainer = new System.Windows.Forms.SplitContainer();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblSourceComputer = new System.Windows.Forms.Label();
            this.lblDestinationComputer = new System.Windows.Forms.Label();
            this.lblUserList = new System.Windows.Forms.Label();
            this.tbSourceComputer = new System.Windows.Forms.TextBox();
            this.tbDestinationComputer = new System.Windows.Forms.TextBox();
            this.btStartStop = new System.Windows.Forms.Button();
            this.tbleListUsersButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnListSource = new System.Windows.Forms.Button();
            this.btnListStore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.pnlLogoBorder = new System.Windows.Forms.Panel();
            this.imgLoadLogo = new System.Windows.Forms.PictureBox();
            this.logTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).BeginInit();
            this.spltContainer.Panel1.SuspendLayout();
            this.spltContainer.Panel2.SuspendLayout();
            this.spltContainer.SuspendLayout();
            this.tblMainLayout.SuspendLayout();
            this.tbleListUsersButtons.SuspendLayout();
            this.pnlLogoBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadLogo)).BeginInit();
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
            this.LogBox.TabIndex = 0;
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
            this.pbMain.TabIndex = 1;
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
            this.logTable.TabIndex = 2;
            // 
            // spltContainer
            // 
            this.spltContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.spltContainer.TabIndex = 3;
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 2;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Controls.Add(this.lblSourceComputer, 0, 0);
            this.tblMainLayout.Controls.Add(this.lblDestinationComputer, 0, 1);
            this.tblMainLayout.Controls.Add(this.lblUserList, 0, 3);
            this.tblMainLayout.Controls.Add(this.tbSourceComputer, 1, 0);
            this.tblMainLayout.Controls.Add(this.tbDestinationComputer, 1, 1);
            this.tblMainLayout.Controls.Add(this.btStartStop, 0, 4);
            this.tblMainLayout.Controls.Add(this.tbleListUsersButtons, 1, 2);
            this.tblMainLayout.Controls.Add(this.lbxUsers, 1, 3);
            this.tblMainLayout.Controls.Add(this.pnlLogoBorder, 0, 4);
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
            this.tblMainLayout.Size = new System.Drawing.Size(349, 310);
            this.tblMainLayout.TabIndex = 0;
            // 
            // lblSourceComputer
            // 
            this.lblSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSourceComputer.Location = new System.Drawing.Point(3, 0);
            this.lblSourceComputer.Name = "lblSourceComputer";
            this.lblSourceComputer.Size = new System.Drawing.Size(124, 30);
            this.lblSourceComputer.TabIndex = 0;
            this.lblSourceComputer.Text = "Source Computer";
            this.lblSourceComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDestinationComputer
            // 
            this.lblDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationComputer.Location = new System.Drawing.Point(3, 30);
            this.lblDestinationComputer.Name = "lblDestinationComputer";
            this.lblDestinationComputer.Size = new System.Drawing.Size(124, 30);
            this.lblDestinationComputer.TabIndex = 1;
            this.lblDestinationComputer.Text = "Destination Computer";
            this.lblDestinationComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserList
            // 
            this.lblUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserList.Location = new System.Drawing.Point(3, 90);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(124, 80);
            this.lblUserList.TabIndex = 4;
            this.lblUserList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSourceComputer
            // 
            this.tbSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourceComputer.Location = new System.Drawing.Point(133, 4);
            this.tbSourceComputer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSourceComputer.Name = "tbSourceComputer";
            this.tbSourceComputer.Size = new System.Drawing.Size(213, 22);
            this.tbSourceComputer.TabIndex = 5;
            this.tbSourceComputer.TextChanged += new System.EventHandler(this.TbSourceComputer_TextChanged);
            // 
            // tbDestinationComputer
            // 
            this.tbDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDestinationComputer.Location = new System.Drawing.Point(133, 34);
            this.tbDestinationComputer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDestinationComputer.Name = "tbDestinationComputer";
            this.tbDestinationComputer.Size = new System.Drawing.Size(213, 22);
            this.tbDestinationComputer.TabIndex = 7;
            this.tbDestinationComputer.TextChanged += new System.EventHandler(this.TbDestinationComputer_TextChanged);
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
            this.btStartStop.TabIndex = 9;
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
            this.tbleListUsersButtons.TabIndex = 10;
            // 
            // btnListSource
            // 
            this.btnListSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnListSource.Location = new System.Drawing.Point(2, 3);
            this.btnListSource.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnListSource.Name = "btnListSource";
            this.btnListSource.Size = new System.Drawing.Size(68, 25);
            this.btnListSource.TabIndex = 0;
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
            this.btnListStore.TabIndex = 1;
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
            this.btnDelete.TabIndex = 2;
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
            this.lbxUsers.TabIndex = 8;
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
            this.pnlLogoBorder.TabIndex = 11;
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
            this.imgLoadLogo.TabIndex = 11;
            this.imgLoadLogo.TabStop = false;
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
            this.MinimumSize = new System.Drawing.Size(680, 320);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Grate - Remote User Migration & Backup";
            this.Load += new System.EventHandler(this.Main_Load);
            this.logTable.ResumeLayout(false);
            this.spltContainer.Panel1.ResumeLayout(false);
            this.spltContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).EndInit();
            this.spltContainer.ResumeLayout(false);
            this.tblMainLayout.ResumeLayout(false);
            this.tblMainLayout.PerformLayout();
            this.tbleListUsersButtons.ResumeLayout(false);
            this.pnlLogoBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadLogo)).EndInit();
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
        private System.Windows.Forms.TextBox tbSourceComputer;
        private System.Windows.Forms.TextBox tbDestinationComputer;
        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.Button btStartStop;
        private System.Windows.Forms.Button btnListSource;
        private System.Windows.Forms.Button btnListStore;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox imgLoadLogo;
        private System.Windows.Forms.Panel pnlLogoBorder;
        private System.Windows.Forms.TableLayoutPanel tbleListUsersButtons;
    }
}

