# Symage

Wahoo, you found one of my most silliest projects ever.
Some converter tool for experimental art and sound design.

### For consistent results, ALWAYS use, open/save with 16-bit WAV format.
### If your audio editing software has export options, ALWAYS set to 16-bit WAV!

## So what does it do?

Real simple stuff, you place audio files in `_audio` or images in `_images`.
You start the `.exe` which will instruct you further on what to type/input.

It will convert images to audio files and audio to image files.

Basic idea is that you'll be able to edit audio as if it were an image, or the other way around.
Apply reverb to images or edge detect to sounds!

(Spoiler, most of it will sound or look horrible but the key is to do it subtle and careful.)

The default algorithms are super basic and supposed to be as non-destructive as possible.
May add destructive converters later for more interesting sounds or images.


## Potential idea for future algorithms:

- Use Red, Green and Blue channels to generate a sine wave where red is amplitude, green phase and blue stereo position.

Great idea, unfortunately would basically generate 8-bit sound only, which may or may not be very quantized.
Hopefully the combined amplitude + phase allows for more possible values than 0 - 255.


- Time & frequency domain.

Using the X and Y coordinates of a image where X is time and Y is frequency.
Could potentially be used to generate high-detail sounds and be more predictable.

Here I'm thinking about using red and green for amp/phase again and blue for stereo position.


- ???

Some algorithm that converts between sound and images with less pixelated noise.
Would make it easier (and more useful) to actually draw or edit sounds using art software like Krita or GIMP.

I'm thinking about spectrograms / spectrums, but something that can have more detail
and doesn't require some RIDICULOUS resolution like 20,000 x 48,000 pixels and a lot of CPU power for just 1 second of sound.