using ImageMagick;
using NAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Symage
{
	public static class ImgClass
	{

		// Decode a image (with alpha channel) into a data object.
		public static SampleDataObject bitClap32Bit(MagickImage image)
		{
			// Initialize the data object to hold the image's data.
			SampleDataObject dat_object = new SampleDataObject(image.Width * image.Height * 4);

			// Gets all the pixels from the image object.
			IPixelCollection<byte> pixel_collection = image.GetPixels();



			// Iterate through pixel collection.
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					// Read every single pixel and add it's pixel bytes to the data object.
					IPixel<byte> pixel = pixel_collection.GetPixel(x, y);

					dat_object.addByte(pixel.GetChannel(0)); // R
					dat_object.addByte(pixel.GetChannel(1)); // G
					dat_object.addByte(pixel.GetChannel(2)); // B
					dat_object.addByte(pixel.GetChannel(3)); // A
				}
			}

			dat_object.printState();

			return dat_object;
		}



		// Decode a image (without alpha channel) into a data object.
		public static SampleDataObject bitClap24Bit(MagickImage image)
		{
			// Initialize the data object to hold the image's data.
			SampleDataObject dat_object = new SampleDataObject(image.Width * image.Height * 3);

			// Gets all the pixels from the image object.
			IPixelCollection<byte> pixel_collection = image.GetPixels();



			// Iterate through pixel collection.
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					// Read every single pixel and add it's pixel bytes to the data object.
					IPixel<byte> pixel = pixel_collection.GetPixel(x, y);

					dat_object.addByte(pixel.GetChannel(0)); // R
					dat_object.addByte(pixel.GetChannel(1)); // G
					dat_object.addByte(pixel.GetChannel(2)); // B
				}
			}

			dat_object.printState();

			return dat_object;
		}



		// Encodes a image, receives a DatObject as input.
		public static void bitCirc24Bit(SampleDataObject dat_object, string file_path, int res_y = 512)
		{
			int length = dat_object.byte_array.Length; // Length of the byte array.

			// Length of the byte array, rounded up by an increment of 3 bytes.
			// Necessary to accurately calculate the X resolution.
			int sample_count = length + (length % 3);

			// Get the remainder of the array length divided by the height.
			int remainder = sample_count % res_y;

			// Calculate the width of the image based on the height and the remainder.
			int res_x = (sample_count + remainder) / res_y;



			MagickImage image = new MagickImage(
				new byte[] { 0, 0, 0 }, // RGBA values as a byte array.
				(uint) res_x,
				(uint) res_y
			);
			Console.WriteLine($"Calculated image width: {image.Width}, height: {image.Height}.");



			using (IPixelCollection<byte> pixel_collection = image.GetPixels())
			{

				for (int x = 0; x < length; x++)
				{
					for (int y = 0; y < length; y++)
					{
						IPixel<byte> pixel = pixel_collection.GetPixel(x, y);

						pixel.SetChannel(0, dat_object.getByte()); // Red.
						pixel.SetChannel(1, dat_object.getByte()); // Green.
						pixel.SetChannel(2, dat_object.getByte()); // Blue.
					}
				}

				Console.WriteLine($"Written bytes to pixels.");
			}


			image.Write(file_path); // Write the image to the specified file path.
			Console.WriteLine($"Image outputted into {file_path}.");

		}
	}
}
