using System;
using System.Drawing;
using Minecraft.NBT;

namespace INVedit
{
	public class Item
	{
		Data.Item item {
			get {
				if (Data.items.ContainsKey(ID)) {
					if (Data.items[ID].ContainsKey(Damage))
						return Data.items[ID][Damage];
					else return Data.items[ID][0];
				} else return null;
			}
		}
		
		public NbtTag tag;
		public short ID { get { return (short)tag["id"]; }
			set { tag["id"].Value = value; } }
		public byte Count { get { return (byte)tag["Count"]; }
			set { tag["Count"].Value = value; } }
		public byte Slot { get { return (byte)tag["Slot"]; }
			set { tag["Slot"].Value = value; } }
		public short Damage { get { return (short)tag["Damage"]; }
			set { tag["Damage"].Value = value; } }
		
		public bool Known { get { return (item != null); } }
		public bool Alternative { get {
				if (!Known) return false;
				return (Data.items[ID].Count > 1);
			} }
		public string Name { get {
				if (!Known) return "Unknown item "+ID;
				return item.name;
			} }
		public byte Stack { get {
				if (!Known) return 64;
				return item.stack;
			} }
		public byte Preferred { get {
				if (!Known) return 64;
				return item.preferred;
			} }
		public short MaxDamage { get {
				if (!Known) return 0;
				return item.maxDamage;
			} }
		public Image Image { get {
				if (!Known) return Data.unknown;
				return Data.list.Images[item.imageIndex];
			} }
		public bool Enchantable { get {
				return Data.enchantable.Contains(ID);
			} }
		public bool Enchanted { get {
				return tag.Contains("tag") && tag["tag"].Contains("ench");
			} }
		
		public Item(NbtTag tag) { this.tag = tag.Clone(); }
		public Item(short id, byte count = 1, byte slot = 0, short damage = 0)
		{
			tag = NbtTag.CreateCompound(
				"id", id,
				"Count", count,
				"Slot", slot,
				"Damage", damage);
		}
	}
}
