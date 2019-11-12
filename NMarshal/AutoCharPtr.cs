using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace NWin32
{
    public class AutoCharPtr : IDisposable
    {
        public StringBuilder Ptr { get; private set; }
        public int Length => Ptr.Capacity;

        public AutoCharPtr(int length) => Ptr = new StringBuilder(length);
        public void Dispose() { }

        public string Value => Ptr.ToString();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static implicit operator StringBuilder(AutoCharPtr @this)
        {
            return @this.Ptr;
        }

    }
}
