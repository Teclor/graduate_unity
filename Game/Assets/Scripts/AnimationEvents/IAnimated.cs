using System;

namespace BeatThis.Game.AnimationEvents
{
    interface IAnimated
    {
        public void OnAnimationStart(Type ActionType);

        public void OnAnimationEnd(Type ActionType);
    }
}
