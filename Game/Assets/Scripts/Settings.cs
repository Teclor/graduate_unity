using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Globalization;

namespace BeatThis.Game
{
    public class Settings
    {
        private static Settings instance = null;
        public const string FilePath = "/settings.json";
        private Dictionary<string, string> settings;
        public bool IsEmpty() => settings.Count == 0;
        public void Clear() => settings.Clear();

        private Settings()
        {
            settings = new Dictionary<string, string>();
            Load();
        }

        public static Settings GetInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }

        public string Get(string key)
        {
            return settings.GetValueOrDefault(key);
        }

        public float GetFloat(string key)
        {
            if (float.TryParse(settings.GetValueOrDefault(key), NumberStyles.Number, new CultureInfo("en-US"), out float value))
            {
                return value;
            }
            else
            {
                throw new System.Exception($"Value is not set or is not convertable to float for key {key}");
            }
        }

        public void Set(string key, string value)
        {
            settings[key] = value;
        }

        public void Load()
        {
            string filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                string settingsJson = File.ReadAllText(filePath);
                if (settingsJson != null && settingsJson.Length > 0)
                {
                    settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(settingsJson);
                }
            }
        }

        public void Save()
        {
            string settingsJson = JsonConvert.SerializeObject(settings);
            string filePath = GetFilePath();
            File.WriteAllText(filePath, settingsJson);
        }

        private string GetFilePath()
        {
            return Application.persistentDataPath + FilePath;
        }
    }
}
