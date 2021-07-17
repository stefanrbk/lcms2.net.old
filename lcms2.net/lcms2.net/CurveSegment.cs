namespace lcms2dotnet
{
    public unsafe struct CurveSegment
    {
        public float X0, X1;
        public int Type;
        public fixed double Params[10];
        public uint NumGridPoints;
        public float[] SampledPoints;
    }
}
