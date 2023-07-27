namespace SuperGrate.Controls
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
            this.btnCancel = new Components.SGButton();
            this.btnSave = new Components.SGButton();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.btnRestoreDefault = new Components.SGButton();
            this.SuspendLayout();
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(5, 5);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComment.Size = new System.Drawing.Size(381, 63);
            this.tbComment.TabIndex = 0;
            this.tbComment.TabStop = false;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(5, 74);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(381, 65);
            this.tbValue.TabIndex = 1;
            this.tbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbValue_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(312, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Icon = "";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(232, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Icon = "";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestoreDefault.Location = new System.Drawing.Point(4, 143);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.btnRestoreDefault.Icon = "";
            this.btnRestoreDefault.Size = new System.Drawing.Size(75, 25);
            this.btnRestoreDefault.TabIndex = 4;
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
            this.HelpButton = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ChangeSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.TextBox tbValue;
        private Components.SGButton btnCancel;
        private Components.SGButton btnSave;
        private System.Windows.Forms.HelpProvider helpProvider;
        private Components.SGButton btnRestoreDefault;
    }
}