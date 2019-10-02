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
            this.btnSave = new System.Windows.Forms.Button();
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
            this.settingsList.HideSelection = false;
            this.settingsList.Location = new System.Drawing.Point(0, 0);
            this.settingsList.MultiSelect = false;
            this.settingsList.Name = "settingsList";
            this.settingsList.Size = new System.Drawing.Size(550, 207);
            this.settingsList.TabIndex = 0;
            this.settingsList.UseCompatibleStateImageBehavior = false;
            this.settingsList.View = System.Windows.Forms.View.Details;
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
            this.btnSave.Location = new System.Drawing.Point(446, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 253);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.settingsList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Super Grate - Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView settingsList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader Setting;
        private System.Windows.Forms.ColumnHeader Value;
    }
}