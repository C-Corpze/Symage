using NAudio.Wave;

namespace Symage
{
	public static class AudClass
	{

		public static SampleDataObject decodeWavFloat( string wav_path )
		{
			WaveFileReader wave_reader = new WaveFileReader( wav_path );

			ISampleProvider sample_provider = wave_reader.ToSampleProvider();
			float[] buffer = new float[ wave_reader.Length / 4 ]; // Buffer for reading samples.

			sample_provider.Read( buffer, 0, buffer.Length );


			//ImgClass.bitCirc24Bit( audio_data_object, debug_dir + "testimg2.webp", 1280 );

			return new SampleDataObject( buffer );
		}


		public static void encodeWavFloat( string wav_path, SampleDataObject data_object )
		{
			
			WaveFileWriter wave_writer = new WaveFileWriter(
				wav_path, // Location and name of file.
                new WaveFormat( 44100, 32, 1 )
			);


			//float[] samples = new float[ ArrayMan.lengthFromBytes(data_object.byte_array, 4) ];

			//for ( int i = 0; i < samples.Length; i++ )
			//{
			//	samples[ i ] = data_object.getFloat();
			//}


			//wave_writer.WriteSamples( samples, 0, samples.Length );

			wave_writer.Write( data_object.byte_array, 0, data_object.byte_array.Length );

			wave_writer.Flush();
			//wave_writer.Close();

			Console.WriteLine( $"Wrote sound file in {wav_path}." );
		}


	}
}
