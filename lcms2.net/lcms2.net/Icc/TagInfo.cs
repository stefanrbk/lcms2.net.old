using System.IO;
using System.Runtime.CompilerServices;

namespace lcms2dotnet.Icc
{
    public struct TagInfo
    {
        public Signature Signature;
        public uint Offset;
        public uint Size;

        public static TagInfo Read(Stream stream)
        {
            var bytes = new byte[SizeOf.TagInfo];
            stream.Read(bytes, 0, SizeOf.TagInfo);

            var result = Unsafe.ReadUnaligned<TagInfo>(ref bytes[0]);

            result = result.EndianAdjust(Endian.Big);

            return result;
        }

        public void Write(Stream stream)
        {
            var bytes = new byte[SizeOf.TagInfo];

            var tagEntry = EndianAdjust(Endian.Big);
            Unsafe.WriteUnaligned(ref bytes[0], tagEntry);

            stream.Write(bytes, 0, SizeOf.TagInfo);
        }

        private TagInfo EndianAdjust(Endian endian)
        {
            var result = this;

            switch (endian)
            {
                case Endian.Big:
                    result.Offset = Endianness.Big(result.Offset);
                    result.Size = Endianness.Big(result.Size);
                    result.Signature = Endianness.Big(result.Signature);
                    break;
                default:
                    result.Offset = Endianness.Little(result.Offset);
                    result.Size = Endianness.Little(result.Size);
                    result.Signature = Endianness.Little(result.Signature);
                    break;
            }
            return result;
        }
    }
}
