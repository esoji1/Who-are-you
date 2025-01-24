public static class SoundSettings
{
    public static float Volume { get; private set; }

    public static void SetVolume(float value) => 
        Volume = value;
}
