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
                }catch
                {
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
                catch
                {
                    return false;
                }

            }
        }

        public string AppID
        {
            get
            {
                try
                {
                    return ApplicationHelper.GetAppId(hWnd);
                }catch
                {
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
                    
                }catch
                {
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
                catch
                {
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
            }
        }

        public void Pin()
        {
            try
            {
                VirtualDesktop.PinWindow(hWnd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        public void PinApplication()
        {
            try
            {
                VirtualDesktop.PinApplication(AppID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured pinning the specified application. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
            }
        }

        public void MoveToPreviousDesktop()
        {
            if(this.DesktopNumber > 1)
            {
                MoveToDesktop(this.DesktopNumber - 1);
            }
        }

        public void MoveToPreviousDesktop(bool follow)
        {
            if (this.DesktopNumber > 1)
            {
                MoveToDesktop(this.DesktopNumber - 1, follow);
            }
        }

        public void MoveToNextDesktop()
        {
            MoveToDesktop(this.DesktopNumber + 1);
        }

        public void MoveToNextDesktop(bool follow)
        {
            MoveToDesktop(this.DesktopNumber + 1, follow);
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
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured moving the specified window. See additional details below." + Environment.NewLine + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.Source + "::" + ex.TargetSite.Name);
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
                return 1;
            }

        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

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
