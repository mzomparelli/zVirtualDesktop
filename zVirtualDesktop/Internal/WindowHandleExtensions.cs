using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Win32Interop.WinHandles.Internal;

namespace Win32Interop.WinHandles
{
  /// <summary> Extension methods for <see cref="WindowHandle"/> </summary>
  public static class WindowHandleExtensions
  {
    /// <summary> Check if the given window handle is currently visible. </summary>
    /// <param name="windowHandle"> The window to act on. </param>
    /// <returns> true if the window is visible, false if not. </returns>
    public static bool IsVisible(this WindowHandle windowHandle)
    {
      return NativeMethods.IsWindowVisible(windowHandle.RawPtr);
    }

    /// <summary> Gets the Win32 class name of the given window. </summary>
    /// <param name="windowHandle"> The window handle to act on. </param>
    /// <returns> The class name of the passed in window. </returns>
    public static string GetClassName(this WindowHandle windowHandle)
    {
      int size = 255;
      int actualSize = 0;
      StringBuilder builder;
      do
      {
        builder = new StringBuilder(size);
        actualSize = NativeMethods.GetClassName(windowHandle.RawPtr, builder, builder.Capacity);
        size *= 2;
      } while (actualSize == size - 1);

      return builder.ToString();
    }

    /// <summary> Gets the text associated with the given window handle. </summary>
    /// <param name="windowHandle"> The window handle to act on. </param>
    /// <returns> The window text. </returns>
    public static string GetWindowText(this WindowHandle windowHandle)
    {
      int size = NativeMethods.GetWindowTextLength(windowHandle.RawPtr);
      if (size > 0)
      {
        var builder = new StringBuilder(size + 1);
        NativeMethods.GetWindowText(windowHandle.RawPtr, builder, builder.Capacity);
        return builder.ToString();
      }

      return String.Empty;
    }
  }
}