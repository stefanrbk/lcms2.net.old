namespace lcms2dotnet
{
    public struct ICCMeasurementConditions
    {
        public uint Observer; // 0 = unknown, 1=CIE 1931, 2=CIE 1964
        public CIEXYZ Backing;        // Value of backing
        public uint Geometry; // 0=unknown, 1=45/0, 0/45 2=0d, d/0
        public double Flare;   // 0..1.0
        public Illuminant IlluminantType;
    }
}
