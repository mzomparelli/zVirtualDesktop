using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDesktop;

namespace zVirtualDesktop
{
    public class Window
    {

        #region "Static Instances"

        //Create a new instance from the current foreground window
        public static Window ForegroundWindow()
        {
            try
            {
                Window win = new Window(GetForegroundWindow());
                return win;
            }catch
            {
                return null;
            }
            
        }

        //Create a new instance from the taskbar window
        public static Window Taskbar()
        {
            try
            {
                IntPtr hWnd = FindWindow("Shell_TrayWnd", null);
                Window win = new Window(hWnd);
                return win;
            }
            catch
            {
                return null;
            }

        }

        #endregion

        public Window(IntPtr hWnd)
        {
            this.hWnd = hWnd;
        }


        private IntPtr hWnd;

        public IntPtr Handle
        {
            get
            {
                return hWnd;
            }
            set
            {
                hWnd = value;
            }
        }

        public string Caption
        { get
            {
                return GetWindowText();
            }
        }

        public string ApplicationName
        {
            get
            {
                return GetWindowName();
            }
        }

        public int DesktopNumber
        {
            get
            {
                try
                {
                    return GetDesktopNumber(VirtualDesktop.FromHwnd(hWnd).Id);
                }catch(Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return 0;
                }
                
            }
        }

        public bool IsDesktop
        {
            get
            {
                try
                {
                    const int maxChars = 256;
                    StringBuilder className = new StringBuilder(maxChars);
                    if (GetClassName(this.hWnd, className, maxChars) > 0)
                    {
                        string cName = className.ToString();
                        if (cName == "Progman" || cName == "WorkerW")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
                catch (Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return false;
                }

            }
        }

        public bool SetAsForegroundWindow()
        {
            try
            {
                return SetForegroundWindow(this.hWnd);
            }
            catch (Exception ex)
            {
                Log.LogEvent("Exception", "", "", "Window", ex);
                return false;
            }
        }

        public string AppID
        {
            get
            {
                try
                {
                    return ApplicationHelper.GetAppId(hWnd);
                }
                catch (Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return "";
                }
            }
        }

        public bool IsPinnedWindow
        {
            get
            {
                try
                {
                    if(hWnd != IntPtr.Zero)
                    {
                        return VirtualDesktop.IsPinnedWindow(hWnd);
                    }else
                    {
                        return false;
                    }
                    
                }
                catch (Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return false;
                }
                
            }
        }

        public bool IsPinnedApplication
        {
            get
            {
                try
                {
                    if (hWnd != IntPtr.Zero)
                    {
                        return VirtualDesktop.IsPinnedApplication(AppID);
                    }
                    else
                    {
                        return false;
                    }                    
                }
                catch (Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return false;
                }

            }
        }

        public System.Diagnostics.Process Process
        {
            get
            {
                try
                {
                    return System.Diagnostics.Process.GetProcessById((int)GetProcessID());
                }catch(Exception ex)
                {
                    Log.LogEvent("Exception", "", "", "Window", ex);
                    return null;
                }
                
            }
        }

        public void Unpin()
        {
            try
            {
                VirtualDesktop.UnpinWindow(hWnd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured unpinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "Window", ex);
            }
        } 

        public void UnpinApplication()
        {
            try
            {
                VirtualDesktop.UnpinApplication(AppID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured unpinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "Window", ex);

            }
        }

        public void Pin()
        {
            try
            {
                VirtualDesktop.PinWindow(hWnd);
                Program.PinCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "Window", ex);
            }
        }

        public void PinApplication()
        {
            try
            {
                VirtualDesktop.PinApplication(AppID);
                Program.PinCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "Window", ex);
            }
        }

        public void MoveToPreviousDesktop()
        {
            if (this.DesktopNumber == 1)
            {
                MoveToDesktop(VirtualDesktop.GetDesktops().Count());
            }
            else
            {
                MoveToDesktop(this.DesktopNumber - 1);
            }
        }

        public void MoveToPreviousDesktop(bool follow)
        {
            MoveToPreviousDesktop();
            this.GoToDesktop();
        }

        public void MoveToNextDesktop()
        {
            if (this.DesktopNumber == VirtualDesktop.GetDesktops().Count())
            {
                MoveToDesktop(1);
            }
            else
            {
                MoveToDesktop(this.DesktopNumber + 1);
            }
            
        }

        public void MoveToNextDesktop(bool follow)
        {
            MoveToNextDesktop();
            this.GoToDesktop();
        }

