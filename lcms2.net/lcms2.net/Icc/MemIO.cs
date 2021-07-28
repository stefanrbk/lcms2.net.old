using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;

namespace lcms2dotnet.Icc
{
    public class MemIO : IO
    {
        protected byte[]? data = null;
        protected int size = 0;
        protected int avail = 0;
        protected int pos = 0;

        bool freeData = false;

        public Span<byte> Data =>
            new(data, 0, size);

        public bool Alloc(int size, bool write = false)
        {
            if (data is not null)
                Close();

            var _data = ArrayPool<byte>.Shared.Rent(size);

            if (!Attach(_data, size, write))
            {
                ArrayPool<byte>.Shared.Return(_data);
                return false;
            }

            freeData = true;

            return true;
        }

        public bool Attach(byte[] data, int size, bool write)
        {
            ref var _data = ref this.data;
            ref var _size = ref this.size;

            if (data is null)
                return false;

            if (_data is not null)
                Close();

            _data = data;
            pos = 0;

            if (write)
            {
                avail = size;
                _size = 0;
            }
            else
                avail = _size = size;

            return true;
        }

        public override void Close()
        {
            if (data is not null)
            {
                if (freeData)
                {
                    ArrayPool<byte>.Shared.Return(data);
                    freeData = false;
                }
                data = null;
            }
        }

        internal override int Read8(Span<byte> buf, int num = 1)
        {
            if (data is null)
                return 0;

            num = Math.Min(size - pos, num);

            new Span<byte>(data, pos, num).CopyTo(buf);
            pos += num;

            return num;
        }

        internal override int Write8(ReadOnlySpan<byte> buf, int num = 1)
        {
            if (data is null)
                return 0;

            num = Math.Min(size - pos, num);

            buf.CopyTo(new Span<byte>(data, pos, num));
            pos += num;
            if (pos > size)
                size = pos;

            return num;
        }

        internal override int Length =>
            data is null
                ? 0
                : size;

        internal override int Seek(int offset, SeekOrigin origin)
        {
            if (data is null)
                return -1;

            var _pos = origin switch
            {
                SeekOrigin.Begin => offset,
                SeekOrigin.Current => pos + offset,
                SeekOrigin.End => size + offset,
                _ => 0
            };

            if (_pos < 0)
                return -1;

            if (_pos > size && size != avail && _pos <= avail)
            {
                Unsafe.InitBlock(ref data[size], 0, (uint)(_pos - size));
                size = _pos;
            }
            if (_pos > size)
                return -1;

            pos = _pos;

            return _pos;
        }

        internal override int Position =>
            data is null
                ? -1
                : pos;
    }
}
