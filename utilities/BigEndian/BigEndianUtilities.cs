using System;
using System.IO;

namespace Minecraft.Utility
{
    public class BigEndianUtilities
    {
        public static byte[] IsEndian(byte[] array)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(array);
            return array;
        }
    }
}
