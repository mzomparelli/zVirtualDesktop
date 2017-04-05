using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace zVirtualDesktop
{
    public static class VirtualDestopFunctions
    {

        public static void PinWindow(object sender, EventArgs e)
        {
            try
            {
                Hotkey hotkey = (Hotkey)sender;
                Window win = Window.ForegroundWindow();
                IEnumerable<Window> window = from Window w in Program.windows
                                             where w.Handle == win.Handle
                                             select w;
                if (window.Count() < 1)
                {
                    Program.windows.Add(win);
                }

                if (win.IsPinnedWindow)
                {
                    win.Unpin();
                }
                else
                {
                    win.Pin();
                }

                Program.MainForm.SetPinnedAppListBox();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning or unpinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "frmMain", ex);
            }

        }

        public static void PinApp(object sender, EventArgs e)
        {
            try
            {
                Hotkey hotkey = (Hotkey)sender;
                Window win = Window.ForegroundWindow();
                IEnumerable<Window> window = from Window w in Program.windows
                                             where w.Handle == win.Handle
                                             select w;
                if (window.Count() < 1)
                {
                    Program.windows.Add(win);
                }

                if (win.IsPinnedApplication)
                {
                    win.UnpinApplication();
                    Program.PinnedApps.Remove(win.AppID);
                }
                else
                {
                    win.PinApplication();
                    Program.PinnedApps.Add(win.AppID);
                }

                Program.MainForm.SetPinnedAppListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning or unpinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "frmMain", ex);
            }

        }

        public static void DesktopGo(object sender, EventArgs e)
        {
            Hotkey hotkey = (Hotkey)sender;
            int hotkeyID;
            int.TryParse(hotkey.ID, out hotkeyID);
            GoToDesktop(hotkeyID);
        }

        public static void DesktopMove(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            int hotkeyID;
            int.TryParse(hotkey.ID, out hotkeyID);
            win.MoveToDesktop(hotkeyID);
            //MoveToDesktop(hotkey.ID);
        }

        public static void DesktopMoveFollow(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            int hotkeyID;
            int.TryParse(hotkey.ID, out hotkeyID);
            win.MoveToDesktop(hotkeyID, true);
            //MoveToDesktop(hotkey.ID);
        }

        public static void DesktopMoveNextFollow(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            win.MoveToNextDesktop(true);
            //MoveToDesktop(hotkey.ID);
        }

        public static void DesktopMoveNext(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            win.MoveToNextDesktop();
            //MoveToDesktop(hotkey.ID);
        }

        public static void DesktopMovePreviousFollow(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            win.MoveToPreviousDesktop(true);
            //MoveToDesktop(hotkey.ID);
        }

        public static void DesktopMovePrevious(object sender, EventArgs e)
        {

            Window win = Window.ForegroundWindow();
            IEnumerable<Window> window = from Window w in Program.windows
                                         where w.Handle == win.Handle
                                         select w;
            if (window.Count() < 1)
            {
                //win = new Window(hWnd);
                Program.windows.Add(win);
            }

            Hotkey hotkey = (Hotkey)sender;
            win.MoveToPreviousDesktop();
            //MoveToDesktop(hotkey.ID);
        }

        public static int GetDesktopNumber(Guid Guid)
        {
            try
            {
                Program.Desktops = VirtualDesktop.GetDesktops();
                for (int i = 0; i <= Program.Desktops.Count() - 1; i++)
                {
                    if (Program.Desktops[i].Id == Guid)
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
                Log.LogEvent("Exception", "", "", "frmMain", ex);
                return 1;

            }

        }

        public static void GoToDesktop(int desktopNumber)
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

                    //Right beofre switching the desktop, set the active window as the taskbar
                    //This prevents windows from flashing in the taskbar when switching desktops
                    Window w = Window.Taskbar();
                    w.SetAsForegroundWindow();
                    current.Switch();
                    Program.NavigateCount++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured navigating to the specified desktop. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "frmMain", ex);
            }




        }

    }
}
