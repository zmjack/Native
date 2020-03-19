using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Native.FrameworkTest.CppDll.NativeMethods;

namespace Native.FrameworkTest
{
    [TestClass]
    public class CppDllTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var pstr = new AutoCharPtr(10);
            WriteString(pstr);
            Assert.AreEqual("string...", pstr.Value);
        }

    }
}
