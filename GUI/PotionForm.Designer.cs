
namespace INVedit
{
	partial class PotionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PotionForm));
            this.boxPotionEffects = new System.Windows.Forms.ListView();
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerAmplifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boxName = new System.Windows.Forms.ComboBox();
            this.editDuration = new System.Windows.Forms.NumericUpDown();
            this.editId = new System.Windows.Forms.NumericUpDown();
            this.boxAllow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editAmplifier = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.editDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAmplifier)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPotionEffects
            // 
            this.boxPotionEffects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxPotionEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerName,
            this.headerAmplifier,
            this.headerDuration});
            this.boxPotionEffects.FullRowSelect = true;
            this.boxPotionEffects.GridLines = true;
            this.boxPotionEffects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.boxPotionEffects.HideSelection = false;
            this.boxPotionEffects.Location = new System.Drawing.Point(6, 6);
            this.boxPotionEffects.MultiSelect = false;
            this.boxPotionEffects.Name = "boxPotionEffects";
            this.boxPotionEffects.Size = new System.Drawing.Size(304, 135);
            this.boxPotionEffects.TabIndex = 0;
            this.boxPotionEffects.UseCompatibleStateImageBehavior = false;
            this.boxPotionEffects.View = System.Windows.Forms.View.Details;
            this.boxPotionEffects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxPotionEffectsKeyDown);
            // 
            // headerName
            // 
            this.headerName.Text = "Effect";
            this.headerName.Width = 140;
            // 
            // headerAmplifier
            // 
            this.headerAmplifier.Text = "Amplifier";
            this.headerAmplifier.Width = 78;
            // 
            // headerDuration
            // 
            this.headerDuration.Text = "Duration";
            this.headerDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerDuration.Width = 82;
            // 
            // boxName
            // 
            this.boxName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxName.Enabled = false;
            this.boxName.FormattingEnabled = true;
            this.boxName.Location = new System.Drawing.Point(6, 173);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(304, 21);
            this.boxName.TabIndex = 2;
            this.boxName.SelectedIndexChanged += new System.EventHandler(this.BoxNameSelectedIndexChanged);
            // 
            // editDuration
            // 
            this.editDuration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editDuration.Enabled = false;
            this.editDuration.Location = new System.Drawing.Point(248, 147);
            this.editDuration.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.editDuration.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.editDuration.Name = "editDuration";
            this.editDuration.Size = new System.Drawing.Size(62, 20);
            this.editDuration.TabIndex = 3;
            this.editDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editDuration.ValueChanged += new System.EventHandler(this.editDurationValueChanged);
            // 
            // editId
            // 
            this.editId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editId.Enabled = false;
            this.editId.Location = new System.Drawing.Point(6, 147);
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
            this.editId.ValueChanged += new System.EventHandler(this.EditIdValueChanged);
            // 
            // boxAllow
            // 
            this.boxAllow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxAllow.Location = new System.Drawing.Point(6, 202);
            this.boxAllow.Name = "boxAllow";
            this.boxAllow.Size = new System.Drawing.Size(298, 18);
            this.boxAllow.TabIndex = 4;
            this.boxAllow.Text = "Allow potentially unsafe potions";
            this.boxAllow.UseVisualStyleBackColor = true;
            this.boxAllow.CheckedChanged += new System.EventHandler(this.BoxAllowCheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amplifier:";
            // 
            // editAmplifier
            // 
            this.editAmplifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editAmplifier.Enabled = false;
            this.editAmplifier.Location = new System.Drawing.Point(126, 147);
            this.editAmplifier.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.editAmplifier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.editAmplifier.Name = "editAmplifier";
            this.editAmplifier.Size = new System.Drawing.Size(62, 20);
            this.editAmplifier.TabIndex = 6;
            this.editAmplifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editAmplifier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.editAmplifier.ValueChanged += new System.EventHandler(this.editAmplifierValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Duration:";
            // 
            // PotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editAmplifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxAllow);
            this.Controls.Add(this.editId);
            this.Controls.Add(this.editDuration);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.boxPotionEffects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PotionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Potion Editor";
            this.Load += new System.EventHandler(this.PotionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAmplifier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox boxAllow;
		private System.Windows.Forms.NumericUpDown editId;
		private System.Windows.Forms.NumericUpDown editDuration;
		private System.Windows.Forms.ComboBox boxName;
		private System.Windows.Forms.ColumnHeader headerDuration;
		private System.Windows.Forms.ColumnHeader headerName;
		private System.Windows.Forms.ListView boxPotionEffects;
        private System.Windows.Forms.ColumnHeader headerAmplifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown editAmplifier;
        private System.Windows.Forms.Label label2;
	}
}
