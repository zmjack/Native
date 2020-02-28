using System;
using System.Collections.Generic;
using System.Text;

namespace NMarshal._extern.NStandard
{
    public static class XObject
    {
        /// <summary>
        /// Convert a basic struct to another basic struct with same memory sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static object As(this object @this, Type type)
        {
            var bytes = @this switch
            {
                char t => BitConverter.GetBytes(t),
                bool t => BitConverter.GetBytes(t),
                byte t => BitConverter.GetBytes(t),
                sbyte t => BitConverter.GetBytes(t),
                short t => BitConverter.GetBytes(t),
                ushort t => BitConverter.GetBytes(t),
                int t => BitConverter.GetBytes(t),
                uint t => BitConverter.GetBytes(t),
                long t => BitConverter.GetBytes(t),
                ulong t => BitConverter.GetBytes(t),
                float t => BitConverter.GetBytes(t),
                double t => BitConverter.GetBytes(t),
                _ => throw new NotSupportedException(),
            };

            switch (type)
            {
                case Type t when t == typeof(char): return BitConverter.ToChar(bytes, 0);
                case Type t when t == typeof(bool): return BitConverter.ToBoolean(bytes, 0);
                case Type t when t == typeof(byte): return bytes[0];
                case Type t when t == typeof(sbyte): return (sbyte)bytes[0];
                case Type t when t == typeof(short): return BitConverter.ToInt16(bytes, 0);
                case Type t when t == typeof(ushort): return BitConverter.ToUInt16(bytes, 0);
                case Type t when t == typeof(int): return BitConverter.ToInt32(bytes, 0);
                case Type t when t == typeof(uint): return BitConverter.ToUInt32(bytes, 0);
                case Type t when t == typeof(long): return BitConverter.ToInt64(bytes, 0);
                case Type t when t == typeof(ulong): return BitConverter.ToUInt64(bytes, 0);
                case Type t when t == typeof(float): return BitConverter.ToSingle(bytes, 0);
                case Type t when t == typeof(double): return BitConverter.ToDouble(bytes, 0);
                default: throw new NotSupportedException();
            };
        }

    }
}
