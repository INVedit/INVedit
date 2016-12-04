using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Minecraft.NBT;


namespace INVedit
{
	public partial class EditForm : Form
	{
		ItemSlot slot;
		int page;
        int BoxFocused = 1;
        const int MAX_LINES = 12; //13//-minus 1 line cause 0 is counted.
        int CurrentLine = 0;
		
		public EditForm()
		{
			InitializeComponent();
		}
		
		
		public void Update(ItemSlot slot)
		{
			boxTitle.TextChanged -= BoxTitleTextChanged;
			boxAuthor.TextChanged -= BoxAuthorTextChanged;
			boxSigned.CheckedChanged -= BoxSignedCheckedChanged;
			boxText.TextChanged -= BoxTextTextChanged;
			
			this.slot = slot;
			Item item = ((slot != null) ? slot.Item : null);





            btnRandom.Enabled = (item != null);
            btnBold.Enabled = (item != null);
            btnStrike.Enabled = (item != null);
            btnUnderline.Enabled = (item != null);
            btnItalic.Enabled = (item != null);
            btnReset.Enabled = (item != null);

            btnPreview.Enabled = (item != null);

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

			
			if (item != null && (item.ID == "minecraft:writable_book" || item.ID == "minecraft:written_book")) {
				string title = "";
				string author = "";
				int pages = 0;
				string pageText = "";
				
				if (!item.tag.Contains("tag")) item.tag["tag"] = NbtTag.CreateCompound();
				NbtTag tag = item.tag["tag"];
				if (item.ID == "minecraft:written_book") {
					if (!tag.Contains("title")) tag.Add("title", "");
					if (!tag.Contains("author")) tag.Add("author", "");
					title = (string)tag["title"];
					author = (string)tag["author"];
				}
				if (!tag.Contains("pages"))
					tag["pages"] = NbtTag.CreateList(NbtTagType.String);
				if (tag["pages"].Count == 0)
					tag["pages"].Add("");
				page = 0;
				pages = tag["pages"].Count;
				pageText = ((string)tag["pages"][page]).Replace("\\n", "\r\n");
                pageText = pageText.Replace("{\"text\":\"",""); // {"text":"1\n2\n3\n4\n5"}
                pageText = pageText.Replace("\"}", "");

				boxTitle.Text = title;
				boxTitle.Enabled = (item.ID == "minecraft:written_book");
				boxAuthor.Text = author;
				boxAuthor.Enabled = (item.ID == "minecraft:written_book");
				boxSigned.Checked = (item.ID == "minecraft:written_book");
				boxSigned.Enabled = true;
				boxText.Text = pageText;
				boxText.Enabled = true;
				labelPage.Text = "Page " + (page + 1) + " of " + pages;
				btnNext.Enabled = true;

                btnRandom.Enabled = true;
                btnBold.Enabled = true;
                btnStrike.Enabled = true;
                btnUnderline.Enabled = true;
                btnItalic.Enabled = true;
                btnReset.Enabled = true;

                btnPreview.Enabled = true;

                btnBlack.Enabled = true;
                btnDarkBlue.Enabled = true;
                btnDarkGreen.Enabled = true;
                btnDarkAqua.Enabled = true;
                btnDarkRed.Enabled = true;
                btnPurple.Enabled = true;
                btnGold.Enabled = true;
                btnGray.Enabled = true;
                btnDarkGray.Enabled = true;
                btnIndigo.Enabled = true;
                btnBrightGreen.Enabled = true;
                btnAqua.Enabled = true;
                btnRed.Enabled = true;
                btnPink.Enabled = true;
                btnYellow.Enabled = true;
                btnWhite.Enabled = true;

            } else {
				boxTitle.Text = "";
				boxTitle.Enabled = false;
				boxAuthor.Text = "";
				boxAuthor.Enabled = false;
				boxSigned.Checked = false;
				boxSigned.Enabled = false;
				boxText.Text = "";
				boxText.Enabled = false;
				labelPage.Text = "Page 0 of 0";
				btnPrevious.Enabled = false;
				btnNext.Enabled = false;
                btnPreview.Enabled = false;



                btnRandom.Enabled = false;
                btnBold.Enabled = false;
                btnStrike.Enabled = false;
                btnUnderline.Enabled = false;
                btnItalic.Enabled = false;
                btnReset.Enabled = false;

                btnPreview.Enabled = false;

                btnBlack.Enabled = false;
                btnDarkBlue.Enabled = false;
                btnDarkGreen.Enabled = false;
                btnDarkAqua.Enabled = false;
                btnDarkRed.Enabled = false;
                btnPurple.Enabled = false;
                btnGold.Enabled = false;
                btnGray.Enabled = false;
                btnDarkGray.Enabled = false;
                btnIndigo.Enabled = false;
                btnBrightGreen.Enabled = false;
                btnAqua.Enabled = false;
                btnRed.Enabled = false;
                btnPink.Enabled = false;
                btnYellow.Enabled = true;
                btnWhite.Enabled = true;


			}
			
			boxTitle.TextChanged += BoxTitleTextChanged;
			boxAuthor.TextChanged += BoxAuthorTextChanged;
			boxSigned.CheckedChanged += BoxSignedCheckedChanged;
			boxText.TextChanged += BoxTextTextChanged;
		}
		

		
		void BoxTitleTextChanged(object sender, EventArgs e)
		{
			if (slot.Item.ID != "minecraft:written_book") return;
			slot.Item.tag["tag"]["title"].Value = boxTitle.Text;
			slot.CallChanged();
		}
		
