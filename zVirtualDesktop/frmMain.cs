using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace zVirtualDesktop
{
    public partial class frmMain : Form
    {
        

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

        }


        public void SetSystemTrayIcon()
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
                MessageBox.Show("An error occured setting the system tray icon. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
                MessageBox.Show("An error occured pinning or unpinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
                MessageBox.Show("An error occured identifying the desktop number. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
                return 1;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured navigating to the specified desktop. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
                MessageBox.Show("An error occured moving the specified window. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
                MessageBox.Show("An error occured showing the settings window. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
                MessageBox.Show("An error occured hiding the settings window. See additional details below." + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + ex.Source + "::" + ex.TargetSite.Name);
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
    }
}
