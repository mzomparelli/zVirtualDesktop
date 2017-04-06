using System;
using System.Collections.Generic;
using System.Linq;
using Win32Interop.WinHandles.Internal;

namespace Win32Interop.WinHandles
{
  /// <summary>
  ///  Utilities for operating on windows that are top-level on the screen.
  /// </summary>
  public static class TopLevelWindowUtils
  {
    /// <summary> Gets the WindowHandle to the current foreground window. </summary>
    /// <returns> The foreground window. </returns>
    public static WindowHandle GetForegroundWindow()
    {
      var ptr = NativeMethods.GetForegroundWindow();
      return new WindowHandle(ptr);
    }

    /// <summary> Finds all the windows that match the given predicate. </summary>
    /// <exception cref="ArgumentNullException"> Thrown when one or more required
    ///  arguments are null. </exception>
    /// <param name="windowPredicate"> A predicate which determines if the given
    ///  window should be included in the collection returned. </param>
    /// <returns> A collection of windows that passed the predicate. </returns>
    public static IEnumerable<WindowHandle> FindWindows(Predicate<WindowHandle> windowPredicate)
    {
      if (windowPredicate == null)
        throw new ArgumentNullException(nameof(windowPredicate));

      List<WindowHandle> windows = null;

      NativeMethods.EnumWindows((ptr, param) =>
                                {
                                  var window = new WindowHandle(ptr);
                                  if (windowPredicate.Invoke(window))
                                  {
                                    if (windows == null)
                                    {
                                      windows = new List<WindowHandle>();
                                    }

                                    windows.Add(window);
                                  }

                                  return NativeMethods.EnumWindows_ContinueEnumerating;
                                },
                                IntPtr.Zero);

      // ReSharper disable once AssignNullToNotNullAttribute
      return windows ?? Enumerable.Empty<WindowHandle>();
    }

    /// <summary>
    ///  Searches for the first window that matches the predicate.
    /// </summary>
    /// <exception cref="ArgumentNullException"> Thrown when one or more required
    ///  arguments are null. </exception>
    /// <param name="callback"> The search criteria for the window.  Return true
    ///  when the window has been found. </param>
    /// <returns>
    ///  The window handle for which callback() returned true, or
    ///  <see cref="WindowHandle.Invalid"/> if callback() never returned true.
    /// </returns>
    public static WindowHandle FindWindow(Predicate<WindowHandle> callback)
    {
      if (callback == null)
        throw new ArgumentNullException(nameof(callback));

      WindowHandle found = WindowHandle.Invalid;
      NativeMethods.EnumWindows(delegate(IntPtr wnd, IntPtr param)
                                {
                                  var window = new WindowHandle(wnd);
                                  if (callback.Invoke(window))
                                  {
                                    found = window;
                                    return NativeMethods.EnumWindows_StopEnumerating;
                                  }

                                  return NativeMethods.EnumWindows_ContinueEnumerating;
                                },
                                IntPtr.Zero);

      return found;
    }
  }
}