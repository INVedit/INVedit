using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Text;

using System.Drawing.Drawing2D;

using System.IO;
using System.Net;

using Minecraft.NBT;


namespace INVedit
{
	public partial class ItemDataForm : Form
	{



        //Get Player Skin
        //http://www.minecraft.net/skin/DHIteration.png

		ItemSlot slot;
        int BoxFocused = 1;
		
		public ItemDataForm()
		{
			InitializeComponent();
		}
		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			//CenterToParent();
		}
		
		public void Update(ItemSlot slot)
		{
			boxName.TextChanged -= BoxNameTextChanged;
			boxLore.TextChanged -= BoxLoreTextChanged;
			boxColor.TextChanged -= BoxColorTextChanged;
			boxPlayer.TextChanged -= BoxPlayerTextChanged;
			
			this.slot = slot;
			Item item = ((slot != null) ? slot.Item : null);
			
			boxName.Text = "";
			boxLore.Text = "";
			boxColor.Text = "";
			panelColor.BackColor = Color.Transparent;
			boxPlayer.Text = "";
			
			boxName.Enabled = (item != null);
			boxLore.Enabled = (item != null);
			boxColor.Enabled = (item != null && (item.ID == 298 || item.ID == 299 || item.ID == 300 || item.ID == 301));
			
            panelColor.Enabled = boxColor.Enabled;
			boxPlayer.Enabled = (item != null && item.ID == 397);
            btnPreview.Enabled = (item != null && item.ID == 397);

            btnRandom.Enabled = (item != null);
            btnBold.Enabled = (item != null);
            btnStrike.Enabled = (item != null);
            btnUnderline.Enabled = (item != null);
            btnItalic.Enabled = (item != null);
            btnReset.Enabled = (item != null);

            btnBlack.Enabled = (item != null);
            btnDarkBlue.Enabled = (item != null);
            btnDarkGreen.Enabled = (item != null);
            btnDarkAqua.Enabled = (item != null);
            btnDarkRed.Enabled = (item != null);
            btnPurple.Enabled = (item != null);
            btnGold.Enabled = (item != null);
            btnGray.Enabled = (item != null);
            btnDarkGray.Enabled = (item != null);
            btnIndigo.Enabled = (item != null);
            btnBrightGreen.Enabled = (item != null);
            btnAqua.Enabled = (item != null);
            btnRed.Enabled = (item != null);
            btnPink.Enabled = (item != null);
            btnYellow.Enabled = (item != null);
            btnWhite.Enabled = (item != null);



			
			if (item != null && item.tag.Contains("tag")) {
				var tag = item.tag["tag"];
				if (tag.Contains("display")) {
					var display = tag["display"];
					if (display.Contains("Name"))
						boxName.Text = (string)display["Name"];
					if (display.Contains("Lore"))
						boxLore.Lines = display["Lore"].Select((t) => (string)t).ToArray();
					if (boxColor.Enabled && display.Contains("color")) {
						int c = (int)display["color"];
						Color color = Color.FromArgb(c >> 16, (c >> 8) & 0xFF, c & 0xFF);
						boxColor.Text = (color.ToArgb() & 0xFFFFFF).ToString("X6");
						panelColor.BackColor = color;
					}
				}
				if (boxPlayer.Enabled && tag.Contains("SkullOwner"))
					boxPlayer.Text = (string)tag["SkullOwner"];
			}
			
			boxName.TextChanged += BoxNameTextChanged;
			boxLore.TextChanged += BoxLoreTextChanged;
			boxColor.TextChanged += BoxColorTextChanged;
			boxPlayer.TextChanged += BoxPlayerTextChanged;
		}
		

		
		void BoxNameTextChanged(object sender, EventArgs e)
		{
			var tag = (slot.Item.tag.Contains("tag") ? slot.Item.tag["tag"] : null);
			var display = ((tag != null && tag.Contains("display")) ? tag["display"] : null);
			var name = boxName.Text;
			if (name != "") {
				if (tag == null) {
					tag = NbtTag.CreateCompound();
					slot.Item.tag.Add("tag", tag);
				}
				if (display == null) {
					display = NbtTag.CreateCompound();
					tag.Add("display", display);
				}
				if (display.Contains("Name"))
					display["Name"].Value = name;
				else display.Add("Name", name);
			} else display["Name"].Remove();
			slot.CallChanged();
		}
		
		void BoxLoreTextChanged(object sender, EventArgs e)
		{
			var tag = (slot.Item.tag.Contains("tag") ? slot.Item.tag["tag"] : null);
			var display = ((tag != null && tag.Contains("display")) ? tag["display"] : null);
			if (boxLore.Text != "") {
				if (tag == null) {
					tag = NbtTag.CreateCompound();
					slot.Item.tag.Add("tag", tag);
				}
				if (display == null) {
					display = NbtTag.CreateCompound();
					tag.Add("display", display);
				}
				var lore = (display.Contains("Lore") ? display["Lore"] : null);
				if (lore == null) {
					lore = NbtTag.CreateList(NbtTagType.String);
					display.Add("Lore", lore);
				} else lore.Clear();
				lore.Add(boxLore.Lines);
			} else display["Lore"].Remove();
			slot.CallChanged();
		}
		
