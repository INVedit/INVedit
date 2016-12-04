/*
 * Erstellt mit SharpDevelop.
 * Benutzer: copyboy
 * Datum: 28.06.2010
 * Zeit: 09:35
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace INVedit
{
	partial class AboutForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tmrScroll = new System.Windows.Forms.Timer(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.picPP2 = new System.Windows.Forms.PictureBox();
            this.picPP1 = new System.Windows.Forms.PictureBox();
            this.picSide = new System.Windows.Forms.PictureBox();
            this.picAbout = new System.Windows.Forms.PictureBox();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel6
            // 
            this.linkLabel6.Location = new System.Drawing.Point(0, 0);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(100, 23);
            this.linkLabel6.TabIndex = 44;
            // 
            // linkLabel5
            // 
            this.linkLabel5.Location = new System.Drawing.Point(0, 0);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(100, 23);
            this.linkLabel5.TabIndex = 45;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(252, 144);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Information";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "DHIteration\'s webiste:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Newest Thread:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Origional Thread:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "copyboy\'s website:";
            // 
            // txtChange
            // 
            this.txtChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChange.Location = new System.Drawing.Point(3, 3);
            this.txtChange.Multiline = true;
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChange.Size = new System.Drawing.Size(246, 138);
            this.txtChange.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picAbout);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 144);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "About";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(107, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 170);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtChange);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 144);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Change Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tmrScroll
            // 
            this.tmrScroll.Enabled = true;
            this.tmrScroll.Interval = 45;
            this.tmrScroll.Tick += new System.EventHandler(this.tmrScroll_Tick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(291, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // picPP2
            // 
            this.picPP2.Location = new System.Drawing.Point(5, 218);
            this.picPP2.Name = "picPP2";
            this.picPP2.Size = new System.Drawing.Size(16, 16);
            this.picPP2.TabIndex = 43;
            this.picPP2.TabStop = false;
            // 
            // picPP1
            // 
            this.picPP1.Location = new System.Drawing.Point(5, 194);
            this.picPP1.Name = "picPP1";
            this.picPP1.Size = new System.Drawing.Size(16, 16);
            this.picPP1.TabIndex = 42;
            this.picPP1.TabStop = false;
            // 
            // picSide
            // 
            this.picSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSide.Image = global::INVedit.Properties.Resources.side;
            this.picSide.Location = new System.Drawing.Point(12, 12);
            this.picSide.Name = "picSide";
            this.picSide.Size = new System.Drawing.Size(89, 170);
            this.picSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSide.TabIndex = 38;
            this.picSide.TabStop = false;
            // 
            // picAbout
            // 
            this.picAbout.BackColor = System.Drawing.Color.White;
            this.picAbout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAbout.Location = new System.Drawing.Point(3, 3);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(246, 138);
            this.picAbout.TabIndex = 30;
            this.picAbout.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(376, 245);
            this.Controls.Add(this.picPP2);
            this.Controls.Add(this.picPP1);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.picSide);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About INVedit 2.0";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox picPP2;
        private System.Windows.Forms.PictureBox picPP1;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.PictureBox picSide;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.PictureBox picAbout;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer tmrScroll;
        private System.Windows.Forms.Button btnOK;
	}
}
