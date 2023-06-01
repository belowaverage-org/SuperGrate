namespace SuperGrate.Controls
{
    partial class Settings
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
            this.settingsList = new System.Windows.Forms.ListView();
            this.Setting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new SuperGrate.Controls.Components.SGButton();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnRevert = new SuperGrate.Controls.Components.SGButton();
            this.btnApply = new SuperGrate.Controls.Components.SGButton();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // settingsList
            // 
            this.settingsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.settingsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Setting,
            this.Value});
            this.settingsList.FullRowSelect = true;
            this.settingsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.helpProvider.SetHelpString(this.settingsList, "List of settings / parameters for Super Grate. Double click any setting to change" +
        " its value.");
            this.settingsList.HideSelection = false;
            this.settingsList.Location = new System.Drawing.Point(0, 0);
            this.settingsList.MultiSelect = false;
            this.settingsList.Name = "settingsList";
            this.helpProvider.SetShowHelp(this.settingsList, true);
            this.settingsList.Size = new System.Drawing.Size(694, 308);
            this.settingsList.TabIndex = 0;
            this.settingsList.UseCompatibleStateImageBehavior = false;
            this.settingsList.View = System.Windows.Forms.View.Details;
            this.settingsList.DoubleClick += new System.EventHandler(this.SettingsList_DoubleClick);
            // 
            // Setting
            // 
            this.Setting.Text = "Setting";
            this.Setting.Width = 113;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 525;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnSave, "Saves the configuration to disk.");
            this.btnSave.Icon = "";
            this.btnSave.Location = new System.Drawing.Point(460, 316);
            this.btnSave.Name = "btnSave";
            this.helpProvider.SetShowHelp(this.btnSave, true);
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save to Disk";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHint.AutoEllipsis = true;
            this.lblHint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblHint.Location = new System.Drawing.Point(10, 325);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(375, 20);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Double Click a setting to change its value.";
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnRevert, "Re-load the configuration from disk.");
            this.btnRevert.Icon = "";
            this.btnRevert.Location = new System.Drawing.Point(344, 316);
            this.btnRevert.Name = "btnRevert";
            this.helpProvider.SetShowHelp(this.btnRevert, true);
            this.btnRevert.Size = new System.Drawing.Size(109, 34);
            this.btnRevert.TabIndex = 3;
            this.btnRevert.Text = "Reload";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnApply, "Closes this window.");
            this.btnApply.Icon = "";
            this.btnApply.Location = new System.Drawing.Point(576, 316);
            this.btnApply.Name = "btnApply";
            this.helpProvider.SetShowHelp(this.btnApply, true);
            this.btnApply.Size = new System.Drawing.Size(109, 34);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Close";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CancelButton = this.btnApply;
            this.ClientSize = new System.Drawing.Size(694, 357);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.settingsList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 257);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView settingsList;
        private Components.SGButton btnSave;
        private System.Windows.Forms.ColumnHeader Setting;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Label lblHint;
        private Components.SGButton btnRevert;
        private Components.SGButton btnApply;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}