
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
            this.tbOrigUser = new SuperGrate.Controls.Components.SGTextBox();
            this.tbDestUser = new SuperGrate.Controls.Components.SGTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCancel = new SuperGrate.Controls.Components.SGButton();
            this.btnSave = new SuperGrate.Controls.Components.SGButton();
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
            this.lblOrigName.Location = new System.Drawing.Point(29, 43);
            this.lblOrigName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrigName.Name = "lblOrigName";
            this.lblOrigName.Size = new System.Drawing.Size(107, 15);
            this.lblOrigName.TabIndex = 0;
            this.lblOrigName.Text = "Source User Name:";
            // 
            // lblDestName
            // 
            this.lblDestName.AutoSize = true;
            this.lblDestName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDestName.Location = new System.Drawing.Point(29, 89);
            this.lblDestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestName.Name = "lblDestName";
            this.lblDestName.Size = new System.Drawing.Size(131, 15);
            this.lblDestName.TabIndex = 1;
            this.lblDestName.Text = "Destination User Name:";
            // 
            // tbOrigUser
            // 
            this.tbOrigUser.Enabled = false;
            this.tbOrigUser.Icon = "";
            this.tbOrigUser.Location = new System.Drawing.Point(200, 35);
            this.tbOrigUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbOrigUser.Multiline = true;
            this.tbOrigUser.Name = "tbOrigUser";
            this.tbOrigUser.Size = new System.Drawing.Size(247, 30);
            this.tbOrigUser.TabIndex = 2;
            // 
            // tbDestUser
            // 
            this.tbDestUser.Icon = "";
            this.tbDestUser.Location = new System.Drawing.Point(200, 81);
            this.tbDestUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDestUser.MaxLength = 50;
            this.tbDestUser.Multiline = true;
            this.tbDestUser.Name = "tbDestUser";
            this.tbDestUser.Size = new System.Drawing.Size(247, 30);
            this.tbDestUser.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription.Location = new System.Drawing.Point(26, 23);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(359, 30);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Use this dialog to specify a \"destination user name\" when restoring\r\na profile fr" +
    "om the \"store\".";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Icon = "";
            this.btnCancel.Location = new System.Drawing.Point(391, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Icon = "";
            this.btnSave.Location = new System.Drawing.Point(279, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "OK";
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
            this.gb1.Location = new System.Drawing.Point(14, 77);
            this.gb1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb1.Size = new System.Drawing.Size(477, 138);
            this.gb1.TabIndex = 7;
            this.gb1.TabStop = false;
            this.gb1.Text = "User Name - Properties";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(0, 218);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 52);
            this.panel1.TabIndex = 8;
            // 
            // RenameStoreUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(506, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.lblDescription);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
        private Components.SGTextBox tbOrigUser;
        private Components.SGTextBox tbDestUser;
        private System.Windows.Forms.Label lblDescription;
        private Components.SGButton btnCancel;
        private Components.SGButton btnSave;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Panel panel1;
    }
}