using NAudio.Wave;

namespace Symage.audio
{
	public static class AudioWav16
	{

		// 32-bit WAV.

		public static SampleDataObject decodeWavFloat( string wav_path )
		{
			WaveFileReader wave_reader = new WaveFileReader( wav_path );

			ISampleProvider sample_provider = wave_reader.ToSampleProvider();
			float[] buffer = new float[ wave_reader.Length / 4 ]; // Buffer for reading samples.

			sample_provider.Read( buffer, 0, buffer.Length );


			//ImageBitClapper24.encodeBitCirc24( audio_data_object, debug_dir + "testimg2.webp", 1280 );

			return new SampleDataObject( buffer );
		}

		public static void encodeWavFloat( string wav_path, SampleDataObject data_object )
		{

			WaveFormat wav_format = WaveFormat.CreateIeeeFloatWaveFormat(44100, 2);

			WaveFileWriter wave_writer = new WaveFileWriter(
				wav_path, // Location and name of file.
                wav_format // Format the WAV is in.
			);


			float[] samples = new float[ ArrayMan.lengthFromBytes(data_object.byte_array, 4) ];

			for ( int i = 0; i < samples.Length; i++ )
			{
				samples[ i ] = data_object.getFloat();
			}


			wave_writer.WriteSamples( samples, 0, samples.Length );


			wave_writer.Flush();
			wave_writer.Dispose();

			Console.WriteLine( $"Wrote sound file in {wav_path}." );
		}



		// 16-bit WAV.

		public static SampleDataObject decodeWavInt16( string wav_path )
		{
			WaveFileReader wave_reader = new WaveFileReader( wav_path );




			return new SampleDataObject( buffer );
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
