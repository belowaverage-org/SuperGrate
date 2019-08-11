using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrateInstaller
{
    public class InstallPage : UserControl
    {
        /// <summary>
        /// This event is fired whenever the Next button is pressed.
        /// </summary>
        public event EventHandler OnNext;
        /// <summary>
        /// This event is fired whenever the Previous button is pressed.
        /// </summary>
        public event EventHandler OnPrevious;
        /// <summary>
        /// Invokes the OnNext event for the currently displayed install page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Next(object sender, EventArgs e)
        {
            OnNext.Invoke(sender, e);
        }
        /// <summary>
        /// Invokes the OnPrevious event for the currently displayed install page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Previous(object sender, EventArgs e)
        {
            OnPrevious.Invoke(sender, e);
        }
    }
}
