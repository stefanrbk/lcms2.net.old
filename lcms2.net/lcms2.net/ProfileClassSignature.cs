using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature InputClass = 0x73636E72;       // 'scnr'
        public static readonly Signature DisplayClass = 0x6D6E7472;     // 'mntr'
        public static readonly Signature OutputClass = 0x70727472;      // 'prtr'
        public static readonly Signature LinkClass = 0x6C696E6B;        // 'link'
        public static readonly Signature AbstractClass = 0x61627374;    // 'abst'
        public static readonly Signature ColorSpaceClass = 0x73706163;  // 'spac'
        public static readonly Signature NamedColorClass = 0x6e6d636c;  // 'nmcl'
    }
}