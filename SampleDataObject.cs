using Symage;
using System;
using System.Collections.Generic;



namespace Symage
{
	// Wahoo, the data object.
	public class SampleDataObject
	{

		//List<byte> bytelist = new List<byte>();

		public byte[] byte_array;
		public int index = 0;


		// Constructor function.
		public SampleDataObject(uint asize = 10)
		{
			byte_array = new byte[asize];
			index = 0;
		}


		// This just initializes an byte array, you must know the size beforehand.
		public void initArray(uint asize)
		{
			byte_array = new byte[asize];
			index = 0;
		}


		// This will add one (1) byte into the array, or rather overwrites one.
		public void addByte(byte b)
		{
			byte_array[index] = b; // Add one byte at a time and move the index.
			index++;

			// Dead-simple measure to prevent ever going outta bounds.
			if (index >= byte_array.Length) { index = 0; }
		}

		// Splits an 16-bit integer into 2 bytes and adds them to the array.
		public void add16Bit(short num)
		{
			addByte(BitConv.getByte(num, 1)); // Add the first byte.
			addByte(BitConv.getByte(num, 0)); // Add the second byte.
		}

		// Splits an integer into 4 bytes and adds them to the list.
		public void add32Bit(int num)
		{
			addByte(BitConv.getByte(num, 3)); // Add the first byte.
			addByte(BitConv.getByte(num, 2)); // Add the second byte.
			addByte(BitConv.getByte(num, 1)); // Add the third byte.
			addByte(BitConv.getByte(num, 0)); // Add the fourth byte.
		}


		public byte getByte()
		{
			byte selected = byte_array[index];

			index++;
			if (index >= byte_array.Length) index = 0;

			return selected;
		}


		public int getInt16(uint position)
		{
			return BitConv.makeInt16(
				getByte(),
				getByte()
			);
		}


		public int getInt32(uint position)
		{
			return BitConv.makeInt32(
				getByte(),
				getByte(),
				getByte(),
				getByte()
			);
		}



		// This is mostly for debugging and checking values.
		public void printState()
		{
			Console.WriteLine($"Current index: {index}");

			for (int i = 0; i < byte_array.Length; i++)
			{
				if (i < 50 || i > byte_array.Length - 50)
				{
					Console.WriteLine($"Index: {i} has value: {byte_array[i]}");
				}
				else if (i == 50 && byte_array.Length > 50)
				{
					Console.WriteLine("...");
				}
			}

			Console.WriteLine($"Total bytes in array: {byte_array.Length}");
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