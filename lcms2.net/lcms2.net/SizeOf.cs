using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcms2dotnet
{
    internal static class SizeOf
    {
        public const int Signature = sizeof(uint);
        public const int TagInfo = (sizeof(uint) * 2) + Signature;
    }
}
