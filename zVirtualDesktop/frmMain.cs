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
            this.Closing += frmMain_Closing;
            this.Load += frmMain_Load;
            mnuExit.Click += mnuExit_Click;
            mnuSettings.Click += mnuSettings_Click;
            btnCancel.Click += btnCancel_Click;
            btnApply.Click += btnApply_Click;
            lblGithub.LinkClicked += lblGithub_LinkClicked;
            mnuGithub.Click += mnuGithub_Click;

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

        private void DesktopMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            GoToDesktop((int)mnu.Tag);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                RegisterHotKeys();
                LoadSettings();
                //Make sure there are at least 9 desktops.
                int diff = Math.Abs(Desktops.Count() - 9);
                for (int i = 1; i <= diff; i += 1)
                {
                    VirtualDesktop.Create();
                }
                timerSystemTray.Tick += TimerSystemTray_Tick;
                timerSystemTray.Interval = 500;
                timerSystemTray.Start();

            }
            catch (Exception ex)
            {
            }

        }

        private void TimerSystemTray_Tick(object sender, EventArgs e)
        {

            SetSystemTrayIcon();
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

        private void PinWindow(object sender, EventArgs e)
        {
            try
            {
                IntPtr window = Globals.GetForegroundWindow();
                if (VirtualDesktop.IsPinnedWindow(window))
                {
                    VirtualDesktop.UnpinWindow(window);
                }
                else
                {
                    VirtualDesktop.PinWindow(window);
                }
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
                //IntPtr window = Globals.GetForegroundWindow();
                //System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById((int)Globals.GetProcessID());
                //IntPtr hWnd = p.MainWindowHandle;
                //int nRet;
                //// Pre-allocate 256 characters, since this is the maximum class name length.
                //StringBuilder ClassName = new StringBuilder(256);
                ////Get the window class name
                //nRet = Globals.GetClassName(window, ClassName, ClassName.Capacity);
                //if (nRet != 0)
                //{
                //    MessageBox.Show(ClassName.ToString());
                //}
                //else
                //{
                    
                //}

                
                MessageBox.Show(Globals.GetTopWindowName());
                return;
                
                if (VirtualDesktop.IsPinnedApplication(Globals.GetTopWindowName()))
                {
                    VirtualDesktop.PinApplication(Globals.GetTopWindowName());
                }
                else
                {
                    VirtualDesktop.PinApplication(Globals.GetTopWindowName());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning or unpinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }

        }

        public int GetDesktopNumber(Guid Guid)
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

        private void SetWallpaper()
        {
            VirtualDesktop current = VirtualDesktop.Current;
            int i = GetDesktopNumber(current.Id);
            switch (i)
            {
                case 1:
                    if (txtWallpaper1.Text != "" && System.IO.File.Exists(txtWallpaper1.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper1.Text), Wallpaper.Style.Stretched);
                    }else {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 2:
                    if (txtWallpaper2.Text != "" && System.IO.File.Exists(txtWallpaper2.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper2.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 3:
                    if (txtWallpaper3.Text != "" && System.IO.File.Exists(txtWallpaper3.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper3.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 4:
                    if (txtWallpaper4.Text != "" && System.IO.File.Exists(txtWallpaper4.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper4.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 5:
                    if (txtWallpaper5.Text != "" && System.IO.File.Exists(txtWallpaper5.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper5.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 6:
                    if (txtWallpaper6.Text != "" && System.IO.File.Exists(txtWallpaper6.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper6.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 7:
                    if (txtWallpaper7.Text != "" && System.IO.File.Exists(txtWallpaper7.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper7.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 8:
                    if (txtWallpaper8.Text != "" && System.IO.File.Exists(txtWallpaper8.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper8.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
                case 9:
                    if (txtWallpaper9.Text != "" && System.IO.File.Exists(txtWallpaper9.Text))
                    {
                        Wallpaper.Set(new System.Uri(txtWallpaper9.Text), Wallpaper.Style.Stretched);
                    }
                    else
                    {
                        if (txtDefaultWallpaper.Text != "" && System.IO.File.Exists(txtDefaultWallpaper.Text))
                        {
                            Wallpaper.Set(new System.Uri(txtDefaultWallpaper.Text), Wallpaper.Style.Stretched);
                        }
                    }
                    break;
            }
        }

        public void GoToDesktop(int desktopNumber)
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
                        for (int z = 1; z <= diff; z += 1)
                        {
                            current = current.GetRight();
                        }
                    }
                    else
                    {
                        for (int z = 1; z <= diff; z += 1)
                        {
                            current = current.GetLeft();
                        }
                    }

                    current.Switch();
                    
                }

                SetSystemTrayIcon();
                SetWallpaper();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured navigating to the specified desktop. See additional details below." + Environment.NewLine + Environment.NewLine + 
                    ex.Message + Environment.NewLine + 
                    ex.Source + "::" + ex.TargetSite.Name);
            }

        


        }

        public void MoveToDesktop(int desktopNumber)
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
                        for (int z = 1; z <= diff; z += 1)
                        {
                            current = current.GetRight();
                        }
                    }
                    else
                    {
                        for (int z = 1; z <= diff; z += 1)
                        {
                            current = current.GetLeft();
                        }
                    }
                    VirtualDesktopHelper.MoveToDesktop(Globals.GetForegroundWindow(), current);
                }

                SetSystemTrayIcon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured moving the specified window. See additional details below." + Environment.NewLine + Environment.NewLine + 
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
            Hotkey hotkey = (Hotkey)sender;
            MoveToDesktop(hotkey.ID);
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
            HideSettings();
        }

        public void ShowSettings()
        {
            try
            {
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
                if (Globals.GetSystemMetrics(Globals.SystemMetric.SM_SHUTTINGDOWN) == 0)
                {
                    e.Cancel = true;
                    HideSettings();
                }
               
            }
        }

        private void timerSystemTray_Tick(object sender, EventArgs e)
        {
            SetSystemTrayIcon();
        }

        private void mnuSwitchDesktop_Click(object sender, EventArgs e)
        {

        }

        private void SystemTrayMenu_Opening(object sender, CancelEventArgs e)
        {
            CreateDesktopMenu();
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

                stream.Close();
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
                settings.Append("~DesktopWallpaper1;" + txtWallpaper1.Text);
                settings.Append("~DesktopWallpaper2;" + txtWallpaper2.Text);
                settings.Append("~DesktopWallpaper3;" + txtWallpaper3.Text);
                settings.Append("~DesktopWallpaper4;" + txtWallpaper4.Text);
                settings.Append("~DesktopWallpaper5;" + txtWallpaper5.Text);
                settings.Append("~DesktopWallpaper6;" + txtWallpaper6.Text);
                settings.Append("~DesktopWallpaper7;" + txtWallpaper7.Text);
                settings.Append("~DesktopWallpaper8;" + txtWallpaper8.Text);
                settings.Append("~DesktopWallpaper9;" + txtWallpaper9.Text);
                settings.Append("~DefaultWallpaper;" + txtDefaultWallpaper.Text);

                System.IO.Stream stream = new IsolatedStorageFileStream("zVirtualDesktop.bin", System.IO.FileMode.OpenOrCreate, storage);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(stream, settings.ToString());
                stream.Close();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
