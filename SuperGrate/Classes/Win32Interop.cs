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
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        /// </summary>
        /// <param name="hwnd">The handle to the window for which the attribute value is to be set.</param>
        /// <param name="dwAttribute">A flag describing which value to set, specified as a value of the DWMWINDOWATTRIBUTE enumeration.</param>
        /// <param name="pvAttribute">A pointer to an object containing the attribute value to set.</param>
        /// <param name="cbAttribute">The size, in bytes, of the attribute value being set via the pvAttribute parameter.</param>
        /// <returns>If the function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern uint DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] IntPtr pvAttribute, uint cbAttribute);
        /// <summary>
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="Object">A handle to the object to be selected.</param>
        /// <returns>If an error occurs and the selected object is not a region, the return value is NULL.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr Object);
        /// <summary>
        /// The GetStockObject function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
        /// </summary>
        /// <returns>If the function fails, the return value is NULL.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr GetStockObject(StockLogicalObjects Object);
        /// <summary>
        /// The SetBkMode function sets the background mix mode of the specified device context.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="Mode">The background mode.</param>
        /// <returns>If the function fails, the return value is zero.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, BkMode Mode);
        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>If the function succeeds, the return value is a handle to the DC for the specified window's client area.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// The DrawText function draws formatted text in the specified rectangle. It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="Text">A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated.</param>
        /// <param name="Length">The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawText computes the character count automatically.</param>
        /// <param name="Rectangle">A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.</param>
        /// <param name="Format">The method of formatting the text.</param>
        /// <returns>If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern int DrawText(IntPtr hdc, string Text, int Length, RECT Rectangle, DTFormat Format);
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
        /// <summary>
        /// Contains information about a menu item.
        /// </summary>
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
        /// <summary>
        /// The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        /// <summary>
        /// The background mode. This parameter can be one of the following values.
        /// </summary>
        public enum BkMode
        {
            Opaque = 0,
            Transparent = 1
        }
        public enum StockLogicalObjects
        {
            OEM_FIXED_FONT = 10,
            ANSI_FIXED_FONT = 11,
            ANSI_VAR_FONT = 12,
            SYSTEM_FONT = 13,
            DEVICE_DEFAULT_FONT = 14,
            SYSTEM_FIXED_FONT = 16
        }
        /// <summary>
        /// DrawText() Format Flags
        /// </summary>
        public enum DTFormat
        {
            DT_TOP = 0x00000000,
            DT_LEFT = 0x00000000,
            DT_CENTER = 0x00000001,
            DT_RIGHT = 0x00000002,
            DT_VCENTER = 0x00000004,
            DT_BOTTOM = 0x00000008,
            DT_WORDBREAK = 0x00000010,
            DT_SINGLELINE = 0x00000020,
            DT_EXPANDTABS = 0x00000040,
            DT_TABSTOP = 0x00000080,
            DT_NOCLIP = 0x00000100,
            DT_EXTERNALLEADING = 0x00000200,
            DT_CALCRECT = 0x00000400,
            DT_NOPREFIX = 0x00000800,
            DT_INTERNAL = 0x00001000
        }
        /// <summary>
        /// DwmSetWindowAttribute() Flags
        /// </summary>
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_NCRENDERING_ENABLED,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_PASSIVE_UPDATE_MODE,
            DWMWA_USE_HOSTBACKDROPBRUSH,
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            DWMWA_BORDER_COLOR,
            DWMWA_CAPTION_COLOR,
            DWMWA_TEXT_COLOR,
            DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
            DWMWA_SYSTEMBACKDROP_TYPE,
            DWMWA_LAST
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