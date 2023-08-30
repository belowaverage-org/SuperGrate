using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SuperGrate.Controls.Components
{
    public class SGProgressBar : ProgressBar
    {
        private System.Windows.Controls.ProgressBar ProgressBar = new System.Windows.Controls.ProgressBar();
        public SGProgressBar()
        {
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime) return;
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Parent = this;
            host.Child = ProgressBar;
            Misc.ApplyStyles(ProgressBar);
        }
        public new int Value
        {
            get
            {
                return (int)ProgressBar.Value;
            }
            set
            {
                ProgressBar.Value = value;
            }
        }
        public new ProgressBarStyle Style
        {
            get
            {
                if (ProgressBar.IsIndeterminate) return ProgressBarStyle.Marquee;
                return ProgressBarStyle.Continuous;
            }
            set
            {
                ProgressBar.IsIndeterminate = (value == ProgressBarStyle.Marquee);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Misc.ApplyStyles(ProgressBar);
        }
    }
}