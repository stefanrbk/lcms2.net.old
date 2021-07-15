using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature ChromaticityType = 0x6368726D;             // 'chrm'
        public static readonly Signature ColorantOrderType = 0x636C726F;            // 'clro'
        public static readonly Signature ColorantTableType = 0x636C7274;            // 'clrt'
        public static readonly Signature CrdInfoType = 0x63726469;                  // 'crdi'
        public static readonly Signature CurveType = 0x63757276;                    // 'curv'
        public static readonly Signature DataType = 0x64617461;                     // 'data'
        public static readonly Signature DictType = 0x64696374;                     // 'dict'
        public static readonly Signature DateTimeType = 0x6474696D;                 // 'dtim'
        public static readonly Signature DeviceSettingsType = 0x64657673;           // 'devs'
        public static readonly Signature Lut16Type = 0x6d667432;                    // 'mft2'
        public static readonly Signature Lut8Type = 0x6d667431;                     // 'mft1'
        public static readonly Signature LutAtoBType = 0x6d414220;                  // 'mAB '
        public static readonly Signature LutBtoAType = 0x6d424120;                  // 'mBA '
        public static readonly Signature MeasurementType = 0x6D656173;              // 'meas'
        public static readonly Signature MultiLocalizedUnicodeType = 0x6D6C7563;    // 'mluc'
        public static readonly Signature MultiProcessElementType = 0x6D706574;      // 'mpet'
        [Obsolete("Use ncl2 if possible")]
        public static readonly Signature NamedColorType = 0x6E636f6C;               // 'ncol'
        public static readonly Signature NamedColor2Type = 0x6E636C32;              // 'ncl2'
        public static readonly Signature ParametricCurveType = 0x70617261;          // 'para'
        public static readonly Signature ProfileSequenceDescType = 0x70736571;      // 'pseq'
        public static readonly Signature ProfileSequenceIdType = 0x70736964;        // 'psid'
        public static readonly Signature ResponseCurveSet16Type = 0x72637332;       // 'rcs2'
        public static readonly Signature S15Fixed16ArrayType = 0x73663332;          // 'sf32'
        public static readonly Signature ScreeningType = 0x7363726E;                // 'scrn'
        public static readonly Signature SignatureType = 0x73696720;                // 'sig '
        public static readonly Signature TextType = 0x74657874;                     // 'text'
        public static readonly Signature TextDescriptionType = 0x64657363;          // 'desc'
        public static readonly Signature U16Fixed16ArrayType = 0x75663332;          // 'uf32'
        public static readonly Signature UcrBgType = 0x62666420;                    // 'bfd '
        public static readonly Signature UInt16ArrayType = 0x75693136;              // 'ui16'
        public static readonly Signature UInt32ArrayType = 0x75693332;              // 'ui32'
        public static readonly Signature UInt64ArrayType = 0x75693634;              // 'ui64'
        public static readonly Signature UInt8ArrayType = 0x75693038;               // 'ui08'
        public static readonly Signature VcgtType = 0x76636774;                     // 'vcgt'
        public static readonly Signature ViewingConditionsType = 0x76696577;        // 'view'
        public static readonly Signature XYZType = 0x58595A20;                      // 'XYZ '
    }
}