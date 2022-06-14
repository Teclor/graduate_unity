using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using BeatThis.Tools.lib;
using BeatThis.Tools.lib.audioplayers;

namespace BeatThis.Tools
{
    public partial class MainForm : Form
    {
        private AudioPlayer musicPlayer;
        private SoundPlayer clickSound;
        private TrackTimestamp trackTimeMarks;
        private Metronome metronome;
        public MainForm()
        {
            InitializeComponent();
            InitializeAudioPlayers();
            InitializeTrackTimestampGenerator();
        }
        private void InitializeAudioPlayers()
        {
            musicPlayer = new AudioPlayer();
            clickSound = new SoundPlayer("click");
            metronome = new Metronome();
        }
        private void InitializeTrackTimestampGenerator()
        {
            trackTimeMarks = new TrackTimestamp();
        }

        private void OnAddBtnClick(object sender, MouseEventArgs e)
        {
            if (musicPlayer.IsPlaying)
            {
                if(trackTimeMarks.Add(musicPlayer.GetSecondsElapsedRaw()))
                {
                    TimestampList.Items.Add(new ListViewItem(trackTimeMarks.GetLastValue().ToString()));
                }
            }
            TimestampsCountLabel.Text = TimestampsCountLabel.AccessibleDescription + trackTimeMarks.Count;
            clickSound.Play();
        }

        private void OnRemoveBtnClick(object sender, EventArgs e)
        {
            List<int> selectedIndexes = TimestampList.SelectedIndices.Cast<int>().ToList();
            int[] selectedIndexesReversed = selectedIndexes.OrderByDescending(c => c).ToArray();
            foreach (int selectedIndex in selectedIndexesReversed)
            {
                trackTimeMarks.RemoveByIndex(selectedIndex);
                TimestampList.Items.RemoveAt(selectedIndex);
            }
            TimestampsCountLabel.Text = TimestampsCountLabel.AccessibleDescription + trackTimeMarks.Count;
        }

        private void OnStartBtnClick(object sender, EventArgs e)
        {
            if (!musicPlayer.IsPlaying)
            {
                ProgressBarTimer.Start();
                LockButtons();
                LockSettings();
            }
            if (UseMetronomeCheckbox.Checked)
            {
                metronome.Start();
            }
            musicPlayer.Play();
        }

        private void OnPauseBtnClick(object sender, EventArgs e)
        {
            musicPlayer.Pause();
            ProgressBarTimer.Stop();
            if (metronome.IsWorking)
            {
                metronome.Stop();
            }
            SaveTimestampsBtn.Enabled = true;
        }

        private void OnDiscardBtnClick(object sender, EventArgs e)
        {
            musicPlayer.Stop();
            ProgressBarTimer.Stop();
            ProgressBar.Value = 0;
            UnlockButtons();
            UnLockSettings();
            SecondsPassedLabel.Text = SecondsPassedLabel.AccessibleDescription + "0";
            SecondsLeftLabel.Text = SecondsLeftLabel.AccessibleDescription + ((int)musicPlayer.TrackDuration).ToString();
            TimestampList.Clear();
            trackTimeMarks.Clear();
            TimestampsCountLabel.Text = TimestampsCountLabel.AccessibleDescription + "0";

            if (metronome.IsWorking)
            {
                metronome.Stop();
            }
        }

        private void OnVolumeChange(object sender, EventArgs e)
        {
            musicPlayer.SetVolume(VolumeTrackBar.Value);
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            SaveTimestampsDialog.FileName = musicPlayer.GetTrackName();
            if (trackTimeMarks.Count > 0 && SaveTimestampsDialog.ShowDialog() == DialogResult.OK)
            {
                trackTimeMarks.SaveToFile(SaveTimestampsDialog.FileName);
            }
        }

        private void OnOpenBtnClick(object sender, EventArgs e)
        {
            if (OpenTrackDialog.ShowDialog() == DialogResult.OK)
            {
                musicPlayer.LoadFile(OpenTrackDialog.FileName);
                musicPlayer.SetVolume(VolumeTrackBar.Value);
                TrackNameLabel.Text = TrackNameLabel.AccessibleDescription + musicPlayer.GetTrackName();
                double trackDuration = musicPlayer.TrackDuration;
                TrackLengthLabel.Text = TrackLengthLabel.AccessibleDescription + trackDuration.ToString();
                ProgressBar.Maximum = (int) (trackDuration * 10);
                ProgressBar.Value = ProgressBar.Minimum;
            }
        }

        private void OnProgressTimerTick(object sender, EventArgs e)
        {
            musicPlayer.CheckPlaybackStopped();
            if (musicPlayer.IsPlaying)
            {
                ProgressBar.PerformStep();
                int secondsPassed = musicPlayer.GetSecondsElapsed();
                SecondsPassedLabel.Text = SecondsPassedLabel.AccessibleDescription + secondsPassed.ToString();
                SecondsLeftLabel.Text = SecondsLeftLabel.AccessibleDescription + ((int)(musicPlayer.TrackDuration - secondsPassed)).ToString();
            }
            else
            {
                ProgressBarTimer.Stop();
                ProgressBar.Value = ProgressBar.Maximum;
                UnlockButtons();
                UnLockSettings();
            }
        }
        private void OnDetectBpmBtnClick(object sender, EventArgs e)
        {
            if (musicPlayer.PathToFile != null)
            {
                BpmDetector bpmDetector = new BpmDetector(musicPlayer.PathToFile);
                BpmInput.Value = bpmDetector.DetectedTempo;
                Console.WriteLine("set metronome delay in seconds: " + bpmDetector.DetectedTempoStartTime.ToString());
                metronome.SetStartDelay(bpmDetector.DetectedTempoStartTime);
            }
        }
        private void OnFillTimestampsBtnClick(object sender, EventArgs e)
        {
            if (metronome.BPM > 0 && musicPlayer.TrackDuration > 0)
            {
                trackTimeMarks.AutoFill(metronome.BPM, musicPlayer.TrackDuration, 4, 0.25 + metronome.StartOffset);
                foreach (double timestamp in trackTimeMarks.Timestamps)
                {
                    TimestampList.Items.Add(timestamp.ToString());
                }
                TimestampsCountLabel.Text = TimestampsCountLabel.AccessibleDescription + trackTimeMarks.Count;
                UnlockButtons();
            }
        }

        private void OnBpmInputValueChanged(object sender, EventArgs e)
        {
            metronome.Stop();
            metronome.SetBpm((double)BpmInput.Value);
        }

        private void LockButtons()
        {
            OpenTrackBtn.Enabled = false;
            SaveTimestampsBtn.Enabled = false;
            AutoSetBpmBtn.Enabled = false;
            FillTimestampsBtn.Enabled = false;
        }
        private void LockSettings()
        {
            UseMetronomeCheckbox.Enabled = false;
            BpmInput.Enabled = false;

        }
        private void UnLockSettings()
        {
            UseMetronomeCheckbox.Enabled = true;
            BpmInput.Enabled = true;
        }
        private void UnlockButtons()
        {
            OpenTrackBtn.Enabled = true;
            SaveTimestampsBtn.Enabled = true;
            AutoSetBpmBtn.Enabled = true;
            FillTimestampsBtn.Enabled = true;
        }
    }
}
