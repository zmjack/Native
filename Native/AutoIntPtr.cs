using Native.external.NStandard;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Native
{
    public class AutoIntPtr<TValue> : IDisposable
    {
        public IntPtr Ptr { get; private set; }
        public int Length { get; private set; }

        public Type ManagedType { get; private set; }
        public Type ElementType { get; private set; }
        private readonly Array ArrayBuffer;

        public AutoIntPtr() : this(0) { }
        public AutoIntPtr(int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException($"The argument(`length`) must be greater than 0.");

            ManagedType = typeof(TValue);
            if (ManagedType.IsArray)
            {
                Length = length;
                ElementType = ManagedType.GetElementType();
                ArrayBuffer = Array.CreateInstance(ElementType, length);
            }
            else Length = Marshal.SizeOf(typeof(TValue));

            Ptr = Marshal.AllocHGlobal(Length);
        }

        public void Dispose() => Marshal.FreeHGlobal(Ptr);

        public static implicit operator IntPtr(AutoIntPtr<TValue> @this) => @this.Ptr;

        public static implicit operator TValue(AutoIntPtr<TValue> @this) => @this.Value;

        public TValue Value
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (ManagedType.IsValueType)
                    return (TValue)Marshal.PtrToStructure(Ptr, typeof(TValue));
                else
                {
                    if (ManagedType == typeof(byte[]))
                    {
                        var buffer = new byte[Length];
                        Marshal.Copy(Ptr, buffer, 0, buffer.Length);
                        return (TValue)(object)buffer;
                    }
                    else throw new NotSupportedException();
                }
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (ManagedType.IsValueType)
                    Marshal.StructureToPtr(value, Ptr, true);
                else
                {
                    if (ManagedType.IsArray)
                    {
                        ElementType = ManagedType.GetElementType();
                        byte[] buffer = ElementType switch
                        {
                            Type _ when ElementType == typeof(byte) => (byte[])(object)value,
                            Type _ when ElementType == typeof(sbyte) => ((sbyte[])(object)value).Select(x => (byte)x).ToArray(),
                            Type _ when ElementType == typeof(char) => ((char[])(object)value).Select(x => (byte)x).ToArray(),
                            _ => throw new NotSupportedException(),
                        };
                        WriteToUnmanaged(buffer);
                    }
                    else throw new NotSupportedException();
                }
            }
        }

        private void ZeroBuffer()
        {
            for (int i = 0; i < Length; i++)
                ArrayBuffer.SetValue(0.As(ElementType), i);
        }

        private void WriteToUnmanaged(Array buffer)
        {
            if (buffer.Length > Length)
                throw new ArgumentOutOfRangeException(nameof(buffer), $"Buffer length({buffer.Length}) overflow. (Allowed length:{Length})");

            ZeroBuffer();
            Buffer.BlockCopy(buffer, 0, ArrayBuffer, 0, buffer.Length);

            switch (ElementType)
            {
                case Type _ when ElementType == typeof(byte): Marshal.Copy(ArrayBuffer as byte[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(sbyte): Marshal.Copy((ArrayBuffer as sbyte[]).Select(x => (byte)x).ToArray(), 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(char): Marshal.Copy(ArrayBuffer as char[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(short): Marshal.Copy(ArrayBuffer as short[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(ushort): Marshal.Copy((ArrayBuffer as ushort[]).Select(x => (short)x).ToArray(), 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(int): Marshal.Copy(ArrayBuffer as int[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(uint): Marshal.Copy((ArrayBuffer as uint[]).Select(x => (int)x).ToArray(), 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(long): Marshal.Copy(ArrayBuffer as long[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(ulong): Marshal.Copy((ArrayBuffer as ulong[]).Select(x => (long)x).ToArray(), 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(float): Marshal.Copy(ArrayBuffer as float[], 0, Ptr, Length); break;
                case Type _ when ElementType == typeof(double): Marshal.Copy(ArrayBuffer as double[], 0, Ptr, Length); break;
                default: throw new NotSupportedException();
            }
        }

        public override string ToString() => Value.ToString();

    }
}
