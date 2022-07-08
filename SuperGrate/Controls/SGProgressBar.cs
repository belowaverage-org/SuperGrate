using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public class SGProgressBar : ProgressBar
    {
        private IntPtr HDC;
        private Win32Interop.RECT RECT = new Win32Interop.RECT() { 
            Top = 10,
            Left = 10
        };
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 1)
            {
                HDC = Win32Interop.GetDC(Handle);
                Win32Interop.SetBkMode(HDC, Win32Interop.BkMode.Transparent);
            }
            if (m.Msg == 15)
            {
                Win32Interop.DrawText(HDC, (((float)Value / (float)Maximum) * 100).ToString() + "%", -1, RECT, Win32Interop.DTFormat.DT_NOCLIP | Win32Interop.DTFormat.DT_BOTTOM);  
            }
        }
    }
}