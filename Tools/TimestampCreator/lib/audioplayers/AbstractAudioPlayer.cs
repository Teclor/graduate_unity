using NAudio.Wave;
using System;

namespace BeatThis.Tools.lib.audioplayers
{
    abstract class AbstractAudioPlayer : IPlayable, IDisposable
    {
        protected bool disposed;
        public string PathToFile { get; protected set; }
        protected WaveOutEvent outputDevice;
        protected AudioFileReader audioFile;
        public abstract void Play();
        public void SetVolume(int volume)
        {
            audioFile.Volume = volume / 100f;
        }
        public void CheckAudioFile()
        {
            FilePath.CheckFileExistsAndHasExtension(PathToFile);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    outputDevice.Stop();
                    outputDevice.Dispose();
                    audioFile.Dispose();
                    outputDevice = null;
                    audioFile = null;
                }
                disposed = true;
            }
        }
        ~AbstractAudioPlayer()
        {
            Dispose(false);
        }
    }
}
