using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NMarshal.FrameworkTest.CppDll.NativeMethods;

namespace NMarshal.FrameworkTest
{
    [TestClass]
    public class CppDllTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var pstr = new AutoCharPtr(10);
            WriteString(pstr);
            Assert.AreEqual("A string", pstr.Value);
        }

    }
}
