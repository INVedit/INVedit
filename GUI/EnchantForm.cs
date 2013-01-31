using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit
{
	public partial class EnchantForm : Form
	{
		ItemSlot slot;
		Dictionary<short, Tuple<NbtTag, ListViewItem>> enchantments = new Dictionary<short, Tuple<NbtTag, ListViewItem>>();
		
		public EnchantForm()
		{
			InitializeComponent();
			editId.Text = "";
		}
		
		
		public void Update(ItemSlot slot)
		{
			boxEnchantments.ItemSelectionChanged -= BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged -= EditIdValueChanged;
			boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
			editLevel.ValueChanged -= EditLevelValueChanged;
			
			this.slot = slot;
			boxEnchantments.Items.Clear();
			editId.Text = "";
			boxName.Items.Clear();
			editLevel.Enabled = false;
			editLevel.Value = 0;
			
			if (slot == null || slot.Item == null ||
			    (!slot.Item.Enchantable && !slot.Item.Enchanted && !boxAllow.Checked)) {
				editId.Enabled = false;
				boxName.Enabled = false;
			} else {
				editId.Enabled = boxAllow.Checked;
				boxName.Enabled = (slot.Item.Enchantable || boxAllow.Checked);
				
				var tag = slot.Item.tag;
				foreach (var kvp in Data.enchantments) {
					var enchantment = kvp.Value;
					if (boxAllow.Checked || enchantment.items.Contains((short)tag["id"]))
						boxName.Items.Add(enchantment);
				}
				
				enchantments.Clear();
				if (tag.Contains("tag") && tag["tag"].Contains("ench"))
					foreach (var ench in tag["tag"]["ench"]) {
					short id = (short)ench["id"];
					if (enchantments.ContainsKey(id))
						MessageBox.Show("Duplicate enchantment with ID '"+slot+"' discarded.",
						                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					string name;
					if (Data.enchantments.ContainsKey(id))
						name = Data.enchantments[id].name;
					else name = "Unknown enchantment " + id;
					var listItem = new ListViewItem(new string[]{ name, ((short)ench["lvl"]).ToString() });
					listItem.Tag = id;
					boxEnchantments.Items.Add(listItem);
					enchantments.Add(id, Tuple.Create(ench, listItem));
				}
			}
			
			boxEnchantments.ItemSelectionChanged += BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged += EditIdValueChanged;
			boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
			editLevel.ValueChanged += EditLevelValueChanged;
		}





		
		Data.Enchantment lastEnchantment = null;
		void SelectEnchantment(short id)
		{
			boxEnchantments.ItemSelectionChanged -= BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged -= EditIdValueChanged;
			boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
			editLevel.ValueChanged -= EditLevelValueChanged;
			
			Data.Enchantment enchantment = null;
			if (Data.enchantments.ContainsKey(id))
				enchantment = Data.enchantments[id];
			
			NbtTag tag = null;
			if (enchantments.ContainsKey(id))
				tag = enchantments[id].Item1;
			
			boxEnchantments.SelectedItems.Clear();
			if (enchantments.ContainsKey(id))
				enchantments[id].Item2.Selected = true;
			editId.Value = id; editId.Text = id.ToString();
			if (lastEnchantment != null)
				boxName.Items.Remove(lastEnchantment);
			if (enchantment == null) {
				lastEnchantment = new Data.Enchantment(id, "Unknown enchantment " + id, 0, new List<short>());
				boxName.SelectedIndex = boxName.Items.Add(lastEnchantment);
			} else if (!boxName.Items.Contains(enchantment))
				boxName.SelectedIndex = boxName.Items.Add(enchantment);
			else boxName.Text = enchantment.name;
			
			editLevel.Enabled = boxAllow.Checked || (enchantment != null && enchantment.items.Contains(slot.Item.ID) &&
			                                         (tag == null || (short)tag["lvl"] >= 0 && (short)tag["lvl"] <= enchantment.max));
			
            bool allow = boxAllow.Checked || enchantment == null || (tag != null && ((short)tag["lvl"] < 0 || (short)tag["lvl"] > enchantment.max));
			editLevel.Minimum = allow ? -32768 : 0;
			editLevel.Maximum = allow ? (short)32767 : enchantment.max;
			editLevel.Value = (tag != null) ? (short)tag["lvl"] : (short)0;
			
			boxEnchantments.ItemSelectionChanged += BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged += EditIdValueChanged;
			boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
			editLevel.ValueChanged += EditLevelValueChanged;
		}





		void DeselectEnchantment()
		{
			boxEnchantments.ItemSelectionChanged -= BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged -= EditIdValueChanged;
			boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
			editLevel.ValueChanged -= EditLevelValueChanged;
			
			boxEnchantments.SelectedItems.Clear();
			editId.Value = 0;
			editId.Text = "";
			boxName.SelectedItem = null;
			editLevel.Enabled = false;
			editLevel.Value = 0;
			
			boxEnchantments.ItemSelectionChanged += BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged += EditIdValueChanged;
			boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
			editLevel.ValueChanged += EditLevelValueChanged;
		}


		void ChangeLevel(short level)
		{
			boxEnchantments.ItemSelectionChanged -= BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged -= EditIdValueChanged;
			boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
			editLevel.ValueChanged -= EditLevelValueChanged;
			
			editLevel.Value = level;
			var enchantment = (Data.Enchantment)boxName.SelectedItem;

			if (level != 0) 
            {

                NbtTag tag = null;

                if (slot.Item.ID == 403) //Enchanted Book
                {

                    if (!slot.Item.tag.Contains("tag"))
                        slot.Item.tag.Add("tag", NbtTag.CreateCompound());

                    if (!slot.Item.tag["tag"].Contains("StoredEnchantments"))
                        slot.Item.tag["tag"].Add("StoredEnchantments", NbtTag.CreateList(NbtTagType.Compound));

                    foreach (var ench in slot.Item.tag["tag"]["StoredEnchantments"])
                        if ((short)ench["id"] == enchantment.id) { tag = ench; break; }

                    if (tag == null)
                    {
                        tag = NbtTag.CreateCompound("id", enchantment.id, "lvl", level);

                        slot.Item.tag["tag"]["StoredEnchantments"].Add(tag);

                        var listItem = new ListViewItem(new string[] { enchantment.name, editLevel.Value.ToString() });
                        listItem.Tag = enchantment.id;
                        boxEnchantments.Items.Add(listItem);
                        listItem.Selected = true;
                        enchantments.Add(enchantment.id, Tuple.Create(tag, listItem));
                    }
                    else
                    {
                        tag["lvl"].Value = level;
                        foreach (ListViewItem item in boxEnchantments.Items)
                            if ((short)item.Tag == enchantment.id)
                                item.SubItems[1].Text = editLevel.Value.ToString();
                    }
                }
                else //Any other item.
                {
                    if (!slot.Item.tag.Contains("tag"))
                        slot.Item.tag.Add("tag", NbtTag.CreateCompound());
                    
                    if (!slot.Item.tag["tag"].Contains("ench"))
                        slot.Item.tag["tag"].Add("ench", NbtTag.CreateList(NbtTagType.Compound));
                    
                    foreach (var ench in slot.Item.tag["tag"]["ench"])
                        if ((short)ench["id"] == enchantment.id) { tag = ench; break; }

                    if (tag == null)
                    {
                        tag = NbtTag.CreateCompound(
                            "id", enchantment.id,
                            "lvl", level);
                        slot.Item.tag["tag"]["ench"].Add(tag);
                        var listItem = new ListViewItem(new string[] { enchantment.name, editLevel.Value.ToString() });
                        listItem.Tag = enchantment.id;
                        boxEnchantments.Items.Add(listItem);
                        listItem.Selected = true;
                        enchantments.Add(enchantment.id, Tuple.Create(tag, listItem));
                    }
                    else
                    {
                        tag["lvl"].Value = level;
                        foreach (ListViewItem item in boxEnchantments.Items)
                            if ((short)item.Tag == enchantment.id)
                                item.SubItems[1].Text = editLevel.Value.ToString();
                    }


                }

			} else {

                NbtTag tag = null;
                if (slot.Item.ID == 403) //Enchanted Book
                {
                    foreach (var ench in slot.Item.tag["tag"]["StoredEnchantments"])
                        if ((short)ench["id"] == enchantment.id) { tag = ench; break; }
                    tag.Remove();
                    foreach (ListViewItem item in boxEnchantments.Items)
                        if ((short)item.Tag == enchantment.id) { item.Remove(); break; }
                    if (slot.Item.tag["tag"]["StoredEnchantments"].Count == 0)
                        slot.Item.tag["tag"]["StoredEnchantments"].Remove();
                    if (slot.Item.tag["tag"].Count == 0)
                        slot.Item.tag["tag"].Remove();
                    enchantments.Remove(enchantment.id);

                }
                else //Any other item.
                {
                    foreach (var ench in slot.Item.tag["tag"]["ench"])
                        if ((short)ench["id"] == enchantment.id) { tag = ench; break; }
                    tag.Remove();
                    foreach (ListViewItem item in boxEnchantments.Items)
                        if ((short)item.Tag == enchantment.id) { item.Remove(); break; }
                    if (slot.Item.tag["tag"]["ench"].Count == 0)
                        slot.Item.tag["tag"]["ench"].Remove();
                    if (slot.Item.tag["tag"].Count == 0)
                        slot.Item.tag["tag"].Remove();
                    enchantments.Remove(enchantment.id);
                }
			}

			slot.CallChanged();
			
			boxEnchantments.ItemSelectionChanged += BoxEnchantmentsItemSelectionChanged;
			editId.ValueChanged += EditIdValueChanged;
			boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
			editLevel.ValueChanged += EditLevelValueChanged;
		}
		
		void EditIdValueChanged(object sender, EventArgs e)
		{
			SelectEnchantment((short)editId.Value);
		}
		void BoxNameSelectedIndexChanged(object sender, EventArgs e)
		{
			if (boxName.SelectedItem != null)
				SelectEnchantment(((Data.Enchantment)boxName.SelectedItem).id);
		}
		void BoxEnchantmentsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
				SelectEnchantment((short)e.Item.Tag);
			else DeselectEnchantment();
		}
		
		void EditLevelValueChanged(object sender, EventArgs e)
		{
			ChangeLevel((short)editLevel.Value);
		}
		
		void BoxAllowCheckedChanged(object sender, EventArgs e)
		{
			if (slot == null || slot.Item == null) return;
			
			Data.Enchantment enchantment = null;
			if (Data.enchantments.ContainsKey((short)editId.Value))
				enchantment = Data.enchantments[(short)editId.Value];
			
			editId.Enabled = boxAllow.Checked;
			
			if (enchantment == null && editLevel.Value == 0) {
				DeselectEnchantment();
				return;
			}
			
			boxName.Enabled = (slot.Item.Enchantable || boxAllow.Checked);
			foreach (var kvp in Data.enchantments) {
				var ench = kvp.Value;
				if (boxAllow.Checked || ench.items.Contains(slot.Item.ID)) {
					if (!boxName.Items.Contains(ench)) boxName.Items.Add(ench);
				} else if (boxName.Items.Contains(ench) &&
				           boxName.SelectedItem != ench) boxName.Items.Remove(ench);
			}
			
			if (boxName.SelectedItem == null) return;
			
			editLevel.Enabled = boxAllow.Checked || (enchantment != null && enchantment.items.Contains(slot.Item.ID) &&
			                                         editLevel.Value >= 0 && editLevel.Value <= enchantment.max);
			bool allow = boxAllow.Checked || enchantment == null || editLevel.Value < 0 || editLevel.Value > enchantment.max;
			editLevel.Minimum = allow ? -32768 : 0;
			editLevel.Maximum = allow ? (short)32767 : enchantment.max;
		}
		
		void BoxEnchantmentsKeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode & Keys.Delete) != Keys.Delete ||
			    slot == null || slot.Item == null ||
			    boxName.SelectedItem == null) return;
			ChangeLevel(0);
			DeselectEnchantment();
		}
		
		void BoxEnchantmentsColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			e.Cancel = true;
			e.NewWidth = boxEnchantments.Columns[e.ColumnIndex].Width;
		}

        private void EnchantForm_Load(object sender, EventArgs e)
        {

        }
	}
}
