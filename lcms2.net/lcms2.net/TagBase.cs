namespace lcms2dotnet
{
    public unsafe struct TagBase
    {
        public Signature Signature;
        public fixed byte reserved[4];
    }
}
