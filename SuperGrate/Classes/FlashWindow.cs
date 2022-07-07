using System;
using System.Runtime.InteropServices;

namespace SuperGrate
{
    class FlashWindow
    {
        /// <summary>
        /// Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <param name="pwfi">A pointer to a FLASHWINFO structure.</param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindowEx function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure, in bytes.
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// A handle to the window to be flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The flash status.
            /// </summary>
            public FlashWindowStyle dwFlags;
            /// <summary>
            /// The number of times to flash the window.
            /// </summary>
            public uint uCount;
            /// <summary>
            /// The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.
            /// </summary>
            public uint dwTimeout;
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
        /// <summary>
        /// Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <param name="Handle">A handle to the window to be flashed. The window can be either opened or minimized.</param>
        /// <param name="Flags">The flash status.</param>
        /// <param name="Count">The number of times to flash the window.</param>
        /// <param name="FlashRate">The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.</param>
        /// <returns>True if success.</returns>
        public static bool Start(IntPtr Handle, FlashWindowStyle Flags, uint Count = uint.MaxValue, uint FlashRate = 500)
        {
            try
            {
                FLASHWINFO info = new FLASHWINFO();
                info.cbSize = Convert.ToUInt32(Marshal.SizeOf(info));
                info.hwnd = Handle;
                info.dwFlags = Flags;
                info.uCount = Count;
                info.dwTimeout = FlashRate;
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
