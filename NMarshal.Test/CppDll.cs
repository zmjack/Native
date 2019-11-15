using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NMarshal.Test
{
    public static class CppDll
    {
        public partial class NativeMethods
        {
            public const string CPP_DLL = "../../../CppDll/bin/Debug/CppDll.dll";

            [DllImport(CPP_DLL)]
            public static extern void WriteString([MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpwstr);
        }
    }
}
