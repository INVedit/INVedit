using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Net;
using System.ComponentModel;
using System.Diagnostics;

using Minecraft.NBT;

namespace INVedit
{
	public partial class MainForm : Form
	{
		static string appdata;
		static MainForm() {
			if (Platform.Current == Platform.Windows)
				appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft";
			else if (Platform.Current == Platform.Mac)
				appdata = Environment.GetEnvironmentVariable("HOME") + "/Library/Application Support/minecraft";
			else
				appdata = Environment.GetEnvironmentVariable("HOME") + "/.minecraft";
		}
		
		EnchantForm enchantForm = null;
		EditForm editForm = null;
		ItemDataForm itemDataForm = null;
		List<CheckBox> groups = new List<CheckBox>();
		
		string[][] servers = new string[][]{
			new string[]{ "http://copy.mcft.net/mc/INVedit/", "version" },
			new string[]{ "http://mirror.mcmyadmin.com/copyboy/INVedit/", "version.txt" }
		};
		WebClient[] clients;
		List<string> download;
		List<byte[]> files;
		int current;
		int currentServer;
		int serversChecked;
		
		public MainForm(string[] files)
		{
			InitializeComponent();

            Data.Init("data.xml");
			
			labelVersion.Text = Data.mcVersion;
			
			boxItems.LargeImageList = Data.list;
			boxItems.ItemDrag += ItemDrag;
			
			foreach (Data.Group group in Data.groups.Values) {
				CheckBox box = new CheckBox();
				box.Size = new Size(26, 26);
				//box.Location = new Point(Width-205 + (groups.Count / 12) * 27, 29 + (groups.Count % 12) * 27);
                box.Location = new Point(491, 31);
				box.ImageList = Data.list;
                box.ImageIndex = group.imageIndex; //Fix this Image Problem
				box.Appearance = Appearance.Button;
				box.Checked = true;
				box.Tag = group;
				box.MouseDown += ItemMouseDown;
				Controls.Add(box);
				groups.Add(box);
			}
			Width += ((groups.Count-1) / 12) * 27;
			
			UpdateItems();
			
			foreach (string file in files)
				if (File.Exists(file)) Open(file);
		}
		
		void Open(string file)
		{
			Page page = new Page();
			page.Changed += Change;
			Change(null);
			Open(page,file);
			tabControl.TabPages.Add(page);
			tabControl.SelectedTab = page;
		}
		
		void Open(Page page, string file)
		{
			try {
				FileInfo info = new FileInfo(file);
				page.file = info.FullName;
				if (info.Name == "level.dat") { page.Text = info.Directory.Name; }
				else { page.Text = info.Name; }
				Text = "INVedit 2.0 - "+page.Text;
				page.changed = false;
				btnSave.Enabled = true;
				btnCloseTab.Enabled = true;
				btnReload.Enabled = true;
				NbtTag tag = NbtTag.Load(file);
				if (tag.Type==NbtTagType.Compound && tag.Contains("Data")) { tag = tag["Data"]; }
				if (tag.Type==NbtTagType.Compound && tag.Contains("Player")) { tag = tag["Player"]; }
				if (tag.Type==NbtTagType.Compound && tag.Contains("Inventory")) { tag = tag["Inventory"]; }
				if (tag.Name != "Inventory") { throw new Exception("Can't find Inventory tag."); }
				Inventory.Load(tag, page.slots);
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		void Save(Page page, string file)
		{
			try {
				FileInfo info = new FileInfo(file);
				if (info.Exists && page.file != info.FullName) {
					string str;
					if (info.Name == "level.dat")
						str = "Are you sure you want to overwrite "+info.Directory.Name+"?";
					else str = "Are you sure you want to overwrite '"+info.Name+"'?";
					DialogResult result = MessageBox.Show(str, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result != DialogResult.Yes) return;
				}
				page.file = info.FullName;
				NbtTag root,tag;
				if (info.Exists) {
					root = NbtTag.Load(page.file);
					if (info.Extension.ToLower() == ".dat")
						CreateBackup(file);
					tag = root;
				} else {
					if (info.Extension.ToLower() == ".dat") {
						MessageBox.Show("You can't create a new Minecraft level/player file.\n"+
						                "Select an existing one instead.", "Error",
						                MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					} root = NbtTag.CreateCompound("Inventory", NbtTag.CreateList(NbtTagType.Compound));
					tag = root;
				} if (tag.Type==NbtTagType.Compound && tag.Contains("Data")) { tag = tag["Data"]; }
				if (tag.Type==NbtTagType.Compound && tag.Contains("Player")) { tag = tag["Player"]; }
				if (tag.Type!=NbtTagType.Compound || !tag.Contains("Inventory")) { throw new Exception("Can't find Inventory tag."); }
				Inventory.Save(tag, page.slots);
				root.Save(page.file);
				if (info.Name == "level.dat") { page.Text = info.Directory.Name; }
				else { page.Text = info.Name; }
				Text = "INVedit 2.0 - "+page.Text;
				page.changed = false;
				btnReload.Enabled = true;
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		protected override void OnDragEnter(DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop));
				foreach (string file in files) {
					FileInfo info = new FileInfo(file);
					if (info.Extension.ToLower() == ".inv" || info.Extension.ToLower() == ".dat")
						e.Effect = DragDropEffects.Copy;
				}
			}
		}
		protected override void OnDragDrop(DragEventArgs e) {
			OnDragEnter(e);
			BringToFront();
			if (e.Effect == DragDropEffects.None) return;
			string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop));
			foreach (string file in files)
				if (File.Exists(file)) Open(file);
		}
		
