namespace SuperGrate.Controls
{
    partial class License
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
            this.rtbLicense = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLicense
            // 
            this.rtbLicense.BackColor = System.Drawing.Color.White;
            this.rtbLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLicense.HideSelection = false;
            this.rtbLicense.Location = new System.Drawing.Point(0, 0);
            this.rtbLicense.Name = "rtbLicense";
            this.rtbLicense.ReadOnly = true;
            this.rtbLicense.ShowSelectionMargin = true;
            this.rtbLicense.Size = new System.Drawing.Size(512, 496);
            this.rtbLicense.TabIndex = 0;
            this.rtbLicense.Text = "";
            this.rtbLicense.WordWrap = false;
            this.rtbLicense.ZoomFactor = 1.3F;
            this.rtbLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbLicense_LinkClicked);
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 496);
            this.Controls.Add(this.rtbLicense);
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.License_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLicense;
    }
}