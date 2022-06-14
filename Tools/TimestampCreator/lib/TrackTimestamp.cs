using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeatThis.Tools
{
    class TrackTimestamp
    {
        public List<double> Timestamps { get; private set; }
        public int Count => Timestamps.Count;
        public void Clear() => Timestamps.Clear();
        public TrackTimestamp()
        {
            Timestamps = new List<double>();
        }
        public bool Add(double timestamp)
        {
            if (Timestamps.IndexOf(timestamp) == -1)
            {
                Timestamps.Add(Math.Round(timestamp, 2));
                return true;
            }
            return false;
        }
        public void RemoveByIndex(int index)
        {
            Timestamps.RemoveAt(index);
        }
        public double GetLastValue()
        {
            return Timestamps.Last();
        }
        public (int index, double value) GetLastWithIndex()
        {
            return ((Timestamps.Count-1), Timestamps.Last());
        }
        public void AutoFill(double bpm, double trackLength, int numberOfTick = 4, double offset = 0, int quantity = 0)
        {
            if (Count == 0)
            {
                double step = 60.0 / bpm;
                double timestamp = Math.Round(offset + step * (numberOfTick-1), 2); //tick-1 т.к. первый тик происходит в offset
                if (quantity == 0)
                {
                    quantity = (int)(((trackLength - offset) / step) / numberOfTick);
                }
                Timestamps.Add(timestamp);
                for (int i = 1; i < quantity; i++)
                {
                    timestamp += Math.Round(step * numberOfTick, 2);
                    Timestamps.Add(timestamp);
                }
            }
        }
        public void SaveToFile(string filePath)
        {
            string JsonResult = JsonConvert.SerializeObject(Timestamps);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(JsonResult.ToString());
                streamWriter.Close();
            }
        }
        public void LoadFromFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath, true))
            {
                string jsonTimestamps = streamReader.ReadLine();
                streamReader.Close();
                Timestamps = JsonConvert.DeserializeObject<List<double>>(jsonTimestamps);
            }
        }
    }
}