		void UpdateItems()
		{
			boxItems.BeginUpdate();
			boxItems.Clear();
			if (boxSearch.Text == "" || boxSearch.Font.Italic) {
				foreach (CheckBox box in groups) if (box.Checked)
					foreach (Data.Item item in ((Data.Group)box.Tag).items)
						boxItems.Items.Add(new ListViewItem(item.name, item.imageIndex){ Tag = new Item(item.id, 0, 0, item.damage) });
			} else {
				string id;
                id = "";
				if (boxSearch.Text != "") {
					if (Data.items.ContainsKey(id))
						foreach (Data.Item item in Data.items[id].Values)
							boxItems.Items.Add(new ListViewItem(item.name, item.imageIndex){ Tag = new Item(item.id, 0, 0, item.damage) });
					else boxItems.Items.Add(new ListViewItem("Unknown item "+id, 0){ Tag = new Item(id) });
				} else foreach (CheckBox box in groups) if (box.Checked)
					foreach (Data.Item item in ((Data.Group)box.Tag).items)
						if (item.name.IndexOf(boxSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
							boxItems.Items.Add(new ListViewItem(item.name, item.imageIndex){ Tag = new Item(item.id, 0, 0, item.damage) });
			}
			boxItems.EndUpdate();
		}
		
		void ItemMouseDown(object sender, MouseEventArgs e)
		{
			CheckBox self = (CheckBox)sender;
			bool changed = false;
			if (e.Button == MouseButtons.Left) {
				bool other = true;
				foreach (CheckBox box in groups)
					if (box.Checked == (self!=box))
						other = false;
				foreach (CheckBox box in groups)
					if (box.Checked == (self!=box) || other) {
					changed = true;
					box.Checked = (self==box) || other;
				}
			} else if (e.Button == MouseButtons.Right) {
				self.Checked = !self.Checked;
				changed = true;
			} else return;
			self.Select();
			if (changed) UpdateItems();
			if (e.Button == MouseButtons.Left)
				self.Checked = !self.Checked;
		}
		
		void BoxSearchEnter(object sender, EventArgs e)
		{
			if (!boxSearch.Font.Italic) return;
			boxSearch.Font = new Font(boxSearch.Font, FontStyle.Regular);
			boxSearch.ForeColor = SystemColors.ControlText;
			boxSearch.Text = "";
		}
		
		void BoxSearchLeave(object sender, EventArgs e)
		{
			if (boxSearch.Text != "") return;
			boxSearch.Font = new Font(boxSearch.Font, FontStyle.Italic);
			boxSearch.ForeColor = Color.Gray;
			boxSearch.Text = "Search...";
		}
		
		void BoxSearchTextChanged(object sender, EventArgs e)
		{
			UpdateItems();
		}
		
		void ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			Item item = (Item)((ListViewItem)e.Item).Tag;
			item = new Item(item.ID, item.Preferred, 0, item.Damage);
			DoDragDrop(item, DragDropEffects.Copy | DragDropEffects.Move);
		}
		
		void BtnNewClick(object sender, EventArgs e)
		{
			Page page = new Page();
			page.Changed += Change;
			Change(null);
			page.Text = "unnamed.inv";
			Text = "INVedit 2.0 - unnamed.inv";
			tabControl.TabPages.Add(page);
			tabControl.SelectedTab = page;
			btnSave.Enabled = true;
			btnCloseTab.Enabled = true;
			btnReload.Enabled = false;
		}
		
		void BtnOpenClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				Open(openFileDialog.FileName);
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			Page page = (Page)tabControl.SelectedTab;
			saveFileDialog.FileName = page.file;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
				Save(page, saveFileDialog.FileName);
		}
		
