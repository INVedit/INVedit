using System;
using System.IO;
using System.Text;

using Minecraft.Utility;

namespace Minecraft.NBT
{
	public class NbtReader
	{
		BigEndianReader _reader;
		
		public NbtReader(Stream stream)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");
			if (!stream.CanRead)
				throw new ArgumentException("Can't read from stream.", "stream");
			_reader = new BigEndianReader(stream);
		}
		
		public NbtTag Read(out string name)
		{
			name = null;
			NbtTagType type = (NbtTagType)_reader.ReadByte();
			if (type == NbtTagType.End) return null;
			short length = _reader.ReadInt16();
			byte[] array = _reader.ReadBytes(length);
			name = Encoding.UTF8.GetString(array);
			return Read(type);
		}
		public NbtTag Read(NbtTagType type)
		{
			switch (type) {
				case NbtTagType.End:
					return null;
				case NbtTagType.Byte:
					return NbtTag.Create(_reader.ReadByte());
				case NbtTagType.Short:
					return NbtTag.Create(_reader.ReadInt16());
				case NbtTagType.Int:
					return NbtTag.Create(_reader.ReadInt32());
				case NbtTagType.Long:
					return NbtTag.Create(_reader.ReadInt64());
				case NbtTagType.Float:
					return NbtTag.Create(_reader.ReadSingle());
				case NbtTagType.Double:
					return NbtTag.Create(_reader.ReadDouble());
				case NbtTagType.ByteArray:
					int length = _reader.ReadInt32();
					return NbtTag.Create(_reader.ReadBytes(length));
				case NbtTagType.String:
					short len = _reader.ReadInt16();
					byte[] array = _reader.ReadBytes(len);
					return NbtTag.Create(Encoding.UTF8.GetString(array));
				case NbtTagType.List:
					NbtTagType listType = (NbtTagType)_reader.ReadByte();
					if (listType < NbtTagType.Byte || listType > NbtTagType.Compound)
						throw new FormatException("'"+(int)type+"' is not a valid ListType.");
					int count = _reader.ReadInt32();
					NbtTag list = NbtTag.CreateList(listType);
					for (int i = 0; i < count; i++)
						list.Add(Read(listType));
					return list;
				case NbtTagType.Compound:
					NbtTag compound = NbtTag.CreateCompound();
					while (true) {
						string name;
						NbtTag item = Read(out name);
						if (item == null) return compound;
						compound.Add(name, item);
					}
				default:
					throw new FormatException("'"+(int)type+"' is not a valid TagType.");
			}
		}
	}
}
