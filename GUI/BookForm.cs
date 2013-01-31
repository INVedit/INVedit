using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INVedit
{
    public partial class BookForm : Form
    {

        private string _BookText;
        public string BookText
        {
            get { return _BookText; }
            set { _BookText = value; }
        }


        public BookForm()
        {
            InitializeComponent();

            //Have to do it this way cause some how SharpDevelop Screwed the Resources.
            pictureBox1.Image  = INVedit.Resources.book;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            BookText = parseText(BookText);
            webBrowser1.Navigate("about: <html><body bgcolor=\"#fdf8ec\">" + BookText + "</body></html>");
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private string parseText(string Text)
        {
            string parsedText = Text;

            parsedText = parsedText.Replace("§r", "</font></b></i></s></u>");
            parsedText = parsedText.Replace("§k", "[RndLtrs]");
            parsedText = parsedText.Replace("§l", "<b>");
            parsedText = parsedText.Replace("§m", "<s>");
            parsedText = parsedText.Replace("§n", "<u>");
            parsedText = parsedText.Replace("§o", "<i>");
            parsedText = parsedText.Replace("§0", "<font color=\"#000000\">");
            parsedText = parsedText.Replace("§1", "<font color=\"#0000AA\">");
            parsedText = parsedText.Replace("§2", "<font color=\"#00AA00\">");
            parsedText = parsedText.Replace("§3", "<font color=\"#00AAAA\">");
            parsedText = parsedText.Replace("§4", "<font color=\"#AA0000\">");
            parsedText = parsedText.Replace("§5", "<font color=\"#AA00AA\">");
            parsedText = parsedText.Replace("§6", "<font color=\"#FFAA00\">");
            parsedText = parsedText.Replace("§7", "<font color=\"#AAAAAA\">");
            parsedText = parsedText.Replace("§8", "<font color=\"#555555\">");
            parsedText = parsedText.Replace("§9", "<font color=\"#5555FF\">");
            parsedText = parsedText.Replace("§a", "<font color=\"#55FF55\">");
            parsedText = parsedText.Replace("§b", "<font color=\"#55FFFF\">");
            parsedText = parsedText.Replace("§c", "<font color=\"#FF5555\">");
            parsedText = parsedText.Replace("§d", "<font color=\"#FF55FF\">");
            parsedText = parsedText.Replace("§e", "<font color=\"#FFFF55\">");
            parsedText = parsedText.Replace("§f", "<font color=\"#FFFFFF\">");
            parsedText = parsedText.Replace("\r\n", "<br>");
            parsedText = parsedText.Replace("\n", "<br>");

            return parsedText;
        }




    }
}
