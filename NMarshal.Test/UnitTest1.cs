using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NWin32;
using static NMarshal.Test.NativeMethods;

namespace NMarshal.Test
{
    public class NativeMethods
    {
        public const string CppDll = "../../../CppDll/bin/Debug/CppDll.dll";

        [DllImport(CppDll, EntryPoint = "writeString", CharSet = CharSet.Auto)]
        public static extern void WriteString([Out] [MarshalAs(UnmanagedType.LPStr)]StringBuilder ptr);
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
