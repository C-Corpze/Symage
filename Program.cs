

using ImageMagick;
using NAudio;

namespace Symage;

internal class Program
{
	static void Main(string[] args)
	{
		//Console.WriteLine("Hit enter to start.");
		//var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");

		Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

		var img = new MagickImage(AppDomain.CurrentDomain.BaseDirectory + "testimg.webp");

	}

}