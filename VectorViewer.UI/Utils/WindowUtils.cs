namespace VectorViewer.UI.Utils
{
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using Model.Positions;
    using Native;

    public static class WindowUtils
    {
        public static Position GetAbsolutePosition(this Window window)
        {
            if (window.WindowState != WindowState.Maximized)
                return new Position(window.Left, window.Top, window.Left + window.Width, window.Top - window.Height);

            var multiMonitorSupported = OsInterop.GetSystemMetrics(OsInterop.SmCmonitors) != 0;
            if (!multiMonitorSupported)
            {
                var rectangle = new OsInterop.Rect();
                OsInterop.SystemParametersInfo(48, 0, ref rectangle, 0);
                return new Position(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }

            var interopHelper = new WindowInteropHelper(window);
            var monitor = OsInterop.MonitorFromWindow(new HandleRef(null, interopHelper.EnsureHandle()), 2);
            var info = new OsInterop.MonitorInfoEx();
            OsInterop.GetMonitorInfo(new HandleRef(null, monitor), info);
            return new Position(info.rcWork.Left, info.rcWork.Top, info.rcWork.Right, info.rcWork.Bottom);
        }
    }
}