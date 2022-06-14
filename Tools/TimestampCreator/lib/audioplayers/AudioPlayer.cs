using System;
using System.IO;
using NAudio.Wave;

namespace BeatThis.Tools.lib.audioplayers
{
    class AudioPlayer : AbstractAudioPlayer
    {
        public bool IsPlaying { get; private set; }
        public double TrackDuration { get; private set; }

        public AudioPlayer()
        {
            outputDevice = new WaveOutEvent();
            audioFile = null;
            TrackDuration = 0;
        }
        public void Pause()
        {
            if (audioFile != null)
            {
                outputDevice.Pause();
            }
        }

        public override void Play()
        {
            if (audioFile != null)
            {
                outputDevice.Play();
                IsPlaying = true;
            }
        }

        public void Stop()
        {
            if (audioFile != null)
            {
                outputDevice.Stop();
                audioFile.Position = 0;
                IsPlaying = false;
            }
        }
        public void LoadFile(string filePath)
        {
            if (!IsPlaying)
            {
                PathToFile = filePath;
                CheckFilePath();
                audioFile = new AudioFileReader(filePath);
                outputDevice.Init(audioFile);
                TrackDuration = audioFile.TotalTime.TotalSeconds;
            }
        }

        public string GetTrackName()
        {
            return Path.GetFileNameWithoutExtension(PathToFile);
        }

        public bool CheckPlaybackStopped()
        {
            bool isStopped = outputDevice.PlaybackState == PlaybackState.Stopped;
            if (isStopped)
            {
                IsPlaying = false;
            }
            return isStopped;
        }

        public int GetSecondsElapsed()
        {
            return (int)audioFile.CurrentTime.TotalSeconds;
        }
        public double GetSecondsElapsedRaw()
        {
            return audioFile.CurrentTime.TotalSeconds;
        }
        private void CheckFilePath()
        {
            if (!File.Exists(this.PathToFile) || !Path.HasExtension(this.PathToFile))
            {
                throw new FileNotFoundException(string.Format("Path {0} is not correct!", this.PathToFile));
            }
        }
    }
}