		void BtnReloadClick(object sender, EventArgs e)
		{
			if (((Page)tabControl.SelectedTab).changed) {
				DialogResult result = MessageBox.Show(
					"Are you sure you want to reload this tab?\n"+
					"All unsaved changes will be lost.", "Question",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes) return;
			}
			try {
				Page page = (Page)tabControl.SelectedTab;
				Open(page, page.file);
				page.ItemChanged(false);
			} catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		
		void BtnCloseTabClick(object sender, EventArgs e)
		{
			if (((Page)tabControl.SelectedTab).changed) {
				DialogResult result = MessageBox.Show(
					"Are you sure you want to close this tab?\n"+
					"All unsaved changes will be lost.", "Question",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes) return;
			}
			
			tabControl.TabPages.Remove(tabControl.SelectedTab);
			if (tabControl.TabPages.Count == 0) {
				btnSave.Enabled = false;
				btnCloseTab.Enabled = false;
			}
		}
		
		void BtnEnchantClick(object sender, EventArgs e)
		{
			btnEnchant.Enabled = false;
			enchantForm = new EnchantForm();
			enchantForm.Closed += delegate {
				btnEnchant.Enabled = true;
				enchantForm = null;
			};
			if (tabControl.SelectedTab != null)
				enchantForm.Update(((Page)tabControl.SelectedTab).selected);
			enchantForm.Show(this);
		}
		
		void BtnEditClick(object sender, EventArgs e)
		{
			btnEdit.Enabled = false;
			editForm = new EditForm();
			editForm.Closed += delegate {
				btnEdit.Enabled = true;
				editForm = null;
			};
			if (tabControl.SelectedTab != null)
				editForm.Update(((Page)tabControl.SelectedTab).selected);
			editForm.Show(this);
		}
		
		void BtnItemDataClick(object sender, EventArgs e)
		{
			btnItemData.Enabled = false;
			itemDataForm = new ItemDataForm();
			itemDataForm.Closed += delegate {
				btnItemData.Enabled = true;
				itemDataForm = null;
			};
			if (tabControl.SelectedTab != null)
				itemDataForm.Update(((Page)tabControl.SelectedTab).selected);
			itemDataForm.Show(this);
		}
		
		void Change(ItemSlot slot)
		{
			if (enchantForm != null)
				enchantForm.Update(slot);
			if (editForm != null)
				editForm.Update(slot);
			if (itemDataForm != null)
				itemDataForm.Update(slot);
		}
		
		void BtnAboutClick(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			foreach (TabPage page in tabControl.TabPages)
				if (((Page)page).changed) {
				DialogResult result = MessageBox.Show(
					"Are you sure you want to close INVedit?\n"+
					"There still are unsaved inventory tabs.", "Question",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes) e.Cancel = true;
				break;
			}
		}
		
		void TabControlDragOver(object sender, DragEventArgs e)
		{
			Point point = tabControl.PointToClient(new Point(e.X, e.Y));
			TabPage hover = null;
			for (int i = 0; i < tabControl.TabPages.Count; ++i)
				if (tabControl.GetTabRect(i).Contains(point)) {
				hover = tabControl.TabPages[i];
				break;
			}
			if (hover == null || hover == tabControl.SelectedTab) return;
			if (!e.Data.GetDataPresent(typeof(Item))) return;
			tabControl.SelectedTab = hover;
			Change(((Page)tabControl.SelectedTab).selected);
		}
		
		void TabControlSelected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage != null) {
				Text = "INVedit - "+e.TabPage.Text;
				btnReload.Enabled = (((Page)e.TabPage).file != null);
				Change(((Page)tabControl.SelectedTab).selected);
			} else {
				Text = "INVedit - Minecraft Inventory Editor";
				btnReload.Enabled = false;
				Change(null);
			}
			
		}
		
		void BtnOpenDropDownOpening(object sender, EventArgs e)
		{
			btnOpen.DropDownItems.Clear();
			ResourceManager resources = new ResourceManager("INVedit.Properties.Resources", GetType().Assembly);
			Image world = (Image)resources.GetObject("world");
			DirectoryInfo dirs = new DirectoryInfo(appdata+"/saves");
			if (dirs.Exists) foreach (DirectoryInfo dir in dirs.GetDirectories()) {
				if (dir.GetFiles("level.dat").Length > 0) {
					ToolStripItem item = btnOpen.DropDownItems.Add("Open from „"+dir.Name+"“", world);
					item.Tag = dir.FullName+"/level.dat";
				}
			}
		}
		
