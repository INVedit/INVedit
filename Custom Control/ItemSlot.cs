using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;

namespace INVedit
{
	public class ItemSlot : CheckBox
	{
		static Font font1 = new Font(FontFamily.GenericMonospace, 6, FontStyle.Bold); //8
		static Font font2 = new Font(FontFamily.GenericMonospace, 6, FontStyle.Bold); //10
		protected static Item other = null;
		
		protected static event Action DragBegin = delegate {  };
		protected static event Action DragEnd = delegate {  };
		
		public bool Selected { get; set; }
		public int Slot { get; set; }
		public Item Item { get; set; }
		public Image Default { get; set; }
		
		public event Action<bool> Changed = delegate {  };
		
		public ItemSlot(int slot)
		{
			Slot = slot;
			
			Size = new Size(48, 48);
			
			Appearance = Appearance.Button;
			AllowDrop = true;
			TabStop = false;
		}
		
		internal void CallChanged() { Changed(true); }
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
            LostFocus += OnLostFocus;
            if (Item == null) return;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    
                    //Debug Testing
                    Console.WriteLine(Item.tag.ToString());

                    Checked = true;
                    DragBegin();
                    other = Item;
                    DragDropEffects final = DoDragDrop(Item, DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Link);
                    DragEnd();
                    if (final == DragDropEffects.Move) { Item = other; Changed(false); }
                    Checked = false;
                    break;
                case MouseButtons.Right:
                    // if ItemSlot contains item, set amount to max/damage to zero
                    Item.Count = Item.Stack;
                    if (!Item.Alternative) Item.Damage = 0;
                    // todo: update Damage, Count
                    break;
                default:
                    break;
            }
            Refresh();
		}
		
		void OnLostFocus(object sender, EventArgs e)
		{
			LostFocus -= OnLostFocus;
			Refresh();
		}
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if ((e.KeyCode & Keys.Delete) != Keys.Delete) return;
			if (Item == null) return;
			Item = null;
			Changed(false);
			Refresh();
		}
		
		protected override void OnDragOver(DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Item))) {
				Item item = (Item)e.Data.GetData(typeof(Item));
				if (Item != item) {
					if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) {
						if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
							e.Effect = DragDropEffects.Copy;
						else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt && item.Count > 1) {
							if (Item != null) {
								if (Item.ID == item.ID && Item.Count <= item.Stack)
									e.Effect = DragDropEffects.Link;
								else e.Effect = DragDropEffects.None;
							} else e.Effect = DragDropEffects.Link;
						} else if (Item != null && Item.ID == item.ID &&
						           Item.Damage == item.Damage && Item.Count >= Item.Stack) {
							e.Effect = DragDropEffects.None;
						} else e.Effect = DragDropEffects.Move;
					} else e.Effect = DragDropEffects.Copy;
				} else e.Effect = DragDropEffects.None;
			} else e.Effect = DragDropEffects.None;
		}
		
		protected override void OnDragDrop(DragEventArgs e)
		{
			OnDragOver(e);
			if (e.Effect == DragDropEffects.None) return;
			Item item = (Item)e.Data.GetData(typeof(Item));
			if (e.Effect == DragDropEffects.Link) {
				if (Item == null) {
					Item = new Item(item.tag);
					Item.Slot = Slot;
					Item.Count -= (byte)(item.Count / 2);
					item.Count -= Item.Count;
				} else {
					byte count = Item.Count;
					Item.Count = Math.Min((byte)(count+item.Count/2), (byte)64);
					item.Count -= (byte)(Item.Count-count);
				}
			} else if (e.Effect == DragDropEffects.Move && Item != null && item.ID == Item.ID && Item.Damage == item.Damage) {
				byte count = (byte)Math.Min((int)Item.Count + item.Count, item.Stack);
				byte over = (byte)Math.Max((int)Item.Count + item.Count - item.Stack, 0);
				Item = new Item(Item.tag);
				Item.Slot = Slot;
				Item.Count = count;
				if (over > 0) other.Count = over;
				else other = null;
			} else {
				other = Item; Item = item;
				if (e.Effect == DragDropEffects.Copy) {
					Item = new Item(Item.tag);
					Item.Slot = Slot;
				} else Item.Slot = Slot;
			}
			LostFocus += OnLostFocus;
			try { Changed(false); }
			catch (Exception ex) { MessageBox.Show(ex.ToString()); }
			Focus();
		}
		
		protected override void OnMouseWheel(MouseEventArgs e)
		{
            /*
			if (Item == null) return;
			int count = (((Control.ModifierKeys & Keys.Control) == Keys.Control) ? 4 : 1) * Math.Sign(e.Delta);
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
				int before = Item.Damage;
				if (Item.MaxDamage > 0)
					Item.Damage = (short)Math.Min(Math.Max((int)Item.Damage + Math.Max(Math.Abs(count*(int)Item.MaxDamage/32), 1) * -Math.Sign(count), 0), Item.MaxDamage);
				else if (Item.Alternative) {
					Dictionary<string, Data.Item> items = Data.items[Item.ID];
					List<string> list = new List<string>(items.Keys);
					int index = list.IndexOf(Item.Damage.ToString());
					if (index == -1) return;
					if (count > 0) { if (index < list.Count-1) Item.Damage = list[index+1]; }
					else { if (index > 0) Item.Damage = list[index-1]; }
				} if (before == Item.Damage) return;
			} else {
				if (Item.Stack==1) return;
				int before = Item.Count;
				if (Item.Count == 1 && count == 4) count = 3;
				Item.Count = (byte)Math.Min(Math.Max((int)Item.Count + count, 1), Item.Stack);
				if (before == Item.Count) return;
			}
			Changed(false);
			Refresh();
             */
		}

        //int test = 20;
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			Graphics g = e.Graphics;
			if (Selected) using (Pen pen = new Pen(Color.Black)) { g.DrawRectangle(pen, 4, 4, Width-9, Height-9); }
			
			Image image = Default;
			if (Item != null) image = Item.Image;
			if (image == null) return;
			
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;


            //if (test == 180) { test = 20;}
            //test = test + 10; ;



            //Enchanted
			if (Item != null && Item.Enchanted)
				g.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.SlateBlue)), 5, 5, Width-10, Height-10);
			
			g.DrawImage(image, ClientSize.Width/2-16, ClientSize.Height/2-16, 32, 32);
			
			if (Item == null) return;
			
			if (!Item.Known) {
				string value = Item.ID.ToString();
				Color color1 = Color.Black;
				Color color2 = Color.White;
				DrawString3(g, color1, 0, -1, value);
				DrawString3(g, color1, 1, -1, value);
				DrawString3(g, color1, -1, 0, value);
				DrawString3(g, color1, 2, 0, value);
				DrawString3(g, color1, 0, 1, value);
				DrawString3(g, color1, 1, 1, value);
				DrawString3(g, color2, 0, 0, value);
				DrawString3(g, color2, 1, 0, value);
			}
			
			if (Item.Count > 1) {
				string value = Item.Count.ToString();
				Color color1 = Color.Black;
				Color color2 = Color.White;
				if (Item.Count > Item.Stack)
					color1 = Color.FromArgb(172, 0, 0);
				DrawString2(g, color1, 3, 1, value);
				DrawString2(g, color1, 4, 1, value);
				DrawString2(g, color1, 2, 2, value);
				DrawString2(g, color1, 5, 2, value);
				DrawString2(g, color1, 3, 3, value);
				DrawString2(g, color1, 4, 3, value);
				DrawString2(g, color2, 3, 2, value);
				DrawString2(g, color2, 4, 2, value);
			}
			if (Data.items.ContainsKey(Item.ID) &&
			    !Data.items[Item.ID].ContainsKey(Item.Damage.ToString())) {
				if (Item.Damage > 0 && Item.Damage <= Item.MaxDamage && Item.MaxDamage > 0) {
					Rectangle rect = new Rectangle(5, ClientSize.Height-8, ClientSize.Width-10, 3);
					g.FillRectangle(new SolidBrush(Color.Black), rect);
					byte b = (byte)(Item.Damage*255/Item.MaxDamage);
					Color color = Color.FromArgb(b, 255-b, 0);
					int width = (int)((1-(double)Item.Damage/Item.MaxDamage)*(ClientSize.Width-10));
					rect = new Rectangle(5, ClientSize.Height-8, width, 3);
					g.FillRectangle(new SolidBrush(color), rect);
				} else {
					string value = Math.Abs((int)Item.Damage).ToString();
					Color color1 = Color.FromArgb(56, 0, 0);
					Color color2 = Color.FromArgb(240, 0, 0);
					if (Item.Damage < 0) {
						color1 = Color.FromArgb(0, 56, 0);
						color2 = Color.FromArgb(0, 212, 0);
					}
					DrawString(g, color1, 3, 1, value);
					DrawString(g, color1, 4, 1, value);
					DrawString(g, color1, 2, 2, value);
					DrawString(g, color1, 5, 2, value);
					DrawString(g, color1, 3, 3, value);
					DrawString(g, color1, 4, 3, value);
					DrawString(g, color2, 3, 2, value);
					DrawString(g, color2, 4, 2, value);
				}
			}
		}
		
		void DrawString(Graphics g, Color color, int x, int y, string text)
		{
			g.DrawString(text, font1, new SolidBrush(color), x+2, y+1);
		}
		void DrawString2(Graphics g, Color color, int x, int y, string text)
		{
			StringFormat format = new StringFormat(){
				Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };
			g.DrawString(text, font2, new SolidBrush(color), ClientSize.Width-x, ClientSize.Width-y, format);
		}
		void DrawString3(Graphics g, Color color, int x, int y, string text)
		{
			StringFormat format = new StringFormat(){
				Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
			g.DrawString(text, font1, new SolidBrush(color), ClientSize.Width/2+x, ClientSize.Width/2+y, format);
		}
	}
}
