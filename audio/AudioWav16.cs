using NAudio.Wave;

namespace Symage.audio;


public static class AudioWav16
{

	// Circumsizes bytes.
	public static SampleDataObject decodeBitCirc16( string wav_path )
	{
		SampleDataObject audio_data;
		float[] buffer;
		WaveFileReader wave_reader = new WaveFileReader( wav_path );


		if ( wave_reader.WaveFormat.BitsPerSample == 16 && wave_reader.WaveFormat.Encoding == WaveFormatEncoding.Pcm )
		{
			Console.WriteLine( "\nAudio was detected to be 16-bit PCM.\n" );

			byte[] byte_buffer = new byte[ wave_reader.Length ]; // Buffer for reading samples.
			wave_reader.Read( byte_buffer, 0, byte_buffer.Length );

			audio_data = new SampleDataObject( byte_buffer );

			return audio_data;
		}


		Console.WriteLine( "\nAudio is not 16-bit PCM, will interpret as 32-bit float and attempt to convert to 16-bit.\n" );

		ISampleProvider sample_provider = wave_reader.ToSampleProvider();
		buffer = new float[ wave_reader.Length ];

		sample_provider.Read( buffer, 0, buffer.Length );
		audio_data = new SampleDataObject( buffer );


		return audio_data;
	}



	// Claps bytes together.
	public static void encodeWavBitClap16( string wav_path, SampleDataObject data_object, int sample_rate = 44100, int channels = 2 )
	{

		WaveFormat wav_format = new WaveFormat(sample_rate, channels);

		WaveFileWriter wave_writer = new WaveFileWriter(
				wav_path, // Location and name of file.
                wav_format // Format the WAV is in.
			);


		Console.WriteLine( $"data_object contains {data_object.byte_array.Length} bytes." );
		wave_writer.Write( data_object.byte_array, 0, data_object.byte_array.Length );


		wave_writer.Flush();
		wave_writer.Dispose();
		wave_writer.Close();

		Console.WriteLine( $"Wrote sound file in {wav_path}." );
	}









}

