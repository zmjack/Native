using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NMarshal.FrameworkTest.CppDll.NativeMethods;

namespace NMarshal.FrameworkTest
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
