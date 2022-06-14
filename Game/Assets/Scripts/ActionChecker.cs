using System;
using System.Linq;
using UnityEngine;
using BeatThis.Game.Obstacles;
using BeatThis.Game.ControlActions;


namespace BeatThis.Game
{ 
    public class ActionChecker
    {
        private float checkTimeOffset;
        private ProcessableActionRegistry actionRegistry;
        private ActionDetector actionDetector;

        public ActionChecker(ProcessableActionRegistry actionRegistry, ActionDetector actionDetector, float checkTimeOffsetInSeconds = 0.5f)
        {
            this.actionRegistry = actionRegistry;
            this.actionDetector = actionDetector;
            checkTimeOffset = checkTimeOffsetInSeconds;
        }
        public bool CheckFitsInTime(IObstacle obstacle, float time)
        {
            Type[] obstacleActions = obstacle.ApplicableActions;
            bool isInTime = false;
            if (obstacleActions.Contains(actionDetector.GetLastAction()))
            {
                bool isActionActive = false;
                foreach (Type controlActionType in obstacleActions)
                {
                    if (actionRegistry.GetAction(controlActionType).IsProcessing())
                    {
                        isActionActive = true;
                        break;
                    }
                }

                if (isActionActive)
                {
                    if (IsCheckTimeReached(time) && !IsCheckTimeELapsed(time))
                    {
                        isInTime = true;
                    }
                }
            }
            return isInTime;
        }

        public bool IsCheckTimeReached(float time)
        {
            return (-checkTimeOffset + time <= Time.timeSinceLevelLoad);
        }
        public bool IsCheckTimeELapsed(float time)
        {
            return (Time.timeSinceLevelLoad > time + checkTimeOffset);
        }
    }
}