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
    public partial class NetworkPage : UserControl
    {
        public NetworkPage()
        {
            InitializeComponent();
            Main.Next.Click += Next_Click;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            
        }
    }
}
