namespace Symage
{
	public class UserInput
	{

		// Primitive functions for reading input.


		public int getIntFromUser( int default_value = 0 )
		{
			string? text = Console.ReadLine();
			if ( text == null ) return default_value;

			try { return Int32.Parse( text ); }
			catch
			{
				Console.WriteLine( $"Invalid input, defaulting to {default_value}." );
				return default_value;
			}
		}

		public float getFloatFromUser( float default_value = 0.0f )
		{
			string? text = Console.ReadLine();
			if ( text == null ) return default_value;

			try { return float.Parse( text ); }
			catch
			{
				Console.WriteLine( $"Invalid input, defaulting to {default_value}." );
				return default_value;
			}
		}






		// The sound part.

		public ushort sound_decode_mode = 0;
		public string[] sound_decode_modes = [
			"32-bit Decode (Any format)",
			"16-bit Decode (WAV only)"
		];

		public ushort sound_encode_mode = 0;
		public string[] sound_encode_modes = [
			"32-bit Float Encode",
			"16-bit Encode (WAV only)"
		];


		// The image part.

		public ushort image_decode_mode = 0;
		public string[] image_decode_modes = [
			"24-bit BitClap (Any format)",
			"32-bit BitClap (RGBA) (PNG & WEBP Only)"
		];

		public ushort image_encode_mode = 0;
		public string[] image_encode_modes = [
			"24-bit BitCircumcision",
			"32-bit BitCircumcision (RGBA) (PNG & WEBP Only)",
		];


		public ushort selectChoice( string[] choices )
		{
			Console.WriteLine( "Press a number followed by the [Enter] key to select a mode." );

			for ( int i = 0; i < choices.Length; i++ )
			{
				Console.WriteLine( $"Mode: {i} = {choices[ i ]}" );
			}


			string? input = Console.ReadLine();

			if ( input == null )
			{
				Console.WriteLine( "No input received, defaulting to 0." );
				return 0; // Default to the first mode if no input is received.
			}


			ushort choice = 0;

			if ( ushort.TryParse( input, out ushort num ) )
			{
				choice = num;
			}

			Console.WriteLine( $"{choice} was chosen." );
			return choice;
		}



	}
}
