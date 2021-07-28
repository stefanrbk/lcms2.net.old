using System;
using System.Buffers;
using System.IO;

namespace lcms2dotnet.Icc
{
    public class NullIO : IO
    {
        protected int size = 0;
        protected int pos = 0;

        public void Open() =>
            size = pos = 0;
        public override void Close() { }

        internal override int Read8(Span<byte> buf, int num = 1)
        {
            int left = size - pos;
            int read = (num <= left) ? num : left;

            new byte[num].CopyTo(buf);
            pos += read;

            return read;
        }

        internal override int Write8(ReadOnlySpan<byte> buf, int num = 1)
        {
            pos += num;
            if (pos > size)
                size = pos;

            return num;
        }

        internal override int Length => size;

        internal override int Seek(int offset, SeekOrigin origin)
        {
            int _pos = origin switch
            {
                SeekOrigin.Begin => offset,
                SeekOrigin.Current => pos + offset,
                SeekOrigin.End => size + offset,
                _ => 0,
            };

            if (_pos < 0)
                return -1;

            pos = _pos;

            if (pos > size)
                size = pos;

            return pos;
        }

        internal override int Position => pos;
    }
}
