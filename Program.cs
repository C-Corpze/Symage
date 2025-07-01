

using ImageMagick;
using NAudio;
using NAudio.Wave;

namespace Symage;


internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hit enter to start.");
		var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");
		Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);




		MagickImage image = new MagickImage("D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\testimg.webp");
		Console.WriteLine($"Image width: {image.Width}, height: {image.Height}");

		DatObject dat_object = ImgClass.decodeImage24Bit(image);


		WaveFileWriter wave_writer = new WaveFileWriter(
			"D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\test.wav",
			new WaveFormat(44100, 32, 1)
		);

		wave_writer.Write(dat_object.byte_array, 0, dat_object.byte_array.Length);


	}

}