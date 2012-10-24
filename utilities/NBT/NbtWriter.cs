using System;
using System.IO;
using System.Text;

using Minecraft.Utility;

namespace Minecraft.NBT
{
    public class NbtWriter
    {
        BigEndianWriter _writer;
        
        public NbtWriter(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanWrite)
                throw new ArgumentException("Can't write to stream.", "stream");
            _writer = new BigEndianWriter(stream);
        }
        
        public void Write(string name, NbtTag tag)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (tag == null)
                throw new ArgumentNullException("tag");
            Write((byte)tag.Type);
            Write(name);
            Write(tag, false);
        }
        public void Write(NbtTag tag)
        {
            Write(tag, true);
        }
        void Write(NbtTag tag, bool writeType)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            if (tag.Type < NbtTagType.Byte || tag.Type > NbtTagType.Compound)
                    throw new FormatException("Unknown TagType '"+(int)tag.Type+"'.");
            if (writeType) Write((byte)tag.Type);
            switch (tag.Type) {
                case NbtTagType.Byte:
                    Write((byte)tag.Value);
                    break;
                case NbtTagType.Short:
                    Write((short)tag.Value);
                    break;
                case NbtTagType.Int:
                    Write((int)tag.Value);
                    break;
                case NbtTagType.Long:
                    Write((long)tag.Value);
                    break;
                case NbtTagType.Float:
                    Write((float)tag.Value);
                    break;
                case NbtTagType.Double:
                    Write((double)tag.Value);
                    break;
                case NbtTagType.ByteArray:
                    Write((byte[])tag.Value);
                    break;
                case NbtTagType.String:
                    Write((string)tag.Value);
                    break;
                case NbtTagType.List:
                    Write((byte)tag.ListType);
                    Write(tag.Count);
                    foreach (NbtTag item in tag)
                        Write(item, false);
                    break;
                case NbtTagType.Compound:
                    foreach(NbtTag item in tag)
                        Write(item.Name, item);
                    Write((byte)NbtTagType.End);
                    break;
            }
        }
        
        void Write(byte value)
        {
            _writer.Write(value);
        }
        void Write(short value)
        {
            _writer.Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        void Write(int value)
        {
            _writer.Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        void Write(long value)
        {
            _writer.Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        void Write(float value)
        {
            _writer.Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        void Write(double value)
        {
            _writer.Write(BigEndianUtilities.IsEndian(BitConverter.GetBytes(value)));
        }
        void Write(byte[] value)
        {
            Write(value.Length);
            _writer.Write(value);
        }
        void Write(string value)
        {
            int length = Encoding.UTF8.GetByteCount(value);
            if (length > short.MaxValue)
                throw new Exception("String too long.");
            Write((short)length);
            _writer.Write(Encoding.UTF8.GetBytes(value));
        }
    }
}
