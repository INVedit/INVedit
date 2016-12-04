using System;
using System.Collections.Generic;

namespace Minecraft.NBT
{
	class NbtTagList : NbtTag
	{
		NbtTagType _type;
		List<NbtTag> _list = new List<NbtTag>();
		
		public override NbtTagType Type {
			get { return NbtTagType.List; }
		}
		
		public override NbtTagType ListType {
			get { return _type; }
			set {
				if (Count != 0)
					throw new InvalidOperationException("Can't change ListType if List isn't empty.");
				if (value < NbtTagType.Byte || value > NbtTagType.Compound)
					throw new ArgumentException("'"+(int)value+"' is not a valid ListType.", "value");
				_type = value;
			}
		}
		public override int Count { get { return _list.Count; } }
		
		public override NbtTag this[int index] {
			get { return _list[index]; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");
				_list[index].Parent = null;
				_list[index] = value.Clone();
				_list[index].Parent = this;
			}
		}
		
		public NbtTagList(NbtTagType type)
		{
			if (type < NbtTagType.End || type > NbtTagType.Compound)
				throw new ArgumentException("'"+(int)type+"' is not a valid ListType.", "type");
			_type = type;
		}
		
		internal override NbtTag Clone()
		{
			NbtTagList list = new NbtTagList(_type);
			foreach (NbtTag tag in this) list.Add(tag);
			return list;
		}
		
		public override NbtTag Add(NbtTag item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
			if (item.Parent != null)
				item = item.Clone();
			_list.Add(item);
			item.Parent = this;
			return item;
		}
		public override NbtTag Insert(int index, NbtTag item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
			if (item.Parent != null)
				item = item.Clone();
			_list.Insert(index, item);
			item.Parent = this;
			return item;
		}
		
		public override int IndexOf(object value)
		{
			for (int i = 0; i < Count; i++)
				if (_list[i].Value == value)
					return i;
			return -1;
		}
		
		protected override void Remove(NbtTag item)
		{
			_list.Remove(item);
			item.Parent = null;
		}
		public override void RemoveAt(int index)
		{
			NbtTag item = this[index];
			item.Parent = null;
			_list.RemoveAt(index);
		}
		public override void Clear()
		{
			foreach (NbtTag item in this)
				item.Parent = null;
			_list.Clear();
		}
		
		public override IEnumerator<NbtTag> GetEnumerator()
		{
			return _list.GetEnumerator();
		}
		
		internal override string ToString(int indent)
		{
			string str = new string(' ', indent*2);
			str += "TAG_List";
			if (Name != null)
				str += "(\""+Name+"\")";
			str += ": "+Count;
			if (Count == 1)
				str += " entry";
			else str += " entries";
			str += " of type ";
			switch (ListType) {
				case NbtTagType.Byte: str += "TAG_Byte"; break;
				case NbtTagType.Short: str += "TAG_Short"; break;
				case NbtTagType.Int: str += "TAG_Int"; break;
				case NbtTagType.Long: str += "TAG_Long"; break;
				case NbtTagType.Float: str += "TAG_Float"; break;
				case NbtTagType.Double: str += "TAG_Double"; break;
				case NbtTagType.ByteArray: str += "TAG_Byte_Array"; break;
				case NbtTagType.String: str += "TAG_String"; break;
				case NbtTagType.List: str += "TAG_List"; break;
				case NbtTagType.Compound: str += "TAG_Compound"; break;
				case NbtTagType.IntArray: str += "TAG_Int_Array"; break;
			}
			if (Count != 0) {
				str += "\n"+new string(' ', indent*2)+"{\n";
				foreach (NbtTag tag in this)
					str += tag.ToString(indent+2)+"\n";
				str += new string(' ', indent*2)+"}";
			}
			return str;
		}
	}
}
