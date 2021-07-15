using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature cmsSigStatusA = 0x53746141;    //'StaA'
        public static readonly Signature cmsSigStatusE = 0x53746145;    //'StaE'
        public static readonly Signature cmsSigStatusI = 0x53746149;    //'StaI'
        public static readonly Signature cmsSigStatusT = 0x53746154;    //'StaT'
        public static readonly Signature cmsSigStatusM = 0x5374614D;    //'StaM'
        public static readonly Signature cmsSigDN = 0x444E2020;         //'DN  '
        public static readonly Signature cmsSigDNP = 0x444E2050;        //'DN P'
        public static readonly Signature cmsSigDNN = 0x444E4E20;        //'DNN '
        public static readonly Signature cmsSigDNNP = 0x444E4E50;       //'DNNP'
    }
}