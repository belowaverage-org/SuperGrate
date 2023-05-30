using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SuperGrate.Controls.Components
{
    public class SGTextBox : System.Windows.Forms.TextBox
    {
        private System.Windows.Controls.TextBox TextBox = new System.Windows.Controls.TextBox();
        public SGTextBox()
        {
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime) return;
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
            Multiline = true;
            host.Parent = this;
            host.Child = TextBox;
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.KeyDown += TextBox_KeyDown;
            Misc.ApplyStyles(TextBox);
        }
        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
                OnKeyDown(kea);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e);
        }
        public override string Text
        {
            get => TextBox.Text;
            set
            {
                base.Text = value;
                TextBox.Text = value;
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            TextBox.Focus();
        }
    }
}