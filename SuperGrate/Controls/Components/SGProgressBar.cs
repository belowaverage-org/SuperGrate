using System;
using System.Windows.Forms;

namespace SuperGrate.Controls.Components
{
    public class SGProgressBar : ProgressBar
    {
        private IntPtr HDC;

        /// <summary>
        /// Position to use to draw the text.
        /// </summary>
        private Win32Interop.RECT RECT = new Win32Interop.RECT() { 
            Top = 8,
            Left = 6
        };
        /// <summary>
        /// Draws specified text over the ProgressBar control.
        /// </summary>
        /// <param name="Text">Text to draw.</param>
        private void DrawText(string Text)
        {
            Win32Interop.DrawText(HDC, Text, -1, RECT, Win32Interop.DTFormat.DT_NOCLIP | Win32Interop.DTFormat.DT_BOTTOM);
        }
        /// <summary>
        /// WndProc Override. Drawing text over top existing ProgressBar control.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 1)
            {
                HDC = Win32Interop.GetDC(Handle);
                Win32Interop.SetBkMode(HDC, Win32Interop.BkMode.Transparent);
                IntPtr sfo = Win32Interop.GetStockObject(Win32Interop.StockLogicalObjects.ANSI_VAR_FONT);
                Win32Interop.SelectObject(HDC, sfo);
            }
            if (m.Msg == 15)
            {
                if (Style == ProgressBarStyle.Marquee)
                {
                    //DrawText("Working...");
                    return;
                }
                if (Value == 100 || Value == 0) return;
                DrawText((((float)Value / (float)Maximum) * 100).ToString() + "%");
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}