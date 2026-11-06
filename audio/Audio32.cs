using NAudio.Wave;

namespace Symage.audio
{
	internal class Audio32
	{

		public static SampleDataObject decodeWavFloat( string wav_path )
		{
			WaveFileReader wave_reader = new WaveFileReader( wav_path );

			ISampleProvider sample_provider = wave_reader.ToSampleProvider();
			float[] buffer = new float[ wave_reader.Length / 4 ]; // Buffer for reading samples.

			sample_provider.Read( buffer, 0, buffer.Length );



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
				samples[ i ] = data_object.getCastedFloatFromInt16();
			}


			wave_writer.WriteSamples( samples, 0, samples.Length );


			wave_writer.Flush();
			wave_writer.Dispose();

			Console.WriteLine( $"Wrote sound file in {wav_path}." );
		}


	}
}
