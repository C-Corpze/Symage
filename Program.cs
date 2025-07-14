

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
				debug_dir + "test.wav", // Location and name of file.
				new WaveFormat(44100, 32, 1)
		))
		{
			wave_writer.Write(dat_object.byte_array, 0, dat_object.byte_array.Length);
		}



		// Now we convert a audio to an image.

		using (WaveFileReader wave_reader = new WaveFileReader(debug_dir + "test.wav"))
		{
			DatObject audio_dat_object = new DatObject( (uint) wave_reader.Length);

			ISampleProvider sample_provider = wave_reader.ToSampleProvider();
			float[] buffer = new float[wave_reader.Length / 4]; // Buffer for reading samples.

			sample_provider.Read(buffer, 0, buffer.Length);


			ImgClass.bitCirc24Bit(audio_dat_object, debug_dir + "testimg2.webp", 512);
		}


	}

}