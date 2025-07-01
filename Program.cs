

using ImageMagick;
using NAudio;

namespace Symage;


internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hit enter to start.");
		var input = Console.ReadLine();
		//Console.WriteLine($"You entered: {input}");
		Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);




		MagickImage image = new MagickImage("D:\\_ASSETS\\_MyPrograms\\Symage\\Symage\\testimg.webp");
		Console.WriteLine($"Image width: {image.Width}, height: {image.Height}");


	


	}

}