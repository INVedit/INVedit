using System;
using System.IO;
using System.Runtime.InteropServices;

namespace INVedit
{
	public class Platform
	{
		#region Static members
		static Platform()
		{
			if (IsWindows()) Current = Windows;
			else if (IsMac()) Current = Mac;
			else Current = Unix;
		}
		
		public static Platform Windows = new Platform("Windows");
		public static Platform Unix = new Platform("Unix");
		public static Platform Mac = new Platform("Mac");
		
		public static Platform Current { get; private set; }
		
		static bool IsWindows()
		{
			return (Path.DirectorySeparatorChar == '\\');
		}
		
		static bool IsMac()
		{
			IntPtr buf = IntPtr.Zero;
			try {
				buf = Marshal.AllocHGlobal(8192);
				if (uname(buf) == 0)
					if (Marshal.PtrToStringAnsi(buf) == "Darwin") return true;
			} catch {  }
			finally { if (buf != IntPtr.Zero) Marshal.FreeHGlobal(buf); }
			return false;
		}
		
		[DllImport("libc")]
		static extern int uname(IntPtr buf);
		#endregion
		
		public string Name { get; private set; }
		
		public Platform(string name)
		{
			Name = name;
		}
		
		public override string ToString()
		{
			return Name;
		}
	}
}
