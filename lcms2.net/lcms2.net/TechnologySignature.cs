using System;

namespace lcms2dotnet
{
    public partial struct Signature
    {
        public static readonly Signature DigitalCamera = 0x6463616D;                // 'dcam'
        public static readonly Signature FilmScanner = 0x6673636E;                  // 'fscn'
        public static readonly Signature ReflectiveScanner = 0x7273636E;            // 'rscn'
        public static readonly Signature InkJetPrinter = 0x696A6574;                // 'ijet'
        public static readonly Signature ThermalWaxPrinter = 0x74776178;            // 'twax'
        public static readonly Signature ElectrophotographicPrinter = 0x6570686F;   // 'epho'
        public static readonly Signature ElectrostaticPrinter = 0x65737461;         // 'esta'
        public static readonly Signature DyeSublimationPrinter = 0x64737562;        // 'dsub'
        public static readonly Signature PhotographicPaperPrinter = 0x7270686F;     // 'rpho'
        public static readonly Signature FilmWriter = 0x6670726E;                   // 'fprn'
        public static readonly Signature VideoMonitor = 0x7669646D;                 // 'vidm'
        public static readonly Signature VideoCamera = 0x76696463;                  // 'vidc'
        public static readonly Signature ProjectionTelevision = 0x706A7476;         // 'pjtv'
        public static readonly Signature CRTDisplay = 0x43525420;                   // 'CRT '
        public static readonly Signature PMDisplay = 0x504D4420;                    // 'PMD '
        public static readonly Signature AMDisplay = 0x414D4420;                    // 'AMD '
        public static readonly Signature PhotoCD = 0x4B504344;                      // 'KPCD'
        public static readonly Signature PhotoImageSetter = 0x696D6773;             // 'imgs'
        public static readonly Signature Gravure = 0x67726176;                      // 'grav'
        public static readonly Signature OffsetLithography = 0x6F666673;            // 'offs'
        public static readonly Signature Silkscreen = 0x73696C6B;                   // 'silk'
        public static readonly Signature Flexography = 0x666C6578;                  // 'flex'
        public static readonly Signature MotionPictureFilmScanner = 0x6D706673;     // 'mpfs'
        public static readonly Signature MotionPictureFilmRecorder = 0x6D706672;    // 'mpfr'
        public static readonly Signature DigitalMotionPictureCamera = 0x646D7063;   // 'dmpc'
        public static readonly Signature DigitalCinemaProjector = 0x64636A70;       // 'dcpj'
    }
}