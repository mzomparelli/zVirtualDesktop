using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zVirtualDesktop
{
    public class COMProgram
    {
        string progID = "";
        string exe = "";


        public COMProgram(string progID, string exe)
        {
            this.progID = progID;
            this.exe = exe;
        }
    }
}
