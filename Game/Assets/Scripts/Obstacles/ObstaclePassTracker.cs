using UnityEngine;
using BeatThis.Game.Generators;
using BeatThis.Game.Controllers;

namespace BeatThis.Game.Obstacles
{
    public class ObstaclePassTracker : MonoBehaviour
    {
        public static bool IsTracking = false;
        private ObstaclePool obstaclePool;
        private MainCharacterController mainCharacterController;
        private ActionChecker actionChecker;
        [SerializeField] SceneChanger sceneChanger;
        public void Awake()
        {
            IsTracking = false;
        }

        public void SetCharacterController(MainCharacterController characterController)
        {
            mainCharacterController = characterController;
        }

        public void StartTracking(ActionChecker actionChecker)
        {
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