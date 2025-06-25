

using ImageMagick;
using NAudio;

namespace Symage;


internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hit enter to start.");
		var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");
		Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);


		MagickImage img = new MagickImage("D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\testimg.webp");

		Console.WriteLine($"Image width: {img.Width}, height: {img.Height}");


		IPixelCollection<byte> pixels = img.GetPixels();

		// Iterate through pixel collection.
		for ( int x = 0; x < img.Width; x++ )
		{
			for ( int y = 0; y < img.Height; y++ )
			{
				IPixel<byte> pixel = pixels.GetPixel(x, y);

				int pix_to_num = BitConv.make_int32(
					pixel.GetChannel(0),
					pixel.GetChannel(1),
					pixel.GetChannel(2),
					pixel.GetChannel(3)
					);

				Console.WriteLine($"Pixel ({x}, {y}): {pix_to_num:x8}");

				//Console.WriteLine($"Pixel ({x}, {y}): R={pixel.GetChannel(0)}, G={pixel.GetChannel(1)}, B={pixel.GetChannel(2)}, A={pixel.GetChannel(3)}");

			}
		}


	}

}