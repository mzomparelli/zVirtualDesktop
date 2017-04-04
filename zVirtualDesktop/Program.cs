using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace zVirtualDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm = new frmMain());
            
        }

        public static frmMain MainForm;
        public const string version = "1.0.11p";

        public static IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
        public static List<string> WallpaperStyles = new List<string>();
        public static List<string> PinnedApps = new List<string>();
        public static List<Window> windows = new List<Window>();
        public static List<HotkeyItem> hotkeys = new List<HotkeyItem>();
        public static VirtualDesktop[] Desktops = VirtualDesktop.GetDesktops();

        public static string IconTheme = "White Box";

        
    }
}
