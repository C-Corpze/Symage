using ImageMagick;

namespace Symage.image;

public static class Image8BW
{

	// Decode a image (without alpha channel) into a data object.

	public static SampleDataObject decodeBytes( MagickImage image )
	{
		// Initialize the data object to hold the image's data.
		SampleDataObject dat_object = new SampleDataObject( image.Width * image.Height );

		// Gets all the pixels from the image object.
		IPixelCollection<byte> pixel_collection = image.GetPixels();


		Console.WriteLine( $"(Greyscale) Image width: {image.Width}, height: {image.Height}." );

		// Iterate through pixel collection.
		for ( int x = 0; x < image.Width; x++ )
		{
			for ( int y = 0; y < image.Height; y++ )
			{
				// Read every single pixel and add it's pixel bytes to the data object.
				IPixel<byte> pixel = pixel_collection.GetPixel( x, y );

				int val = (
					pixel.GetChannel( 0 ) +
					pixel.GetChannel( 1 ) +
					pixel.GetChannel( 2 )
					) / 3;

				dat_object.addByte( (byte) val ); // R
			}
		}

		dat_object.printState();

		return dat_object;
	}





	// Encodes a image.

	public static void encodeBytes( string file_path, SampleDataObject dat_object, int res_y = 512, int res_x = 512 )
	{
		int length = dat_object.byte_array.Length; // Length of the byte array.


		MagickColor color = new MagickColor( 0, 0, 0 ); // Black color for the image background.

		MagickImage image = new MagickImage(
				color,
				(uint) res_x,
				(uint) res_y
			);

		Console.WriteLine( $"(Greyscale) Set image width: {image.Width}, height: {image.Height}." );



		using ( IPixelCollection<byte> pixel_collection = image.GetPixels() )
		{
			// This is the part where we color in the entire image with bytes.

			for ( int x = 0; x < res_x; x++ )
			{
				for ( int y = 0; y < res_y; y++ )
				{
					IPixel<byte> pixel = pixel_collection.GetPixel( x, y );

					byte val = dat_object.getByte();

					pixel.SetChannel( 0, val ); // Red.
					pixel.SetChannel( 1, val ); // Green.
					pixel.SetChannel( 2, val ); // Blue.
				}
			}

			Console.WriteLine( $"Written bytes to pixels." );
		}


		image.Write( file_path ); // Write the image to the specified file path.
		Console.WriteLine( $"Image outputted into {file_path}." );
	}

}

