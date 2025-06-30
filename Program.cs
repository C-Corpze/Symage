

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




		MagickImage image = new MagickImage("D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\testimg.webp");
		Console.WriteLine($"Image width: {image.Width}, height: {image.Height}");


		DatObject dat_object = new DatObject(image.Width * image.Height * 4);


		IPixelCollection<byte> pixel_collection = image.GetPixels();

		// Iterate through pixel collection.
		for ( int x = 0; x < image.Width; x++ )
		{
			for ( int y = 0; y < image.Height; y++ )
			{
				IPixel<byte> pixel = pixel_collection.GetPixel(x, y);

				dat_object.addByte(pixel.GetChannel(0)); // R
				dat_object.addByte(pixel.GetChannel(1)); // G
				dat_object.addByte(pixel.GetChannel(2)); // B
				dat_object.addByte(pixel.GetChannel(3)); // A

				//int rgba_int = BitConv.make_int32(
				//	pixel.GetChannel(0),
				//	pixel.GetChannel(1),
				//	pixel.GetChannel(2),
				//	pixel.GetChannel(3)
				//);

				//Console.WriteLine($"Pixel ({x}, {y}): {rgba_int:x8}");

			}
		}

		for ( int i = 0; i < dat_object.byte_array.Length; i++ )
		{
			Console.WriteLine($"Byte: {dat_object.byte_array[i]}");
		}


	}

}