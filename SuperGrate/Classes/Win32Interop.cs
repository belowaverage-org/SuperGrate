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
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="wMsg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc">A handle to the device context into which the icon or cursor will be drawn.</param>
        /// <param name="xLeft">The logical x-coordinate of the upper-left corner of the icon or cursor.</param>
        /// <param name="yTop">The logical y-coordinate of the upper-left corner of the icon or cursor.</param>
        /// <param name="hIcon">A handle to the icon or cursor to be drawn. This parameter can identify an animated cursor.</param>
        /// <param name="cxWidth">The logical width of the icon or cursor. If this parameter is zero and the diFlags parameter is DI_DEFAULTSIZE, the function uses the SM_CXICON system metric value to set the width. If this parameter is zero and DI_DEFAULTSIZE is not used, the function uses the actual resource width.</param>
        /// <param name="cyHeight">The logical height of the icon or cursor. If this parameter is zero and the diFlags parameter is DI_DEFAULTSIZE, the function uses the SM_CYICON system metric value to set the width. If this parameter is zero and DI_DEFAULTSIZE is not used, the function uses the actual resource height.</param>
        /// <param name="istepIfAniCur">The index of the frame to draw, if hIcon identifies an animated cursor. This parameter is ignored if hIcon does not identify an animated cursor.</param>
        /// <param name="hbrFlickerFreeDraw">A handle to a brush that the system uses for flicker-free drawing. If hbrFlickerFreeDraw is a valid brush handle, the system creates an offscreen bitmap using the specified brush for the background color, draws the icon or cursor into the bitmap, and then copies the bitmap into the device context identified by hdc. If hbrFlickerFreeDraw is NULL, the system draws the icon or cursor directly into the device context.</param>
        /// <param name="diFlags">The drawing flags. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);
        /// <summary>
        /// The color of the brush. To create a COLORREF color value, use the RGB macro.
        /// </summary>
        /// <param name="crColor">The color of the brush. To create a COLORREF color value, use the RGB macro.</param>
        /// <returns>If the function succeeds, the return value identifies a logical brush. If the function fails, the return value is NULL.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);
        /// <summary>
        /// Changes information about a menu item.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item.</param>
        /// <param name="uItem">The identifier or position of the menu item to change. The meaning of this parameter depends on the value of fByPosition.</param>
        /// <param name="lpmii">A pointer to a MENUITEMINFO structure that contains information about the menu item and specifies which menu item attributes to change.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
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
        /// <summary>
        /// Sets bitmap to a menu item object.
        /// </summary>
        /// <param name="MenuItem">Menu item object.</param>
        /// <param name="Image">Image to use.</param>
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
        /// <summary>
        /// Adds the icons from MenuItemIcons to the selected menu.
        /// </summary>
        /// <param name="Menu">Menu to apply icons to.</param>
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
        /// <summary>
        /// Converts an icon to a transparent bitmap.
        /// </summary>
        /// <param name="Icon">Icon to convert.</param>
        /// <param name="Width">New width.</param>
        /// <param name="Height">New height.</param>
        /// <param name="Background">New background color.</param>
        /// <returns>A bitmap.</returns>
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
        /// <summary>
        /// Converts an icon to a transparent bitmap.
        /// </summary>
        /// <param name="Icon">Icon to convert.</param>
        /// <param name="Width">New width.</param>
        /// <param name="Height">New height.</param>
        /// <returns>A bitmap.</returns>
        public static Bitmap ToBitmapAlpha(this Icon Icon, int Width, int Height)
        {
            return ToBitmapAlpha(Icon, Width, Height, Color.White);
        }
    }
}