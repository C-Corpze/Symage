namespace Symage
{
    public static class FileMan
    {

        public static string getDirInApp( string dir )
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + dir;

            if ( Directory.Exists( path ) ) return path;
            Directory.CreateDirectory( path );

            Console.WriteLine( $"Created directory: {path}" );
            return path;
        }



        public static string[] getFilesInDir( string dir )
        {
            string[] files = Directory.GetFiles( dir );

            return files;
        }



    }
}
