using Xunit;
using static Native.CoreTest.CppDll.NativeMethods;

namespace Native.CoreTest
{
    public class CppDllTests
    {
        [Fact]
        public void TestMethod1()
        {
            using var pstr = new AutoCharPtr(10);
            WriteString(pstr);
            Assert.Equal("string...", pstr.Value);
        }

    }
}
