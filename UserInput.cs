namespace Symage;


public static class UserInput
{

	// Primitive functions for reading input.


	public static int getIntFromUser( string text_message, int default_value = 0 )
	{
		Console.WriteLine( text_message );

		string? text = Console.ReadLine();
		if ( text == null ) return default_value;

		try { return Int32.Parse( text ); }
		catch
		{
			Console.WriteLine( $"\nNo valid input given, defaulting to {default_value}." );
			return default_value;
		}
	}



	public static float getFloatFromUser( string text_message, float default_value = 0.0f )
	{
		Console.WriteLine( text_message );

		string? text = Console.ReadLine();
		if ( text == null ) return default_value;

		try { return float.Parse( text ); }
		catch
		{
			Console.WriteLine( $"\nNo valid input given, defaulting to {default_value}." );
			return default_value;
		}
	}



}

