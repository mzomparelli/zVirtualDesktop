using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace zVirtualDesktop
{
    public class Window
    {
        private IntPtr _hWnd;

        public IntPtr hWnd
        {
            get
            {
                return hWnd;
            }
            set
            {
                _hWnd = value;
            }
        }

        public string Caption
        { get
            {
                return GetWindowText();
            }
        }

        public string Name
        {
            get
            {
                return GetWindowName();
            }
        }

        public uint ProcessID
        {
            get
            {
                return GetProcessID();
            }
        }

        public Window(IntPtr hWnd)
        {
            this.hWnd = hWnd;
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



    }
}
