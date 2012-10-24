using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;

namespace INVedit
{
	public class Page : TabPage
	{
		static ResourceManager resources;
		static Image head, chest, pants, boots;
		
		GroupBox boxInventory;
		NumericUpDown boxDamage;
		NumericUpDown boxCount;
		
		public ItemSlot selected = null;
		public string file = null;
		public bool world = false;
		public bool changed = false;
		public Dictionary<byte, ItemSlot> slots = new Dictionary<byte, ItemSlot>();
		
		public event Action<ItemSlot> Changed;
		
		public Page()
		{
			UseVisualStyleBackColor = true;
			
			if (resources == null) {
				resources = new ResourceManager("INVedit.Resources", GetType().Assembly);
				head = (Image)resources.GetObject("head");
				chest = (Image)resources.GetObject("chest");
				pants = (Image)resources.GetObject("pants");
				boots = (Image)resources.GetObject("boots");
			}
			
			boxInventory = new GroupBox(){ Text = "Inventory", Location = new Point(6, 6), Size = new Size(461, 285) };
			Controls.Add(boxInventory);
			boxInventory.Controls.Add(new Label(){ Location = new Point(287, 19), Size = new Size(54, 20),
			                          	Text = "Damage:", TextAlign = ContentAlignment.MiddleRight });
			boxInventory.Controls.Add(new Label(){ Location = new Point(287, 44), Size = new Size(54, 20),
			                          	Text = "Count:", TextAlign = ContentAlignment.MiddleRight });
			boxDamage = new NumericUpDown();
			boxDamage.Location = new Point(344, 21);
			boxDamage.Size = new Size(57, 20);
			boxDamage.Minimum = -32657;
			boxDamage.Maximum = 32656;
			boxDamage.TextAlign = HorizontalAlignment.Right;
			boxDamage.Enabled = false;
			boxInventory.Controls.Add(boxDamage);
			boxCount = new NumericUpDown();
			boxCount.Location = new Point(344, 46);
			boxCount.Size = new Size(57, 20);
			boxCount.Minimum = 0;
			boxCount.Maximum = 255;
			boxCount.TextAlign = HorizontalAlignment.Right;
			boxCount.Enabled = false;
			boxInventory.Controls.Add(boxCount);
			
			CreateSlot(103, 7, 19, head);
			CreateSlot(102, 7 + 50, 19, chest);
			CreateSlot(101, 7 + 100, 19, pants);
			CreateSlot(100, 7 + 150, 19, boots);
			for (int i = 0; i < 9; ++i) CreateSlot((byte)(9+i), 7 + i*50, 75);
			for (int i = 0; i < 9; ++i) CreateSlot((byte)(18+i), 7 + i*50, 125);
			for (int i = 0; i < 9; ++i) CreateSlot((byte)(27+i), 7 + i*50, 175);
			for (int i = 0; i < 9; ++i) CreateSlot((byte)i, 7 + i*50, 231);
			
			DeleteItemSlot delete = new DeleteItemSlot(
				(Image)resources.GetObject("delete1"),
				(Image)resources.GetObject("delete2")
			){ Location = new Point(407, 19), UseVisualStyleBackColor = true };
			boxInventory.Controls.Add(delete);
			delete.DeleteDone += delegate {
				boxDamage.Enabled = false;
				boxCount.Enabled = false;
				boxDamage.Value = 0;
				boxCount.Minimum = 0;
				boxCount.Value = 0;
			};
			
			boxDamage.LostFocus += BoxLostFocus;
			boxCount.LostFocus += BoxLostFocus;
			boxDamage.ValueChanged += ValueChanged;
			boxCount.ValueChanged += ValueChanged;
		}
		
		void CreateSlot(byte slot, int x, int y, Image def = null)
		{
			ItemSlot itemSlot = new ItemSlot(slot){
				Location = new Point(x, y), Default = def, UseVisualStyleBackColor = true
			};
			itemSlot.GotFocus += SelectionChanged;
			itemSlot.Changed += (enchantment) => ItemChanged(true, enchantment);
			boxInventory.Controls.Add(itemSlot);
			slots.Add(slot, itemSlot);
		}
		
		void BoxLostFocus(object sender, EventArgs e)
		{
			NumericUpDown box = (NumericUpDown)sender;
			if (box.Text == "") box.Text = "0";
		}
		
		void ValueChanged(object sender, EventArgs e)
		{
			if (selected.Item == null) return;
			NumericUpDown box = (NumericUpDown)sender;
			if (box == boxDamage) selected.Item.Damage = (short)box.Value;
			if (box == boxCount) selected.Item.Count = (byte)box.Value;
			selected.Refresh();
			
			if (!changed) {
				changed = true;
				Text += "*";
				Parent.Parent.Text += "*";
			}
		}
		
		void SelectionChanged(object sender, EventArgs e)
		{
			if (selected != null) {
				selected.Selected = false;
				selected.Refresh();
			}
			selected = (ItemSlot)sender;
			selected.Selected = true;
			
			boxDamage.ValueChanged -= ValueChanged;
			boxCount.ValueChanged -= ValueChanged;
			
			bool enabled = (selected.Item != null);
			boxDamage.Enabled = enabled;
			boxCount.Enabled = enabled;
			boxDamage.Value = enabled ? (int)selected.Item.Damage : 0;
			boxCount.Minimum = enabled ? 1 : 0;
			boxCount.Value = enabled ? (int)selected.Item.Count : 0;
			
			boxDamage.ValueChanged += ValueChanged;
			boxCount.ValueChanged += ValueChanged;
			
			if (Changed != null) Changed(selected);
		}
		
		public void ItemChanged(bool change, bool enchantment = false)
		{
			if (selected != null) {
				if (enchantment)
					selected.Refresh();
				
				boxDamage.ValueChanged -= ValueChanged;
				boxCount.ValueChanged -= ValueChanged;
				
				bool enabled = (selected.Item != null);
				boxDamage.Enabled = enabled;
				boxCount.Enabled = enabled;
				boxDamage.Value = enabled ? (int)selected.Item.Damage : 0;
				boxCount.Minimum = enabled ? 1 : 0;
				boxCount.Value = enabled ? (int)selected.Item.Count : 0;
				
				boxDamage.ValueChanged += ValueChanged;
				boxCount.ValueChanged += ValueChanged;
				
				if (((TabControl)Parent).SelectedTab == this &&
				    Changed != null && !enchantment) Changed(selected);
			}
			
			if (!changed && change) {
				changed = true;
				Text += "*";
				if (((TabControl)Parent).SelectedTab == this)
					Parent.Parent.Text += "*";
			}
		}
	}
}