        public void MoveToDesktop(int desktopNumber)
        {
            try
            {
                //Create addtional desktops if necessary
                VirtualDesktop[] Desktops = VirtualDesktop.GetDesktops();
                if (Desktops.Count() < desktopNumber)
                {
                    int diff = Math.Abs(Desktops.Count() - desktopNumber);
                    for (int x = 1; x <= diff; x++)
                    {
                        VirtualDesktop.Create();
                    }
                }             

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
                    VirtualDesktopHelper.MoveToDesktop(hWnd, current);
                    Program.MoveCount++;
                }

            }
            catch (Exception ex)
            {
                if (this.Caption != "")
                {
                    MessageBox.Show("An error occured moving the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                                        ex.Message + Environment.NewLine +
                                        ex.Source + "::" + ex.TargetSite.Name);
                }
                
                Log.LogEvent("Exception", "", 
                             "Window Handle: " + this.Handle.ToString() + Environment.NewLine + 
                             "Window Caption: " + this.Caption + Environment.NewLine + 
                             "Application: " + this.ApplicationName, 
                             "Window", 
                             ex);
            }


        }

        public void MoveToDesktop(int desktopNumber, bool follow)
        {
            MoveToDesktop(desktopNumber);
            if(follow)
            {                
                GoToDesktop(desktopNumber);
            }
        }

        public void GoToDesktop()
        {
            GoToDesktop(DesktopNumber);
        }

        #region "pInvoke & Private"

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

                    //Right before switching the desktop, set the active window as the taskbar
                    //This prevents windows from flashing in the taskbar when switching desktops
                    Window w = Window.Taskbar();
                    w.SetAsForegroundWindow();
                    current.Switch();
                    //give focus to the window we followed
                    this.SetAsForegroundWindow();
                    Program.NavigateCount++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured navigating to the specified desktop. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
                Log.LogEvent("Exception", "", "", "Window", ex);
            }




        }

        private string GetWindowText()
        {
            try
            {
                int length = GetWindowTextLength(hWnd);
                StringBuilder text = new StringBuilder(length + 1);
                GetWindowText(hWnd, text, text.Capacity);
                return text.ToString();
            }catch (Exception ex)
            {
                Log.LogEvent("Exception", "", "", "Window", ex);
                return "";
            }
            
        }

        private string GetWindowName()
        {
            try
            {
                uint lpdwProcessId;
                GetWindowThreadProcessId(hWnd, out lpdwProcessId);

                IntPtr hProcess = OpenProcess(0x0410, false, lpdwProcessId);

                StringBuilder text = new StringBuilder(1000);
                //GetModuleBaseName(hProcess, IntPtr.Zero, text, text.Capacity);
                GetModuleFileNameEx(hProcess, IntPtr.Zero, text, text.Capacity);

                CloseHandle(hProcess);

                return text.ToString();
            }
            catch (Exception ex)
            {
                Log.LogEvent("Exception", "", "", "Window", ex);
                return "";
            }
            
        }

        private uint GetProcessID()
        {
            try
            {
                uint lpdwProcessId;
                GetWindowThreadProcessId(hWnd, out lpdwProcessId);
                return lpdwProcessId;
            }catch (Exception ex)
            {
                Log.LogEvent("Exception", "", "", "Window", ex);
                return 0;
            }
            
        }

        private int GetDesktopNumber(Guid Guid)
        {
            try
            {
                VirtualDesktop[] Desktops = VirtualDesktop.GetDesktops();
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
                Log.LogEvent("Exception", "", "", "Window", ex);
                return 1;
            }

        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        //  DWORD GetWindowThreadProcessId(
        //      __in   HWND hWnd,
        //      __out  LPDWORD lpdwProcessId
        //  );
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //  DWORD WINAPI GetModuleBaseName(
        //      __in      HANDLE hProcess,
        //      __in_opt  HMODULE hModule,
        //      __out     LPTSTR lpBaseName,
        //      __in      DWORD nSize
        //  );
        [DllImport("psapi.dll")]
        private static extern uint GetModuleBaseName(IntPtr hWnd, IntPtr hModule, StringBuilder lpFileName, int nSize);

        //  DWORD WINAPI GetModuleFileNameEx(
        //      __in      HANDLE hProcess,
        //      __in_opt  HMODULE hModule,
        //      __out     LPTSTR lpFilename,
        //      __in      DWORD nSize
        //  );
        [DllImport("psapi.dll")]
        private static extern uint GetModuleFileNameEx(IntPtr hWnd, IntPtr hModule, StringBuilder lpFileName, int nSize);

        //HANDLE WINAPI OpenProcess(
        //  __in  DWORD dwDesiredAccess,
        //  __in  BOOL bInheritHandle,
        //  __in  DWORD dwProcessId
        //);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);

        #endregion


    }
}
