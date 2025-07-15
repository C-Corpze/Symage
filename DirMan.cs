namespace Symage
{
	public static class DirMan
	{

		public static string createDirInApp( string dir )
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + dir;

			if ( Directory.Exists( path ) ) return path;
			Directory.CreateDirectory( path );

			Console.WriteLine( $"Created directory: {path}" );
			return path;
		}

	}
}
