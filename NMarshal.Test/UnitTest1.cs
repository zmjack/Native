using Microsoft.VisualStudio.TestTools.UnitTesting;
using NWin32;
using System.Runtime.InteropServices;
using System.Text;
using static NMarshal.Test.NativeMethods;

namespace NMarshal.Test
{
    public class NativeMethods
    {
        [DllImport("CppDll.dll")]
        public static extern void WriteString([MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpwstr);
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var autoPtr = new AutoCharPtr(20);
            WriteString(autoPtr);
            Assert.AreEqual("a string", autoPtr.Value);
        }

    }
}
