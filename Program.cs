using ImageMagick;

namespace Symage;


public static class Program
{
	public static string debug_dir = "D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\";


	static void Main( string[] args )
	{
		// Create dem directories, they probably won't exist yet at the first run.
		FileMan.getDirInApp( "_images" );
		FileMan.getDirInApp( "_audio" );
		FileMan.getDirInApp( "_output" );


		Console.WriteLine( "Hit enter to start." );
		var input = Console.ReadLine();

		//Console.WriteLine($"You entered: {input}");

		Console.WriteLine( FileMan.base_dir );


		// Some testing code.
		MagickImage image = new MagickImage( debug_dir + "testimg.webp" );

		SampleDataObject dat = ImgClass.bitClap24Bit( image );

		AudClass.encodeWavFloat( debug_dir + "test.wav", dat );

		//ImgClass.bitCirc24Bit( debug_dir + "testimg2.png", dat, 1280 );

	}


}