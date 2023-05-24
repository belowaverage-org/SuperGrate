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
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
            Multiline = true;
            host.Parent = this;
            host.Child = TextBox;
            TextBox.TextChanged += TextBox_TextChanged;
            Misc.ApplyStyles(TextBox);
        }
        public override string Text { get => TextBox.Text; set => TextBox.Text = value; }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e);
        }
    }
}