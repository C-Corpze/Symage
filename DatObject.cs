using Symage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Symage
{
	public class DatObject
	{

		List<byte> bytelist = new List<byte>();


		void clearByteList() { bytelist.Clear(); }

		// Adds a single byte to the list.
		void addByte(byte num) { bytelist.Add(num); }

		// Splits a 16-bit integer into 2 bytes and adds them to the list.
		void add16Bit(ushort num)
		{
			bytelist.Add(BitConv.get_byte(num, 1)); // Add the first byte.
			bytelist.Add(BitConv.get_byte(num, 0)); // Add the second byte.
		}

		// Splits an integer into 3 bytes and adds them to the list.
		// C# however doesn't really have 24-bit numbers so it just discards the 4th byte.
		void add24Bit(int num)
		{
			bytelist.Add(BitConv.get_byte(num, 2)); // Add the first byte.
			bytelist.Add(BitConv.get_byte(num, 1)); // Add the second byte.
			bytelist.Add(BitConv.get_byte(num, 0)); // Add the third byte.
													// The fourth byte is discarded.
		}

		// Splits an integer into 4 bytes and adds them to the list.
		void add32Bit(int num)
		{
			bytelist.Add(BitConv.get_byte(num, 3)); // Add the first byte.
			bytelist.Add(BitConv.get_byte(num, 2)); // Add the second byte.
			bytelist.Add(BitConv.get_byte(num, 1)); // Add the third byte.
			bytelist.Add(BitConv.get_byte(num, 0)); // Add the fourth byte.
		}

	}
}
