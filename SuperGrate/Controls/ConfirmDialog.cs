using System.Drawing;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(string DialogTitle, string DialogDescription = null, Icon DialogIcon = null)
        {
            InitializeComponent();
            btnAccept.SetSystemIcon(Properties.Resources.check);
            btnCancel.SetSystemIcon(Properties.Resources.cancel);
            if (DialogDescription == null) DialogDescription = DialogTitle;
            if (DialogIcon == null)
            {
                Icon = Properties.Resources.question;
                pbIcon.Image = Properties.Resources.question_32.ToBitmapAlpha(32, 32);
            }
            else
            {
                Icon = DialogIcon;
                pbIcon.Image = DialogIcon.ToBitmapAlpha(32, 32);
            }
            Text = DialogTitle;
            lblDescription.Text = DialogDescription;
        }
    }
}