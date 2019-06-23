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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserList = new System.Windows.Forms.Label();
            this.tbSourceComputer = new System.Windows.Forms.TextBox();
            this.tbDestinationComputer = new System.Windows.Forms.TextBox();
            this.btStartStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnListSource = new System.Windows.Forms.Button();
            this.btnListStore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.pnlLogoBorder = new System.Windows.Forms.Panel();
            this.imgLoadLogo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tblMainLayout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.LogBox.Size = new System.Drawing.Size(314, 363);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            this.LogBox.DoubleClick += new System.EventHandler(this.LogBox_DoubleClick);
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.ForeColor = System.Drawing.Color.Black;
            this.pbMain.Location = new System.Drawing.Point(3, 375);
            this.pbMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(314, 22);
            this.pbMain.TabIndex = 1;
            this.pbMain.Value = 100;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LogBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 401);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tblMainLayout);
            this.splitContainer1.Panel1MinSize = 330;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(654, 401);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 3;
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 2;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Controls.Add(this.label1, 0, 0);
            this.tblMainLayout.Controls.Add(this.label2, 0, 1);
            this.tblMainLayout.Controls.Add(this.lblUserList, 0, 3);
            this.tblMainLayout.Controls.Add(this.tbSourceComputer, 1, 0);
            this.tblMainLayout.Controls.Add(this.tbDestinationComputer, 1, 1);
            this.tblMainLayout.Controls.Add(this.btStartStop, 0, 4);
            this.tblMainLayout.Controls.Add(this.tableLayoutPanel3, 1, 2);
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
            this.tblMainLayout.Size = new System.Drawing.Size(330, 401);
            this.tblMainLayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Computer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Computer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserList
            // 
            this.lblUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserList.Location = new System.Drawing.Point(3, 90);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(114, 171);
            this.lblUserList.TabIndex = 4;
            this.lblUserList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSourceComputer
            // 
            this.tbSourceComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourceComputer.Location = new System.Drawing.Point(123, 4);
            this.tbSourceComputer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSourceComputer.Multiline = true;
            this.tbSourceComputer.Name = "tbSourceComputer";
            this.tbSourceComputer.Size = new System.Drawing.Size(204, 22);
            this.tbSourceComputer.TabIndex = 5;
            this.tbSourceComputer.TextChanged += new System.EventHandler(this.TbSourceComputer_TextChanged);
            // 
            // tbDestinationComputer
            // 
            this.tbDestinationComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDestinationComputer.Location = new System.Drawing.Point(123, 34);
            this.tbDestinationComputer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDestinationComputer.Multiline = true;
            this.tbDestinationComputer.Name = "tbDestinationComputer";
            this.tbDestinationComputer.Size = new System.Drawing.Size(204, 22);
            this.tbDestinationComputer.TabIndex = 7;
            this.tbDestinationComputer.TextChanged += new System.EventHandler(this.TbDestinationComputer_TextChanged);
            // 
            // btStartStop
            // 
            this.tblMainLayout.SetColumnSpan(this.btStartStop, 2);
            this.btStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btStartStop.Enabled = false;
            this.btStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btStartStop.Location = new System.Drawing.Point(3, 374);
            this.btStartStop.Name = "btStartStop";
            this.btStartStop.Size = new System.Drawing.Size(324, 24);
            this.btStartStop.TabIndex = 9;
            this.btStartStop.Text = "Start";
            this.btStartStop.UseVisualStyleBackColor = true;
            this.btStartStop.Click += new System.EventHandler(this.BtStartStop_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btnListSource, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnListStore, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(120, 60);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(210, 30);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // btnListSource
            // 
            this.btnListSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnListSource.Location = new System.Drawing.Point(3, 3);
            this.btnListSource.Name = "btnListSource";
            this.btnListSource.Size = new System.Drawing.Size(64, 24);
            this.btnListSource.TabIndex = 0;
            this.btnListSource.Text = "List Source";
            this.btnListSource.UseVisualStyleBackColor = true;
            this.btnListSource.Click += new System.EventHandler(this.BtnListSource_Click);
            // 
            // btnListStore
            // 
            this.btnListStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListStore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnListStore.Location = new System.Drawing.Point(73, 3);
            this.btnListStore.Name = "btnListStore";
            this.btnListStore.Size = new System.Drawing.Size(64, 24);
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
            this.btnDelete.Location = new System.Drawing.Point(143, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 24);
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
            this.lbxUsers.Location = new System.Drawing.Point(123, 94);
            this.lbxUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbxUsers.Name = "lbxUsers";
            this.tblMainLayout.SetRowSpan(this.lbxUsers, 2);
            this.lbxUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxUsers.Size = new System.Drawing.Size(204, 273);
            this.lbxUsers.TabIndex = 8;
            this.lbxUsers.SelectedIndexChanged += new System.EventHandler(this.UpdateFormRestrictions);
            // 
            // pnlLogoBorder
            // 
            this.pnlLogoBorder.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLogoBorder.Controls.Add(this.imgLoadLogo);
            this.pnlLogoBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoBorder.Location = new System.Drawing.Point(4, 261);
            this.pnlLogoBorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pnlLogoBorder.Name = "pnlLogoBorder";
            this.pnlLogoBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLogoBorder.Size = new System.Drawing.Size(112, 106);
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
            this.imgLoadLogo.Size = new System.Drawing.Size(110, 104);
            this.imgLoadLogo.TabIndex = 11;
            this.imgLoadLogo.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(664, 411);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(680, 320);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Super Grate - Remote User Migration & Backup";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tblMainLayout.ResumeLayout(false);
            this.tblMainLayout.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlLogoBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserList;
        private System.Windows.Forms.TextBox tbSourceComputer;
        private System.Windows.Forms.TextBox tbDestinationComputer;
        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.Button btStartStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnListSource;
        private System.Windows.Forms.Button btnListStore;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox imgLoadLogo;
        private System.Windows.Forms.Panel pnlLogoBorder;
    }
}

