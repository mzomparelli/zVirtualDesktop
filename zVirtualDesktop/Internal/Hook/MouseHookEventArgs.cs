using System;
using System.Windows.Forms;

namespace Microsoft.Win32
{
	/// <summary>
	/// Contains the values passed by the MouseHook to the internal MouseProc,
	/// repackaged as .NET types
	/// </summary>
	public class MouseHookEventArgs
	{
		/// <summary>
		/// The button that is associated with the event
		/// </summary>
		public readonly MouseButtons Button = MouseButtons.None;

		/// <summary>
		/// The X location of the mouse when the event occured
		/// </summary>
		public readonly int X = 0;

		/// <summary>
		/// The Y location of the mouse when the event occured
		/// </summary>
		public readonly int Y = 0;

		/// <summary>
		/// The control that will ultimately receive the hooked message
		/// </summary>
		public readonly Control Control = null;

		/// <summary>
		/// The window area that the mouse is over
		/// </summary>
		public readonly HitTestCode HitTestCode = HitTestCode.HTNOWHERE;

		private bool isNonClientArea = false;

		public MouseHookEventArgs( MouseButtons button, int x, int y, Control control, HitTestCode hitTestCode )
		{
			Button = button;
			X = x;
			Y = y;
			Control = control;
			HitTestCode = hitTestCode;
		}

		/// <summary>
		/// Did the event occur over a non-client area
		/// </summary>
		public bool IsNonClientArea
		{
			get{ return isNonClientArea; }
		}

		internal void SetNonClient(){ isNonClientArea = true; }
	}
}
