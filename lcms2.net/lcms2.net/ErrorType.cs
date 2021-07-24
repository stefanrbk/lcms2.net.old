using Microsoft.Extensions.Logging;

namespace lcms2dotnet
{
    public static class ErrorType
    {
        public static readonly EventId Undefined = new(0);
        public static readonly EventId File = new(1);
        public static readonly EventId Range = new(2);
        public static readonly EventId Internal = new(3);
        public static readonly EventId Null = new(4);
        public static readonly EventId Read = new(5);
        public static readonly EventId Seek = new(6);
        public static readonly EventId Write = new(7);
        public static readonly EventId UnknownExtension = new(8);
        public static readonly EventId ColorSpaceCheck = new(9);
        public static readonly EventId AlreadyDefined = new(10);
        public static readonly EventId BadSignature = new(11);
        public static readonly EventId CorruptionDetected = new(12);
        public static readonly EventId NotSuitable = new(13);
    }
}
