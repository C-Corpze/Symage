using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symage
{
	public static class BitConv
	{

		// Returns a byte from a 32-bit integer.
		public static byte get_byte(int val, ushort pos = 0)
		{
			// Return first byte if no position is specified.
			if (pos == 0 || pos > 4) return (byte)(val & 0xff);

			int new_val = val >> (pos * 8); // Bit shift the thingus to get the desired byte.

			return (byte)(new_val & 0xff); // Mask it and convert to byte to return 8-bit integer.
		}


		// Combines bytes into a 32-bit integer.
		public static int make_int(byte b1, byte b2, byte b3, byte b4)
		{
			return (int)(
					(b1 << 24) | (b2 << 16) | (b3 << 8) | b4
				);
		}


	}
}