		void PanelColorClick(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.Cancel) return;
			var color = colorDialog.Color;
			boxColor.Text = (color.ToArgb() & 0xFFFFFF).ToString("X6");
		}
		
		void BoxColorTextChanged(object sender, EventArgs e)
		{
			Color color;
			if (!ValidateColor(boxColor.Text, out color)) return;
			if (color == panelColor.BackColor) return;
			panelColor.BackColor = color;
			
			int c = color.ToArgb() & 0xFFFFFF;
			
			var tag = (slot.Item.tag.Contains("tag") ? slot.Item.tag["tag"] : null);
			var display = ((tag != null && tag.Contains("display")) ? tag["display"] : null);
			if (color != Color.Transparent) {
				if (tag == null) {
					tag = NbtTag.CreateCompound();
					slot.Item.tag.Add("tag", tag);
				}
				if (display == null) {
					display = NbtTag.CreateCompound();
					tag.Add("display", display);
				}
				if (display.Contains("color"))
					display["color"].Value = c;
				else display.Add("color", c);
			} else display["color"].Remove();
			slot.CallChanged();
		}
		
		void BoxPlayerTextChanged(object sender, EventArgs e)
		{
			var tag = (slot.Item.tag.Contains("tag") ? slot.Item.tag["tag"] : null);
			var player = boxPlayer.Text;
			if (player != "") {
				if (tag == null) {
					tag = NbtTag.CreateCompound();
					slot.Item.tag.Add("tag", tag);
				}
				if (tag.Contains("SkullOwner"))
					tag["SkullOwner"].Value = player;
				else tag.Add("SkullOwner", player);
			} else tag["SkullOwner"].Remove();
			slot.CallChanged();
		}
		
		bool ValidateColor(string str, out Color color)
		{
			color = Color.Transparent;
			if (str == "") return true;
			if (str.Length != 6) return false;
			int c;
			if (!int.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c)) return false;
			color = Color.FromArgb(c >> 16, (c >> 8) & 0xFF, c & 0xFF);
			return true;
		}





        private void boxColor_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 0;
        }

        private void boxPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 0;
        }

        private void panelColor_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 0;
        }

        private void boxName_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 1;
        }

        private void boxLore_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 2;
        }

        private void ItemDataForm_Load(object sender, EventArgs e)
        {
            //Have to do it this way cause some how SharpDevelop Screwed the Resources.
            picCharHead.Image = INVedit.Resources.steve;
            btnPreview.Image = INVedit.Resources.preview;
        }



        private void btnRandom_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§k");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§k");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }










        private void btnBold_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§l");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§l");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnStrike_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§m");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§m");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§n");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§n");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§o");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§o");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§r");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§r");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§0");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§0");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnDarkBlue_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§1");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§1");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnDarkGreen_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§2");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§2");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnDarkAqua_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§3");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§3");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnDarkRed_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§4");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§4");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§5");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§5");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§6");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§6");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§7");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§7");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnDarkGray_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§8");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§8");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnIndigo_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§9");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§9");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnBrightGreen_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§a");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§a");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§b");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§b");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§c");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§c");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§d");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§d");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§e");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§e");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxName.SelectionStart;
                Text = boxName.Text;
                Text = Text.Insert(start, "§f");
                boxName.Text = Text;
                boxName.Focus();
                boxName.DeselectAll();
                boxName.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxLore.SelectionStart;
                Text = boxLore.Text;
                Text = Text.Insert(start, "§f");
                boxLore.Text = Text;
                boxLore.Focus();
                boxLore.DeselectAll();
                boxLore.SelectionStart = start + 2;
            }
        }
















        private byte[] downloadData(string url)
        {
            byte[] downloadedData;
            downloadedData = new byte[0];

            try
            {
                Application.DoEvents();

                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                byte[] buffer = new byte[1024];
                int dataLength = (int)response.ContentLength;

                Application.DoEvents();

                MemoryStream memStream = new MemoryStream();

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        Application.DoEvents();
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }

                downloadedData = memStream.ToArray();

                stream.Close();
                memStream.Close();

                return downloadedData;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error accessing the Minecraft skin server. " + ex.Message);
                return null;
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (boxPlayer.Text == "")
            {
                MessageBox.Show("Please select a player name before trying to preview the skin.", "Select Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnPreview.Enabled = false;

            byte[] imageData = downloadData("http://www.minecraft.net/skin/" + boxPlayer.Text + ".png"); //DownloadData function from here

            if (imageData == null)
            {
                picCharHead.Image = INVedit.Resources.steve;
                btnPreview.Enabled = true;
                return;
            }
            
            MemoryStream stream = new MemoryStream(imageData);
            Image img = Image.FromStream(stream);
            stream.Close();


            
            Bitmap sourceBitmap = new Bitmap(img, img.Width, img.Height);
            Graphics g = picCharHead.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(sourceBitmap, new Rectangle(0, 0, 60, 60), new Rectangle(8, 8, 8, 8), GraphicsUnit.Pixel);
            sourceBitmap.Dispose();

            btnPreview.Enabled = true;


        }


        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(52 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        private void tmrRnd_Tick(object sender, EventArgs e)
        {
            btnRandom.Text = RandomString(9).ToLower();
        }

        private void panelColor_Paint(object sender, PaintEventArgs e)
        {

        }
        
	}
}
