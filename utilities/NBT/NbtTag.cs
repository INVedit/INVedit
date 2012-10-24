using System;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;

namespace Minecraft.NBT
{
	public abstract class NbtTag : IEnumerable<NbtTag>
	{
		internal string _name;
		
		public NbtTag Parent { get; internal set; }
		
		public string Name {
			get { return _name; }
			set { Rename(value); }
		}
		
		public abstract NbtTagType Type { get; }
		
		public virtual object Value {
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}
		
		internal NbtTag() {  }
		
		void Rename(string name)
		{
			if (name == null)
				throw new ArgumentNullException("value");
			if (name == _name) return;
			if (Parent == null || Parent.Type != NbtTagType.Compound)
				throw new Exception("Can't change the name of a Tag not in a Compound.");
			if (Parent.Contains(name))
				throw new Exception("This key is already present in the Tag's Parent.");
			Parent.Remove(this);
			Parent.Add(name, this);
		}
		
		public void Remove()
		{
			if (Parent == null)
				throw new Exception("This Tag has no parent.");
			Parent.Remove(this);
		}
		
		internal abstract NbtTag Clone();
		
		#region Load and Save
		public static NbtTag Load(string path, bool compressed = true)
		{
			string name;
			return Load(path, out name, compressed);
		}
		public static NbtTag Load(string path, out string name, bool compressed = true)
		{
			NbtTag tag;
			using (Stream stream = File.OpenRead(path))
				tag = Read(stream, out name, compressed);
			if (tag == null || tag.Type != NbtTagType.Compound)
				throw new FormatException("Root tag has to be Compound.");
			return tag;
		}
		public static NbtTag Read(Stream stream, bool compressed = false)
		{
			string name;
			return Read(stream, out name, compressed);
		}
		public static NbtTag Read(Stream stream, out string name, bool compressed = false)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");
			if (!stream.CanRead)
				throw new ArgumentException("Can't read from stream.", "stream");
			NbtTag tag;
			if (compressed)
				using (Stream gz = new GZipStream(stream, CompressionMode.Decompress))
					tag = new NbtReader(gz).Read(out name);
			else tag = new NbtReader(stream).Read(out name);
			return tag;
		}
		
		public void Save(string path, string name = "", bool compress = true)
		{
			if (Type != NbtTagType.Compound)
				throw new NotSupportedException();
			using (Stream stream = File.OpenWrite(path))
				Write(stream, name, compress);
		}
		public void Write(Stream stream, string name = "", bool compress = false)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");
			if (!stream.CanWrite)
				throw new ArgumentException("Can't write to stream.", "stream");
			if (compress)
				using (Stream gz = new GZipStream(stream, CompressionMode.Compress))
					new NbtWriter(gz).Write(name, this);
			else new NbtWriter(stream).Write(name, this);
		}
		#endregion
		
		#region Creating Tags
		public static NbtTag Create(object value)
		{
			return new NbtTagValue(value);
		}
		public static NbtTag CreateList(NbtTagType type)
		{
			return new NbtTagList(type);
		}
		public static NbtTag CreateList(NbtTagType type, params object[] values)
		{
			NbtTag list = new NbtTagList(type);
			list.Add(values);
			return list;
		}
		public static NbtTag CreateCompound()
		{
			return new NbtTagCompound();
		}
		public static NbtTag CreateCompound(params object[] values)
		{
			NbtTag compound = new NbtTagCompound();
			compound.Add(values);
			return compound;
		}
		public static NbtTag CreateCompound(string[] keys, object[] values)
		{
			NbtTag compound = new NbtTagCompound();
			compound.Add(keys, values);
			return compound;
		}
		#endregion
		
		#region List/Compound members
		public virtual NbtTagType ListType {
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}
		public virtual int Count {
			get { throw new NotSupportedException(); }
		}
		
		public virtual NbtTag this[int index] {
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}
		public virtual NbtTag this[string key] {
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}
		
		public void Add(params object[] values)
		{
			if (values == null)
				throw new ArgumentNullException("values");
			if (this is NbtTagList)
				foreach (object value in values)
					Add(value);
			else if (this is NbtTagCompound) {
				if (values.Length % 2 != 0)
					throw new ArgumentException("The number of keys and values has to be equal.");
				for (int i = 0; i < values.Length; i += 2)
					Add((string)values[i], values[i+1]);
			} else throw new NotSupportedException();
		}
		public void Add(string[] keys, object[] values)
		{
			if (keys == null)
				throw new ArgumentNullException("keys");
			if (values == null)
				throw new ArgumentNullException("values");
			if (!(this is NbtTagCompound))
				throw new NotSupportedException();
			if (keys.Length != values.Length)
				throw new ArgumentException("The number of keys and values has to be equal.");
			for (int i = 0; i < keys.Length; i++)
				Add(keys[0], values[i]);
		}
		public NbtTag Add(object value)
		{
			if (value is NbtTag)
				return Add((NbtTag)value);
			return Add(new NbtTagValue(value));
		}
		public virtual NbtTag Add(NbtTag item)
		{
			throw new NotSupportedException();
		}
		public NbtTag Add(string key, object value)
		{
			if (value is NbtTag)
				return Add(key, (NbtTag)value);
			return Add(key, new NbtTagValue(value));
		}
		public virtual NbtTag Add(string key, NbtTag value)
		{
			throw new NotSupportedException();
		}
		public NbtTag Insert(int index, object value)
		{
			if (value is NbtTag)
				return Insert(index, (NbtTag)value);
			return Insert(index, new NbtTagValue(value));
		}
		public virtual NbtTag Insert(int index, NbtTag item)
		{
			throw new NotSupportedException();
		}
		
		public virtual bool Contains(string key)
		{
			throw new NotSupportedException();
		}
		public virtual int IndexOf(object value)
		{
			throw new NotSupportedException();
		}
		
		protected virtual void Remove(NbtTag item)
		{
			throw new NotSupportedException();
		}
		public virtual void RemoveAt(int index)
		{
			throw new NotSupportedException();
		}
		public virtual void Clear()
		{
			throw new NotSupportedException();
		}
		
		public virtual IEnumerator<NbtTag> GetEnumerator()
		{
			throw new NotSupportedException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
		
		#region ToString()
		public override sealed string ToString()
		{
			return ToString(0);
		}
		
		internal abstract string ToString(int indent);
		#endregion
		
		#region Operators
		public static explicit operator byte(NbtTag tag)
		{
			return (byte)tag.Value;
		}
		public static explicit operator short(NbtTag tag)
		{
			return (short)tag.Value;
		}
		public static explicit operator int(NbtTag tag)
		{
			return (int)tag.Value;
		}
		public static explicit operator long(NbtTag tag)
		{
			return (long)tag.Value;
		}
		public static explicit operator float(NbtTag tag)
		{
			return (float)tag.Value;
		}
		public static explicit operator double(NbtTag tag)
		{
			return (double)tag.Value;
		}
		public static explicit operator byte[](NbtTag tag)
		{
			return (byte[])tag.Value;
		}
		public static explicit operator string(NbtTag tag)
		{
			return (string)tag.Value;
		}
		#endregion
	}
}
