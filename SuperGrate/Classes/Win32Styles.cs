using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SuperGrate
{
    static class Win32Styles
    {
        /// <summary>
        /// Sets a bitmap on a Menu's menu item.
        /// </summary>
        /// <param name="hMenu">Menu handle.</param>
        /// <param name="nPosition">Menu item position.</param>
        /// <param name="wFlags">Should be 0x00000400L for zero position based.</param>
        /// <param name="hBitmapUnchecked">"Unchecked" bitmap to display.</param>
        /// <param name="hBitmapChecked">"Checked" bitmap to display.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetMenuItemBitmaps(IntPtr hMenu, IntPtr nPosition, int wFlags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Sets an icon on a button with the FlatStyle set to System.
        /// </summary>
        /// <param name="Button">Button Object</param>
        /// <param name="Icon">Icon Object</param>
        public static void SetSystemIcon(this Button Button, Icon Icon)
        {
            SendMessage(Button.Handle, 0xf7, (IntPtr)1, Icon.Handle);
        }
    }
}