using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	// CBT hook actions
	public enum CbtHookAction : int
	{
		HCBT_MOVESIZE = 0,
		HCBT_MINMAX = 1,
		HCBT_QS = 2,
		HCBT_CREATEWND = 3,
		HCBT_DESTROYWND = 4,
		HCBT_ACTIVATE = 5,
		HCBT_CLICKSKIPPED = 6,
		HCBT_KEYSKIPPED = 7,
		HCBT_SYSCOMMAND = 8,
		HCBT_SETFOCUS = 9
	}

	public class CbtEventArgs : EventArgs
	{
		public IntPtr Handle;        // Win32 handle of the window
		public string Title;         // caption of the window
		public string ClassName;     // class of the window
		public bool IsDialogWindow;  // whether it's a popup dialog
	}

	public class LocalCbtHook : LocalWindowsHook
	{
		// **************************************************************
		// Event delegate
        
		public delegate void CbtEventHandler(object sender, 
			CbtEventArgs e);
		// **************************************************************
       
		// **************************************************************
		// Events
        
		public event CbtEventHandler WindowCreated;
		public event CbtEventHandler WindowDestroyed;
		public event CbtEventHandler WindowActivated;
		// **************************************************************

		// **************************************************************
		// Internal properties
        
		protected IntPtr m_hwnd = IntPtr.Zero;
		protected string m_title = "";
		protected string m_class = "";
		protected bool m_isDialog = false;
		// **************************************************************

		// **************************************************************
		// Class constructor(s)
        
		public LocalCbtHook() : base(HookType.WH_CBT)
		{
			this.HookInvoked += new HookEventHandler(CbtHookInvoked);
		}
        
		public LocalCbtHook(HookProc func) : base(HookType.WH_CBT, func)
		{
			this.HookInvoked += new HookEventHandler(CbtHookInvoked);
		}       
		// **************************************************************

		// **************************************************************
		// Handles the hook event
        
		private void CbtHookInvoked(object sender, HookEventArgs e)
		{
			CbtHookAction code = (CbtHookAction) e.HookCode;
			IntPtr wParam = e.wParam;
			IntPtr lParam = e.lParam;

			// Handle hook events (only a few of available actions)
            
			switch (code)
			{
				case CbtHookAction.HCBT_CREATEWND:
					HandleCreateWndEvent(wParam, lParam);
					break;
                
				case CbtHookAction.HCBT_DESTROYWND:
					HandleDestroyWndEvent(wParam, lParam);
					break;
                
				case CbtHookAction.HCBT_ACTIVATE:
					HandleActivateEvent(wParam, lParam);
					break;
			}
           
			return;
		}
		// **************************************************************

		// **************************************************************
		// Handle the CREATEWND hook event
        
		private void HandleCreateWndEvent(IntPtr wParam, IntPtr lParam)
		{
			// Cache some information
            
			UpdateWindowData(wParam);

			// raise event
            
			OnWindowCreated();
		}
		// **************************************************************

		// **************************************************************
		// Handle the DESTROYWND hook event
        
		private void HandleDestroyWndEvent(IntPtr wParam, IntPtr lParam)
		{
			// Cache some information
			UpdateWindowData(wParam);

			// raise event
			OnWindowDestroyed();
		}
		// **************************************************************

		// **************************************************************
		// Handle the ACTIVATE hook event
        
		private void HandleActivateEvent(IntPtr wParam, IntPtr lParam)
		{
			// Cache some information
			UpdateWindowData(wParam);

			// raise event
			OnWindowActivated();
		}
		// **************************************************************
   
		// **************************************************************
		// Read and store some information about the window
        
		private void UpdateWindowData(IntPtr wParam)
		{
			// Cache the window handle
			m_hwnd = wParam;

			// Cache the window's class name
			StringBuilder sb1 = new StringBuilder();
			sb1.Capacity = 40;
			GetClassName(m_hwnd, sb1, 40);
			m_class = sb1.ToString();

			// Cache the window's title bar
			StringBuilder sb2 = new StringBuilder();
			sb2.Capacity = 256;
			GetWindowText(m_hwnd, sb2, 256);
			m_title = sb2.ToString();

			// Cache the dialog flag
			m_isDialog = (m_class == "#32770");
		}
		// **************************************************************

		// **************************************************************
		// Helper functions that fire events by executing user code
        
		protected virtual void OnWindowCreated()
		{
			if (WindowCreated != null)
			{
				CbtEventArgs e = new CbtEventArgs();
				PrepareEventData(e);
				WindowCreated(this, e);
			}
		}
        
		protected virtual void OnWindowDestroyed()
		{
			if (WindowDestroyed != null)
			{
				CbtEventArgs e = new CbtEventArgs();
				PrepareEventData(e);
				WindowDestroyed(this, e);
			}
		}
        
		protected virtual void OnWindowActivated()
		{
			if (WindowActivated != null)
			{
				CbtEventArgs e = new CbtEventArgs();
				PrepareEventData(e);
				WindowActivated(this, e);
			}
		}
		// **************************************************************

		// **************************************************************
		// Prepare the event data structure
        
		private void PrepareEventData(CbtEventArgs e)
		{
			e.Handle = m_hwnd;
			e.Title = m_title;
			e.ClassName = m_class;
			e.IsDialogWindow = m_isDialog;
		}
		// **************************************************************

		// **************************************************************
		// Win32: GetClassName
        
		[DllImport("user32.dll")]
		protected static extern int GetClassName(IntPtr hwnd,
			StringBuilder lpClassName, int nMaxCount);
		// **************************************************************

		// **************************************************************
		// Win32: GetWindowText
        
		[DllImport("user32.dll")]
		protected static extern int GetWindowText(IntPtr hwnd,
			StringBuilder lpString, int nMaxCount);
		// **************************************************************
	}
}

