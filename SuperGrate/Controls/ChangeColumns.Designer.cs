namespace SuperGrate.Controls
{
    partial class ChangeColumns
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbAvailable = new System.Windows.Forms.ListBox();
            this.lbDisplayed = new System.Windows.Forms.ListBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.lblAvail = new System.Windows.Forms.Label();
            this.lblDispl = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(153, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 21);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "A&dd ->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Location = new System.Drawing.Point(153, 102);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(88, 21);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<- &Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // lbAvailable
            // 
            this.lbAvailable.FormattingEnabled = true;
            this.lbAvailable.HorizontalScrollbar = true;
            this.lbAvailable.IntegralHeight = false;
            this.lbAvailable.Location = new System.Drawing.Point(11, 28);
            this.lbAvailable.Name = "lbAvailable";
            this.lbAvailable.ScrollAlwaysVisible = true;
            this.lbAvailable.Size = new System.Drawing.Size(135, 192);
            this.lbAvailable.TabIndex = 2;
            this.lbAvailable.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            this.lbAvailable.DoubleClick += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // lbDisplayed
            // 
            this.lbDisplayed.FormattingEnabled = true;
            this.lbDisplayed.HorizontalScrollbar = true;
            this.lbDisplayed.IntegralHeight = false;
            this.lbDisplayed.Location = new System.Drawing.Point(248, 28);
            this.lbDisplayed.Name = "lbDisplayed";
            this.lbDisplayed.ScrollAlwaysVisible = true;
            this.lbDisplayed.Size = new System.Drawing.Size(135, 192);
            this.lbDisplayed.TabIndex = 3;
            this.lbDisplayed.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            this.lbDisplayed.DoubleClick += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveUp.Location = new System.Drawing.Point(392, 27);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(118, 21);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "M&ove Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMoveDown.Location = new System.Drawing.Point(392, 56);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(118, 21);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Text = "Mo&ve Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestoreDefaults.Location = new System.Drawing.Point(392, 95);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(118, 21);
            this.btnRestoreDefaults.TabIndex = 6;
            this.btnRestoreDefaults.Text = "Re&store Defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // lblAvail
            // 
            this.lblAvail.AutoSize = true;
            this.lblAvail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAvail.Location = new System.Drawing.Point(12, 9);
            this.lblAvail.Name = "lblAvail";
            this.lblAvail.Size = new System.Drawing.Size(102, 13);
            this.lblAvail.TabIndex = 9;
            this.lblAvail.Text = "&Available columns:";
            // 
            // lblDispl
            // 
            this.lblDispl.AutoSize = true;
            this.lblDispl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDispl.Location = new System.Drawing.Point(247, 9);
            this.lblDispl.Name = "lblDispl";
            this.lblDispl.Size = new System.Drawing.Size(106, 13);
            this.lblDispl.TabIndex = 10;
            this.lblDispl.Text = "Display&ed columns:";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLine.Location = new System.Drawing.Point(11, 236);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(499, 2);
            this.lblLine.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(356, 250);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 21);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(437, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 21);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangeColumns
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 281);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblDispl);
            this.Controls.Add(this.lblAvail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.lbDisplayed);
            this.Controls.Add(this.lbAvailable);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeColumns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Remove Columns";
            this.Load += new System.EventHandler(this.ChangeColumns_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbAvailable;
        private System.Windows.Forms.ListBox lbDisplayed;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Label lblAvail;
        private System.Windows.Forms.Label lblDispl;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}