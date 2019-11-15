using Microsoft.VisualStudio.TestTools.UnitTesting;
using NWin32;
using static NMarshal.Test.CppDll.NativeMethods;

namespace NMarshal.Test
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var pstr = new AutoCharPtr(10);
            WriteString(pstr);
            Assert.AreEqual("a string", pstr.Value);
        }

    }
}
