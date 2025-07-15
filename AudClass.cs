


using NAudio.Wave;

namespace Symage
{
    public static class AudClass
    {

        public static SampleDataObject decodeWav( string wav_path )
        {
            WaveFileReader wave_reader = new WaveFileReader( wav_path );

            ISampleProvider sample_provider = wave_reader.ToSampleProvider();
            float[] buffer = new float[ wave_reader.Length / 4 ]; // Buffer for reading samples.

            sample_provider.Read( buffer, 0, buffer.Length );


            //ImgClass.bitCirc24Bit( audio_data_object, debug_dir + "testimg2.webp", 1280 );
            return new SampleDataObject( buffer );
        }


    }
}
