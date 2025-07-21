using NAudio.Wave;

namespace Symage.audio
{
	public static class AudioWav16
	{

		public static SampleDataObject decodeWavInt16( string wav_path )
		{
			SampleDataObject audio_data;


			WaveFileReader wave_reader = new WaveFileReader( wav_path );

			if ( wave_reader.WaveFormat.BitsPerSample == 16 )
			{
				byte[] buffer = new byte[ wave_reader.Length ]; // Buffer for reading samples.
				wave_reader.Read( buffer, 0, buffer.Length );
			}
			else
			{ 
				ISampleProvider sample_provider = wave_reader.ToSampleProvider();
			}


			return new audio_data;
		}




		public static void encodeWav16( string wav_path, SampleDataObject data_object, int sample_rate = 44100, int channels = 2 )
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

			Console.WriteLine( $"Wrote sound file in {wav_path}." );
		}









	}
}