		void BoxAuthorTextChanged(object sender, EventArgs e)
		{
			if (slot.Item.ID != "minecraft:written_book") return;
			slot.Item.tag["tag"]["author"].Value = boxAuthor.Text;
			slot.CallChanged();
		}
		
		void BoxSignedCheckedChanged(object sender, EventArgs e)
		{
			slot.Item.ID = (string)(boxSigned.Checked ? "minecraft:written_book" : "minecraft:writable_book");
			boxTitle.Enabled = boxSigned.Checked;
			boxAuthor.Enabled = boxSigned.Checked;
			NbtTag tag = slot.Item.tag;
			if (boxSigned.Checked) {
				tag["tag"]["title"] = NbtTag.Create(boxTitle.Text);
				tag["tag"]["author"] = NbtTag.Create(boxAuthor.Text);
			} else {
				tag = tag["tag"];
				tag["title"].Remove();
				tag["author"].Remove();
				boxTitle.Text = "";
				boxAuthor.Text = "";
			}
			slot.CallChanged();
		}
		


		void BoxTextTextChanged(object sender, EventArgs e)
		{

            int Left = (256 - boxText.TextLength);
            lblCharCount.Text = "Chars Left: " + Left;

            CurrentLine = boxText.GetLineFromCharIndex(boxText.SelectionStart);
            lblLine.Text = "Current Line: " + (boxText.GetLineFromCharIndex(boxText.SelectionStart) + 1) + " / 13";


			string text = boxText.Text.Replace("\r\n", "\n");
			NbtTag pages = slot.Item.tag["tag"]["pages"];
			if (text == "") {
				pages[page].Value = text;
				if (page == pages.Count - 1)
					for (int p = page; p > 1; p--) {
					if ((string)pages[p].Value == "")
						pages[p].Remove();
					else break;
				}
			} else {
				while (pages.Count < page + 1)
					pages.Add("");
				pages[page].Value = text;
			}
			slot.CallChanged();

		}
		




		void BtnPreviousClick(object sender, EventArgs e)
		{
			page--;
			if (page <= 0)
				btnPrevious.Enabled = false;
			
			NbtTag pages = slot.Item.tag["tag"]["pages"];
			int pageCount = Math.Max(page + 1, pages.Count);
			labelPage.Text = "Page " + (page + 1) + " of " + pageCount;
			
			boxText.TextChanged -= BoxTextTextChanged;
			boxText.Text = ((page < pages.Count) ? ((string)pages[page].Value).Replace("\n", "\r\n") : "");
			boxText.TextChanged += BoxTextTextChanged;
		}
		
		void BtnNextClick(object sender, EventArgs e)
		{
			page++;
			if (page > 0)
				btnPrevious.Enabled = true;
			
			NbtTag pages = slot.Item.tag["tag"]["pages"];
			int pageCount = Math.Max(page + 1, pages.Count);
			labelPage.Text = "Page " + (page + 1) + " of " + pageCount;
			
			boxText.TextChanged -= BoxTextTextChanged;
			boxText.Text = ((page < pages.Count) ? ((string)pages[page].Value).Replace("\n", "\r\n") : "");
			boxText.TextChanged += BoxTextTextChanged;
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

   
        private void boxTitle_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 1;
        }

        private void boxAuthor_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 2;
        }

        private void boxText_MouseUp(object sender, MouseEventArgs e)
        {
            BoxFocused = 3;
        }



