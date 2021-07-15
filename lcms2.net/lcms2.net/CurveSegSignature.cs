using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature FormulaCurveSeg = 0x70617266;  // 'parf'
        public static readonly Signature SampledCurveSeg = 0x73616d66;  // 'samf'
        public static readonly Signature SegmentedCurve = 0x63757266;   // 'curf'
    }
}