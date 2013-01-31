namespace INVedit
{
    partial class FireworkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FireworkForm));
            this.boxType = new System.Windows.Forms.ComboBox();
            this.editFlight = new System.Windows.Forms.NumericUpDown();
            this.chkTrail = new System.Windows.Forms.CheckBox();
            this.chkFlicker = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwColors = new System.Windows.Forms.ListView();
            this.headerColors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.editFlight)).BeginInit();
            this.SuspendLayout();
            // 
            // boxType
            // 
            this.boxType.Enabled = false;
            this.boxType.FormattingEnabled = true;
            this.boxType.Location = new System.Drawing.Point(49, 20);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(163, 21);
            this.boxType.TabIndex = 0;
            // 
            // editFlight
            // 
            this.editFlight.Enabled = false;
            this.editFlight.Location = new System.Drawing.Point(49, 57);
            this.editFlight.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.editFlight.Name = "editFlight";
            this.editFlight.Size = new System.Drawing.Size(163, 20);
            this.editFlight.TabIndex = 1;
            this.editFlight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkTrail
            // 
            this.chkTrail.AutoSize = true;
            this.chkTrail.Enabled = false;
            this.chkTrail.Location = new System.Drawing.Point(91, 83);
            this.chkTrail.Name = "chkTrail";
            this.chkTrail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTrail.Size = new System.Drawing.Size(49, 17);
            this.chkTrail.TabIndex = 2;
            this.chkTrail.Text = ":Trail";
            this.chkTrail.UseVisualStyleBackColor = true;
            // 
            // chkFlicker
            // 
            this.chkFlicker.AutoSize = true;
            this.chkFlicker.Enabled = false;
            this.chkFlicker.Location = new System.Drawing.Point(146, 83);
            this.chkFlicker.Name = "chkFlicker";
            this.chkFlicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFlicker.Size = new System.Drawing.Size(66, 17);
            this.chkFlicker.TabIndex = 3;
            this.chkFlicker.Text = ":Twinkle";
            this.chkFlicker.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Flight:";
            // 
            // lvwColors
            // 
            this.lvwColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerColors});
            this.lvwColors.Enabled = false;
            this.lvwColors.FullRowSelect = true;
            this.lvwColors.Location = new System.Drawing.Point(12, 114);
            this.lvwColors.Name = "lvwColors";
            this.lvwColors.Size = new System.Drawing.Size(199, 154);
            this.lvwColors.TabIndex = 6;
            this.lvwColors.UseCompatibleStateImageBehavior = false;
            this.lvwColors.View = System.Windows.Forms.View.Details;
            // 
            // headerColors
            // 
            this.headerColors.Text = "Colors";
            this.headerColors.Width = 193;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(138, 283);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 24);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(11, 283);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(73, 24);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FireworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 320);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwColors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkFlicker);
            this.Controls.Add(this.chkTrail);
            this.Controls.Add(this.editFlight);
            this.Controls.Add(this.boxType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FireworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fireworks Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FireworkForm_FormClosing);
            this.Load += new System.EventHandler(this.FireworkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editFlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxType;
        private System.Windows.Forms.NumericUpDown editFlight;
        private System.Windows.Forms.CheckBox chkTrail;
        private System.Windows.Forms.CheckBox chkFlicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwColors;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColumnHeader headerColors;
        private System.Windows.Forms.ColorDialog colorDialog;

    }
}