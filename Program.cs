using ImageMagick;
using Symage.audio;
using Symage.image;

namespace Symage;


public static class Program
{

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
			Console.WriteLine( "a - Convert images to WAV files using BitClap.\n" );
			Console.WriteLine( "i - Convert audio to PNG files using BitCirc.\n" );



			input = Console.ReadLine();
			Console.Clear();

			switch ( input )
			{
				case "a":
				{
					Console.WriteLine( "\nYou chose converting images to audio.\n" );
					Console.WriteLine( $"Place image files (PNG, JPG, WEBP) in    >  {FileMan.getDirInApp( "_images" )}.\n" );
					convertImageToAudio();
					break;
				}

				case "i":
				{
					Console.WriteLine( "\nYou chose converting audio to images.\n" );
					Console.WriteLine( $"Place audio files (WAV, MP3, OGG) in    >  {FileMan.getDirInApp( "_audio" )}.\n" );
					convertAudioToImage();
					break;
				}

				default:
				{
					Console.WriteLine( "\nNothing was selected, please try again.\n" );
					break;
				}

			}
		}



	}



	public static void convertImageToAudio()
	{
		Console.WriteLine( "\nEnter your desired sample rate. \nExample sample rates are:" );

		Console.WriteLine( "\n- 44100 - Typical for CD & DVD audio." );
		Console.WriteLine( "\n- 48000 - Used for studio recordings & professional sound editing." );
		Console.WriteLine( "\n- 32000 - Has a maximum (nyquist) frequency of 16khz (basically MP3 quality), \nlonger and lower-pitched WAV file." );

		int sample_rate = UserInput.getIntFromUser( "\nEnter target sample rate (default: 44100): ", 44100 );
		int channels = UserInput.getIntFromUser( "Enter number of channels (default: 2 (stereo)): ", 2 );


		string[] files = FileMan.getFilesInAppDir( "_images" );
		if ( files.Length < 1 )
		{
			Console.WriteLine( $"No files in directory {FileMan.getDirInApp( "_images" )}." );
			return;
		}


		for ( uint i = 0; i < files.Length; i++ )
		{
			Console.WriteLine( $"\nEncoding {files[ i ]} - ({i + 1} / {files.Length}) into audio...\n" );
			SampleDataObject pixel_data = Image24.decodeBytesRGB( new MagickImage( files[i] ) );

			AudioWav16.encodeWavBitClap16(
				FileMan.getDirInApp( "_output" ) + $"\\image_{i}.wav",
				pixel_data, sample_rate, channels
			);

		}

		Console.WriteLine( $"\nFinished! Hit enter to reset the program.\n" );
		Console.ReadLine();
	}




	public static void convertAudioToImage()
	{
		Console.WriteLine( "\nYou chose converting audio to images. \nIf no Y resolution is specified it \nwill be estimated for each image instead.\n" );

		int res_x = UserInput.getIntFromUser( "Enter the X resolution of the image (default: 512): ", 512 );
		int res_y = UserInput.getIntFromUser( "Enter the Y resolution of the image (default: 512): ", 512 );



		string[] files = FileMan.getFilesInAppDir( "_audio" );
		if ( files.Length < 1 )
		{
			Console.WriteLine( $"No files in directory {FileMan.getDirInApp( "_images" )}." );
			return;
		}


		for ( uint i = 0; i < files.Length; i++ )
		{
			Console.WriteLine( $"\nEncoding {files[ i ]} - ({i + 1} / {files.Length}) into image...\n" );
			SampleDataObject audio_data = AudioWav16.decodeBitCirc16( files[i] );

			Image24.encodeBytesRGB(
				FileMan.getDirInApp( "_output" ) + $"\\audio_{i}.png",
				audio_data, res_y, res_x
			);

		}

		Console.WriteLine( $"\nFinished! Hit enter to reset the program.\n" );
		Console.ReadLine();
	}


}