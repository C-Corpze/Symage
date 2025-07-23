namespace Symage
{
	public static class FileMan
	{

		public static string base_dir = AppDomain.CurrentDomain.BaseDirectory;


		public static string getDirInApp( string dir )
		{
			string path = base_dir + dir;

			if ( Directory.Exists( path ) ) return path;
			Directory.CreateDirectory( path );

			Console.WriteLine( $"Created directory: {path}" );
			return path;
		}



		public static string[] getFilesInAppDir( string folder )
		{
			return Directory.GetFiles( base_dir + folder );
		}


		public static string[] getFilesInDir( string dir )
		{
			string[] files = Directory.GetFiles( dir );

			return files;
		}



	}
}
