using System;
using System.Collections;
using UnityEngine;
using BeatThis.Game.ControlActions;

namespace BeatThis.Game.Obstacles
{
    public class JumpableObstacle : BaseObstacle
    {
        public override int[] AvailableLanes { get;  } = new int[] { 0 };
        public override Type[] ApplicableActions { get; } = new Type[] { typeof(UpAction) };
        public override int LaneWidth { get; } = 5;


        protected override IEnumerator DeactivateWithDelay()
        {
            yield return new WaitForSeconds(DeactivationDelay);
            gameObject.SetActive(false);
        }
    }
}
