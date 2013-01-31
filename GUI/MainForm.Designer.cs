/*
 * Erstellt mit SharpDevelop.
 * Benutzer: copyboy
 * Datum: 19.06.2010
 * Zeit: 20:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace INVedit
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSave = new System.Windows.Forms.ToolStripSplitButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.btnCloseTab = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.barUpdate = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnItemData = new System.Windows.Forms.ToolStripButton();
            this.btnEnchant = new System.Windows.Forms.ToolStripButton();
            this.btnPotion = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnFirework = new System.Windows.Forms.ToolStripButton();
            this.labelVersion = new System.Windows.Forms.ToolStripLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.boxItems = new System.Windows.Forms.ListView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.boxSearch = new System.Windows.Forms.TextBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnAbout,
            this.toolStripSeparator1,
            this.btnReload,
            this.btnCloseTab,
            this.btnUpdate,
            this.barUpdate,
            this.toolStripSeparator2,
            this.btnItemData,
            this.btnEnchant,
            this.btnPotion,
            this.btnEdit,
            this.btnFirework,
            this.labelVersion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(688, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(32, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.ButtonClick += new System.EventHandler(this.BtnOpenClick);
            this.btnOpen.DropDownOpening += new System.EventHandler(this.BtnOpenDropDownOpening);
            this.btnOpen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BtnOpenDropDownItemClicked);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 22);
            this.btnSave.Text = "Save";
            this.btnSave.ButtonClick += new System.EventHandler(this.BtnSaveClick);
            this.btnSave.DropDownOpening += new System.EventHandler(this.BtnSaveDropDownOpening);
            this.btnSave.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BtnSaveDropDownItemClicked);
            // 
            // btnAbout
            // 
            this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(23, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.BtnAboutClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Enabled = false;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.BtnReloadClick);
            // 
            // btnCloseTab
            // 
            this.btnCloseTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseTab.Enabled = false;
            this.btnCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseTab.Image")));
            this.btnCloseTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseTab.Name = "btnCloseTab";
            this.btnCloseTab.Size = new System.Drawing.Size(23, 22);
            this.btnCloseTab.Text = "Close tab";
            this.btnCloseTab.Click += new System.EventHandler(this.BtnCloseTabClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 22);
            this.btnUpdate.Text = "Check for updates";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
            // 
            // barUpdate
            // 
            this.barUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.barUpdate.AutoSize = false;
            this.barUpdate.Margin = new System.Windows.Forms.Padding(1, 2, 4, 1);
            this.barUpdate.Name = "barUpdate";
            this.barUpdate.Size = new System.Drawing.Size(100, 21);
            this.barUpdate.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnItemData
            // 
            this.btnItemData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItemData.Image = ((System.Drawing.Image)(resources.GetObject("btnItemData.Image")));
            this.btnItemData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItemData.Name = "btnItemData";
            this.btnItemData.Size = new System.Drawing.Size(23, 22);
            this.btnItemData.Text = "Item Editor";
            this.btnItemData.Click += new System.EventHandler(this.BtnItemDataClick);
            // 
            // btnEnchant
            // 
            this.btnEnchant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEnchant.Image = ((System.Drawing.Image)(resources.GetObject("btnEnchant.Image")));
            this.btnEnchant.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnchant.Name = "btnEnchant";
            this.btnEnchant.Size = new System.Drawing.Size(23, 22);
            this.btnEnchant.Text = "Enchantment Editor";
            this.btnEnchant.Click += new System.EventHandler(this.BtnEnchantClick);
            // 
            // btnPotion
            // 
            this.btnPotion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPotion.Image = ((System.Drawing.Image)(resources.GetObject("btnPotion.Image")));
            this.btnPotion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPotion.Name = "btnPotion";
            this.btnPotion.Size = new System.Drawing.Size(23, 22);
            this.btnPotion.Text = "Potion Editor";
            this.btnPotion.ToolTipText = "Potion Editor";
            this.btnPotion.Click += new System.EventHandler(this.btnPotionData_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "Book Editor";
            this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
            // 
            // btnFirework
            // 
            this.btnFirework.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirework.Image = ((System.Drawing.Image)(resources.GetObject("btnFirework.Image")));
            this.btnFirework.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirework.Name = "btnFirework";
            this.btnFirework.Size = new System.Drawing.Size(23, 22);
            this.btnFirework.Text = "Firework Editor";
            this.btnFirework.Click += new System.EventHandler(this.btnFirework_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(65, 22);
            this.labelVersion.Text = "{mc-version}";
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Location = new System.Drawing.Point(5, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(481, 322);
            this.tabControl.TabIndex = 1;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlSelected);
            this.tabControl.DragOver += new System.Windows.Forms.DragEventHandler(this.TabControlDragOver);
            // 
            // boxItems
            // 
            this.boxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxItems.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.boxItems.Location = new System.Drawing.Point(518, 51);
            this.boxItems.MultiSelect = false;
            this.boxItems.Name = "boxItems";
            this.boxItems.Size = new System.Drawing.Size(166, 300);
            this.boxItems.TabIndex = 3;
            this.boxItems.TileSize = new System.Drawing.Size(140, 19);
            this.boxItems.UseCompatibleStateImageBehavior = false;
            this.boxItems.View = System.Windows.Forms.View.Tile;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "inv";
            this.saveFileDialog.Filter = "All supported files|*.dat;*.inv|Minecraft files (*.dat)|*.dat|Inventory files (*." +
    "inv)|*.inv|All files (*.*)|*.*";
            this.saveFileDialog.Title = "Save inventory";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "inv";
            this.openFileDialog.Filter = "All supported files|*.dat;*.inv|Minecraft files (*.dat)|*.dat|Inventory files (*." +
    "inv)|*.inv|All files (*.*)|*.*";
            this.openFileDialog.Title = "Open inventory";
            // 
            // boxSearch
            // 
            this.boxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSearch.ForeColor = System.Drawing.Color.Gray;
            this.boxSearch.Location = new System.Drawing.Point(518, 29);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(166, 20);
            this.boxSearch.TabIndex = 2;
            this.boxSearch.Text = "Search...";
            this.boxSearch.TextChanged += new System.EventHandler(this.BoxSearchTextChanged);
            this.boxSearch.Enter += new System.EventHandler(this.BoxSearchEnter);
            this.boxSearch.Leave += new System.EventHandler(this.BoxSearchLeave);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(688, 355);
            this.Controls.Add(this.boxSearch);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.boxItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INVedit - Minecraft Inventory Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton btnEdit;
		private System.Windows.Forms.ToolStripButton btnItemData;
		private System.Windows.Forms.ToolStripButton btnEnchant;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel labelVersion;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.TextBox boxSearch;
		private System.Windows.Forms.ToolStripProgressBar barUpdate;
		private System.Windows.Forms.ToolStripButton btnUpdate;
		private System.Windows.Forms.ToolStripButton btnReload;
		private System.Windows.Forms.ToolStripButton btnCloseTab;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ListView boxItems;
		private System.Windows.Forms.ToolStripSplitButton btnSave;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripSplitButton btnOpen;
		private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnPotion;
        private System.Windows.Forms.ToolStripButton btnFirework;
	}
}
