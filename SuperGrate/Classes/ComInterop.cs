using System;
using System.Runtime.InteropServices;

namespace SuperGrate.ComInterop
{
    [ComImport, Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
    public class TaskbarList { }
    [ComImport, Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList3
    {
        /// <summary>
        /// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
        /// </summary>
        /// <returns>Returns S_OK if successful, or an error value otherwise. If the method fails, no other methods can be called. The calling application should release the interface pointer.</returns>
        uint HrInit();
        /// <summary>
        /// Do not use
        /// </summary>
        void AddTab();
        /// <summary>
        /// Do not use
        /// </summary>
        void DeleteTab();
        /// <summary>
        /// Do not use
        /// </summary>
        void ActivateTab();
        /// <summary>
        /// Do not use
        /// </summary>
        void SetActiveAlt();
        /// <summary>
        /// Do not use
        /// </summary>
        void MarkFullScreenWindow();
        /// <summary>
        /// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
        /// </summary>
        /// <param name="Handle">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
        /// <param name="Completed">An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.</param>
        /// <param name="Total">An application-defined value that specifies the value ullCompleted will have when the operation is complete.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        uint SetProgressValue(IntPtr Handle, ulong Completed, ulong Total);
        /// <summary>
        /// Sets the type and state of the progress indicator displayed on a taskbar button.
        /// </summary>
        /// <param name="Handle">The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.</param>
        /// <param name="Flags">Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        uint SetProgressState(IntPtr Handle, TBPFlags Flags);
    }
    /// <summary>
    /// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.
    /// </summary>
    public enum TBPFlags
    {
        /// <summary>
        /// Stops displaying progress and returns the button to its normal state. Call this method with this flag to dismiss the progress bar when the operation is complete or canceled.
        /// </summary>
        TBPF_NOPROGRESS = 0,
        /// <summary>
        /// The progress indicator does not grow in size, but cycles repeatedly along the length of the taskbar button. This indicates activity without specifying what proportion of the progress is complete. Progress is taking place, but there is no prediction as to how long the operation will take.
        /// </summary>
        TBPF_INDETERMINATE = 0x1,
        /// <summary>
        /// The progress indicator grows in size from left to right in proportion to the estimated amount of the operation completed. This is a determinate progress indicator; a prediction is being made as to the duration of the operation.
        /// </summary>
        TBPF_NORMAL = 0x2,
        /// <summary>
        /// The progress indicator turns red to show that an error has occurred in one of the windows that is broadcasting progress. This is a determinate state. If the progress indicator is in the indeterminate state, it switches to a red determinate display of a generic percentage not indicative of actual progress.
        /// </summary>
        TBPF_ERROR = 0x4,
        /// <summary>
        /// The progress indicator turns yellow to show that progress is currently stopped in one of the windows but can be resumed by the user. No error condition exists and nothing is preventing the progress from continuing. This is a determinate state. If the progress indicator is in the indeterminate state, it switches to a yellow determinate display of a generic percentage not indicative of actual progress.
        /// </summary>
        TBPF_PAUSED = 0x8
    }
}