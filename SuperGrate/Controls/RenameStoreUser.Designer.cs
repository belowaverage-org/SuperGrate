
namespace SuperGrate.Controls
{
    partial class RenameStoreUser
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
            this.lblOrigName = new System.Windows.Forms.Label();
            this.lblDestName = new System.Windows.Forms.Label();
            this.tbOrigUser = new System.Windows.Forms.TextBox();
            this.tbDestUser = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrigName
            // 
            this.lblOrigName.AutoSize = true;
            this.lblOrigName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrigName.Location = new System.Drawing.Point(25, 37);
            this.lblOrigName.Name = "lblOrigName";
            this.lblOrigName.Size = new System.Drawing.Size(103, 13);
            this.lblOrigName.TabIndex = 0;
            this.lblOrigName.Text = "Source User Name:";
            // 
            // lblDestName
            // 
            this.lblDestName.AutoSize = true;
            this.lblDestName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDestName.Location = new System.Drawing.Point(25, 77);
            this.lblDestName.Name = "lblDestName";
            this.lblDestName.Size = new System.Drawing.Size(128, 13);
            this.lblDestName.TabIndex = 1;
            this.lblDestName.Text = "Destination User Name:";
            // 
            // tbOrigUser
            // 
            this.tbOrigUser.Enabled = false;
            this.tbOrigUser.Location = new System.Drawing.Point(171, 34);
            this.tbOrigUser.Name = "tbOrigUser";
            this.tbOrigUser.Size = new System.Drawing.Size(212, 22);
            this.tbOrigUser.TabIndex = 2;
            // 
            // tbDestUser
            // 
            this.tbDestUser.Location = new System.Drawing.Point(171, 74);
            this.tbDestUser.MaxLength = 50;
            this.tbDestUser.Name = "tbDestUser";
            this.tbDestUser.Size = new System.Drawing.Size(212, 22);
            this.tbDestUser.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription.Location = new System.Drawing.Point(22, 20);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(353, 26);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Use this dialog to specify a \"destination user name\" when restoring\r\na profile fr" +
    "om the \"store\".";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(336, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = " &Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(240, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = " &OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.lblOrigName);
            this.gb1.Controls.Add(this.lblDestName);
            this.gb1.Controls.Add(this.tbOrigUser);
            this.gb1.Controls.Add(this.tbDestUser);
            this.gb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gb1.Location = new System.Drawing.Point(12, 67);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(409, 120);
            this.gb1.TabIndex = 7;
            this.gb1.TabStop = false;
            this.gb1.Text = "User Name - Properties";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 45);
            this.panel1.TabIndex = 8;
            // 
            // RenameStoreUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 248);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.lblDescription);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameStoreUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Destination User Name";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrigName;
        private System.Windows.Forms.Label lblDestName;
        private System.Windows.Forms.TextBox tbOrigUser;
        private System.Windows.Forms.TextBox tbDestUser;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Panel panel1;
    }
}