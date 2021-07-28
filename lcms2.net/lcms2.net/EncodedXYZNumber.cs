using System;
using System.Runtime.CompilerServices;

namespace lcms2dotnet
{
    public struct EncodedXYZNumber
    {
        public static readonly EncodedXYZNumber D50 = new()
        { 
            X = (Fix16)0.9642, 
            Y = (Fix16)1.0, 
            Z = (Fix16)0.8249 
        };

        public Fix16 X;
        public Fix16 Y;
        public Fix16 Z;
        internal EncodedXYZNumber EndianAdjust(Endian endian)
        {
            var result = this;
            uint temp;
            switch (endian)
            {
                case Endian.Big:
                    temp = Endianness.Big(Unsafe.As<Fix16, uint>(ref result.X));
                    result.X = Unsafe.As<uint, Fix16>(ref temp);
                    temp = Endianness.Big(Unsafe.As<Fix16, uint>(ref result.Y));
                    result.Y = Unsafe.As<uint, Fix16>(ref temp);
                    temp = Endianness.Big(Unsafe.As<Fix16, uint>(ref result.Z));
                    result.Z = Unsafe.As<uint, Fix16>(ref temp);
                    break;
                default:
                    temp = Endianness.Little(Unsafe.As<Fix16, uint>(ref result.X));
                    result.X = Unsafe.As<uint, Fix16>(ref temp);
                    temp = Endianness.Little(Unsafe.As<Fix16, uint>(ref result.Y));
                    result.Y = Unsafe.As<uint, Fix16>(ref temp);
                    temp = Endianness.Little(Unsafe.As<Fix16, uint>(ref result.Z));
                    result.Z = Unsafe.As<uint, Fix16>(ref temp);
                    break;
            }
            return result;
        }
    }
}
