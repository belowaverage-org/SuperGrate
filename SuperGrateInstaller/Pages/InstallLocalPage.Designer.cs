namespace SuperGrateInstaller.Pages
{
    partial class InstallLocalPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbNetworkPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDescript = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileDialog
            // 
            this.fileDialog.Description = "Select a local folder to install Super Grate.";
            this.fileDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tbNetworkPath
            // 
            this.tbNetworkPath.Location = new System.Drawing.Point(42, 121);
            this.tbNetworkPath.Name = "tbNetworkPath";
            this.tbNetworkPath.Size = new System.Drawing.Size(418, 23);
            this.tbNetworkPath.TabIndex = 0;
            this.tbNetworkPath.Text = "C:\\Program Files\\Super Grate";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Location = new System.Drawing.Point(475, 120);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 25);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblDescript
            // 
            this.lblDescript.AutoSize = true;
            this.lblDescript.Location = new System.Drawing.Point(39, 63);
            this.lblDescript.Name = "lblDescript";
            this.lblDescript.Size = new System.Drawing.Size(222, 15);
            this.lblDescript.TabIndex = 2;
            this.lblDescript.Text = "Select a local folder to install Super Grate.";
            // 
            // InstallLocalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblDescript);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbNetworkPath);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InstallLocalPage";
            this.Size = new System.Drawing.Size(600, 250);
            this.OnPrevious += new System.EventHandler(this.NetworkPage_OnPrevious);
            this.Load += new System.EventHandler(this.InstallLocalPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fileDialog;
        private System.Windows.Forms.TextBox tbNetworkPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblDescript;
    }
}
