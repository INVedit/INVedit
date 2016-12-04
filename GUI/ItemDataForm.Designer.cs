/*
 * Created by SharpDevelop.
 * User: copygirl
 * Date: 29.10.2012
 * Time: 13:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace INVedit
{
	partial class ItemDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDataForm));
            this.picCharHead = new System.Windows.Forms.PictureBox();
            this.btnWhite = new System.Windows.Forms.PictureBox();
            this.btnYellow = new System.Windows.Forms.PictureBox();
            this.btnPink = new System.Windows.Forms.PictureBox();
            this.btnRed = new System.Windows.Forms.PictureBox();
            this.btnAqua = new System.Windows.Forms.PictureBox();
            this.btnBrightGreen = new System.Windows.Forms.PictureBox();
            this.btnIndigo = new System.Windows.Forms.PictureBox();
            this.btnDarkGray = new System.Windows.Forms.PictureBox();
            this.btnGray = new System.Windows.Forms.PictureBox();
            this.btnGold = new System.Windows.Forms.PictureBox();
            this.btnPurple = new System.Windows.Forms.PictureBox();
            this.btnDarkRed = new System.Windows.Forms.PictureBox();
            this.btnDarkAqua = new System.Windows.Forms.PictureBox();
            this.btnDarkGreen = new System.Windows.Forms.PictureBox();
            this.btnDarkBlue = new System.Windows.Forms.PictureBox();
            this.btnBlack = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.btnStrike = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.boxColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelColor = new System.Windows.Forms.Panel();
            this.boxLore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxPlayer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tmrRnd = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCharHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAqua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrightGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIndigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkAqua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // picCharHead
            // 
            this.picCharHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCharHead.ErrorImage = null;
            this.picCharHead.Image = ((System.Drawing.Image)(resources.GetObject("picCharHead.Image")));
            this.picCharHead.Location = new System.Drawing.Point(333, 169);
            this.picCharHead.Name = "picCharHead";
            this.picCharHead.Size = new System.Drawing.Size(63, 63);
            this.picCharHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCharHead.TabIndex = 76;
            this.picCharHead.TabStop = false;
            this.picCharHead.Click += new System.EventHandler(this.picCharHead_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnWhite.Enabled = false;
            this.btnWhite.Location = new System.Drawing.Point(445, 204);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(23, 22);
            this.btnWhite.TabIndex = 75;
            this.btnWhite.TabStop = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(85)))));
            this.btnYellow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnYellow.Enabled = false;
            this.btnYellow.Location = new System.Drawing.Point(445, 176);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(23, 22);
            this.btnYellow.TabIndex = 74;
            this.btnYellow.TabStop = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnPink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnPink.Enabled = false;
            this.btnPink.Location = new System.Drawing.Point(445, 148);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(23, 22);
            this.btnPink.TabIndex = 73;
            this.btnPink.TabStop = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnRed.Enabled = false;
            this.btnRed.Location = new System.Drawing.Point(445, 120);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(23, 22);
            this.btnRed.TabIndex = 72;
            this.btnRed.TabStop = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnAqua
            // 
            this.btnAqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAqua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnAqua.Enabled = false;
            this.btnAqua.Location = new System.Drawing.Point(445, 92);
            this.btnAqua.Name = "btnAqua";
            this.btnAqua.Size = new System.Drawing.Size(23, 22);
            this.btnAqua.TabIndex = 71;
            this.btnAqua.TabStop = false;
            this.btnAqua.Click += new System.EventHandler(this.btnAqua_Click);
            // 
            // btnBrightGreen
            // 
            this.btnBrightGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(255)))), ((int)(((byte)(85)))));
            this.btnBrightGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnBrightGreen.Enabled = false;
            this.btnBrightGreen.Location = new System.Drawing.Point(445, 64);
            this.btnBrightGreen.Name = "btnBrightGreen";
            this.btnBrightGreen.Size = new System.Drawing.Size(23, 22);
            this.btnBrightGreen.TabIndex = 70;
            this.btnBrightGreen.TabStop = false;
            this.btnBrightGreen.Click += new System.EventHandler(this.btnBrightGreen_Click);
            // 
            // btnIndigo
            // 
            this.btnIndigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnIndigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnIndigo.Enabled = false;
            this.btnIndigo.Location = new System.Drawing.Point(445, 36);
            this.btnIndigo.Name = "btnIndigo";
            this.btnIndigo.Size = new System.Drawing.Size(23, 22);
            this.btnIndigo.TabIndex = 69;
            this.btnIndigo.TabStop = false;
            this.btnIndigo.Click += new System.EventHandler(this.btnIndigo_Click);
            // 
            // btnDarkGray
            // 
            this.btnDarkGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnDarkGray.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDarkGray.Enabled = false;
            this.btnDarkGray.Location = new System.Drawing.Point(445, 8);
            this.btnDarkGray.Name = "btnDarkGray";
            this.btnDarkGray.Size = new System.Drawing.Size(23, 22);
            this.btnDarkGray.TabIndex = 68;
            this.btnDarkGray.TabStop = false;
            this.btnDarkGray.Click += new System.EventHandler(this.btnDarkGray_Click);
            // 
            // btnGray
            // 
            this.btnGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnGray.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnGray.Enabled = false;
            this.btnGray.Location = new System.Drawing.Point(416, 204);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(23, 22);
            this.btnGray.TabIndex = 67;
            this.btnGray.TabStop = false;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // btnGold
            // 
            this.btnGold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.btnGold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnGold.Enabled = false;
            this.btnGold.Location = new System.Drawing.Point(416, 176);
            this.btnGold.Name = "btnGold";
            this.btnGold.Size = new System.Drawing.Size(23, 22);
            this.btnGold.TabIndex = 66;
            this.btnGold.TabStop = false;
            this.btnGold.Click += new System.EventHandler(this.btnGold_Click);
            // 
            // btnPurple
            // 
            this.btnPurple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.btnPurple.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnPurple.Enabled = false;
            this.btnPurple.Location = new System.Drawing.Point(416, 148);
            this.btnPurple.Name = "btnPurple";
            this.btnPurple.Size = new System.Drawing.Size(23, 22);
            this.btnPurple.TabIndex = 65;
            this.btnPurple.TabStop = false;
            this.btnPurple.Click += new System.EventHandler(this.btnPurple_Click);
            // 
            // btnDarkRed
            // 
            this.btnDarkRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDarkRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDarkRed.Enabled = false;
            this.btnDarkRed.Location = new System.Drawing.Point(416, 120);
            this.btnDarkRed.Name = "btnDarkRed";
            this.btnDarkRed.Size = new System.Drawing.Size(23, 22);
            this.btnDarkRed.TabIndex = 64;
            this.btnDarkRed.TabStop = false;
            this.btnDarkRed.Click += new System.EventHandler(this.btnDarkRed_Click);
            // 
            // btnDarkAqua
            // 
            this.btnDarkAqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnDarkAqua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDarkAqua.Enabled = false;
            this.btnDarkAqua.Location = new System.Drawing.Point(416, 92);
            this.btnDarkAqua.Name = "btnDarkAqua";
            this.btnDarkAqua.Size = new System.Drawing.Size(23, 22);
            this.btnDarkAqua.TabIndex = 63;
            this.btnDarkAqua.TabStop = false;
            this.btnDarkAqua.Click += new System.EventHandler(this.btnDarkAqua_Click);
            // 
            // btnDarkGreen
            // 
            this.btnDarkGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.btnDarkGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDarkGreen.Enabled = false;
            this.btnDarkGreen.Location = new System.Drawing.Point(416, 64);
            this.btnDarkGreen.Name = "btnDarkGreen";
            this.btnDarkGreen.Size = new System.Drawing.Size(23, 22);
            this.btnDarkGreen.TabIndex = 62;
            this.btnDarkGreen.TabStop = false;
            this.btnDarkGreen.Click += new System.EventHandler(this.btnDarkGreen_Click);
            // 
            // btnDarkBlue
            // 
            this.btnDarkBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.btnDarkBlue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDarkBlue.Enabled = false;
            this.btnDarkBlue.Location = new System.Drawing.Point(416, 36);
            this.btnDarkBlue.Name = "btnDarkBlue";
            this.btnDarkBlue.Size = new System.Drawing.Size(23, 22);
            this.btnDarkBlue.TabIndex = 61;
            this.btnDarkBlue.TabStop = false;
            this.btnDarkBlue.Click += new System.EventHandler(this.btnDarkBlue_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnBlack.Enabled = false;
            this.btnBlack.Location = new System.Drawing.Point(416, 8);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(23, 22);
            this.btnBlack.TabIndex = 60;
            this.btnBlack.TabStop = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(333, 142);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 21);
            this.btnReset.TabIndex = 59;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.Enabled = false;
            this.btnItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalic.Location = new System.Drawing.Point(333, 115);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(63, 21);
            this.btnItalic.TabIndex = 58;
            this.btnItalic.Text = "Italic";
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.Enabled = false;
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnderline.Location = new System.Drawing.Point(333, 88);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(63, 21);
            this.btnUnderline.TabIndex = 57;
            this.btnUnderline.Text = "Underline";
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnStrike
            // 
            this.btnStrike.Enabled = false;
            this.btnStrike.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStrike.Location = new System.Drawing.Point(333, 61);
            this.btnStrike.Name = "btnStrike";
            this.btnStrike.Size = new System.Drawing.Size(63, 21);
            this.btnStrike.TabIndex = 56;
            this.btnStrike.Text = "Strike";
            this.btnStrike.UseVisualStyleBackColor = true;
            this.btnStrike.Click += new System.EventHandler(this.btnStrike_Click);
            // 
            // btnBold
            // 
            this.btnBold.Enabled = false;
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(333, 34);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(63, 21);
            this.btnBold.TabIndex = 55;
            this.btnBold.Text = "Bold";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Enabled = false;
            this.btnRandom.Location = new System.Drawing.Point(333, 7);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(63, 21);
            this.btnRandom.TabIndex = 54;
            this.btnRandom.Text = "Rnd Text";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.Location = new System.Drawing.Point(293, 202);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(26, 26);
            this.btnPreview.TabIndex = 53;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // boxColor
            // 
            this.boxColor.Enabled = false;
            this.boxColor.Font = new System.Drawing.Font("Courier New", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxColor.Location = new System.Drawing.Point(245, 174);
            this.boxColor.MaxLength = 6;
            this.boxColor.Name = "boxColor";
            this.boxColor.Size = new System.Drawing.Size(72, 18);
            this.boxColor.TabIndex = 50;
            this.boxColor.TextChanged += new System.EventHandler(this.BoxColorTextChanged);
            this.boxColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxColor_MouseUp);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(230, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 49;
            this.label5.Text = "#";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Transparent;
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Enabled = false;
            this.panelColor.Location = new System.Drawing.Point(61, 174);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(169, 20);
            this.panelColor.TabIndex = 48;
            this.panelColor.Click += new System.EventHandler(this.PanelColorClick);
            this.panelColor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelColor_Paint);
            this.panelColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseUp);
            // 
            // boxLore
            // 
            this.boxLore.Enabled = false;
            this.boxLore.Location = new System.Drawing.Point(61, 34);
            this.boxLore.Multiline = true;
            this.boxLore.Name = "boxLore";
            this.boxLore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxLore.Size = new System.Drawing.Size(256, 129);
            this.boxLore.TabIndex = 46;
            this.boxLore.TextChanged += new System.EventHandler(this.BoxLoreTextChanged);
            this.boxLore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxLore_MouseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Lore:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "Color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxPlayer
            // 
            this.boxPlayer.Enabled = false;
            this.boxPlayer.Location = new System.Drawing.Point(61, 206);
            this.boxPlayer.Name = "boxPlayer";
            this.boxPlayer.Size = new System.Drawing.Size(226, 20);
            this.boxPlayer.TabIndex = 52;
            this.boxPlayer.TextChanged += new System.EventHandler(this.BoxPlayerTextChanged);
            this.boxPlayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxPlayer_MouseUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 51;
            this.label3.Text = "Player:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxName
            // 
            this.boxName.Enabled = false;
            this.boxName.Location = new System.Drawing.Point(61, 8);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(256, 20);
            this.boxName.TabIndex = 44;
            this.boxName.TextChanged += new System.EventHandler(this.BoxNameTextChanged);
            this.boxName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxName_MouseUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrRnd
            // 
            this.tmrRnd.Enabled = true;
            this.tmrRnd.Interval = 50;
            this.tmrRnd.Tick += new System.EventHandler(this.tmrRnd_Tick);
            // 
            // ItemDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 238);
            this.Controls.Add(this.picCharHead);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnPink);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnAqua);
            this.Controls.Add(this.btnBrightGreen);
            this.Controls.Add(this.btnIndigo);
            this.Controls.Add(this.btnDarkGray);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.btnGold);
            this.Controls.Add(this.btnPurple);
            this.Controls.Add(this.btnDarkRed);
            this.Controls.Add(this.btnDarkAqua);
            this.Controls.Add(this.btnDarkGreen);
            this.Controls.Add(this.btnDarkBlue);
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnUnderline);
            this.Controls.Add(this.btnStrike);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.boxColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.boxLore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxPlayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDataForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.ItemDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCharHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAqua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrightGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIndigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkAqua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDarkBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picCharHead;
        private System.Windows.Forms.PictureBox btnWhite;
        private System.Windows.Forms.PictureBox btnYellow;
        private System.Windows.Forms.PictureBox btnPink;
        private System.Windows.Forms.PictureBox btnRed;
        private System.Windows.Forms.PictureBox btnAqua;
        private System.Windows.Forms.PictureBox btnBrightGreen;
        private System.Windows.Forms.PictureBox btnIndigo;
        private System.Windows.Forms.PictureBox btnDarkGray;
        private System.Windows.Forms.PictureBox btnGray;
        private System.Windows.Forms.PictureBox btnGold;
        private System.Windows.Forms.PictureBox btnPurple;
        private System.Windows.Forms.PictureBox btnDarkRed;
        private System.Windows.Forms.PictureBox btnDarkAqua;
        private System.Windows.Forms.PictureBox btnDarkGreen;
        private System.Windows.Forms.PictureBox btnDarkBlue;
        private System.Windows.Forms.PictureBox btnBlack;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.Button btnStrike;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox boxColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TextBox boxLore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer tmrRnd;
	}
}
