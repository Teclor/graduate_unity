using System;
using System.Collections;
using UnityEngine;
using BeatThis.Game.ControlActions;

namespace BeatThis.Game.Obstacles
{
    public class DestructibleObstacle : BaseObstacle
    {
        public override int[] AvailableLanes { get; } = new int[] {-1, 0, 1};
        public override Type[] ApplicableActions { get; } = new Type[] { typeof(SingleTapAction) };
        public override bool StrictLaneCheck { get; } = true;

        protected override IEnumerator DeactivateWithDelay()
        {
            yield return new WaitForSeconds(DeactivationDelay);
            gameObject.SetActive(false);
        }
    }
}
