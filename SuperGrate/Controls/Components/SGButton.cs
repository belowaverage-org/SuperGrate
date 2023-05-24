using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SuperGrate.Controls.Components
{
    public class SGButton : System.Windows.Forms.Button
    {
        [Browsable(true)]
        public string Icon { get; set; }
        private System.Windows.Controls.Button Button = new System.Windows.Controls.Button();
        public SGButton()
        {
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Parent = this;
            host.Child = Button;
            Button.Click += Button_Click;
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Runtime) Button.Loaded += Button_Loaded;
            Misc.ApplyStyles(Button);
        }
        private void Button_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((System.Windows.Controls.Label)Button.Template.FindName("BtnIcon", Button)).Content = Icon;
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.OnClick(e);
        }
        public override string Text { 
            get => (string)Button.Content;
            set => Button.Content = value;
        }
    }
}