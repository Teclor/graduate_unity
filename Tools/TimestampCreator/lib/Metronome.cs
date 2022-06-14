using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using BeatThis.Tools.lib.audioplayers;
using System;

namespace BeatThis.Tools.lib
{
    class Metronome
    {
        private SoundPlayer tickPlayer;
        private BackgroundWorker backgroundWorker;
        public bool IsWorking { get; private set; }
        public int TickDelayMs { get; private set; }
        public float StartOffset { get; private set; }
        private int startOffsetMs;
        public double BPM { get; private set; }
        public Metronome(double bpm = 0, float startOffset = 0.0f, string soundEffectName = "sticks")
        {
            SetStartDelay(startOffset);
            tickPlayer = new SoundPlayer(soundEffectName);
            BPM = bpm;
            IsWorking = false;
            CalculateTickDelay();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += DoTicks;
        }
        public void SetStartDelay(float delayInSeconds)
        {
            StartOffset = delayInSeconds;
            startOffsetMs = (int)(delayInSeconds * 1000);
        }
        public void Start()
        {
            if (IsWorking)
            {
                Stop();
            }
            if (BPM > 0)
            {
                IsWorking = true;
                if (startOffsetMs > 0)
                {
                    Task.Delay(startOffsetMs).ContinueWith(t => backgroundWorker.RunWorkerAsync());
                }
                else
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }
        public void Stop()
        {
            IsWorking = false;
        }
        public void SetBpm(double bpm)
        {
            Stop();
            BPM = bpm > 1 ? bpm : 1;
            CalculateTickDelay();
        }
        private void CalculateTickDelay()
        {
            if (BPM > 0)
            {
                TickDelayMs = (int)Math.Round(60000 / BPM);
            }
        }
        private void DoTicks(object sender, DoWorkEventArgs e)
        {
            if (IsWorking)
            {
                tickPlayer.Play();
                Task.Delay(TickDelayMs).ContinueWith(t => backgroundWorker.RunWorkerAsync());
            }
        }
    }
}
