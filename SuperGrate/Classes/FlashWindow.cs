using System;
using System.Runtime.InteropServices;

namespace SuperGrate
{
    class FlashWindow
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public enum FlashWindowStyle : uint
        {
            /// <summary>
            /// Stop flashing. The system restores the window to its original state.
            /// </summary>    
            FLASHW_STOP = 0,
            /// <summary>
            /// Flash the window caption
            /// </summary>
            FLASHW_CAPTION = 1,
            /// <summary>
            /// Flash the taskbar button.
            /// </summary>
            FLASHW_TRAY = 2,
            /// <summary>
            /// Flash both the window caption and taskbar button.
            /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
            /// </summary>
            FLASHW_ALL = 3,
            /// <summary>
            /// Flash continuously, until the FLASHW_STOP flag is set.
            /// </summary>
            FLASHW_TIMER = 4,
            /// <summary>
            /// Flash continuously until the window comes to the foreground.
            /// </summary>
            FLASHW_TIMERNOFG = 12
        }
        public static bool Start(IntPtr Handle, FlashWindowStyle Flags, UInt32 Count = UInt32.MaxValue, UInt32 Timeout = 0)
        {
            try
            {
                FLASHWINFO info = new FLASHWINFO();
                info.cbSize = Convert.ToUInt32(Marshal.SizeOf(info));
                info.hwnd = Handle;
                info.dwFlags = (uint)Flags;
                info.uCount = Count;
                info.dwTimeout = Timeout;
                FlashWindowEx(ref info);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
