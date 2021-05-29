using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Native
{
    public class AutoCharPtr : IDisposable
    {
        private bool disposedValue;

        public StringBuilder Ptr { get; private set; }
        public int Length => Ptr.Capacity;

        public AutoCharPtr(int length) => Ptr = new StringBuilder(length);

        public string Value => Ptr.ToString();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static implicit operator StringBuilder(AutoCharPtr @this)
        {
            return @this.Ptr;
        }

        public override string ToString() => Value;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AutoCharPtr()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
