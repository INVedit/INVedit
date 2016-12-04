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
						if (File.Exists("NBT.dll"))
							RepeatUntilSuccessful(() => File.Delete("NBT.dll"));
						if (File.Exists("_INVedit.exe")) {
							RepeatUntilSuccessful(() => File.Delete("INVedit.exe"));
							File.Copy("_INVedit.exe", "INVedit.exe");
							Process.Start("INVedit.exe", "-finish");
							return;
						}
						break;
					case "-finish":
						RepeatUntilSuccessful(() => File.Delete("_INVedit.exe"));
						break;
				}
			} else { files.Add(arg); }

            if (!File.Exists("data.xml"))
            {
                MessageBox.Show("Couldn't find file 'data.xml'.\n" +
				                "Did you unpack INVedit correctly?", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(files.ToArray()));
		}
		
		private static void RepeatUntilSuccessful(Action action)
		{
			int times = 0;
			while (true) {
				try { action(); break; } catch {  }
				Thread.Sleep(500);
				if (times++ > 4) {
					var result = MessageBox.Show("Couldn't update INVedit.\n" +
					                             "Is another instance of INVedit running?", "Warning",
					                             MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
					if (result == DialogResult.Cancel)
						Application.Exit();
					times = 0;
				}
			}
		}
	}
}
