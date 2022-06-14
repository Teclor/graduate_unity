using NAudio.Wave;

namespace BeatThis.Tools.lib.audioplayers
{
    class SoundPlayer : AbstractAudioPlayer
    {
        public SoundPlayer(string soundName, int volume = 100)
        {
            PathToFile = FilePath.GetResourceFile(string.Format("sounds\\{0}.mp3", soundName));
            CheckAudioFile();
            audioFile = new AudioFileReader(PathToFile);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            SetVolume(volume);
        }
        public override void Play()
        {
            outputDevice.Stop();
            audioFile.Position = 0;
            outputDevice.Play();
        }
    }
}
