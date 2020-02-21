using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace SuperGrate
{
    static class Win32Interop
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);
        [DllImport("user32.dll")]
        private static extern bool SetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPosition, [In] ref MENUITEMINFO lpmii);
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
        public static void SetMenuItemBitmap(this MenuItem MenuItem, Image Image)
        {
            Bitmap bitmap = new Bitmap(Image.Width, Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(Image, 0, 0, Image.Width, Image.Height);
            MENUITEMINFO mii = new MENUITEMINFO();
            mii.cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO));
            mii.fMask = 0x80u;
            mii.hbmpItem = bitmap.GetHbitmap(Color.FromArgb(0,0,0,0));
            SetMenuItemInfo(MenuItem.Parent.Handle, (uint)MenuItem.Index, true, ref mii);
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
        [StructLayout(LayoutKind.Sequential)]
        private struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;
        }
        [Flags]
        private enum MIIM
        {
            BITMAP = 0x00000080
        }
    }
}