using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrateInstaller.Controls
{
    public partial class InitialPage : UserControl
    {
        public InitialPage()
        {
            InitializeComponent();
        }

        private void RbSolNetworkShare_CheckedChanged(object sender, EventArgs e)
        {
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will be placed in a network share so all Super Grate users will have a consistent experience.";
        }
    }
}
