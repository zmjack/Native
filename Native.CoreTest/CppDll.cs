using System.Runtime.InteropServices;
using System.Text;

namespace Native.CoreTest
{
    public static class CppDll
    {
        public partial class NativeMethods
        {
            [DllImport("CppDll.dll")]
            public static extern void WriteString([MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpwstr);
        }
    }
}
