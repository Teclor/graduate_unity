using System;
using UnityEngine;
using BeatThis.Game.ControlActions;

namespace BeatThis.Game
{
    class MobileActionDetector : MonoBehaviour
    {
        private static bool isDragging = false;
        private static Vector2 startTouch, swipeDelta;


        public static Type GetAction()
        {
            Type currentAction = null;
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    isDragging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    if (isDragging)
                    {
                        currentAction = typeof(SingleTapAction);
                    }
                    Reset();
                }
            }

            swipeDelta = Vector2.zero;
            if (isDragging)
            {
                if (Input.touches.Length < 0)
                    swipeDelta = Input.touches[0].position - startTouch;
                else if (Input.GetMouseButton(0))
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

            if (swipeDelta.magnitude > 100)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {

                    if (x < 0)
                        currentAction = typeof(LeftAction);
                    else
                        currentAction = typeof(RightAction);
                }
                else
                {
                    if (y < 0)
                        currentAction = typeof(DownAction);
                    else
                        currentAction = typeof(UpAction);
                }

                Reset();
            }
            return currentAction;
        }

        private static void Reset()
        {
            startTouch = swipeDelta = Vector2.zero;
            isDragging = false;
        }
    }
}
