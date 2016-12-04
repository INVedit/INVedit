namespace INVedit.GUI
{
    partial class PotionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PotionForm));
            this.label2 = new System.Windows.Forms.Label();
            this.editAmplifier = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.boxAllow = new System.Windows.Forms.CheckBox();
            this.editDuration = new System.Windows.Forms.NumericUpDown();
            this.boxName = new System.Windows.Forms.ComboBox();
            this.boxPotionEffects = new System.Windows.Forms.ListView();
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerAmplifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.editAmplifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Duration:";
            // 
            // editAmplifier
            // 
            this.editAmplifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editAmplifier.Enabled = false;
            this.editAmplifier.Location = new System.Drawing.Point(56, 207);
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
            this.editAmplifier.TabIndex = 13;
            this.editAmplifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editAmplifier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Amplifier:";
            // 
            // boxAllow
            // 
            this.boxAllow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxAllow.Location = new System.Drawing.Point(4, 325);
            this.boxAllow.Name = "boxAllow";
            this.boxAllow.Size = new System.Drawing.Size(298, 18);
            this.boxAllow.TabIndex = 11;
            this.boxAllow.Text = "Allow potentially unsafe potions";
            this.boxAllow.UseVisualStyleBackColor = true;
            this.boxAllow.CheckedChanged += new System.EventHandler(this.boxAllow_CheckedChanged);
            // 
            // editDuration
            // 
            this.editDuration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editDuration.Enabled = false;
            this.editDuration.Location = new System.Drawing.Point(178, 207);
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
            this.editDuration.TabIndex = 10;
            this.editDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // boxName
            // 
            this.boxName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxName.Enabled = false;
            this.boxName.FormattingEnabled = true;
            this.boxName.Location = new System.Drawing.Point(4, 256);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(307, 21);
            this.boxName.TabIndex = 9;
            this.boxName.SelectedIndexChanged += new System.EventHandler(this.boxName_SelectedIndexChanged);
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
            this.boxPotionEffects.Location = new System.Drawing.Point(4, 45);
            this.boxPotionEffects.MultiSelect = false;
            this.boxPotionEffects.Name = "boxPotionEffects";
            this.boxPotionEffects.Size = new System.Drawing.Size(304, 156);
            this.boxPotionEffects.TabIndex = 8;
            this.boxPotionEffects.UseCompatibleStateImageBehavior = false;
            this.boxPotionEffects.View = System.Windows.Forms.View.Details;
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "sec(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Effect:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Base Potion:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 298);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(307, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // PotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 346);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editAmplifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxAllow);
            this.Controls.Add(this.editDuration);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.boxPotionEffects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PotionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Potion Editor";
            this.Load += new System.EventHandler(this.PotionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editAmplifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown editAmplifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox boxAllow;
        private System.Windows.Forms.NumericUpDown editDuration;
        private System.Windows.Forms.ComboBox boxName;
        private System.Windows.Forms.ListView boxPotionEffects;
        private System.Windows.Forms.ColumnHeader headerName;
        private System.Windows.Forms.ColumnHeader headerAmplifier;
        private System.Windows.Forms.ColumnHeader headerDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}