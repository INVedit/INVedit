using System;
using System.IO;

namespace Minecraft.Utility
{
    public class BigEndianWriter : BinaryWriter
    {
        public BigEndianWriter(Stream output)
            : base(output) {  }
        
        public override void Write(short value)
        {
            Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        public override void Write(int value)
        {
            Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        public override void Write(long value)
        {
            Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        public override void Write(float value)
        {
            Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        public override void Write(double value)
        {
            Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
    }
}
