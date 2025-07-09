using ImageMagick;
using NAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Symage
{
	public static class ImgClass
	{

		// Decode a image (with alpha channel) into a data object.
		public static DatObject decodeImage32Bit(MagickImage image)
		{
			// Initialize the data object to hold the image's data.
			DatObject dat_object = new DatObject(image.Width * image.Height * 4);

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
		public static DatObject decodeImage24Bit(MagickImage image)
		{
			// Initialize the data object to hold the image's data.
			DatObject dat_object = new DatObject(image.Width * image.Height * 3);

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



		// ENcodes a image, receives a DatObject as input.
		public static void bitClap24Bit(DatObject dat_object, int res_y = 512)
		{
			// Get the remainder of the array length divided by the height.
			int remainder = dat_object.byte_array.Length % res_y;

			// Calculate the width of the image based on the height and the remainder.
			int res_x = (dat_object.byte_array.Length + remainder) / res_y;



			MagickImage image = new MagickImage(
				new byte[] { 0, 0, 0, 0 }, // RGBA values as a byte array.
				(uint) res_x,
				(uint) res_y
			);
			

		}
	}
}
