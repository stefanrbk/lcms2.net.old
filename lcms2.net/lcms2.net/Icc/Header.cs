using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace lcms2dotnet.Icc
{
    public unsafe struct Header
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

        public static Header Read(Stream stream)
        {
            var logger = ICCProfile.logger;

            var headerBytes = new byte[sizeof(Header)];
            stream.Read(headerBytes, 0, sizeof(Header));

            var result = Unsafe.ReadUnaligned<Header>(ref headerBytes[0]);

            result = result.EndianAdjust(Endian.Big);

            return result;
        }

        public void Write(Stream stream)
        {
            var headerBytes = new byte[sizeof(Header)];

            var header = EndianAdjust(Endian.Big);
            Unsafe.WriteUnaligned(ref headerBytes[0], header);

            stream.Write(headerBytes, 0, sizeof(Header));
        }

        private Header EndianAdjust(Endian endian)
        {
            var result = this;
            switch (endian)
            {
                case Endian.Big:
                    result.size = Endianness.Big(size);
                    result.cmmId = Endianness.Big(cmmId);
                    result.version = Endianness.Big(version);
                    result.deviceClass = Endianness.Big(deviceClass);
                    result.colorSpace = Endianness.Big(colorSpace);
                    result.pcs = Endianness.Big(pcs);
                    result.magic = Endianness.Big(magic);
                    result.platform = Endianness.Big(platform);
                    result.flags = Endianness.Big(flags);
                    result.manufacturer = Endianness.Big(manufacturer);
                    result.model = Endianness.Big(model);
                    result.attributes = Endianness.Big(attributes);
                    result.renderingIntent = Endianness.Big(renderingIntent);
                    result.illuminant = result.illuminant.EndianAdjust(endian);
                    result.creator = Endianness.Big(creator);
                    break;
                default:
                    result.size = Endianness.Little(size);
                    result.cmmId = Endianness.Little(cmmId);
                    result.version = Endianness.Little(version);
                    result.deviceClass = Endianness.Little(deviceClass);
                    result.colorSpace = Endianness.Little(colorSpace);
                    result.pcs = Endianness.Little(pcs);
                    result.magic = Endianness.Little(magic);
                    result.platform = Endianness.Little(platform);
                    result.flags = Endianness.Little(flags);
                    result.manufacturer = Endianness.Little(manufacturer);
                    result.model = Endianness.Little(model);
                    result.attributes = Endianness.Little(attributes);
                    result.renderingIntent = Endianness.Little(renderingIntent);
                    result.illuminant = result.illuminant.EndianAdjust(endian);
                    result.creator = Endianness.Little(creator);
                    break;
            }
            return result;
        }
    }
}
