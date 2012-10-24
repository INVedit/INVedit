using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace INVedit
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			label1.Text = label1.Text.Replace("{version}", Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
		}
		
		void LinkLabel1LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.icsharpcode.net/OpenSource/SD/");
		}
		void LinkLabel2LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.minecraftforum.net/viewtopic.php?t=15921");
		}
		void LinkLabel3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.famfamfam.com/lab/icons/silk/");
		}
		void LinkLabel4LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://copy.mcft.net/");
		}
		void LinkLabel5LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://phonicuk.com/");
		}
	}
}
