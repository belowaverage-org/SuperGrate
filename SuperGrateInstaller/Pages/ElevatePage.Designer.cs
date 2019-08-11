namespace SuperGrateInstaller.Pages
{
    partial class ElevatePage
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
            this.btnElevate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnElevate
            // 
            this.btnElevate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnElevate.Location = new System.Drawing.Point(45, 28);
            this.btnElevate.Name = "btnElevate";
            this.btnElevate.Size = new System.Drawing.Size(144, 41);
            this.btnElevate.TabIndex = 0;
            this.btnElevate.Text = "Elevate";
            // 
            // ElevatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnElevate);
            this.Name = "ElevatePage";
            this.Size = new System.Drawing.Size(231, 99);
            this.Load += new System.EventHandler(this.ElevatePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnElevate;
    }
}
