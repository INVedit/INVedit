using System;
using System.Collections.Generic;

namespace Minecraft.NBT
{
	class NbtTagCompound : NbtTag
	{
		Dictionary<string, NbtTag> _dict = new Dictionary<string, NbtTag>();
		
		public override NbtTagType Type {
			get { return NbtTagType.Compound; }
		}
		
		public override int Count { get { return _dict.Count; } }
		
		public override NbtTag this[string key] {
			get { return _dict[key]; }
			set {
				if (key == null)
					throw new ArgumentNullException("key");
				if (value == null)
					throw new ArgumentNullException("value");
				if (Contains(key)) Remove(_dict[key]);
				if (value.Parent != null)
					value = value.Clone();
				Add(key, value);
			}
		}
		
		internal override NbtTag Clone()
		{
			NbtTagCompound compound = new NbtTagCompound();
			foreach (NbtTag tag in this) compound.Add(tag.Name, tag);
			return compound;
		}
		
		public override NbtTag Add(string key, NbtTag item)
		{
			if (key == null)
				throw new ArgumentNullException("key");
			if (item == null)
				throw new ArgumentNullException("item");
			if (item.Parent != null)
				item = item.Clone();
			_dict.Add(key, item);
			item._name = key;
			item.Parent = this;
			return item;
		}
		
		public override bool Contains(string key)
		{
			return _dict.ContainsKey(key);
		}
		
		protected override void Remove(NbtTag item)
		{
			_dict.Remove(item.Name);
			item._name = null;
			item.Parent = null;
		}
		public override void Clear()
		{
			foreach (NbtTag item in this) {
				item._name = null;
				item.Parent = null;
			}
			_dict.Clear();
		}
		
		public override IEnumerator<NbtTag> GetEnumerator()
		{
			return _dict.Values.GetEnumerator();
		}
		
		internal override string ToString(int indent)
		{
			string str = new string(' ', indent*2);
			str += "TAG_Compound";
			if (Name != null)
				str += "(\""+Name+"\")";
			str += ": "+Count;
			if (Count == 1)
				str += " entry";
			else str += " entries";
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
