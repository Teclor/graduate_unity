using System;
using UnityEngine;

namespace BeatThis.Game
{
    public class ActionDetector : MonoBehaviour
    {
        private Type currentAction;
        private Type lastAction;

        private void Update()
        {
            if(SystemInfo.deviceType == DeviceType.Handheld)
            {
                currentAction = MobileActionDetector.GetAction();
            }
            else
            {
                currentAction = DesktopActionDetectorMock.GetAction();
            }
            if (currentAction != null)
            {
                lastAction = currentAction;
            }
        }

        public Type GetCurrentAction()
        {
            return currentAction;
        }

        public Type GetLastAction()
        {
            return lastAction;
        }
    }
}
