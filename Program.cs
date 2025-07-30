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

		while ( true )
		{
			Console.WriteLine( $"\nApp is settled in {FileMan.base_dir}.\n" );
			Console.WriteLine( "Symage will automatically batch-process images and sounds placed in \ntheir designated folders.\n" );

			Console.WriteLine( $"Images go in    >  {FileMan.getDirInApp( "_images" )}." );
			Console.WriteLine( $"Audio goes in   >  {FileMan.getDirInApp( "_audio" )}." );
			Console.WriteLine( $"Output goes to  >  {FileMan.getDirInApp( "_output" )}." );




			Console.WriteLine( "\nHit enter to start Symage.\n" );
			string? input = Console.ReadLine();


			Console.WriteLine( "Select mode, type and press enter to select:\n\n" );
			Console.WriteLine( "i - Convert images to WAV files.\n" );
			Console.WriteLine( "a - Convert audio to PNG files.\n" );



			input = Console.ReadLine();
			Console.Clear();

			switch ( input )
			{
				case "i":
				{
					Console.WriteLine( "\nYou chose converting images to audio.\n" );
					Console.WriteLine( $"Place image files (PNG, JPG, WEBP) in    >  {FileMan.getDirInApp( "_images" )}.\n" );
					convertImageToAudio();
					break;
				}

				case "a":
				{
					Console.WriteLine( "\nYou chose converting audio to images.\n" );
					Console.WriteLine( $"Place audio files (WAV, MP3, OGG) in    >  {FileMan.getDirInApp( "_audio" )}.\n" );
					//convertImageToAudio();
					break;
				}

				default:
				{
					Console.WriteLine( "\nNothing was selected, please try again.\n" );
					break;
				}

			}
		}


		// Some testing code.

		Console.WriteLine( $"Encoding image into audio." );
		MagickImage image = new MagickImage( debug_dir + "testimg.webp" );

		SampleDataObject dat = Image24.decodeBytesRGB( image );
		AudioWav16.encodeWavBitClap16( debug_dir + "test.wav", dat );



		Console.WriteLine( "Hit enter to encode audio file back into image." );
		Console.ReadLine();

		Console.WriteLine( $"Now encoding audio file back into image." );
		SampleDataObject aud_dat = AudioWav16.decodeBitCirc16( debug_dir + "test.wav" );

		Image24.encodeBytesRGB( debug_dir + "audio_to_image.png", aud_dat, 256 * 2 );

	}


	public static void convertImageToAudio()
	{
		Console.WriteLine( "\nEnter your desired sample rate. \nExample sample rates are:" );

		Console.WriteLine( "\n- 44100 - Typical for CD & DVD audio." );
		Console.WriteLine( "\n- 48000 - Used for studio recordings & professional sound editing." );
		Console.WriteLine( "\n- 32000 - Has a maximum (nyquist) frequency of 16khz (basically MP3 quality), \nlonger and lower-pitched WAV file." );

		int sample_rate = UserInput.getIntFromUser( "\nEnter target sample rate (default: 44100): ", 44100 );
		int channels = UserInput.getIntFromUser( "Enter number of channels (default: 2 (stereo)): ", 2 );
	}

	public static void convertAudioToImage()
	{
		int res_x = UserInput.getIntFromUser( "Enter the X resolution of the image (default: 512): ", 512 );
		int res_y = UserInput.getIntFromUser( "Enter the Y resolution of the image (default: auto): ", 0 );
	}


}