namespace SuperGrateInstaller.Controls
{
    partial class InitialPage
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
            this.lblGreet = new System.Windows.Forms.Label();
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.rbSolUpgrade = new System.Windows.Forms.RadioButton();
            this.rbSolLocalComputer = new System.Windows.Forms.RadioButton();
            this.rbSolNetworkShare = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSolDescription = new System.Windows.Forms.Label();
            this.gbSolution.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGreet
            // 
            this.lblGreet.Location = new System.Drawing.Point(19, 12);
            this.lblGreet.Name = "lblGreet";
            this.lblGreet.Size = new System.Drawing.Size(368, 54);
            this.lblGreet.TabIndex = 0;
            this.lblGreet.Text = "Welcome to the Super Grate Installer!\r\n\r\nPlease choose how you would like to inst" +
    "all Super Grate:";
            // 
            // gbSolution
            // 
            this.gbSolution.Controls.Add(this.rbSolUpgrade);
            this.gbSolution.Controls.Add(this.rbSolLocalComputer);
            this.gbSolution.Controls.Add(this.rbSolNetworkShare);
            this.gbSolution.Location = new System.Drawing.Point(22, 70);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Size = new System.Drawing.Size(551, 79);
            this.gbSolution.TabIndex = 1;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Install Solution";
            // 
            // rbSolUpgrade
            // 
            this.rbSolUpgrade.AutoSize = true;
            this.rbSolUpgrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSolUpgrade.Location = new System.Drawing.Point(428, 35);
            this.rbSolUpgrade.Name = "rbSolUpgrade";
            this.rbSolUpgrade.Size = new System.Drawing.Size(76, 20);
            this.rbSolUpgrade.TabIndex = 2;
            this.rbSolUpgrade.TabStop = true;
            this.rbSolUpgrade.Text = "Upgrade";
            this.rbSolUpgrade.UseVisualStyleBackColor = true;
            // 
            // rbSolLocalComputer
            // 
            this.rbSolLocalComputer.AutoSize = true;
            this.rbSolLocalComputer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSolLocalComputer.Location = new System.Drawing.Point(224, 35);
            this.rbSolLocalComputer.Name = "rbSolLocalComputer";
            this.rbSolLocalComputer.Size = new System.Drawing.Size(113, 20);
            this.rbSolLocalComputer.TabIndex = 1;
            this.rbSolLocalComputer.TabStop = true;
            this.rbSolLocalComputer.Text = "Local Computer";
            this.rbSolLocalComputer.UseVisualStyleBackColor = true;
            // 
            // rbSolNetworkShare
            // 
            this.rbSolNetworkShare.AutoSize = true;
            this.rbSolNetworkShare.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSolNetworkShare.Location = new System.Drawing.Point(29, 35);
            this.rbSolNetworkShare.Name = "rbSolNetworkShare";
            this.rbSolNetworkShare.Size = new System.Drawing.Size(107, 20);
            this.rbSolNetworkShare.TabIndex = 0;
            this.rbSolNetworkShare.TabStop = true;
            this.rbSolNetworkShare.Text = "Network Share";
            this.rbSolNetworkShare.UseVisualStyleBackColor = true;
            this.rbSolNetworkShare.CheckedChanged += new System.EventHandler(this.RbSolNetworkShare_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSolDescription);
            this.groupBox1.Location = new System.Drawing.Point(22, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(551, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solution Description";
            // 
            // lbSolDescription
            // 
            this.lbSolDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSolDescription.Location = new System.Drawing.Point(7, 19);
            this.lbSolDescription.Name = "lbSolDescription";
            this.lbSolDescription.Size = new System.Drawing.Size(541, 53);
            this.lbSolDescription.TabIndex = 0;
            this.lbSolDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InitialPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSolution);
            this.Controls.Add(this.lblGreet);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InitialPage";
            this.Size = new System.Drawing.Size(600, 250);
            this.gbSolution.ResumeLayout(false);
            this.gbSolution.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGreet;
        private System.Windows.Forms.GroupBox gbSolution;
        private System.Windows.Forms.RadioButton rbSolUpgrade;
        private System.Windows.Forms.RadioButton rbSolLocalComputer;
        private System.Windows.Forms.RadioButton rbSolNetworkShare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbSolDescription;
    }
}
