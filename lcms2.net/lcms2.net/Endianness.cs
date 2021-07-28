
using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace lcms2dotnet
{
    internal static class Endianness
    {
        private delegate void Swab(Span<byte> span, int num);

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
        private static readonly Swab swab16;
        private static readonly Swab swab32;
        private static readonly Swab swab64;

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

        public static void Swab16(Span<byte> span, int num = 1) =>
            swab16(span, num);
        public static void Swab32(Span<byte> span, int num = 1) =>
            swab32(span, num);
        public static void Swab64(Span<byte> span, int num = 1) =>
            swab64(span, num);

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

                BigEndULong = BinaryPrimitives.ReverseEndianness;
                BigEndUInt = BinaryPrimitives.ReverseEndianness;
                BigEndUShort = BinaryPrimitives.ReverseEndianness;
                BigEndDouble = SwapEndianness;
                BigEndSingle = SwapEndianness;
                BigEndHalf = SwapEndianness;

                swab16 = Swab16Swap;
                swab32 = Swab32Swap;
                swab64 = Swab64Swap;
            }
            else
            {
                BigEndULong = SameEndianness;
                BigEndUInt = SameEndianness;
                BigEndUShort = SameEndianness;
                BigEndDouble = SameEndianness;
                BigEndSingle = SameEndianness;
                BigEndHalf = SameEndianness;

                LittleEndULong = BinaryPrimitives.ReverseEndianness;
                LittleEndUInt = BinaryPrimitives.ReverseEndianness;
                LittleEndUShort = BinaryPrimitives.ReverseEndianness;
                LittleEndDouble = SwapEndianness;
                LittleEndSingle = SwapEndianness;
                LittleEndHalf = SwapEndianness;

                swab16 = SwabSame;
                swab32 = SwabSame;
                swab64 = SwabSame;
            }
        }

        private static T SameEndianness<T>(T value) => value;
        private static double SwapEndianness(double value) =>
            BinaryPrimitives.ReadDoubleBigEndian(BitConverter.GetBytes(value));
        private static float SwapEndianness(float value) =>
            BinaryPrimitives.ReadSingleBigEndian(BitConverter.GetBytes(value));
        private static Half SwapEndianness(Half value)
        {
            var temp = BinaryPrimitives.ReverseEndianness(Unsafe.As<Half, ushort>(ref value));
            return Unsafe.As<ushort, Half>(ref temp);
        }
        private static void Swab16Swap(Span<byte> span, int num)
        {
            byte tmp;

            while (num > 0)
            {
                tmp = span[0]; span[0] = span[1]; span[1] = tmp;
                span = span[2..]; num--;
            }
        }
        private static void Swab32Swap(Span<byte> span, int num)
        {
            byte tmp;

            while (num > 0)
            {
                tmp = span[0]; span[0] = span[3]; span[3] = tmp;
                tmp = span[1]; span[1] = span[2]; span[2] = tmp;
                span = span[4..]; num--;
            }
        }
        private static void Swab64Swap(Span<byte> span, int num)
        {
            byte tmp;

            while (num > 0)
            {
                tmp = span[0]; span[0] = span[7]; span[7] = tmp;
                tmp = span[1]; span[1] = span[6]; span[6] = tmp;
                tmp = span[2]; span[2] = span[5]; span[5] = tmp;
                tmp = span[3]; span[3] = span[4]; span[4] = tmp;
                span = span[8..]; num--;
            }
        }
        private static void SwabSame(Span<byte> _0, int _1) { }
    }
}
