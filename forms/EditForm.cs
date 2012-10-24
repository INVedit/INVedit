using System;
using System.Drawing;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit
{
	public partial class EditForm : Form
	{
		ItemSlot slot;
		int page;
		
		public EditForm()
		{
			InitializeComponent();
		}
		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			CenterToParent();
		}
		
		public void Update(ItemSlot slot)
		{
			boxTitle.TextChanged -= BoxTitleTextChanged;
			boxAuthor.TextChanged -= BoxAuthorTextChanged;
			boxSigned.CheckedChanged -= BoxSignedCheckedChanged;
			boxText.TextChanged -= BoxTextTextChanged;
			
			this.slot = slot;
			Item item = ((slot != null) ? slot.Item : null);
			
			if (item != null && (item.ID == 386 || item.ID == 387)) {
				string title = "";
				string author = "";
				int pages = 0;
				string pageText = "";
				
				if (!item.tag.Contains("tag")) item.tag["tag"] = NbtTag.CreateCompound();
				NbtTag tag = item.tag["tag"];
				if (item.ID == 387) {
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
				pageText = ((string)tag["pages"][page]).Replace("\n", "\r\n");
				
				boxTitle.Text = title;
				boxTitle.Enabled = (item.ID == 387);
				boxAuthor.Text = author;
				boxAuthor.Enabled = (item.ID == 387);
				boxSigned.Checked = (item.ID == 387);
				boxSigned.Enabled = true;
				boxText.Text = pageText;
				boxText.Enabled = true;
				labelPage.Text = "Page " + (page + 1) + " of " + pages;
				btnNext.Enabled = true;
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
			}
			
			boxTitle.TextChanged += BoxTitleTextChanged;
			boxAuthor.TextChanged += BoxAuthorTextChanged;
			boxSigned.CheckedChanged += BoxSignedCheckedChanged;
			boxText.TextChanged += BoxTextTextChanged;
		}
		
		void BtnHelpClick(object sender, EventArgs e)
		{
			MessageBox.Show("It is recommended to edit the contents of books ingame\n" +
			                "instead of INVedit, to make sure everything looks like\n" +
			                "you want and you don't exceed the page's text limit.",
			                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		void BoxTitleTextChanged(object sender, EventArgs e)
		{
			if (slot.Item.ID != 387) return;
			slot.Item.tag["tag"]["title"].Value = boxTitle.Text;
			slot.CallChanged();
		}
		
		void BoxAuthorTextChanged(object sender, EventArgs e)
		{
			if (slot.Item.ID != 387) return;
			slot.Item.tag["tag"]["author"].Value = boxAuthor.Text;
			slot.CallChanged();
		}
		
		void BoxSignedCheckedChanged(object sender, EventArgs e)
		{
			slot.Item.ID = (short)(boxSigned.Checked ? 387 : 386);
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
	}
}
