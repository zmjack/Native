using NStandard;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Native.CoreTest
{
    public class SimpleTests
    {
        [Fact]
        public void Test1()
        {
            var intptr = new AutoIntPtr<int>().Then(x => x.Value = 416);
            Assert.Equal(416, intptr.Value);
        }

        [Fact]
        public void Test2()
        {
            AutoIntPtr<byte[]> intptr;

            intptr = new AutoIntPtr<byte[]>(5).Then(x => x.Value = new[] { (byte)20, (byte)12, (byte)4, (byte)16 });
            Assert.Equal(new[] { (byte)20, (byte)12, (byte)4, (byte)16, (byte)0 }, intptr.Value);

            intptr = new AutoIntPtr<byte[]>(2);
            Assert.Throws<ArgumentOutOfRangeException>(() => intptr.Value = new[] { (byte)20, (byte)12, (byte)4, (byte)16 });
        }

    }
}
