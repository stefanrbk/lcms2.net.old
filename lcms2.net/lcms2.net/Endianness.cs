
using System;
using System.Runtime.CompilerServices;

namespace lcms2dotnet
{
    internal static class Endianness
    {
        private static readonly Func<ulong, ulong> BigEndULong;
        private static readonly Func<uint, uint> BigEndUInt;
        private static readonly Func<ushort, ushort> BigEndUShort;
        private static readonly Func<double, double> BigEndDouble;
        private static readonly Func<float, float> BigEndSingle;
        private static readonly Func<Half, Half> BigEndHalf;
        private static readonly Func<ulong, ulong> LittleEndULong;
        private static readonly Func<uint, uint> LittleEndUInt;
        private static readonly Func<ushort, ushort> LittleEndUShort;
        private static readonly Func<double, double> LittleEndDouble;
        private static readonly Func<float, float> LittleEndSingle;
        private static readonly Func<Half, Half> LittleEndHalf;

        public static ulong Big(ulong value) =>
            BigEndULong(value);
        public static uint Big(uint value) =>
            BigEndUInt(value);
        public static ushort Big(ushort value) =>
            BigEndUShort(value);
        public static double Big(double value) =>
            BigEndDouble(value);
        public static float Big(float value) =>
            BigEndSingle(value);
        public static Half Big(Half value) =>
            BigEndHalf(value);
        public static ulong Little(ulong value) =>
            LittleEndULong(value);
        public static uint Little(uint value) =>
            LittleEndUInt(value);
        public static ushort Little(ushort value) =>
            LittleEndUShort(value);
        public static double Little(double value) =>
            LittleEndDouble(value);
        public static float Little(float value) =>
            LittleEndSingle(value);
        public static Half Little(Half value) =>
            LittleEndHalf(value);

        static Endianness()
        {
            if (BitConverter.IsLittleEndian)
            {
                LittleEndULong = SameEndianness;
                LittleEndUInt = SameEndianness;
                LittleEndUShort = SameEndianness;
                LittleEndDouble = SameEndianness;
                LittleEndSingle = SameEndianness;
                LittleEndHalf = SameEndianness;

                BigEndULong = SwapEndianness;
                BigEndUInt = SwapEndianness;
                BigEndUShort = SwapEndianness;
                BigEndDouble = SwapEndianness;
                BigEndSingle = SwapEndianness;
                BigEndHalf = SwapEndianness;
            }
            else
            {
                BigEndULong = SameEndianness;
                BigEndUInt = SameEndianness;
                BigEndUShort = SameEndianness;
                BigEndDouble = SameEndianness;
                BigEndSingle = SameEndianness;
                BigEndHalf = SameEndianness;

                LittleEndULong = SwapEndianness;
                LittleEndUInt = SwapEndianness;
                LittleEndUShort = SwapEndianness;
                LittleEndDouble = SwapEndianness;
                LittleEndSingle = SwapEndianness;
                LittleEndHalf = SwapEndianness;
            }
        }

        private static ulong SwapEndianness(ulong value) =>
            ((value & 0xff00000000000000) >> 56) | ((value & 0x00ff000000000000) >> 48) | ((value & 0x0000ff0000000000) >> 40) | ((value & 0x000000ff00000000) >> 32) | ((value & 0x00000000ff000000) >> 24) | ((value & 0x0000000000ff0000) >> 16) | ((value & 0x000000000000ff00) >> 8) | (value & 0x00000000000000ff);
        private static ulong SameEndianness(ulong value) => value;
        private static uint SwapEndianness(uint value) =>
            ((value & 0xff000000) >> 24) | ((value & 0x00ff0000) >> 16) | ((value & 0x0000ff00) >> 8) | (value & 0x000000ff);
        private static uint SameEndianness(uint value) => value;
        private static ushort SwapEndianness(ushort value) =>
            (ushort)(((value & 0xff00u) >> 8) | (value & 0x00ffu));
        private static ushort SameEndianness(ushort value) => value;
        private static double SwapEndianness(double value) =>
            BitConverter.Int64BitsToDouble((long)SwapEndianness((ulong)BitConverter.DoubleToInt64Bits(value)));
        private static double SameEndianness(double value) => value;
        private static float SwapEndianness(float value) =>
            BitConverter.Int32BitsToSingle((int)SwapEndianness((uint)BitConverter.SingleToInt32Bits(value)));
        private static float SameEndianness(float value) => value;
        private static Half SwapEndianness(Half value)
        {
            var temp = SwapEndianness(Unsafe.As<Half, ushort>(ref value));
            return Unsafe.As<ushort, Half>(ref temp);
        }
        private static Half SameEndianness(Half value) => value;
    }
}
