

using ImageMagick;
using NAudio.Wave;

namespace Symage;


public static class Program
{
	public static string debug_dir = "D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\";

	static void Main( string[] args )
	{
		// Create dem directories, they probably won't exist yet at the first run.
		DirMan.createDirInApp( "_images" );
		DirMan.createDirInApp( "_audio" );
		DirMan.createDirInApp( "_output" );


		Console.WriteLine( "Hit enter to start." );
		var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");
		Console.WriteLine( AppDomain.CurrentDomain.BaseDirectory );

	}



	public static void convertImg2Aud()
	{
		MagickImage image = new MagickImage(debug_dir + "testimg.webp");
		Console.WriteLine( $"Image width: {image.Width}, height: {image.Height}" );

		SampleDataObject data_object = ImgClass.bitClap24Bit(image);


		WaveFileWriter wave_writer = new WaveFileWriter(
				debug_dir + "test.wav", // Location and name of file.
				new WaveFormat( 44100, 32, 1 )
		);

		wave_writer.Write( data_object.byte_array, 0, data_object.byte_array.Length );
	}

}