        private void btnRandom_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§k");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§k");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§k");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }



        private void btnBold_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§l");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§l");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§l");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnStrike_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§m");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§m");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§m");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§n");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§n");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§n");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§o");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§o");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§o");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§r");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§r");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§r");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§0");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§0");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§0");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnDarkBlue_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§1");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§1");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§1");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnDarkGreen_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§2");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§2");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§2");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnDarkAqua_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§3");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§3");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§3");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnDarkRed_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§4");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§4");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§4");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§5");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§5");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§5");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§6");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§6");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§6");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§7");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§7");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§7");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnDarkGray_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§8");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§8");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§8");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnIndigo_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§9");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§9");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§9");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnBrightGreen_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§a");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§a");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§a");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§b");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§b");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§b");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§c");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§c");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§c");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§d");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§d");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§d");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§e");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§e");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§e");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            string Text;
            int start = 0;

            if (BoxFocused == 1)
            {
                start = boxTitle.SelectionStart;
                Text = boxTitle.Text;
                Text = Text.Insert(start, "§f");
                boxTitle.Text = Text;
                boxTitle.Focus();
                boxTitle.DeselectAll();
                boxTitle.SelectionStart = start + 2;
            }
            else if (BoxFocused == 2)
            {
                start = boxAuthor.SelectionStart;
                Text = boxAuthor.Text;
                Text = Text.Insert(start, "§f");
                boxAuthor.Text = Text;
                boxAuthor.Focus();
                boxAuthor.DeselectAll();
                boxAuthor.SelectionStart = start + 2;
            }
            else if (BoxFocused == 3)
            {
                start = boxText.SelectionStart;
                Text = boxText.Text;
                Text = Text.Insert(start, "§f");
                boxText.Text = Text;
                boxText.Focus();
                boxText.DeselectAll();
                boxText.SelectionStart = start + 2;
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void boxText_KeyDown(object sender, KeyEventArgs e)
        {

            if (CurrentLine >= MAX_LINES && e.KeyValue == 13)
            {
                e.Handled = true;
                return;
            }


        }




        


        private void boxText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CurrentLine >= MAX_LINES  && e.KeyChar == '\r') 
            {
                e.Handled = true;
            }



            // Get the line count then loop and populate array
            int lineCount = boxText.GetLineFromCharIndex(boxText.Text.Length) + 1;

            // Build array of lines
            string[] lines = new string[lineCount];
            for (int i = 0; i < lineCount; i++)
            {
                int start = boxText.GetFirstCharIndexFromLine(i);
                int end = i < lineCount - 1 ?
                    boxText.GetFirstCharIndexFromLine(i + 1) :
                    boxText.Text.Length;
                lines[i] = boxText.Text.Substring(start, end - start);
            }


            int charCount = 0;

            //if (lineCount >= 13)
            charCount = lines[CurrentLine].Length + 1;

            //Console.WriteLine("Line: " + CurrentLine + "  -  " + "Chars: " + charCount);


            if (charCount >= 20 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                //Console.WriteLine("Suppress");
                e.Handled = true;
                return;
            }

        }

        private void boxText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            int Left = (256 - boxText.TextLength);
            if (boxText.TextLength >= 256)
            {

                if (e.KeyValue == 8)
                {

                }
                else
                {
                    return;
                }
            }

            lblCharCount.Text = "Chars Left: " + Left;

            
        }

        private void boxText_KeyUp(object sender, KeyEventArgs e)
        {
            int Left = (256 - boxText.TextLength);
            lblCharCount.Text = "Chars Left: " + Left;

            lblLine.Text = "Current Line: " + (boxText.GetLineFromCharIndex(boxText.SelectionStart) + 1) + " / 13";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            // Get the line count then loop and populate array
            int lineCount = boxText.GetLineFromCharIndex(boxText.Text.Length) + 1;

            // Build array of lines
            string[] lines = new string[lineCount];
            for (int i = 0; i < lineCount; i++)
            {
                int start = boxText.GetFirstCharIndexFromLine(i);
                int end = i < lineCount - 1 ?
                    boxText.GetFirstCharIndexFromLine(i + 1) :
                    boxText.Text.Length;
                lines[i] = boxText.Text.Substring(start, end - start);
            }


            string CompiledText = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > 2)
                {
                    if (lines[i].Contains("\n"))
                    {
                        CompiledText += lines[i];
                    }
                    else
                    {
                        CompiledText += lines[i] + "\n";
                    }
                }
                else
                {
                    CompiledText += lines[i];
                }
            }


            boxText1.Text = CompiledText;


            BookForm book = new BookForm();
            book.BookText = CompiledText; 
            book.ShowDialog();
        }

        private void boxText_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentLine = boxText.GetLineFromCharIndex(boxText.SelectionStart);
            lblLine.Text = "Current Line: " + (boxText.GetLineFromCharIndex(boxText.SelectionStart) + 1) + " / 13";
        }







	}
}
