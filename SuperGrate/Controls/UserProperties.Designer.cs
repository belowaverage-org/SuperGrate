namespace SuperGrate.Controls
{
    partial class UserProperties
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
            this.lvProperties = new System.Windows.Forms.ListView();
            this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lvProperties
            // 
            this.lvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKey,
            this.colValue});
            this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProperties.FullRowSelect = true;
            this.lvProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.helpProvider.SetHelpString(this.lvProperties, "A list of properties for the user you double-clicked a moment ago.");
            this.lvProperties.HideSelection = false;
            this.lvProperties.Location = new System.Drawing.Point(0, 0);
            this.lvProperties.Name = "lvProperties";
            this.helpProvider.SetShowHelp(this.lvProperties, true);
            this.lvProperties.Size = new System.Drawing.Size(315, 193);
            this.lvProperties.TabIndex = 0;
            this.lvProperties.UseCompatibleStateImageBehavior = false;
            this.lvProperties.View = System.Windows.Forms.View.Details;
            // 
            // colKey
            // 
            this.colKey.Text = "Property";
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // UserProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 193);
            this.Controls.Add(this.lvProperties);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(187, 232);
            this.Name = "UserProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvProperties;
        private System.Windows.Forms.ColumnHeader colKey;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}