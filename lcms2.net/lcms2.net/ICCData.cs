using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcms2dotnet
{
    public struct ICCData
    {
        public uint Length;
        public uint Flags;
        public Memory<byte> Data;
    }
}
