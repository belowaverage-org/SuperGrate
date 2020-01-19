using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SuperGrate
{
    static class Win32Interop
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
        private static extern int SetMenuItemBitmaps(IntPtr hMenu, IntPtr nPosition, int wFlags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);
        /// <summary>
        /// Sets an icon on a button with the FlatStyle set to System.
        /// </summary>
        /// <param name="Button">Button Object</param>
        /// <param name="Icon">Icon Object</param>
        public static void SetSystemIcon(this Button Button, Icon Icon)
        {
            SendMessage(Button.Handle, 0xf7, (IntPtr)1, Icon.Handle);
        }
        public static void SetMenuItemIcon(this MenuItem MenuItem, Icon Icon)
        {
            IntPtr hBitmap = Icon.ToBitmapAlpha(16, 16, SystemColors.Control).GetHbitmap();
            SetMenuItemBitmaps(MenuItem.Parent.Handle, (IntPtr)MenuItem.Index, 0x400, hBitmap, hBitmap);
        }
        public static Bitmap ToBitmapAlpha(this Icon Icon, int Width, int Height, Color Background)
        {
            Icon rsIcon = new Icon(Icon, Width, Height);
            Bitmap bmIcon = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmIcon);
            IntPtr hdc = g.GetHdc();
            DrawIconEx(hdc, 0, 0, rsIcon.Handle, Width, Height, 0, CreateSolidBrush((uint)ColorTranslator.ToWin32(Background)), 0x3);
            g.ReleaseHdc(hdc);
            return bmIcon;
        }
        public static Bitmap ToBitmapAlpha(this Icon Icon, int Width, int Height)
        {
            return ToBitmapAlpha(Icon, Width, Height, Color.White);
        }
    }
}