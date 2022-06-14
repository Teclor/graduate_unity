using UnityEngine;
using BeatThis.Game.Obstacles;

namespace BeatThis.Game
{
    public class CollisionController : MonoBehaviour
    {
        [SerializeField] private SceneChanger sceneChanger;
        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            BaseObstacle obstacleComponent = hit.gameObject.GetComponent<BaseObstacle>();
            if (obstacleComponent != null && !obstacleComponent.IsPassed())
            {
                sceneChanger.LoadGameOverScene();
            }
        }
    }
}
