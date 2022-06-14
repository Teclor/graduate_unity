using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BeatThis.Tools.lib
{
    class BpmDetector
    {
        public List<(int Count, int Tempo, int Position)> Groups { get; private set; }
        public int DetectedTempo { get; private set; }
        public float DetectedTempoStartTime { get; private set; }
        private int sampleRate;
        private int channels;
        private const float secondsInMinute = 60.0f;
        private const float lowestPossibleTempo = 80.0f;
        private const float highestPossibleTempo = 320.0f;
        private const float cutLowPassFrequency = 150.0F;
        private const float cutHighPassFrequency = 100.0F;
        public BpmDetector(string audioFile, int start = 0, int length = 0)
        {
            using (MediaFoundationReader reader = new MediaFoundationReader(audioFile))
            {
                sampleRate = reader.WaveFormat.SampleRate;
                channels = reader.WaveFormat.Channels;

                int bytesPerSample = reader.WaveFormat.BitsPerSample / 8;
                if (bytesPerSample == 0)
                {
                    bytesPerSample = 2; // 16 bit
                }

                int sampleCount = (int)reader.Length / bytesPerSample;

                start *= channels * sampleRate;
                length *= channels * sampleRate;
                if (start >= sampleCount)
                {
                    Groups = new List<(int Count, int Tempo, int Position)>();
                    return;
                }
                if (length == 0 || start + length >= sampleCount)
                {
                    length = sampleCount - start;
                }

                length = (int)(length / channels) * channels;

                ISampleProvider sampleReader = reader.ToSampleProvider();
                float[] samples = new float[length];
                sampleReader.Read(samples, start, length);

                for (int ch = 0; ch < channels; ++ch)
                {
                    BiQuadFilter lowpass = BiQuadFilter.LowPassFilter(sampleRate, cutLowPassFrequency, 1.0F);
                    BiQuadFilter highpass = BiQuadFilter.HighPassFilter(sampleRate, cutHighPassFrequency, 1.0F);

                    for (int i = ch; i < length; i += channels)
                    {
                        samples[i] = highpass.Transform(lowpass.Transform(samples[i]));
                    }
                }

                List<(int Position, float Volume)> peaks = GetPeaks(samples);
                List<(int Count, int Tempo, int Position)> allGroups = GetGroups(peaks);

                allGroups.Sort((x, y) => y.Count.CompareTo(x.Count));

                Groups = allGroups;
                DetectedTempo = allGroups[0].Tempo;

                DetectedTempoStartTime = (allGroups[0].Position + (allGroups[0].Count % 4)) / sampleRate;
            }
        }
        private List<(int Position, float Volume)> GetPeaks(float[] data)
        {
            int partSize = sampleRate / 2;
            int partsCount = data.Length / channels / partSize;
            List<(int Position, float Volume)> peaks = new List<(int Position, float Volume)>();

            for (int i = 0; i < partsCount; ++i)
            {
                (int Position, float Volume) max = (1, 0.0f);

                for (int j = 0; j < partSize; ++j)
                {
                    float vol = 0.0F;
                    for (int k = 0; k < channels; ++k)
                    {
                        float v = data[i * channels * partSize + j * channels + k];
                        if (vol < v)
                        {
                            vol = v;
                        }
                    }
                    if (max.Position == -1 || max.Volume < vol)
                    {
                        max.Position = i * partSize + j;
                        max.Volume = vol;
                    }
                }
                peaks.Add(max);
            }
            peaks.Sort((x, y) => y.Volume.CompareTo(x.Volume));
            peaks.RemoveRange(peaks.Count / 2, peaks.Count / 2);
            peaks.Sort((x,y) => x.Position.CompareTo(y.Position));

            return peaks;
        }

        private List<(int Count, int Tempo, int Position)> GetGroups(List<(int Position, float Volume)> peaks)
        {
            List<(int Count, int Tempo, int Position)> groups = new List<(int Count, int Tempo, int Position)>();

            for (int peakIndex = 0; peakIndex < peaks.Count; ++peakIndex)
            {
                (int Position, float Volume) peak = peaks[peakIndex];
                for (int i = 1; peakIndex + i < peaks.Count && i < 10; ++i)
                {
                    float tempo = secondsInMinute * sampleRate / (peaks[peakIndex + i].Position - peak.Position);
                    while (tempo < lowestPossibleTempo)
                    {
                        tempo *= 2.0F;
                    }
                    while (tempo > highestPossibleTempo)
                    {
                        tempo /= 2.0F;
                    }
                    (int Count, int Tempo, int Position) group = (1, (short)Math.Round(tempo), peak.Position);

                    //ищем и заменяем группу или добавляем новую
                    int j;
                    for (j = 0; j < groups.Count && groups[j].Tempo != group.Tempo; ++j) { }
                    if (j < groups.Count)
                    {
                        group.Count = groups[j].Count + 1;
                        if (group.Position > groups[j].Position)
                        {
                            group.Position = groups[j].Position;
                        }
                        groups[j] = group;
                    }
                    else
                    {
                        groups.Add(group);
                    }
                }
            }
            return groups;
        }
    }
}

