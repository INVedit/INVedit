using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INVedit
{
	public partial class AboutForm : Form
	{


        //Create our Fonts to draw our scroll about credits.
        Font textFont = new Font("Arial", 8);
        Font textFontLink = new Font("Arial", 8, FontStyle.Underline);
        Font textFontBold = new Font("Arial", 8, FontStyle.Bold | FontStyle.Underline);

        //Setup our starting locations for the credits.
        int x = 20;
        int y;



		public AboutForm()
		{
			InitializeComponent();
			
		}

        private void AboutForm_Load(object sender, EventArgs e)
        {

            //Have to do it this way cause some how SharpDevelop Screwed the Resources.
            picSide.Image = INVedit.Resources.side;
            picPP1.Image = INVedit.Resources.paypal;
            picPP2.Image = INVedit.Resources.paypal;
            //Set current location for Y Axis.
            y = 155;



            txtChange.Text = "v1.0.6\r\n"+
                             "   1. Added ability to edit Fireworks Star.\r\n"+
                             "   2. Added Firework design type to items.txt.\r\n" +
                             "\r\n\r\n"+
                             "v1.0.5\r\n" +
                             "   1. Updated/Changed Items.txt.\r\n" +
                             "   2. Added ability to edit enchanted books.\r\n" +
                             "   3. Added ability to edit potions.\r\n" +
                             "   4. Added ability to edit fireworks.\r\n" +
                             "   5. Changed GUI for new coding.\r\n"+
                             "   6. Changed book/item to accept formatting.\r\n" +
                             "   7. Changed book/item to allow previews.\r\n" +
                             "   8. Redesigned About, for new information.\r\n";








        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //Cleanup any stray memory.
            GC.Collect();

            //Close the Form
            this.Close();
        }

        private void tmrScroll_Tick(object sender, EventArgs e)
        {

            //Create our Brushes to draw with.
            SolidBrush BlackBrush = new SolidBrush(Color.Black);
            SolidBrush LinkBrush = new SolidBrush(Color.Blue);

            //Set the Boundries for our Picture.
            Bitmap b = new Bitmap(picAbout.Width, picAbout.Height);

            //Create the graphics object from our Picture.
            Graphics g = Graphics.FromImage(b);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.High;

            //if the scrolled Text is out of users sight reset the location.
            if (y <= -320)
            {
                y = 155;
            }

            //Clear the Picture.
            g.Clear(System.Drawing.Color.White);


            //Draw our Icon on the Image
            g.DrawImage(INVedit.Resources.icon, x + 100, y - Icon.Height + 28);

            //Draw our About Info.
            g.DrawString("INVedit", textFontBold, BlackBrush, x, y);
            g.DrawString("Build: " + Application.ProductVersion, textFontBold, BlackBrush, x, y + 15);

            g.DrawString("[Software Designer]", textFontBold, BlackBrush, x, y + 80);
            g.DrawString("   copyboy - (Programming)", textFont, BlackBrush, x, y + 95);
            g.DrawString("   Iteration - (Programming)", textFont, BlackBrush, x, y + 110);
            
            //space of 20

            g.DrawString("[Graphics Designer]", textFontBold, BlackBrush, x, y + 130);
            g.DrawString("   epaGamer", textFont, BlackBrush, x, y + 145);
            g.DrawString("   famfamfam.com", textFont, BlackBrush, x, y + 160);

            //space of 20

            g.DrawString("[Email]", textFontBold, BlackBrush, x, y + 180);
            g.DrawString("   copyboy@hotmail.de", textFont, BlackBrush, x, y + 195);
            g.DrawString("   dhiteration@Gmail.com", textFont, BlackBrush, x, y + 210);

            g.DrawString("[License]", textFontBold, BlackBrush, x, y + 230);
            g.DrawString("   Freeware", textFont, BlackBrush, x, y + 245);


            g.DrawString("[THE END]", textFontBold, BlackBrush, x, y + 285);

            //Set picAbouts Image to our Drawn Picture.
            picAbout.BackgroundImage = b;
            //Adjust the Size.
            picAbout.Size = b.Size;
            //Scroll our Picture.
            y -= 1;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.minecraftforum.net/topic/14190-discontinued-invedit-minecraft-inventory-editor/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.famfamfam.com/lab/icons/silk/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://copy.mcft.net");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/uk/cgi-bin/webscr?cmd=_flow&SESSION=dQbEL52E1spAnmZGbbW9KH45w7UTQkF8uPGHCToYjN6xI_kM36YSQ33ZKea&dispatch=5885d80a13c0db1f8e263663d3faee8d0b7e678a25d883d0fa72c947f193f8fd");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=7U4M642AQBXNL&lc=US");
        }


	}
}
