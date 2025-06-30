using Symage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Symage
{
	// Wahoo, the data object.
	public class DatObject
	{

		//List<byte> bytelist = new List<byte>();

		byte[] byte_array;

		int index = 0;



		public DatObject(int asize = 10)
		{
			// Constructor, initializes the byte array with a default size of 5.
			byte_array = new byte[asize];
		}


		// This just initializes an byte array, you must know the size beforehand.
		public void initArray(int asize)
		{
			byte_array = new byte[asize];
		}


		// This will add one (1) byte into the array, or rather overwrites one.
		public void addByte(byte b)
		{
			// Dead-simple measure to prevent ever going outta bounds.
			if ( index > byte_array.Length ) { index = 0; }

			byte_array[index] = b; // Add one byte at a time and move the index.
			index++;
		}

		// Splits an 16-bit integer into 2 bytes and adds them to the array.
		public void add16Bit(short num)
		{
			addByte(BitConv.get_byte(num, 1)); // Add the first byte.
			addByte(BitConv.get_byte(num, 0)); // Add the second byte.
		}

		// Splits an integer into 4 bytes and adds them to the list.
		public void add32Bit(int num)
		{
			addByte(BitConv.get_byte(num, 3)); // Add the first byte.
			addByte(BitConv.get_byte(num, 2)); // Add the second byte.
			addByte(BitConv.get_byte(num, 1)); // Add the third byte.
			addByte(BitConv.get_byte(num, 0)); // Add the fourth byte.
		}


		// Splits an integer into 3 bytes and adds them to the list.
		// C# however doesn't really have 24-bit numbers so it just discards the 4th byte.
		// (Dunno if I'll use this.)
		public void add24Bit(int num)
		{
			addByte(BitConv.get_byte(num, 2)); // Add the first byte.
			addByte(BitConv.get_byte(num, 1)); // Add the second byte.
			addByte(BitConv.get_byte(num, 0)); // Add the third byte.
												// The fourth byte is yeeted lol.
		}

		

	}
}