		void BtnOpenDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			Open((string)e.ClickedItem.Tag);
		}
		
		void BtnSaveDropDownOpening(object sender, EventArgs e)
		{
			btnSave.DropDownItems.Clear();
			ResourceManager resources = new ResourceManager("INVedit.Properties.Resources", GetType().Assembly);
			Image world = (Image)resources.GetObject("world");
			DirectoryInfo dirs = new DirectoryInfo(appdata+"/saves");
			if (dirs.Exists) foreach (DirectoryInfo dir in dirs.GetDirectories()) {
				if (dir.GetFiles("level.dat").Length > 0) {
					ToolStripItem item = btnSave.DropDownItems.Add("Save to „"+dir.Name+"“", world);
					item.Tag = dir.FullName+"/level.dat";
				}
			}
		}
		
		void BtnSaveDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			Page page = (Page)tabControl.SelectedTab;
			Save(page, (string)e.ClickedItem.Tag);
		}
		
		void BtnUpdateClick(object sender, EventArgs e)
		{
			switch (btnUpdate.Text) {
				case "Check for updates":
					btnUpdate.Text = "Checking ...";
					btnUpdate.Enabled = false;
					currentServer = -1;
					serversChecked = 0;
					clients = new WebClient[servers.Length];
					for (int i = 0; i < servers.Length; i++) {
						clients[i] = new WebClient();
						clients[i].DownloadStringCompleted += VersionCompleted;
						clients[i].DownloadDataCompleted += FileCompleted;
						clients[i].DownloadProgressChanged += FileProgress;
						clients[i].DownloadStringAsync(new Uri(servers[i][0] + servers[i][1]), i);
					}
					break;
				case "Download":
					btnUpdate.Text = "";
					btnUpdate.Enabled = false;
					barUpdate.Visible = true;
					barUpdate.Value = 0;
					barUpdate.Maximum = download.Count*100;
					int current = 0;
					files = new List<byte[]>();
					Uri uri = new Uri(servers[currentServer][0] + download[current]);
					clients[currentServer].DownloadDataAsync(uri);
					break;
				case "Restart":
					for (int i = 0; i < download.Count; i++) {
						string name = download[i];
						byte[] data = files[i];
						if (name == "INVedit.exe" ||
						    name == "NBT.dll") name = "_" + name;
						File.WriteAllBytes(name, data);
					}
					if (File.Exists("_INVedit.exe"))
						Process.Start("_INVedit.exe", "-update");
					else Process.Start("INVedit.exe", "-update");
					Application.Exit();
					break;
			}
		}
		void VersionCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error != null) {
				serversChecked++;
				if (serversChecked == servers.Length)
					btnUpdate.Text = "Error while checking for updates";
				return;
			}
			if (currentServer != -1) return;
			currentServer = (int)e.UserState;
			int version = 1;
			string[] lines = e.Result.Split(new string[]{ "\r\n" }, StringSplitOptions.None);
			download = new List<string>();
			foreach (string line in lines) {
				if (line == "") version++;
				else if (version > Data.version &&
				         !download.Contains(line)) download.Add(line);
			} if (download.Count > 0) {
				btnUpdate.Text = "Download";
				btnUpdate.Enabled = true;
			} else btnUpdate.Text = "No update available";
		}
		void FileProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			barUpdate.Value = current * 100 + e.ProgressPercentage;
		}
		void FileCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			if (e.Error != null) {
				btnUpdate.Text = "Download";
				btnUpdate.Enabled = true;
				barUpdate.Visible = false;
				throw e.Error;
			} files.Add(e.Result);
			++current;
			if (current == download.Count) {
				btnUpdate.Text = "Restart";
				btnUpdate.Enabled = true;
				barUpdate.Visible = false;
			} else {
				Uri uri = new Uri(servers[currentServer][0] + download[current]);
				clients[currentServer].DownloadDataAsync(uri);
			}
		}
		
		void CreateBackup(string file)
		{
			string backup = Path.ChangeExtension(file, Path.GetExtension(file) + ".backup");
			if (File.Exists(backup))
				try { File.Delete(backup); } catch { return; }
			File.Copy(file, backup);
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            //GUI.DebugForm debug = new GUI.DebugForm();
            //debug.Show();
        }

        private void btnFirework_Click(object sender, EventArgs e)
        {
            btnFirework.Enabled = false;
            FireworkForm fireworkForm = new FireworkForm();
            fireworkForm.Closed += delegate
            {
                btnFirework.Enabled = true;
                fireworkForm = null;
            };
            if (tabControl.SelectedTab != null)
                fireworkForm.Update(((Page)tabControl.SelectedTab).selected);
            fireworkForm.Show(this);
        }

        private void btnPotion_Click(object sender, EventArgs e)
        {

            btnPotion.Enabled = false;
            GUI.PotionForm potionForm = new GUI.PotionForm();
            potionForm.Closed += delegate
            {
                btnPotion.Enabled = true;
                potionForm = null;
            };
            if (tabControl.SelectedTab != null)
                potionForm.Update(((Page)tabControl.SelectedTab).selected);
            potionForm.Show(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
	}
}
