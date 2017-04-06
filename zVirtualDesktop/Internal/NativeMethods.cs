using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win32Interop.WinHandles.Internal
{
  internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

  /// <summary> Win32 methods. </summary>
  internal static class NativeMethods
  {
    public const bool EnumWindows_ContinueEnumerating = true;
    public const bool EnumWindows_StopEnumerating = false;

    [DllImport("user32.dll")]
    public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

    [DllImport("user32.dll")]
    internal static extern IntPtr FindWindow(string sClassName, string sAppName);

    [DllImport("user32.dll")]
    internal static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    internal static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    internal static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    internal static extern int GetClassName(IntPtr hWnd,
                                            StringBuilder lpClassName,
                                            int nMaxCount);
  }
}