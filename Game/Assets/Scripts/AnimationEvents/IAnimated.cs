using System;

namespace BeatThis.Game.AnimationEvents
{
    public interface IAnimated
    {
        public void OnAnimationStart(Type actionType);

        public void OnAnimationEnd(Type actionType);
    }
}
