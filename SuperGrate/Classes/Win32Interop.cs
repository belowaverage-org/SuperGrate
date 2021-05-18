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
        [DllImport("user32.dll")]
        private static extern bool SetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPosition, [In] ref MENUITEMINFO lpmii);
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
        private static readonly Dictionary<MenuItem, Image> MenuItemIcons = new Dictionary<MenuItem, Image>();
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
            if(MenuItemIcons.ContainsKey(MenuItem))
            {
                MenuItemIcons[MenuItem] = Image;
            }
            else
            {
                MenuItemIcons.Add(MenuItem, Image);
            }
        }
        public static void DrawMenuItemBitmaps(this Menu Menu)
        {
            int miIndexOffset = 0;
            foreach(MenuItem mi in Menu.MenuItems)
            {
                if (!MenuItemIcons.ContainsKey(mi)) continue;
                if (!mi.Visible)
                {
                    miIndexOffset--;
                    continue;
                }
                Image image = MenuItemIcons[mi];
                Bitmap bitmap = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(image, 0, 0, image.Width, image.Height);
                MENUITEMINFO mii = new MENUITEMINFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO)),
                    fMask = 0x80u,
                    hbmpItem = bitmap.GetHbitmap(Color.FromArgb(0, 0, 0, 0))
                };
                SetMenuItemInfo(mi.Parent.Handle, (uint)(mi.Index + miIndexOffset), true, ref mii);
            }
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