﻿using System;
using System.Collections.Generic;
using UnityEngine;
using BeatThis.Game.ControlActions;


namespace BeatThis.Game.AnimationEvents
{
    class AnimationEventDispatcher : MonoBehaviour
    {
        public Dictionary<string, Type> EventToActionMap;
        private IAnimated mainController;

        public void Start()
        {
            mainController = GetComponent<IAnimated>();
            EventToActionMap = new Dictionary<string, Type>
            {
                { "Attack", typeof(SingleTapAction) },
                { "Jump", typeof(UpAction) },
                { "SlideLeft", typeof(LeftAction) },
                { "SlideRight", typeof(RightAction) },
                { "Down", typeof(DownAction) },
            };
        }

        public void NotifyAnimationStarted(string eventName)
        {
            if (EventToActionMap.ContainsKey(eventName))
            {
                mainController.OnAnimationStart(EventToActionMap[eventName]);
            }
        }

        public void NotifyAnimationEnded(string eventName)
        {
            if (EventToActionMap.ContainsKey(eventName))
            {
                mainController.OnAnimationEnd(EventToActionMap[eventName]);
            }
        }
    }
}

