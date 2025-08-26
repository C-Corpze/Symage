using System.Numerics;

namespace Symage;



public static class ArrayMan
{


	public static uint getLengthInBytes( byte[] array )
	{
		return (uint) array.Length;
	}
	public static uint getLengthInBytes( short[] array )
	{
		return (uint) array.Length * 2;
	}
	public static uint getLengthInBytes( ushort[] array )
	{
		return (uint) array.Length * 2;
	}
	public static uint getLengthInBytes( int[] array )
	{
		return (uint) array.Length * 4;
	}
	public static uint getLengthInBytes( uint[] array )
	{
		return (uint) array.Length * 4;
	}
	public static uint getLengthInBytes( float[] array, bool as16bit = false )
	{
		if ( as16bit ) return (uint) array.Length * 2;
		return (uint) array.Length * 4;
	}




	// Get the length of the array if all bytes were 16-bit numbers.
	public static uint lengthFromBytes( byte[] byte_array, uint in_bytes = 4 )
	{
		return (uint) ( ( byte_array.Length / in_bytes ) + ( byte_array.Length % in_bytes ) );
	}


	public static T[] swapOddWithEven<T>( T[] array ) where T : INumber<T>
	{
		for ( uint i = 0; i < array.Length; i += 2 )
		{
			if ( i > array.Length || ( i + 1 ) > array.Length ) break; // Prevent out of bounds stuff.

			T odd = array[ i ]; // Technically it's even because arrays start at 0 but can't be arsed to correct it.
			T even = array[ i + 1 ];
			// Da swappening.
			array[ i ] = even;
			array[ i + 1 ] = odd;
		}

		return array;
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

