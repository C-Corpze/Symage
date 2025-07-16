// Simple class for extracting, combining and manipulating bits in a fast and efficient manner.




namespace Symage
{
	public static class BitConv
	{

		// Returns a byte from a 32-bit integer, from right to left.
		// Bytes are usually in little-endian order.
		public static byte getByte( int val, int pos = 0 )
		{
			if ( pos < 1 ) return (byte) ( val & 0xff ); // Return first byte if no position is specified.

			int new_val = val >> ( pos * 8 ); // Bit shift the thingus to get the desired byte.


			return (byte) ( new_val & 0xff ); // Mask it and convert to byte to return 8-bit integer.
		}

		public static byte getByte( uint val, int pos = 0 )
		{
			if ( pos < 1 ) return (byte) ( val & 0xff ); // Return first byte if no position is specified.

			uint new_val = val >> ( pos * 8 ); // Bit shift the thingus to get the desired byte.


			return (byte) ( new_val & 0xff ); // Mask it and convert to byte to return 8-bit integer.
		}





		// Combines bytes into a 32-bit integer, for 24 bit just don't use the last byte. Lmao
		public static int makeInt32( byte b1, byte b2, byte b3, byte b4 = 0x00 )
		{
			return (int) (
				( b1 << 24 ) | ( b2 << 16 ) | ( b3 << 8 ) | b4
			);
		}

		public static uint makeUInt32( byte b1, byte b2, byte b3, byte b4 = 0x00 )
		{
			return (uint) (
				( b1 << 24 ) | ( b2 << 16 ) | ( b3 << 8 ) | b4
			);
		}



		public static float makeFloat( byte b1, byte b2, byte b3, byte b4 = 0x00 )
		{
			return BitConverter.Int32BitsToSingle(
				( b1 << 24 ) | ( b2 << 16 ) | ( b3 << 8 ) | b4
			);
		}




		// Combine 2 bytes into an 16-bit integer.
		public static short makeInt16( byte b1, byte b2 )
		{
			return (short) ( ( b1 << 8 ) | b2 );
		}

		public static ushort makeUInt16( byte b1, byte b2 )
		{
			return (ushort) ( ( b1 << 8 ) | b2 );
		}






		// Converter functions.

		public static int toInt( float x )
		{
			return BitConverter.SingleToInt32Bits( x ); // Converts a float to 32-bit integer.
		}

		public static int toInt( uint x )
		{
			return BitConverter.SingleToInt32Bits( BitConverter.UInt32BitsToSingle( x ) );
		}



		public static float toFloat( int x )
		{
			return BitConverter.Int32BitsToSingle( x );
		}

		public static float toFloat( uint x )
		{
			return BitConverter.UInt32BitsToSingle( x );
		}



		public static uint toUInt( float x )
		{
			return BitConverter.SingleToUInt32Bits( x );
		}

		public static uint toUInt( int x )
		{
			return BitConverter.SingleToUInt32Bits( BitConverter.Int32BitsToSingle( x ) );
		}



	}
}
