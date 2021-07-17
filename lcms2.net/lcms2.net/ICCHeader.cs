namespace lcms2dotnet
{
    public unsafe struct ICCHeader
    {
        public uint size;                          // Profile size in bytes
        public Signature cmmId;                    // CMM for this profile
        public uint version;                       // Format version number
        public Signature deviceClass;              // Type of profile
        public Signature colorSpace;               // Color space of data
        public Signature pcs;                      // PCS, XYZ or Lab only
        public DateTimeNumber date;                // Date profile was created
        public Signature magic;                    // Magic Number to identify an ICC profile
        public Signature platform;                 // Primary Platform
        public uint flags;                         // Various bit settings
        public Signature manufacturer;             // Device manufacturer
        public uint model;                         // Device model number
        public ulong attributes;                   // Device attributes
        public uint renderingIntent;               // Rendering intent
        public EncodedXYZNumber illuminant;        // Profile illuminant
        public Signature creator;                  // Profile creator
        public ProfileID profileID;                // Profile ID using MD5
        public fixed byte reserved[28];            // Reserved for future use

    }
}
