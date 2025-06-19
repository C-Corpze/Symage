using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Symage
{
	public class DatObject
	{

		List<byte> Bytes = new List<byte>();


		void clearByteList()
		{
			Bytes.Clear();
		}

		void addByte(byte num)
		{
			Bytes.Add(num);
		}

		void add16Bit(ushort num)
		{

		}

	}
}
