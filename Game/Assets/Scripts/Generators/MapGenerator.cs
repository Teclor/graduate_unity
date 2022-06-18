using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeatThis.Game.Obstacles;
using System;
using Newtonsoft.Json;

namespace BeatThis.Game.Generators
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private string mapName;
        private const string defaultMapName = "default";
        private string mapPath = "maps/{0}/";
        private List<float> timestamps;
        private AudioSource musicTrack;
        private int mapSeed = 0;
        public float startTimeOffset { get; set; } = 0;

        [SerializeField] private GameObject obstacleGeneratorObject;
        [SerializeField] private GameObject mapPart;

        private ActionChecker actionChecker;

        public void Generate(float characterMoveSpeed, float characterStartPositionZ = 0)
        {
            int.TryParse(Settings.GetInstance().Get("mapSeed"), out mapSeed);
            mapSeed = (mapSeed > 0) ? mapSeed : (int)DateTimeOffset.Now.ToUnixTimeSeconds();
            Debug.Log(string.Format("Seed: {0}", mapSeed));
            timestamps = new List<float>();

            if (mapName == null)
            {
                mapName = defaultMapName;
            }
            mapPath = string.Format(mapPath, mapName);
            LoadMapTimestamps();
            LoadMusic();
            obstacleGeneratorObject.GetComponent<ObstacleGenerator>().Generate(timestamps, characterMoveSpeed, mapSeed, characterStartPositionZ);
            StartCoroutine(StartMusicCoroutine());
            StartCoroutine(StartTrackingCoroutine());

            float mapPartLength = mapPart.transform.Find("Road").GetComponent<Renderer>().bounds.size.z;
            int mapPartsQuantity = CalculateMapPartsQuantity(timestamps[timestamps.Count - 1], mapPartLength);
            StartCoroutine(GenerateMapFromPartsCoroutine(mapPartsQuantity, mapPartLength));
        }

        public void SetActionChecker(ActionChecker actionChecker)
        {
            this.actionChecker = actionChecker;
        }

        private void LoadMapTimestamps()
        {
            TextAsset jsonTimestamps = Resources.Load<TextAsset>(mapPath + "timestamps");
            List<float> timestampList = JsonConvert.DeserializeObject<List<float>>(jsonTimestamps.text);
            foreach (float timestamp in timestampList)
            {
                timestamps.Add(startTimeOffset + timestamp);
            }
        }

        private void LoadMusic()
        {
            musicTrack = GetComponent<AudioSource>();
            musicTrack.clip = Resources.Load<AudioClip>(mapPath + "audio");
        }

        private IEnumerator StartMusicCoroutine()
        {
            yield return new WaitForSeconds(startTimeOffset);
            musicTrack.Play();
        }

        private IEnumerator StartTrackingCoroutine()
        {
            yield return new WaitForSeconds(startTimeOffset);
            obstacleGeneratorObject.GetComponent<ObstaclePassTracker>().StartTracking(actionChecker);
        }

        private int CalculateMapPartsQuantity(float lastTimeStamp, float mapPartLength, int additionalMapPartsQuantity = 5)
        {
            float defaultUnitsPerSecond = Settings.GetInstance().GetFloat("defaultUnitsPerSecond");
            float totalUnits = defaultUnitsPerSecond * lastTimeStamp;
            return (int)(totalUnits / mapPartLength) + additionalMapPartsQuantity;
        }

        private IEnumerator GenerateMapFromPartsCoroutine(int mapPartsQuantity, float mapPartLength)
        {
            for (int i = 0; i < mapPartsQuantity; i++)
            {
                Instantiate(mapPart, new Vector3(mapPart.transform.position.x, mapPart.transform.position.y, i * mapPartLength), mapPart.transform.rotation);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}