using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace INVedit
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
			
			List<string> files = new List<string>();
			foreach (string arg in args)
				if (arg.Length > 0 && arg[0] == '-') {
				switch (args[0]) {
					case "-update":
						if (File.Exists("_INVedit.exe")) {
							while (true) {
								try { File.Delete("INVedit.exe"); break; } catch {  }
								Thread.Sleep(500);
							} File.Copy("_INVedit.exe", "INVedit.exe");
							Process.Start("INVedit.exe", "-finish");
							return;
						} break;
					case "-finish":
						while (true) {
							try { File.Delete("_INVedit.exe"); break; } catch {  }
							Thread.Sleep(500);
						} break;
				}
			} else { files.Add(arg); }
			
			if (!File.Exists("items.txt")) {
				MessageBox.Show("Couldn't find file 'items.txt'.\n" +
				                "Did you unpack INVedit correctly?", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(files.ToArray()));
		}
	}
}
