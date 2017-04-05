using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Microsoft.Win32
{
	/// <summary>
	/// A component based MouseHook that can be placed on a design surface
	/// and automatically installs itself when created with a valid container
	/// </summary>
	public class MouseHookComponent : System.ComponentModel.Component
	{
		private MouseHook hook = null;

		/// <summary>
		/// Creates a new instance of the MouseHookComponent class
		/// and installs the hook
		/// </summary>
		/// <param name="container">Parent Component container</param>
		public MouseHookComponent(System.ComponentModel.IContainer container) : this()
		{
			container.Add( this );

			if ( !base.DesignMode )
				hook.Install();
		}

		/// <summary>
		/// Creates a new instance of the MouseHookComponent class
		/// and does not install the hook. The client is responsible for calling install
		/// </summary>
		public MouseHookComponent()
		{
			hook = new MouseHook();

			hook.MouseDoubleClick += new MouseHookEventHandler(hook_MouseDoubleClick);
			hook.MouseDown += new MouseHookEventHandler(hook_MouseDown);
			hook.MouseMove += new MouseHookEventHandler(hook_MouseMove);
			hook.MouseUp += new MouseHookEventHandler(hook_MouseUp);
		}

		#region Disposer
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			hook.Dispose();

			base.Dispose( disposing );
		}
		#endregion

		#region Events
		public event MouseHookEventHandler MouseDown;
		private void hook_MouseDown(object sender, MouseHookEventArgs e)
		{
			if ( MouseDown != null )
				MouseDown( this, e );
		}

		public event MouseHookEventHandler MouseUp;
		private void hook_MouseUp(object sender, MouseHookEventArgs e)
		{
			if ( MouseUp != null )
				MouseUp( this, e );
		}

		public event MouseHookEventHandler MouseMove;
		private void hook_MouseMove(object sender, MouseHookEventArgs e)
		{
			if ( MouseMove != null )
				MouseMove( this, e );
		}

		public event MouseHookEventHandler MouseDoubleClick;
		private void hook_MouseDoubleClick(object sender, MouseHookEventArgs e)
		{
			if ( MouseDoubleClick != null )
				MouseDoubleClick( this, e );
		}
		#endregion

	}
}
