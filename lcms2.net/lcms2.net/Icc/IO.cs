using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcms2dotnet.Icc
{
    public abstract class IO : IDisposable
    {
        private bool disposedValue;

        public abstract void Close();
        internal virtual int Read8(Span<byte> buf, int num = 1) { return 0; }
        internal virtual int Write8(ReadOnlySpan<byte> buf, int num = 1) { return 0; }
        internal virtual int Length => 0;
        internal virtual int Seek(int offset, SeekOrigin origin) => -1;
        internal virtual int Position => 0;

        internal int ReadLine(Span<byte> buf, int num = 256)
        {
            var n = 0;

            while (n < num)
            {
                var c = new byte[1];
                if (Read8(c) is 0)
                    break;
                if (c[0] is (byte)'\n')
                    break;
                else if (c[0] is not (byte)'\r')
                {
                    buf[0] = c[0];
                    buf = buf[1..];
                    n++;
                }
            }
            buf[0] = 0;
            return n;
        }

        internal int Read16(Span<byte> buf, int num = 1)
        {
            num = Read8(buf, num << 1) >> 1;
            Endianness.Swab16(buf, num);

            return num;
        }

        internal int Write16(ReadOnlySpan<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var tmp = new byte[2];
                buf.CopyTo(tmp);
                Endianness.Swab16(tmp);
                if (Write8(tmp, 2) != 2)
                    break;
                buf = buf[2..];
            }
            return i;
        }

        internal int Read32(Span<byte> buf, int num = 1)
        {
            num = Read8(buf, num << 2) >> 2;
            Endianness.Swab32(buf, num);

            return num;
        }

        internal int Write32(ReadOnlySpan<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var tmp = new byte[4];
                buf.CopyTo(tmp);
                Endianness.Swab32(tmp);
                if (Write8(tmp, 4) != 4)
                    break;
                buf = buf[4..];
            }
            return i;
        }

        internal int Read64(Span<byte> buf, int num = 1)
        {
            num = Read8(buf, num << 3) >> 3;
            Endianness.Swab64(buf, num);

            return num;
        }

        internal int Write64(ReadOnlySpan<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var tmp = new byte[8];
                buf.CopyTo(tmp);
                Endianness.Swab64(tmp);
                if (Write8(tmp, 8) != 8)
                    break;
                buf = buf[8..];
            }
            return i;
        }

        internal int Read8Float(Span<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var tmp = new byte[1];
                buf.CopyTo(tmp);
                if (Read8(tmp, 1) != 1)
                    break;
                var value = tmp[0];
                BitConverter.GetBytes(value / 255.0f).CopyTo(buf);
                buf = buf[4..];
            }
            return i;
        }

        internal int Write8Float(ReadOnlySpan<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var value = BitConverter.ToSingle(buf);
                var tmp = new byte[1] {
                    (byte)((Math.Max(0.0f, Math.Min(1.0f, value)) * 255.0f) + 0.5f)
                };
                if (Write8(tmp, 1) != 1)
                    break;
                buf = buf[1..];
            }
            return i;
        }

        internal int Read16Float(Span<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var tmp = new byte[2];
                buf.CopyTo(tmp);
                if (Read16(tmp, 1) != 1)
                    break;
                var value = BitConverter.ToUInt16(tmp);
                BitConverter.GetBytes(value / 65535.0f).CopyTo(buf);
                buf = buf[4..];
            }
            return i;
        }

        internal int Write16Float(ReadOnlySpan<byte> buf, int num = 1)
        {
            int i;
            for (i = 0; i < num; i++)
            {
                var value = BitConverter.ToSingle(buf);
                var tmp = new byte[1] {
                    (byte)((Math.Max(0.0f, Math.Min(1.0f, value)) * 65535.0f) + 0.5f)
                };
                if (Write16(tmp, 1) != 1)
                    break;
                buf = buf[1..];
            }
            return i;
        }

        internal int ReadFloat32Float(Span<byte> buf, int num = 1) =>
            Read32(buf, num);

        internal int WriteFloat32Float(ReadOnlySpan<byte> buf, int num = 1) =>
            Write32(buf, num);

        internal bool Align32()
        {
            int mod = Length % 4;
            if (mod is not 0)
            {
                var buf = new byte[4];
                if (Seek(0, SeekOrigin.End) < 0)
                    return false;
                if (Write8(buf, 4 - mod) != 4 - mod)
                    return false;
            }
            return true;
        }

        internal bool Sync32(int offset)
        {
            offset &= 0x3;

            var pos = ((Position - offset + 3) >> 2) << 2;
            return Seek(pos + offset, SeekOrigin.Current) >= 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
