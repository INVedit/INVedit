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
					if (Data.items[ID].ContainsKey(Damage.ToString()))
						return Data.items[ID][Damage.ToString()];
					else return Data.items[ID]["0"];
				} else return null;
			}
		}
		
		public NbtTag tag;
		public string ID { get { return (string)tag["id"]; }
			set { tag["id"].Value = value; } }
		public byte Count { get { return (byte)tag["Count"]; }
			set { tag["Count"].Value = value; } }
		public int Slot { get { return (int)tag["Slot"]; }
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
        public bool Brewable  { get {
                return Data.brewable.Contains(ID);
            } }
        public bool Brewed    { get {
                return tag.Contains("tag") && tag["tag"].Contains("CustomPotionEffects");
            } }	

		public Item(NbtTag tag) { this.tag = tag.Clone(); }
		public Item(string id, byte count = 1, int slot = 0, short damage = 0)
		{
			tag = NbtTag.CreateCompound(
				"id", id,
				"Count", count,
				"Slot", slot,
				"Damage", damage);
		}
	}
}
