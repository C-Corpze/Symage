namespace Symage
{
	// Wahoo, the data object.
	public class SampleDataObject
	{

		//List<byte> bytelist = new List<byte>();

		public byte[] byte_array = new byte[1];
		public int index = 0;


		// Constructor function.
		public SampleDataObject( uint asize )
		{
			initArray( asize );
		}

		// Overloads that make it very easy to initialize a byte array from an existing array.
		public SampleDataObject( float[] arr )
		{
			uint len = (uint) lengthOfInBytes( arr );
			initArray( len );

			for ( uint i = 0; i < arr.Length; i++ )
			{
				addFloat( arr[ i ] );
			}
		}

		public SampleDataObject( int[] arr )
		{
			uint len = (uint) lengthOfInBytes( arr );
			initArray( len );

			for ( uint i = 0; i < arr.Length; i++ )
			{
				addFloat( arr[ i ] );
			}
		}

		public SampleDataObject( uint[] arr )
		{
			uint len = (uint) lengthOfInBytes( arr );
			initArray( len );

			for ( uint i = 0; i < arr.Length; i++ )
			{
				addFloat( arr[ i ] );
			}
		}

		public SampleDataObject( short[] arr )
		{
			uint len = (uint) lengthOfInBytes( arr );
			initArray( len );

			for ( uint i = 0; i < arr.Length; i++ )
			{
				addFloat( arr[ i ] );
			}
		}

		public SampleDataObject( ushort[] arr )
		{
			uint len = (uint) lengthOfInBytes( arr );
			initArray( len );

			for ( uint i = 0; i < arr.Length; i++ )
			{
				addFloat( arr[ i ] );
			}
		}



		// This just initializes an byte array, you must know the size beforehand.
		public void initArray( uint asize )
		{
			byte_array = new byte[ asize ];
			index = 0;
		}


		// Get the length of the array if all bytes were 16-bit numbers.
		public int length16()
		{
			return ( byte_array.Length / 2 ) + ( byte_array.Length % 2 ); // Returns the size of the array in 16-bit integers.
		}

		// Get the length of the array if all bytes were 32-bit numbers.
		public int length32()
		{
			return ( byte_array.Length / 4 ) + ( byte_array.Length % 4 ); // Returns the size of the array in 32-bit integers.
		}

		public int lengthOfInBytes( short[] arr )
		{
			return arr.Length * 2;
		}

		public int lengthOfInBytes( ushort[] arr )
		{
			return arr.Length * 2;
		}

		public int lengthOfInBytes( int[] arr )
		{
			return arr.Length * 4;
		}

		public int lengthOfInBytes( uint[] arr )
		{
			return arr.Length * 4;
		}

		public int lengthOfInBytes( float[] arr )
		{
			return arr.Length * 4;
		}





		// This will add one (1) byte into the array, or rather overwrites one.
		public void addByte( byte b )
		{
			byte_array[ index ] = b; // Add one byte at a time and move the index.
			index++;

			// Dead-simple measure to prevent ever going outta bounds.
			if ( index >= byte_array.Length ) { index = 0; }
		}


		// Splits an 16-bit integer into 2 bytes and adds them to the array.
		public void add16Bit( short num )
		{
			addByte( BitConv.getByte( num, 1 ) ); // Add the first byte.
			addByte( BitConv.getByte( num, 0 ) ); // Add the second byte.
		}

		public void add16Bit( ushort num )
		{
			addByte( BitConv.getByte( num, 1 ) ); // Add the first byte.
			addByte( BitConv.getByte( num, 0 ) ); // Add the second byte.
		}



		// Splits an integer into 4 bytes and adds them to the list.
		public void add32Bit( int num )
		{
			addByte( BitConv.getByte( num, 3 ) ); // Add the first byte.
			addByte( BitConv.getByte( num, 2 ) ); // Add the second byte.
			addByte( BitConv.getByte( num, 1 ) ); // Add the third byte.
			addByte( BitConv.getByte( num, 0 ) ); // Add the fourth byte.
		}

		public void add32Bit( uint num )
		{
			addByte( BitConv.getByte( num, 3 ) ); // Add the first byte.
			addByte( BitConv.getByte( num, 2 ) ); // Add the second byte.
			addByte( BitConv.getByte( num, 1 ) ); // Add the third byte.
			addByte( BitConv.getByte( num, 0 ) ); // Add the fourth byte.
		}

		// Converts the float to an integer and inserts it into the data object.
		public void addFloat( float num )
		{
			add32Bit( BitConverter.SingleToInt32Bits( num ) );
		}


		// Convenient function that returns a single byte and immediately moves the index over to the next.
		// Also wraps around itself so you can never go out of bounds.
		public byte getByte()
		{
			byte selected = byte_array[index];

			index++;
			if ( index >= byte_array.Length ) index = 0; // Never go out of bounds.

			return selected;
		}


		public ushort getUInt16()
		{
			return BitConv.makeUInt16(
				getByte(),
				getByte()
			);
		}


		public short getInt16()
		{
			return BitConv.makeInt16(
				getByte(),
				getByte()
			);
		}

		public uint getUInt32()
		{
			return BitConv.makeUInt32(
				getByte(),
				getByte(),
				getByte(),
				getByte()
			);
		}

		public int getInt32()
		{
			return BitConv.makeInt32(
				getByte(),
				getByte(),
				getByte(),
				getByte()
			);
		}

		public float getFloat()
		{
			return BitConverter.Int32BitsToSingle( getInt32() );
		}


		// Bunch or array getters.

		public ushort[] getUInt16Array()
		{
			int len = length16();
			ushort[] arr = new ushort[ len ];

			for ( int i = 0; i < len; i++ )
			{
				arr[ i ] = getUInt16();
			}

			return arr;
		}

		public short[] getInt16Array()
		{
			int len = length16();
			short[] arr = new short[ len ];

			for ( int i = 0; i < len; i++ )
			{
				arr[ i ] = getInt16();
			}

			return arr;
		}


		public int[] getInt32Array()
		{
			int len = length32();
			int[] arr = new int[ len ];

			for ( int i = 0; i < len; i++ )
			{
				arr[ i ] = getInt32();
			}

			return arr;
		}








		// This is mostly for debugging and checking values.
		public void printState()
		{
			Console.WriteLine( $"Current index: {index}" );

			for ( int i = 0; i < byte_array.Length; i++ )
			{
				if ( i < 50 || i > byte_array.Length - 50 )
				{
					Console.WriteLine( $"Index: {i} has value: {byte_array[ i ]}" );
				}
				else if ( i == 50 && byte_array.Length > 50 )
				{
					Console.WriteLine( "..." );
				}
			}

			Console.WriteLine( $"Total bytes in array: {byte_array.Length}" );
		}



	}
}






// Splits an integer into 3 bytes and adds them to the list.
// C# however doesn't really have 24-bit numbers so it just discards the 4th byte.
// (Dunno if I'll use this.)
//public void add24Bit(int num)
//{
//	addByte(BitConv.get_byte(num, 3)); // Add the first byte.
//	addByte(BitConv.get_byte(num, 2)); // Add the second byte.
//	addByte(BitConv.get_byte(num, 1)); // Add the third byte.
//									   // The fourth byte is yeeted lol.
//}