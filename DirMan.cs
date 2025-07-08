using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Symage
{
	public static class DirMan
	{

		public static string createDirInApp( string dir )
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + dir;

			if (Directory.Exists(path)) return path;
			Directory.CreateDirectory(path);

			Console.WriteLine($"Created directory: {path}");
			return path;
		}

	}
}
