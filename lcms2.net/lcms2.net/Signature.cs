using System;
using System.Text.Unicode;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        private uint value;

        public static implicit operator Signature(uint value) => 
            new() { value = value };

        public static implicit operator uint(Signature value) => 
            value.value;

        public static explicit operator Signature(string value)
        {
            value = value.PadRight(4, ' ').Substring(0, 4);
            var utf8 = new byte[4];
            Utf8.FromUtf16(value, utf8, out _, out _);
            return BitConverter.ToUInt32(utf8);
        }

        public static explicit operator string(Signature value)
        {
            var utf16 = new char[4];
            Utf8.ToUtf16(BitConverter.GetBytes(value), utf16, out _, out _);
            return new string(utf16);
        }

        public static readonly Signature MagicNumber = 0x61637370;                              // 'ascp'
        public static readonly Signature LCMS = 0x6c636d73;                                     // 'lcms'

        public static readonly Signature PerceptualReferenceMediumGamut = 0x70726d67;           // 'prmg'

        public static readonly Signature SceneColorimetryEstimates = 0x73636f65;                // 'scoe'
        public static readonly Signature SceneAppearanceEstimates = 0x73617065;                 // 'sape'
        public static readonly Signature FocalPlaneColorimetryEstimates = 0x66706365;           // 'fpce'
        public static readonly Signature ReflectionHardcopyOriginalColorimetry = 0x72686f63;    // 'rhoc'
        public static readonly Signature ReflectionPrintOutputColorimetry = 0x72706f63;         // 'rpoc'
    }
}
