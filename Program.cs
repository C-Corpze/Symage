



namespace Symage;




internal class Program
{


    static void Main(string[] args)
    {
        //Console.WriteLine("Hit enter to start.");

        //var input = Console.ReadLine();

        //Console.WriteLine($"You entered: {input}");


        int number = 1234567890;

        byte b1 = (byte)(number & 0xff);

        byte b2 = (byte)((number >> 8) & 0xff);

        byte b3 = (byte)((number >> 16) & 0xff);

        byte b4 = (byte)((number >> 24) & 0xff);


        Console.WriteLine($"The byte representation of {number} is: {b1} - {b2} - {b3} - {b4}");


    }



}