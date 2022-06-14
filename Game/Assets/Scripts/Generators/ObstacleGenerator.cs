using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeatThis.Game.Obstacles;
using System.Globalization;

namespace BeatThis.Game.Generators
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacles;
        private Dictionary<string, int[]> availableLanesByObstacle;
        private float moveSpeed;
        private int seed;
        public ObstaclePool generatedObstacles { get; private set; }
        public void Awake()
        {
            generatedObstacles = new ObstaclePool();
            availableLanesByObstacle = new Dictionary<string, int[]>();
        }
        public void Generate(List<float> timestamps, float characterMoveSpeed, int mapSeed)
        {
            FillObstacleAvailableLanes();
            moveSpeed = characterMoveSpeed;
            seed = mapSeed;
            Random.InitState(seed);
            StartCoroutine(OnGeneratingRoutine(timestamps));
        }

        private void FillObstacleAvailableLanes()
        {
            foreach(GameObject obstacle in obstacles)
            {
                availableLanesByObstacle.Add(obstacle.name, obstacle.GetComponent<IObstacle>().AvailableLanes);
            }
        }

        private IEnumerator OnGeneratingRoutine(List<float> timestamps)
        {
            float defaultUnitsPerSecond = Settings.GetInstance().GetFloat("defaultUnitsPerSecond");
            foreach (float time in timestamps)
            {
                int obstacleIndex = Random.Range(0, obstacles.Length);
                GameObject generatingObstacle = obstacles[obstacleIndex];

                int[] availableLanes = availableLanesByObstacle[generatingObstacle.name];

                int obstacleLaneIndex = Random.Range(0, availableLanes.Length);
                int obstacleLane = availableLanes[obstacleLaneIndex];
                
                float laneDistance = Settings.GetInstance().GetFloat("laneDistance");
                float distance = time * (defaultUnitsPerSecond * moveSpeed) + (generatingObstacle.transform.localScale.z / 2) + generatingObstacle.transform.position.z;
                Vector3 position = new Vector3(generatingObstacle.transform.position.x + obstacleLane * laneDistance, generatingObstacle.transform.position.y, distance);

                GameObject obstacleGameObject = Instantiate(generatingObstacle, position, generatingObstacle.transform.rotation);
                IObstacle obstacleObject = obstacleGameObject.GetComponent<IObstacle>();
                obstacleObject.Lane = obstacleLane;

                ObstacleEntity generatedObstacle = new ObstacleEntity(time, obstacleLane, obstacleObject);
                generatedObstacles.Add(generatedObstacle);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
