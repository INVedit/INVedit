/*
 * Created by SharpDevelop.
 * User: copyboy
 * Date: 24.02.2012
 * Time: 15:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace INVedit
{
	partial class EnchantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnchantForm));
            this.boxEnchantments = new System.Windows.Forms.ListView();
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boxName = new System.Windows.Forms.ComboBox();
            this.editLevel = new System.Windows.Forms.NumericUpDown();
            this.editId = new System.Windows.Forms.NumericUpDown();
            this.boxAllow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.editLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editId)).BeginInit();
            this.SuspendLayout();
            // 
            // boxEnchantments
            // 
            this.boxEnchantments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxEnchantments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerName,
            this.headerLevel});
            this.boxEnchantments.FullRowSelect = true;
            this.boxEnchantments.GridLines = true;
            this.boxEnchantments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.boxEnchantments.HideSelection = false;
            this.boxEnchantments.Location = new System.Drawing.Point(6, 6);
            this.boxEnchantments.MultiSelect = false;
            this.boxEnchantments.Name = "boxEnchantments";
            this.boxEnchantments.Size = new System.Drawing.Size(285, 138);
            this.boxEnchantments.TabIndex = 0;
            this.boxEnchantments.UseCompatibleStateImageBehavior = false;
            this.boxEnchantments.View = System.Windows.Forms.View.Details;
            this.boxEnchantments.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.BoxEnchantmentsColumnWidthChanging);
            this.boxEnchantments.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.BoxEnchantmentsItemSelectionChanged);
            this.boxEnchantments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoxEnchantmentsKeyDown);
            // 
            // headerName
            // 
            this.headerName.Text = "Name";
            this.headerName.Width = 235;
            // 
            // headerLevel
            // 
            this.headerLevel.Text = "Level";
            this.headerLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerLevel.Width = 46;
            // 
            // boxName
            // 
            this.boxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxName.Enabled = false;
            this.boxName.FormattingEnabled = true;
            this.boxName.Location = new System.Drawing.Point(6, 151);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(219, 21);
            this.boxName.TabIndex = 2;
            this.boxName.SelectedIndexChanged += new System.EventHandler(this.BoxNameSelectedIndexChanged);
            // 
            // editLevel
            // 
            this.editLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editLevel.Enabled = false;
            this.editLevel.Location = new System.Drawing.Point(229, 151);
            this.editLevel.Name = "editLevel";
            this.editLevel.Size = new System.Drawing.Size(62, 20);
            this.editLevel.TabIndex = 3;
            this.editLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editLevel.ValueChanged += new System.EventHandler(this.EditLevelValueChanged);
            // 
            // editId
            // 
            this.editId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editId.Enabled = false;
            this.editId.Location = new System.Drawing.Point(6, 151);
            this.editId.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.editId.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.editId.Name = "editId";
            this.editId.Size = new System.Drawing.Size(62, 20);
            this.editId.TabIndex = 1;
            this.editId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editId.Visible = false;
            this.editId.ValueChanged += new System.EventHandler(this.EditIdValueChanged);
            // 
            // boxAllow
            // 
            this.boxAllow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAllow.Location = new System.Drawing.Point(8, 176);
            this.boxAllow.Name = "boxAllow";
            this.boxAllow.Size = new System.Drawing.Size(281, 18);
            this.boxAllow.TabIndex = 4;
            this.boxAllow.Text = "Allow potentially unsafe enchantments";
            this.boxAllow.UseVisualStyleBackColor = true;
            this.boxAllow.CheckedChanged += new System.EventHandler(this.BoxAllowCheckedChanged);
            // 
            // EnchantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 199);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.boxAllow);
            this.Controls.Add(this.editId);
            this.Controls.Add(this.editLevel);
            this.Controls.Add(this.boxEnchantments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnchantForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enchantment Editor";
            this.Load += new System.EventHandler(this.EnchantForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editId)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.CheckBox boxAllow;
		private System.Windows.Forms.NumericUpDown editId;
		private System.Windows.Forms.NumericUpDown editLevel;
		private System.Windows.Forms.ComboBox boxName;
		private System.Windows.Forms.ColumnHeader headerLevel;
		private System.Windows.Forms.ColumnHeader headerName;
		private System.Windows.Forms.ListView boxEnchantments;
	}
}
