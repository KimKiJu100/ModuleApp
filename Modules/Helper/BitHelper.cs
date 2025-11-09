using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Helper
{
    public static class BitHelper
    {
        public static byte ShiftByteLeft(byte targetByte, int shiftIndex)
        {
            byte resultByte = targetByte;
            resultByte = (byte)(resultByte << shiftIndex);
            return resultByte;
        }
    }
}
