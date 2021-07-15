using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature Macintosh = 0x4150504C;    // 'APPL'
        public static readonly Signature Microsoft = 0x4D534654;    // 'MSFT'
        public static readonly Signature Solaris = 0x53554E57;      // 'SUNW'
        public static readonly Signature SGI = 0x53474920;          // 'SGI '
        public static readonly Signature Taligent = 0x54474E54;     // 'TGNT'
        public static readonly Signature Unices = 0x2A6E6978;       // '*nix'
    }
}