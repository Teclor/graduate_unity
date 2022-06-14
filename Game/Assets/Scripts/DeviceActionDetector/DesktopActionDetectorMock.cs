using System;
using UnityEngine;
using BeatThis.Game.ControlActions;

namespace BeatThis.Game
{
    class DesktopActionDetectorMock : MonoBehaviour
    {
        public static bool tap;
        private static bool isDraging = false;
        private static Vector2 startTouch, swipeDelta;


        public static Type GetAction()
        {
            Type currentAction = null;
            tap = false;

            #region ПК-версия
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (isDraging && !(swipeDelta.magnitude > 100))
                {
                    currentAction = typeof(SingleTapAction);
                }
                Reset();
            }
            #endregion

            //Просчитать дистанцию
            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length < 0)
                    swipeDelta = Input.touches[0].position - startTouch;
                else if (Input.GetMouseButton(0))
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

            //Проверка на пройденность расстояния
            if (swipeDelta.magnitude > 100)
            {
                //Определение направления
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
            isDraging = false;
        }

    }
}
