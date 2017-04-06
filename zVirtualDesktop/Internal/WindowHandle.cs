using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Win32Interop.WinHandles
{
  /// <summary>
  ///  Small wrapper class to allow extension methods specific to Win32 windows.
  /// </summary>
  public struct WindowHandle
  {
    /// <summary> Constructor. </summary>
    /// <param name="rawPtr"> A raw IntPtr to the Win32 handle. </param>
    public WindowHandle(IntPtr rawPtr)
    {
      RawPtr = rawPtr;
    }

    /// <summary> Represents an invalid window handle. </summary>
    public static WindowHandle Invalid { get; }
      = new WindowHandle(IntPtr.Zero);

    /// <summary> A raw IntPtr to the Win32 handle. </summary>
    public IntPtr RawPtr { get; }

    /// <summary> True if the handle represents a valid Win32 handle. </summary>
    public bool IsValid
      => RawPtr != IntPtr.Zero;
  }
}