using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace zVirtualDesktop
{
    public partial class frmMain : Form
    {

        public IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();

        private List<string> WallpaperStyles = new List<string>();
        public List<string> PinnedApps = new List<string>();

        public List<Window> windows = new List<Window>();


        public Hotkey keyGoTo01 = new Hotkey(1);
        public Hotkey keyGoTo02 = new Hotkey(2);
        public Hotkey keyGoTo03 = new Hotkey(3);
        public Hotkey keyGoTo04 = new Hotkey(4);
        public Hotkey keyGoTo05 = new Hotkey(5);
        public Hotkey keyGoTo06 = new Hotkey(6);
        public Hotkey keyGoTo07 = new Hotkey(7);
        public Hotkey keyGoTo08 = new Hotkey(8);

        public Hotkey keyGoTo09 = new Hotkey(9);
        public Hotkey keyMoveTo01 = new Hotkey(1);
        public Hotkey keyMoveTo02 = new Hotkey(2);
        public Hotkey keyMoveTo03 = new Hotkey(3);
        public Hotkey keyMoveTo04 = new Hotkey(4);
        public Hotkey keyMoveTo05 = new Hotkey(5);
        public Hotkey keyMoveTo06 = new Hotkey(6);
        public Hotkey keyMoveTo07 = new Hotkey(7);
        public Hotkey keyMoveTo08 = new Hotkey(8);

        public Hotkey keyMoveTo09 = new Hotkey(9);

        public Hotkey keyPinWindow = new Hotkey(99);
        public Hotkey keyPinApp = new Hotkey(99);

        VirtualDesktop[] Desktops = VirtualDesktop.GetDesktops();

        private bool ExitClicked = false;
        private Timer timerSystemTray = new Timer();

        public frmMain()
        {
            InitializeComponent();
            //foreach(VirtualDesktop d in VirtualDesktop.GetDesktops())
            //{
            //    d.Remove();
            //}
            //Wire up some events
            this.Closing += frmMain_Closing;
            this.Load += frmMain_Load;
            mnuExit.Click += mnuExit_Click;
            mnuSettings.Click += mnuSettings_Click;
            lblGithub.LinkClicked += lblGithub_LinkClicked;
            mnuGithub.Click += mnuGithub_Click;
            VirtualDesktop.CurrentChanged += VirtualDesktop_CurrentChanged;
            VirtualDesktop.ApplicationViewChanged += VirtualDesktop_ApplicationViewChanged;
            btnBrowseWallpaper1.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper2.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper3.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper4.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper5.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper6.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper7.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper8.Click += btnBrowseWallpaper_Click;
            btnBrowseWallpaper9.Click += btnBrowseWallpaper_Click;
            btnBrowseDefaultWalpaper.Click += btnBrowseWallpaper_Click;

            //Create a new thread to retrieve the ProgID and Executables on this machine.
            //This is used so that the app is able to pin an application
            //System.Threading.Thread tGetProgs = new System.Threading.Thread(new System.Threading.ThreadStart(GetProgs));
            //tGetProgs.Start();


        }

        private static void GetProgs()
        {
            //var regClis = Registry.ClassesRoot.OpenSubKey("CLSID");
            //var progs = new List<COMProgram>();

            //foreach (var clsid in regClis.GetSubKeyNames())
            //{
            //    var regClsidKey = regClis.OpenSubKey(clsid);
            //    var ProgID = regClsidKey.OpenSubKey("ProgID");
            //    var regPath = regClsidKey.OpenSubKey("InprocServer32");

            //    if (regPath == null)
            //        regPath = regClsidKey.OpenSubKey("LocalServer32");

            //    if (regPath != null && ProgID != null)
            //    {
            //        var pid = ProgID.GetValue("");
            //        var filePath = regPath.GetValue("");
            //        progs.Add(new COMProgram(pid.ToString(), filePath.ToString()));
            //        regPath.Close();
            //    }

            //    regClsidKey.Close();
            //}
        }

#region "SystemTrayIcon"

        public void SetSystemTrayIcon()
        {
            
            switch(cmbIcons.Text)
            {
                case "Green":
                    SystemTrayGreen();
                    break;
                case "Blue":
                    SystemTrayBlue();
                    break;
                case "Digital Clock":
                    SystemTrayDigitalClock();
                    break;
                case "Red Orb":
                    SystemTrayRedOrb();
                    break;
                case "White Box":
                    SystemTrayWhiteBox();
                    break;
                case "Black Box":
                    SystemTrayBlackBox();
                    break;
            }
        }

        private void SystemTrayBlackBox()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_1_Black;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_2_Black;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_3_Black;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_4_Black;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_5_Black;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_6_Black;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_7_Black;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_8_Black;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_9_Black;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.Windows_8_Numbers_1_Black;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void SystemTrayWhiteBox()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_1;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_2;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_3;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_4;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_5;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_6;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_7;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_8;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.Windows_8_Numbers_9;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.Windows_8_Numbers_1;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void SystemTrayRedOrb()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_1;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_2;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_3;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_4;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_5;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_6;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_7;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_8;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_9;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.Red_Orb_Alphabet_Number_1;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void SystemTrayDigitalClock()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.st_1;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.st_2;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.st_3;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.st_4;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.st_5;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.st_6;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.st_7;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.st_8;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.st_9;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.st_1;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void SystemTrayBlue()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.number_1_blue;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.number_2_blue;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.number_3_blue;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.number_4_blue;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.number_5_blue;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.number_6_blue;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.number_7_blue;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.number_8_blue;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.number_9_blue;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.number_1_blue;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void SystemTrayGreen()
        {
            try
            {
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                switch (i)
                {
                    case 1:
                        SystemTray.Icon = Properties.Resources.number_1_green;
                        break;
                    case 2:
                        SystemTray.Icon = Properties.Resources.number_2_green;
                        break;
                    case 3:
                        SystemTray.Icon = Properties.Resources.number_3_green;
                        break;
                    case 4:
                        SystemTray.Icon = Properties.Resources.number_4_green;
                        break;
                    case 5:
                        SystemTray.Icon = Properties.Resources.number_5_green;
                        break;
                    case 6:
                        SystemTray.Icon = Properties.Resources.number_6_green;
                        break;
                    case 7:
                        SystemTray.Icon = Properties.Resources.number_7_green;
                        break;
                    case 8:
                        SystemTray.Icon = Properties.Resources.number_8_green;
                        break;
                    case 9:
                        SystemTray.Icon = Properties.Resources.number_9_green;
                        break;
                }

                SystemTray.Visible = true;

            }
            catch (Exception ex)
            {
                SystemTray.Icon = Properties.Resources.number_1_green;
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

#endregion

        private void CreateDesktopMenu()
        {
            Desktops = VirtualDesktop.GetDesktops();
            mnuSwitchDesktop.DropDownItems.Clear();


            for (int i = 0; i < Desktops.Count(); i++)
            {
                ToolStripMenuItem mnu = new ToolStripMenuItem();
                mnu.Text = "Desktop " + (i + 1).ToString();
                mnu.Tag = i + 1;
                mnu.Click += DesktopMenu_Click;
                if (GetDesktopNumber(VirtualDesktop.Current.Id) == i + 1)
                {
                    mnu.CheckState = CheckState.Checked;
                }else
                {
                    mnu.CheckState = CheckState.Unchecked;
                }
              
                mnuSwitchDesktop.DropDownItems.Add(mnu);
            }
        }

        public void RegisterHotKeys()
        {
            keyGoTo01.HotkeyActivated += DesktopGo;
            keyGoTo01.Register(Keys.NumPad1, true, false, false, true);

            keyGoTo02.HotkeyActivated += DesktopGo;
            keyGoTo02.Register(Keys.NumPad2, true, false, false, true);

            keyGoTo03.HotkeyActivated += DesktopGo;
            keyGoTo03.Register(Keys.NumPad3, true, false, false, true);

            keyGoTo04.HotkeyActivated += DesktopGo;
            keyGoTo04.Register(Keys.NumPad4, true, false, false, true);

            keyGoTo05.HotkeyActivated += DesktopGo;
            keyGoTo05.Register(Keys.NumPad5, true, false, false, true);

            keyGoTo06.HotkeyActivated += DesktopGo;
            keyGoTo06.Register(Keys.NumPad6, true, false, false, true);

            keyGoTo07.HotkeyActivated += DesktopGo;
            keyGoTo07.Register(Keys.NumPad7, true, false, false, true);

            keyGoTo08.HotkeyActivated += DesktopGo;
            keyGoTo08.Register(Keys.NumPad8, true, false, false, true);

            keyGoTo09.HotkeyActivated += DesktopGo;
            keyGoTo09.Register(Keys.NumPad9, true, false, false, true);


            keyMoveTo01.HotkeyActivated += DesktopMove;
            keyMoveTo01.Register(Keys.NumPad1, false, true, false, true);

            keyMoveTo02.HotkeyActivated += DesktopMove;
            keyMoveTo02.Register(Keys.NumPad2, false, true, false, true);

            keyMoveTo03.HotkeyActivated += DesktopMove;
            keyMoveTo03.Register(Keys.NumPad3, false, true, false, true);

            keyMoveTo04.HotkeyActivated += DesktopMove;
            keyMoveTo04.Register(Keys.NumPad4, false, true, false, true);

            keyMoveTo05.HotkeyActivated += DesktopMove;
            keyMoveTo05.Register(Keys.NumPad5, false, true, false, true);

            keyMoveTo06.HotkeyActivated += DesktopMove;
            keyMoveTo06.Register(Keys.NumPad6, false, true, false, true);

            keyMoveTo07.HotkeyActivated += DesktopMove;
            keyMoveTo07.Register(Keys.NumPad7, false, true, false, true);

            keyMoveTo08.HotkeyActivated += DesktopMove;
            keyMoveTo08.Register(Keys.NumPad8, false, true, false, true);

            keyMoveTo09.HotkeyActivated += DesktopMove;
            keyMoveTo09.Register(Keys.NumPad9, false, true, false, true);


            keyPinWindow.HotkeyActivated += PinWindow;
            keyPinWindow.Register(Keys.Z, true, false, false, true);

            keyPinApp.HotkeyActivated += PinApp;
            keyPinApp.Register(Keys.A, true, false, false, true);

        }

        #region "Event Handlers"

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                RegisterHotKeys();
                LoadSettings();
                SetSystemTrayIcon();
                //Make sure there are at least 9 desktops.
                int diff = Math.Abs(Desktops.Count() - 9);
                for (int i = 1; i <= diff; i += 1)
                {
                    VirtualDesktop.Create();
                }
                timerSystemTray.Tick += timerGrabForegroundWindow_Tick;
                timerSystemTray.Interval = 500;
                timerSystemTray.Start();

            }
            catch (Exception ex)
            {
            }

        }

        private void VirtualDesktop_ApplicationViewChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void VirtualDesktop_CurrentChanged(object sender, VirtualDesktopChangedEventArgs e)
        {
            SetSystemTrayIcon();
            SetWallpaper();
            GC.Collect();
        }

        private void DesktopMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            GoToDesktop((int)mnu.Tag);
        }

        private void PinWindow(object sender, EventArgs e)
        {
            try
            {
                Hotkey hotkey = (Hotkey)sender;
                Window win = Window.ForegroundWindow();
                IEnumerable<Window> window = from Window w in windows
                                             where w.Handle == win.Handle
                                             select w;
                if (window.Count() < 1)
                {
                    windows.Add(win);
                }

                if (win.IsPinnedWindow)
                {
                    win.Unpin();
                }
                else
                {
                    win.Pin();
                }

                SetPinnedAppListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning or unpinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
            }

        }

        private void PinApp(object sender, EventArgs e)
        {
            try
            {
                Hotkey hotkey = (Hotkey)sender;
                Window win = Window.ForegroundWindow();
                IEnumerable<Window> window = from Window w in windows
                                             where w.Handle == win.Handle
                                             select w;
                if (window.Count() < 1)
                {
                    windows.Add(win);
                }

                if (win.IsPinnedApplication)
                {
                    win.UnpinApplication();
                    PinnedApps.Remove(win.AppID);
                }
                else
                {
                    win.PinApplication();
                    PinnedApps.Add(win.AppID);
                }

                SetPinnedAppListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning or unpinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }

        }

        private void DesktopGo(object sender, EventArgs e)
        {
            Hotkey hotkey = (Hotkey)sender;
            GoToDesktop(hotkey.ID);
        }

        private void DesktopMove(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            { 
                //win = new Window(hWnd);
                windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            win.MoveToDesktop(hotkey.ID);
            //MoveToDesktop(hotkey.ID);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            try
            {
                ExitClicked = true;
                this.Close();

            }
            catch (Exception ex)
            {
            }

        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideSettings();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            HideSettings();
            GC.Collect();
        }

        private void lblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mzomparelli/zVirtualDesktop");
        }

        private void mnuGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mzomparelli/zVirtualDesktop");
        }

        private void frmMain_Closing(object sender, CancelEventArgs e)
        {
            if (!ExitClicked)
            {
                if (PInvoke.GetSystemMetrics(PInvoke.SystemMetric.SM_SHUTTINGDOWN) == 0)
                {
                    e.Cancel = true;
                    HideSettings();
                }

            }
        }

        private void timerGrabForegroundWindow_Tick(object sender, EventArgs e)
        {
            //Grab some windows
            IntPtr hWnd = PInvoke.GetForegroundWindow();
            IEnumerable<Window> window = from Window w in windows where w.Handle == hWnd select w;
            if (window.Count() < 1)
            {
                Window win = new Window(hWnd);
                windows.Add(win);
            }
        }

        private void mnuSwitchDesktop_Click(object sender, EventArgs e)
        {

        }

        private void SystemTrayMenu_Opening(object sender, CancelEventArgs e)
        {
            CreateDesktopMenu();
        }

        private void btnBrowseWallpaper_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GetFileDialogResult(btn.Tag.ToString());
        }

        private void mnuPinnedApps_Opening(object sender, CancelEventArgs e)
        {
            if (lstPinnedApps.SelectedIndex == -1)
            {
                mnuUnpin.Enabled = false;
            }
            else
            {
                mnuUnpin.Enabled = true;
            }
        }

        private void mnuUnpin_Click(object sender, EventArgs e)
        {
            try
            {
                VirtualDesktop.UnpinApplication(lstPinnedApps.Text);
                PinnedApps.Remove(lstPinnedApps.Text);
                SetPinnedAppListBox();
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        private void SetPinnedAppListBox()
        {
            lstPinnedApps.Items.Clear();
            foreach (string appID in PinnedApps)
            {
                lstPinnedApps.Items.Add(appID);
            }
        }

        private int GetDesktopNumber(Guid Guid)
        {
            try
            {
                Desktops = VirtualDesktop.GetDesktops();
                for (int i = 0; i <= Desktops.Count() - 1; i++)
                {
                    if (Desktops[i].Id == Guid)
                    {
                        return i + 1;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured identifying the desktop number. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
                return 1;
            }

        }

        private Wallpaper.Style GetWallpaperStyle(string desktop)
        {
            switch (desktop)
            {
                case "1":
                    if(WallpaperStyles[1] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }else
                    {
                        switch(WallpaperStyles[1])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "2":
                    if (WallpaperStyles[2] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[2])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "3":
                    if (WallpaperStyles[3] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[3])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "4":
                    if (WallpaperStyles[4] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[4])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "5":
                    if (WallpaperStyles[5] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[5])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "6":
                    if (WallpaperStyles[6] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[6])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "7":
                    if (WallpaperStyles[7] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[7])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "8":
                    if (WallpaperStyles[8] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[8])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "9":
                    if (WallpaperStyles[9] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[9])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                case "default":
                    if (WallpaperStyles[0] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[0])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
                default:
                    if (WallpaperStyles[0] == "")
                    {
                        return Wallpaper.Style.Centered;
                    }
                    else
                    {
                        switch (WallpaperStyles[0])
                        {
                            case "Centered":
                                return Wallpaper.Style.Centered;
                            case "Streched":
                                return Wallpaper.Style.Stretched;
                            case "Tiled":
                                return Wallpaper.Style.Tiled;
                            default:
                                return Wallpaper.Style.Centered;
                        }
                    }
                    break;
            }
        }

        private void SetWallpaper()
        {
            VirtualDesktop current = VirtualDesktop.Current;
            int i = GetDesktopNumber(current.Id);
            switch (i)
            {
                case 1:
                    if (txtWallpaper1.Text != "" && System.IO.File.Exists(txtWallpaper1.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper1.Text), GetWallpaperStyle("1"));
                    }else {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 2:
                    if (txtWallpaper2.Text != "" && System.IO.File.Exists(txtWallpaper2.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper2.Text), GetWallpaperStyle("2"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 3:
                    if (txtWallpaper3.Text != "" && System.IO.File.Exists(txtWallpaper3.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper3.Text), GetWallpaperStyle("3"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 4:
                    if (txtWallpaper4.Text != "" && System.IO.File.Exists(txtWallpaper4.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper4.Text), GetWallpaperStyle("4"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 5:
                    if (txtWallpaper5.Text != "" && System.IO.File.Exists(txtWallpaper5.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper5.Text), GetWallpaperStyle("5"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 6:
                    if (txtWallpaper6.Text != "" && System.IO.File.Exists(txtWallpaper6.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper6.Text), GetWallpaperStyle("6"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 7:
                    if (txtWallpaper7.Text != "" && System.IO.File.Exists(txtWallpaper7.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper7.Text), GetWallpaperStyle("7"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 8:
                    if (txtWallpaper8.Text != "" && System.IO.File.Exists(txtWallpaper8.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper8.Text), GetWallpaperStyle("8"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
                case 9:
                    if (txtWallpaper9.Text != "" && System.IO.File.Exists(txtWallpaper9.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper9.Text), GetWallpaperStyle("9"));
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), GetWallpaperStyle("default"));
                        }
                    }
                    break;
            }
        }

        private void GoToDesktop(int desktopNumber)
        {
            try
            {                
                VirtualDesktop current = VirtualDesktop.Current;
                int i = GetDesktopNumber(current.Id);
                if (i == desktopNumber)
                {
                    return;
                }
                else
                {
                    int diff = Math.Abs(i - desktopNumber);
                    if (i < desktopNumber)
                    {
                        for (int z = 1; z <= diff; z++)
                        {
                            current = current.GetRight();
                        }
                    }
                    else
                    {
                        for (int z = 1; z <= diff; z++)
                        {
                            current = current.GetLeft();
                        }
                    }

                    current.Switch();
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured navigating to the specified desktop. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
            }

        


        }

        #region "Settings"

        public void ShowSettings()
        {
            try
            {
                LoadSettings();
                this.Opacity = 100;
                this.TopMost = true;
                this.ShowInTaskbar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured showing the settings window. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        public void HideSettings()
        {
            try
            {
                this.Opacity = 0;
                this.TopMost = false;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured hiding the settings window. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (storage.FileExists("zVirtualDesktop.bin") == false)
                {
                    cmbIcons.Text = "Green";
                    SaveSettings();
                }
                System.IO.Stream stream = new IsolatedStorageFileStream("zVirtualDesktop.bin", System.IO.FileMode.Open, storage);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                object oo = bf.Deserialize(stream);
                string settings = (string)oo;
                string[] indivdualSettings = settings.Split('~');

                cmbIcons.Text = indivdualSettings[0].Split(';')[1];
                txtWallpaper1.Text = indivdualSettings[1].Split(';')[1];
                txtWallpaper2.Text = indivdualSettings[2].Split(';')[1];
                txtWallpaper3.Text = indivdualSettings[3].Split(';')[1];
                txtWallpaper4.Text = indivdualSettings[4].Split(';')[1];
                txtWallpaper5.Text = indivdualSettings[5].Split(';')[1];
                txtWallpaper6.Text = indivdualSettings[6].Split(';')[1];
                txtWallpaper7.Text = indivdualSettings[7].Split(';')[1];
                txtWallpaper8.Text = indivdualSettings[8].Split(';')[1];
                txtWallpaper9.Text = indivdualSettings[9].Split(';')[1];
                txtDefaultWallpaper.Text = indivdualSettings[10].Split(';')[1];

                cmbWallpaperStyle1.Text = indivdualSettings[1].Split(';')[2];
                cmbWallpaperStyle2.Text = indivdualSettings[2].Split(';')[2];
                cmbWallpaperStyle3.Text = indivdualSettings[3].Split(';')[2];
                cmbWallpaperStyle4.Text = indivdualSettings[4].Split(';')[2];
                cmbWallpaperStyle5.Text = indivdualSettings[5].Split(';')[2];
                cmbWallpaperStyle6.Text = indivdualSettings[6].Split(';')[2];
                cmbWallpaperStyle7.Text = indivdualSettings[7].Split(';')[2];
                cmbWallpaperStyle8.Text = indivdualSettings[8].Split(';')[2];
                cmbWallpaperStyle9.Text = indivdualSettings[9].Split(';')[2];
                cmbWallpaperStyleDefault.Text = indivdualSettings[10].Split(';')[2];


                stream.Close();
                stream.Dispose();

                WallpaperStyles.Clear();
                WallpaperStyles.Add(cmbWallpaperStyleDefault.Text);
                WallpaperStyles.Add(cmbWallpaperStyle1.Text);
                WallpaperStyles.Add(cmbWallpaperStyle2.Text);
                WallpaperStyles.Add(cmbWallpaperStyle3.Text);
                WallpaperStyles.Add(cmbWallpaperStyle4.Text);
                WallpaperStyles.Add(cmbWallpaperStyle5.Text);
                WallpaperStyles.Add(cmbWallpaperStyle6.Text);
                WallpaperStyles.Add(cmbWallpaperStyle7.Text);
                WallpaperStyles.Add(cmbWallpaperStyle8.Text);
                WallpaperStyles.Add(cmbWallpaperStyle9.Text);

            }
            catch (Exception ex)
            {

            }
        }

        private void SaveSettings()
        {
            try
            {
                StringBuilder settings = new StringBuilder();
                settings.Append("IconTheme;" + cmbIcons.Text);
                //Get the URI for each desktop
                settings.Append("~DesktopWallpaper1;" + txtWallpaper1.Text + ";" + cmbWallpaperStyle1.Text);
                settings.Append("~DesktopWallpaper2;" + txtWallpaper2.Text + ";" + cmbWallpaperStyle2.Text);
                settings.Append("~DesktopWallpaper3;" + txtWallpaper3.Text + ";" + cmbWallpaperStyle3.Text);
                settings.Append("~DesktopWallpaper4;" + txtWallpaper4.Text + ";" + cmbWallpaperStyle4.Text);
                settings.Append("~DesktopWallpaper5;" + txtWallpaper5.Text + ";" + cmbWallpaperStyle5.Text);
                settings.Append("~DesktopWallpaper6;" + txtWallpaper6.Text + ";" + cmbWallpaperStyle6.Text);
                settings.Append("~DesktopWallpaper7;" + txtWallpaper7.Text + ";" + cmbWallpaperStyle7.Text);
                settings.Append("~DesktopWallpaper8;" + txtWallpaper8.Text + ";" + cmbWallpaperStyle8.Text);
                settings.Append("~DesktopWallpaper9;" + txtWallpaper9.Text + ";" + cmbWallpaperStyle9.Text);
                settings.Append("~DefaultWallpaper;" + txtDefaultWallpaper.Text + ";" + cmbWallpaperStyleDefault.Text);

                System.IO.Stream stream = new IsolatedStorageFileStream("zVirtualDesktop.bin", System.IO.FileMode.OpenOrCreate, storage);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(stream, settings.ToString());
                stream.Close();
                stream.Dispose();


                WallpaperStyles.Clear();
                WallpaperStyles.Add(cmbWallpaperStyleDefault.Text);
                WallpaperStyles.Add(cmbWallpaperStyle1.Text);
                WallpaperStyles.Add(cmbWallpaperStyle2.Text);
                WallpaperStyles.Add(cmbWallpaperStyle3.Text);
                WallpaperStyles.Add(cmbWallpaperStyle4.Text);
                WallpaperStyles.Add(cmbWallpaperStyle5.Text);
                WallpaperStyles.Add(cmbWallpaperStyle6.Text);
                WallpaperStyles.Add(cmbWallpaperStyle7.Text);
                WallpaperStyles.Add(cmbWallpaperStyle8.Text);
                WallpaperStyles.Add(cmbWallpaperStyle9.Text);

                SetSystemTrayIcon();
                SetWallpaper();

            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        private void GetFileDialogResult(string desktop)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            
            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                switch (desktop)
                {
                    case "1":
                        txtWallpaper1.Text = dlg.FileName;
                        break;
                    case "2":
                        txtWallpaper2.Text = dlg.FileName;
                        break;
                    case "3":
                        txtWallpaper3.Text = dlg.FileName;
                        break;
                    case "4":
                        txtWallpaper4.Text = dlg.FileName;
                        break;
                    case "5":
                        txtWallpaper5.Text = dlg.FileName;
                        break;
                    case "6":
                        txtWallpaper6.Text = dlg.FileName;
                        break;
                    case "7":
                        txtWallpaper7.Text = dlg.FileName;
                        break;
                    case "8":
                        txtWallpaper8.Text = dlg.FileName;
                        break;
                    case "9":
                        txtWallpaper9.Text = dlg.FileName;
                        break;
                    case "default":
                        txtDefaultWallpaper.Text = dlg.FileName;
                        break;
                }
            }else
            {
                //do nothing
            }

            dlg.Dispose();
        }

        private void btnAddHotkey_Click(object sender, EventArgs e)
        {
            frmHotKey f = new frmHotKey();
            f.ShowDialog(this);

        }
    }
}
