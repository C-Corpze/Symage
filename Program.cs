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
		string? input = Console.ReadLine();

		//Console.WriteLine($"You entered: {input}");

		Console.WriteLine( FileMan.base_dir );


		// Some testing code.

		Console.WriteLine( $"Encoding image nto audio." );
		MagickImage image = new MagickImage( debug_dir + "testimg.webp" );

		SampleDataObject dat = ImgClass.bitClap24Bit( image );
		AudClass.encodeWavFloat( debug_dir + "test.wav", dat );



		Console.WriteLine( "Hit enter to encode audio file back into image." );
		input = Console.ReadLine();

		Console.WriteLine($"Now encoding audio file back into image.");
		SampleDataObject aud_dat = AudClass.decodeWavFloat( debug_dir + "test.wav" );

		ImgClass.bitCirc24Bit( debug_dir + "audio_to_image.png", aud_dat, 1280 );

	}


}