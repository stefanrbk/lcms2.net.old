using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature CurveSetElemType = 0x63767374;         // 'cvst'
        public static readonly Signature MatrixElemType = 0x6D617466;           // 'matf'
        public static readonly Signature CLutElemType = 0x636C7574;             // 'clut'
        public static readonly Signature BAcsElemType = 0x62414353;             // 'bACS'
        public static readonly Signature EAcsElemType = 0x65414353;             // 'eACS'
        // Custom from here, not in the ICC Spec
        public static readonly Signature XYZ2LabElemType = 0x6C327820;          // 'l2x '
        public static readonly Signature Lab2XYZElemType = 0x78326C20;          // 'x2l '
        public static readonly Signature NamedColorElemType = 0x6E636C20;       // 'ncl '
        public static readonly Signature LabV2toV4 = 0x32203420;                // '2 4 '
        public static readonly Signature LabV4toV2 = 0x34203220;                // '4 2 '
        // Identities
        public static readonly Signature IdentityElemType = 0x69646E20;         // 'idn '
        // Float to floatPCS
        public static readonly Signature Lab2FloatPCS = 0x64326C20;             // 'd2l '
        public static readonly Signature FloatPCS2Lab = 0x6C326420;             // 'l2d '
        public static readonly Signature XYZ2FloatPCS = 0x64327820;             // 'd2x '
        public static readonly Signature FloatPCS2XYZ = 0x78326420;             // 'x2d '  
        public static readonly Signature ClipNegativesElemType = 0x636c7020;    // 'clp '
    }
}