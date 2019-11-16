using Xunit;
using static NMarshal.Test.CppDll.NativeMethods;

namespace NMarshal.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            using var pstr = new AutoCharPtr(10);
            WriteString(pstr);
            Assert.Equal("a string", pstr.Value);
        }

    }
}
