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




			Console.WriteLine( "\nHit enter to start Symage." );
			string? input = Console.ReadLine();


			Console.WriteLine( "\nSelect mode, type and press enter to select:\n\n" );
			Console.WriteLine( "\n1 - Convert images to WAV files using BitClap." );
			Console.WriteLine( "\n2 - Convert audio to PNG files using BitCirc." );



			input = Console.ReadLine();
			Console.Clear();

			switch ( input )
			{
				case "1":
				{
					Console.WriteLine( "\nYou chose converting images to audio.\n" );
					Console.WriteLine( $"\nPlace image files (PNG, JPG, WEBP) in    >  {FileMan.getDirInApp( "_images" )}.\n" );
					convertImageToAudio();
					break;
				}

				case "2":
				{
					Console.WriteLine( "\nYou chose converting audio to images.\n" );
					Console.WriteLine( $"\nPlace audio files (WAV, MP3) in    >  {FileMan.getDirInApp( "_audio" )}.\n" );
					convertAudioToImage();
					break;
				}

				default:
				{
					Console.WriteLine( "\nNothing was selected, please try again.\n" );
					break;
				}

			}

			Console.WriteLine( $"\n>> Hit enter to reset the program. <<\n" );
			Console.ReadLine();
			Console.Clear();
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
			Console.WriteLine( $"\nNo files in directory {FileMan.getDirInApp( "_images" )}." );
			return;
		}


		for ( uint i = 0; i < files.Length; i++ )
		{
			string file_name = FileMan.getFileName( files[i] ) + ".wav";
			Console.WriteLine( $"\nEncoding {files[ i ]} - ({i + 1} / {files.Length}) into audio...\n" );

			// Decoding.
			SampleDataObject pixel_data = Image24.decodeBytes( new MagickImage( files[i] ) );

			
			// Re-encoding but different format.
			AudioWav16.encodeWavBitClap16(
				FileMan.getDirInApp( "_output" ) + $"\\{file_name}",
				pixel_data, sample_rate, channels
			);

		}

	}




	public static void convertAudioToImage()
	{
		Console.WriteLine( "\nYou chose converting audio to images. \nIf no Y resolution is specified it \nwill be estimated for each image instead.\n" );

		int res_x = UserInput.getIntFromUser( "Enter the X resolution of the image (default: 512): ", 512 );
		int res_y = UserInput.getIntFromUser( "Enter the Y resolution of the image (default: 512): ", 512 );



		string[] files = FileMan.getFilesInAppDir( "_audio" );
		if ( files.Length < 1 )
		{
			Console.WriteLine( $"\nNo files in directory {FileMan.getDirInApp( "_images" )}." );
			return;
		}


		for ( uint i = 0; i < files.Length; i++ )
		{
			string file_name = FileMan.getFileName( files[i] ) + ".png";
			Console.WriteLine( $"\nEncoding {files[ i ]} - ({i + 1} / {files.Length}) into image...\n" );

			// The decodening.
			SampleDataObject audio_data = AudioWav16.decodeBitCirc16( files[i] );

			

			// The encodening.
			Image24.encodeBytes(
				FileMan.getDirInApp( "_output" ) + $"\\{file_name}",
				audio_data, res_y, res_x
			);

		}
	}


}