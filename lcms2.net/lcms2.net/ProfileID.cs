using System.Runtime.InteropServices;

namespace lcms2dotnet
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ProfileID
    {
        [FieldOffset(0)]
        public fixed byte ID8[16];
        [FieldOffset(0)]
        public fixed ushort ID16[8];
        [FieldOffset(0)]
        public fixed uint ID32[4];

        public enum SaveMethod
        {
            VersionBased,
            AlwaysWrite,
            NeverWrite,
        }
    }
}
