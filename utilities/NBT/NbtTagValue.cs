using System;

namespace Minecraft.NBT
{
	class NbtTagValue : NbtTag
	{
		object _value;
		
		public override object Value {
			get { return _value; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");
				NbtTagType type = GetType(value);
				if (type == NbtTagType.End)
					throw new ArgumentException(value.GetType()+" is not a valid TagType.", "value");
				if (Parent != null && Parent.Type == NbtTagType.List && Type != type)
					throw new ArgumentException("Can't change the TagType of a Tag in a List "+
					                            "("+Type+" => "+type+").", "value");
				_value = value;
			}
		}
		public override NbtTagType Type {
			get { return GetType(_value); }
		}
		
		public NbtTagValue(object value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			if (GetType(value) == NbtTagType.End)
				throw new ArgumentException(value.GetType()+" is not a valid TagType.", "value");
			_value = value;
		}
		
		internal override NbtTag Clone()
		{
			return new NbtTagValue(_value);
		}
		
		internal override string ToString(int indent)
		{
			string str = new string(' ', indent*2);
			switch (Type) {
				case NbtTagType.Byte: str += "TAG_Byte"; break;
				case NbtTagType.Short: str += "TAG_Short"; break;
				case NbtTagType.Int: str += "TAG_Int"; break;
				case NbtTagType.Long: str += "TAG_Long"; break;
				case NbtTagType.Float: str += "TAG_Float"; break;
				case NbtTagType.Double: str += "TAG_Double"; break;
				case NbtTagType.ByteArray: str += "TAG_Byte_Array"; break;
				case NbtTagType.String: str += "TAG_String"; break;
			}
			if (Name != null)
				str += "(\""+Name+"\")";
			if (Type == NbtTagType.ByteArray) {
				int length = ((byte[])Value).Length;
				str += ": ["+length;
				if (length == 1)
					str += " byte]";
				else str += " bytes]";
			} else str += ": "+Value;
			return str;
		}
		
		NbtTagType GetType(object value)
		{
			if (value == null)   return NbtTagType.End;
			if (value is byte)   return NbtTagType.Byte;
			if (value is short)  return NbtTagType.Short;
			if (value is int)    return NbtTagType.Int;
			if (value is long)   return NbtTagType.Long;
			if (value is float)  return NbtTagType.Float;
			if (value is double) return NbtTagType.Double;
			if (value is byte[]) return NbtTagType.ByteArray;
			if (value is string) return NbtTagType.String;
			return NbtTagType.End;
		}
	}
}
