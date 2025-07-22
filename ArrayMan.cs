namespace Symage
{
	public static class ArrayMan
	{


		// Get the length of the array if all bytes were 16-bit numbers.
		public static uint lengthFromBytes( byte[] byte_array, uint in_bytes = 4 )
		{
			return (uint) ( ( byte_array.Length / in_bytes ) + ( byte_array.Length % in_bytes ) );
		}


		public static int[] toIntArray( byte[] arr )
		{
			int[] new_array = new int[ lengthFromBytes(arr, 4) ];


			return new_array;
		}



		public static float[] normalizeArray( float[] arr )
		{
			float peak = 1;

			// First get the peak from the array.

			for ( int i = 0; i < arr.Length; i++ )
			{
				if ( float.Abs( arr[ i ] ) > peak )
					peak = arr[ i ];
			}

			if ( peak <= 1.0f ) return arr; // Return if peak is unchanged.


			for ( int i = 0; i < arr.Length; i++ )
			{
				arr[ i ] /= peak; // NoRmAlIzAtIoN!
			}

			return arr;
		}


	}
}
