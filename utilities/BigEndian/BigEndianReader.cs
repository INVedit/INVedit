using System;
using System.IO;

namespace Minecraft.Utility
{
    public class BigEndianReader : BinaryReader
    {
        public BigEndianReader(Stream input)
            : base(input) {  }

        public override short ReadInt16()
        {
            return BitConverter.ToInt16(BigEndianUtilities.IsEndian(ReadBytes(2)), 0);
        }
        public override int ReadInt32()
        {
            return BitConverter.ToInt32(BigEndianUtilities.IsEndian(ReadBytes(4)), 0);
        }
        public override long ReadInt64()
        {
            return BitConverter.ToInt64(BigEndianUtilities.IsEndian(ReadBytes(8)), 0);
        }
        public override float ReadSingle()
        {
            return BitConverter.ToSingle(BigEndianUtilities.IsEndian(ReadBytes(4)), 0);
        }
        public override double ReadDouble()
        {
            return BitConverter.ToDouble(BigEndianUtilities.IsEndian(ReadBytes(8)), 0);
        }
    }
}
