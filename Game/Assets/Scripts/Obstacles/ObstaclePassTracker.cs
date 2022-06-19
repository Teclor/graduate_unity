using UnityEngine;
using BeatThis.Game.Generators;
using BeatThis.Game.Controllers;

namespace BeatThis.Game.Obstacles
{
    public class ObstaclePassTracker : MonoBehaviour
    {
        public static bool IsTracking = false;
        private ObstaclePool obstaclePool;
        [SerializeField] private GameObject character;
        private MainCharacterController mainCharacterController;
        private ActionChecker actionChecker;
        [SerializeField] SceneChanger sceneChanger;
        public void Awake()
        {
            IsTracking = false;
        }

        public void StartTracking(ActionChecker actionChecker)
        {
            mainCharacterController = character.GetComponent<MainCharacterController>();
            obstaclePool = GetComponent<ObstacleGenerator>().generatedObstacles;
            this.actionChecker = actionChecker;
            IsTracking = true;
        }

        void Update()
        {
            if (IsTracking && actionChecker != null)
            {
                ObstacleEntity nearestObstacle = obstaclePool.Get();
                if (nearestObstacle != null)
                {
                    if (actionChecker.IsCheckTimeReached(nearestObstacle.GetTime()))
                    {
                        //Debug.Log((Time.timeSinceLevelLoad - 1.0f) + " reach time for " + (nearestObstacle.GetTime() - 1.0f).ToString()); //TODO: DELETE LOGGING

                        IObstacle obstacleObject = nearestObstacle.GetObstacle();
                        if (obstacleObject != null)
                        {
                            if (obstacleObject.IsPassed())
                            {
                                obstaclePool.Retrieve();
                            }
                            else
                            {
                                bool isObstacleAvoided = !obstacleObject.StrictLaneCheck && obstacleObject.LaneWidth == 1 && mainCharacterController.CurrentLane != nearestObstacle.GetLane();
                                bool isCharacterOnCorrectLane = obstacleObject.StrictLaneCheck ? mainCharacterController.CurrentLane == nearestObstacle.GetLane() : true;
                                bool isActionInTime = isObstacleAvoided || actionChecker.IsApplicableActionInTime(obstacleObject, nearestObstacle.GetTime());
                                //Debug.Log($"isObstacleAvoided {isObstacleAvoided} isCharacterOnCorrectLane {isCharacterOnCorrectLane} isActionInTime {isActionInTime}");

                                if (isObstacleAvoided || (isCharacterOnCorrectLane && isActionInTime))
                                {
                                    obstacleObject.Pass();
                                    obstaclePool.Retrieve();
                                    if (obstaclePool.IsEmpty())
                                    {
                                        IsTracking = false;
                                    }
                                }
                                else if (actionChecker.IsCheckTimeELapsed(nearestObstacle.GetTime()))
                                {
                                    sceneChanger.LoadGameOverScene();
                                }
                            }
                        }
                        else
                        {
                            throw new System.Exception("Obstacle object doesn't have attached obstacle script");
                        }
                    }
                }
                else
                {
                    IsTracking = false;
                }
            }
        }
    }
}