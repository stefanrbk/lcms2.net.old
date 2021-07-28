using System;
using System.IO;

namespace lcms2dotnet.Icc
{
    public class FileIO : IO
    {
        protected FileStream? file = null;

        public bool Open(string path, FileAccess access)
        {
            try
            {
                if (file is not null)
                    file.Close();

                file = File.Open(path, FileMode.Open, access);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override void Close()
        {
            if (file is not null)
            {
                file.Close();
                file = null;
            }
        }

        internal override int Read8(Span<byte> buf, int num = 1)
        {
            buf = buf.Slice(0, num);

            return file is null
                ? 0
                : file.Read(buf);
        }

        internal override int Write8(ReadOnlySpan<byte> buf, int num = 1)
        {
            buf = buf.Slice(0, num);

            if (file is null)
                return 0;

            var pos = file.Position;
            file.Write(buf);

            return (int)(file.Position - pos);
        }

        internal override int Length => 
            file is null 
                ? 0 
                : (int)file.Length;

        internal override int Seek(int offset, SeekOrigin origin)
        {
            if (file is null)
                return -1;
            try
            {
                return (int)file.Seek(offset, origin);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        internal override int Position => 
            file is null
                ? -1
                : (int)file.Position;
    }
}
