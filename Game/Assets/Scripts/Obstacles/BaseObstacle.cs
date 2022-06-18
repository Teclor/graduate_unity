using System;
using System.Collections;
using UnityEngine;

namespace BeatThis.Game.Obstacles
{
    public abstract class BaseObstacle : MonoBehaviour, IObstacle
    {
        public abstract int[] AvailableLanes { get; }
        public abstract Type[] ApplicableActions { get; }
        public virtual int LaneWidth { get; } = 1;
        protected bool isPassed = false;
        public virtual bool StrictLaneCheck { get; } = false;

        [SerializeField] protected float DeactivationDelay = 0;

        public void Pass()
        {
            isPassed = true;
            StartCoroutine(DeactivateWithDelay());
        }

        public bool IsPassed()
        {
            return isPassed;
        }

        protected abstract IEnumerator DeactivateWithDelay();
    }
}
