using ImageMagick;
using Symage.audio;
using Symage.image;

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

		Console.WriteLine( $"App is settled in {FileMan.base_dir}.\n" );
		Console.WriteLine( "Symage will automatically batch-process images and sounds placed in\ntheir designated folders.\n" );

		Console.WriteLine( $"Images go in    >  {FileMan.getDirInApp( "_images" )}." );
		Console.WriteLine( $"Audio goes in   >  {FileMan.getDirInApp( "_audio" )}." );
		Console.WriteLine( $"Output goes to  >  {FileMan.getDirInApp( "_output" )}." );



		while (true)
		{
			Console.WriteLine( "\nHit enter to start Symage.\n" );
			string? input = Console.ReadLine();


			Console.WriteLine("Select mode:\n\n");
			Console.WriteLine( "i - Convert images to WAV files.\n" );
			Console.WriteLine( "a - Convert audio to PNG files.\n" );




		}


		// Some testing code.

		Console.WriteLine( $"Encoding image nto audio." );
		MagickImage image = new MagickImage( debug_dir + "testimg.webp" );

		SampleDataObject dat = Image24.decodeBytesRGB( image );
		AudioWav16.encodeWavBitClap16( debug_dir + "test.wav", dat );



		Console.WriteLine( "Hit enter to encode audio file back into image." );
		Console.ReadLine();

		Console.WriteLine( $"Now encoding audio file back into image." );
		SampleDataObject aud_dat = AudioWav16.decodeBitCirc16( debug_dir + "test.wav" );

		Image24.encodeBytesRGB( debug_dir + "audio_to_image.png", aud_dat, 256 * 2 );

	}


}