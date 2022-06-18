using System;
using UnityEngine;

namespace BeatThis.Game
{
    public class ActionDetector : MonoBehaviour
    {
        public Type CurrentAction { get; protected set; }
        public Type LastAction { get; protected set; }

        private void Update()
        {
            if(SystemInfo.deviceType == DeviceType.Handheld)
            {
                CurrentAction = MobileActionDetector.GetAction();
            }
            else
            {
                CurrentAction = DesktopActionDetectorMock.GetAction();
            }
            if (CurrentAction != null)
            {
                LastAction = CurrentAction;
            }
        }
    }
}
