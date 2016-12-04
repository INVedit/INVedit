using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit
{
	public static class Inventory
	{
		public static void Load(NbtTag inventory, Dictionary<int, ItemSlot> slots)
		{
			try {
				foreach (ItemSlot slot in slots.Values) slot.Item = null;
				foreach (NbtTag tag in inventory) {
					int slot = (byte)tag["Slot"];
					byte count = (byte)tag["Count"];
					if (count == 0) continue;
					if (!slots.ContainsKey(slot)) {
						MessageBox.Show("Unknown slot '"+slot+"', discarded item.",
						                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
					ItemSlot itemSlot = slots[slot];
					itemSlot.Item = new Item(tag);
				}
			} finally { foreach (ItemSlot slot in slots.Values) slot.Refresh(); }
		}
		
		public static void Save(NbtTag parent, Dictionary<int, ItemSlot> slots)
		{
			if (parent.Contains("Inventory")) parent["Inventory"].Remove();
			NbtTag inventory = parent.Add("Inventory", NbtTag.CreateList(NbtTagType.Compound));
			foreach (ItemSlot slot in slots.Values) {
				if (slot.Item == null) continue;
				inventory.Add(slot.Item.tag);
			}
		}
	}
}
