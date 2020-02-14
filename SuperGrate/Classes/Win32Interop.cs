using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

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
        private static Dictionary<IntPtr, IntPtr[]> MenuItemIcons = new Dictionary<IntPtr, IntPtr[]>();
        /// <summary>
        /// Sets an icon on a button with the FlatStyle set to System.
        /// </summary>
        /// <param name="Button">Button Object</param>
        /// <param name="Icon">Icon Object</param>
        public static void SetSystemIcon(this Button Button, Icon Icon, int Width = 16, int Height = 16)
        {
            SendMessage(Button.Handle, 0xf7, (IntPtr)1, new Icon(Icon, Width, Height).Handle);
        }
        public static void SetMenuItemIcon(this MenuItem MenuItem, Icon Icon)
        {
            IntPtr[] hBitmaps =
            {
                Icon.ToBitmapAlpha(16, 16, SystemColors.Control).GetHbitmap(),
                Icon.ToBitmapAlpha(16, 16, SystemColors.GrayText).GetHbitmap()
            };
            //SetMenuItemBitmaps(MenuItem.Parent.Handle, (IntPtr)MenuItem.Index, 0x400, hBitmap, hBitmap);
            MenuItemIcons.Add(MenuItem.Handle, hBitmaps);
            //MenuItem.Select += MenuItem_Select;
            //MenuItem.MeasureItem += MenuItem_MeasureItem;
            
        }

        private static void MenuItem_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            SetMenuItemBitmaps(mi.Parent.Handle, (IntPtr)mi.Index, 0x400, MenuItemIcons[mi.Handle][0], MenuItemIcons[mi.Handle][0]);
        }

        private static void MenuItem_Select(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            SetMenuItemBitmaps(mi.Parent.Handle, (IntPtr)mi.Index, 0x400, MenuItemIcons[mi.Handle][1], MenuItemIcons[mi.Handle][1]);
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