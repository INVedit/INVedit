/*
 * Created by SharpDevelop.
 * User: copygirl
 * Date: 30.08.2012
 * Time: 13:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace INVedit
{
	partial class EditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
			this.boxText = new System.Windows.Forms.TextBox();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.labelPage = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.boxTitle = new System.Windows.Forms.TextBox();
			this.boxSigned = new System.Windows.Forms.CheckBox();
			this.btnHelp = new System.Windows.Forms.Button();
			this.boxAuthor = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// boxText
			// 
			this.boxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.boxText.Enabled = false;
			this.boxText.Location = new System.Drawing.Point(6, 60);
			this.boxText.Multiline = true;
			this.boxText.Name = "boxText";
			this.boxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.boxText.Size = new System.Drawing.Size(303, 109);
			this.boxText.TabIndex = 5;
			this.boxText.TextChanged += new System.EventHandler(this.BoxTextTextChanged);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrevious.Enabled = false;
			this.btnPrevious.Location = new System.Drawing.Point(5, 173);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(40, 22);
			this.btnPrevious.TabIndex = 6;
			this.btnPrevious.Text = "<<";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.BtnPreviousClick);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(269, 173);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(40, 22);
			this.btnNext.TabIndex = 7;
			this.btnNext.Text = ">>";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
			// 
			// labelPage
			// 
			this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPage.Location = new System.Drawing.Point(51, 173);
			this.labelPage.Name = "labelPage";
			this.labelPage.Size = new System.Drawing.Size(212, 22);
			this.labelPage.TabIndex = 8;
			this.labelPage.Text = "Page 0 of 0";
			this.labelPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Title:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// boxTitle
			// 
			this.boxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.boxTitle.Enabled = false;
			this.boxTitle.Location = new System.Drawing.Point(57, 7);
			this.boxTitle.Name = "boxTitle";
			this.boxTitle.Size = new System.Drawing.Size(220, 20);
			this.boxTitle.TabIndex = 1;
			this.boxTitle.TextChanged += new System.EventHandler(this.BoxTitleTextChanged);
			// 
			// boxSigned
			// 
			this.boxSigned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.boxSigned.Appearance = System.Windows.Forms.Appearance.Button;
			this.boxSigned.Enabled = false;
			this.boxSigned.Location = new System.Drawing.Point(255, 31);
			this.boxSigned.Name = "boxSigned";
			this.boxSigned.Size = new System.Drawing.Size(54, 24);
			this.boxSigned.TabIndex = 4;
			this.boxSigned.Text = "Signed";
			this.boxSigned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.boxSigned.UseVisualStyleBackColor = true;
			this.boxSigned.CheckedChanged += new System.EventHandler(this.BoxSignedCheckedChanged);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
			this.btnHelp.Location = new System.Drawing.Point(283, 4);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(26, 26);
			this.btnHelp.TabIndex = 2;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.BtnHelpClick);
			// 
			// boxAuthor
			// 
			this.boxAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.boxAuthor.Enabled = false;
			this.boxAuthor.Location = new System.Drawing.Point(57, 33);
			this.boxAuthor.Name = "boxAuthor";
			this.boxAuthor.Size = new System.Drawing.Size(192, 20);
			this.boxAuthor.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 18);
			this.label1.TabIndex = 9;
			this.label1.Text = "Author:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 199);
			this.Controls.Add(this.boxSigned);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.boxAuthor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelPage);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.boxText);
			this.Controls.Add(this.boxTitle);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditForm";
			this.ShowInTaskbar = false;
			this.Text = "Book Editor";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox boxTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelPage;
		private System.Windows.Forms.CheckBox boxSigned;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.TextBox boxText;
		private System.Windows.Forms.TextBox boxAuthor;
		private System.Windows.Forms.Label label1;
	}
}
