﻿namespace SuperGrate.Controls
{
    partial class ChangeSetting
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
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.btnRestoreDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbComment
            // 
            this.helpProvider.SetHelpString(this.tbComment, "This is a description of the setting.");
            this.tbComment.Location = new System.Drawing.Point(5, 5);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider.SetShowHelp(this.tbComment, true);
            this.tbComment.Size = new System.Drawing.Size(381, 63);
            this.tbComment.TabIndex = 0;
            this.tbComment.TabStop = false;
            // 
            // tbValue
            // 
            this.helpProvider.SetHelpString(this.tbValue, "This is the value of the setting.");
            this.tbValue.Location = new System.Drawing.Point(5, 74);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.helpProvider.SetShowHelp(this.tbValue, true);
            this.tbValue.Size = new System.Drawing.Size(381, 65);
            this.tbValue.TabIndex = 1;
            this.tbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbValue_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnCancel, "Closes window, and does not apply change.");
            this.btnCancel.Location = new System.Drawing.Point(312, 143);
            this.btnCancel.Name = "btnCancel";
            this.helpProvider.SetShowHelp(this.btnCancel, true);
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = " &Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnSave, "Applies the setting changed above for the current session. Press \"Save to Disk\" o" +
        "n the next screen to save the changes to disk.");
            this.btnSave.Location = new System.Drawing.Point(232, 143);
            this.btnSave.Name = "btnSave";
            this.helpProvider.SetShowHelp(this.btnSave, true);
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = " &Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpProvider.SetHelpString(this.btnRestoreDefault, "Restores default setting value.");
            this.btnRestoreDefault.Location = new System.Drawing.Point(4, 143);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.helpProvider.SetShowHelp(this.btnRestoreDefault, true);
            this.btnRestoreDefault.Size = new System.Drawing.Size(75, 25);
            this.btnRestoreDefault.TabIndex = 4;
            this.btnRestoreDefault.Text = " &Default";
            this.btnRestoreDefault.Click += new System.EventHandler(this.BtnRestoreDefault_Click);
            // 
            // ChangeSetting
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 171);
            this.Controls.Add(this.btnRestoreDefault);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbComment);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Setting: ";
            this.Load += new System.EventHandler(this.ChangeSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Button btnRestoreDefault;
    }
}