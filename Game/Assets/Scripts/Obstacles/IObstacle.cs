using System;

namespace BeatThis.Game.Obstacles
{
    public interface IObstacle
    {
        public abstract int[] AvailableLanes { get; }
        public abstract Type[] ApplicableActions { get; }
        public int LaneWidth { get; }
        public bool StrictLaneCheck { get; }

        public void Pass();

        public bool IsPassed();
    }
}
