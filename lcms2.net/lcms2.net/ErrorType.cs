namespace lcms2dotnet
{
    public enum ErrorType
    {
        Undefined = 0,
        File = 1,
        Range = 2,
        Internal = 3,
        Null = 4,
        Read = 5,
        Seek = 6,
        Write = 7,
        UnknownExtension = 8,
        ColorSpaceCheck = 9,
        AlreadyDefined = 10,
        BadSignature = 11,
        CorruptionDetected = 12,
        NotSuitable = 13,
    }
}
