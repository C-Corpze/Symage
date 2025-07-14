

using ImageMagick;
using NAudio;
using NAudio.Wave;
using System.Text.RegularExpressions;

namespace Symage;


internal class Program
{
	static void Main(string[] args)
	{
		string debug_dir = "D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\";

		// Create dem directories, they probably won't exist yet at the first run.
		DirMan.createDirInApp("_images");
		DirMan.createDirInApp("_audio");
		DirMan.createDirInApp("_output");


		Console.WriteLine("Hit enter to start.");
		var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");
		Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);






		MagickImage image = new MagickImage(debug_dir + "testimg.webp");
		Console.WriteLine($"Image width: {image.Width}, height: {image.Height}");

		DatObject dat_object = ImgClass.bitClap24Bit(image);


		using (WaveFileWriter wave_writer = new WaveFileWriter(
				debug_dir + "test.wav",
				new WaveFormat(44100, 32, 1)
		))
		{
			wave_writer.Write(dat_object.byte_array, 0, dat_object.byte_array.Length);
		}




	}

}