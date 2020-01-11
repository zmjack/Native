using System.Runtime.InteropServices;
using System.Text;

namespace Native.CoreTest
{
    public static class CppDll
    {
        public partial class NativeMethods
        {
            public const string CPP_DLL = "../../../../x64/Debug/CppDll.dll";

            [DllImport(CPP_DLL)]
            public static extern void WriteString([MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpwstr);
        }
    }
}
