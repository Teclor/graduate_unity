using System.Collections.Generic;
using System.Linq;

namespace BeatThis.Game.Obstacles
{
    public class ObstaclePool
    {
        Queue<ObstacleEntity> obstacleEntities = new Queue<ObstacleEntity>();
        public bool IsEmpty() => obstacleEntities.Count() == 0;
        
        public ObstaclePool()
        {
            obstacleEntities = new Queue<ObstacleEntity>();
        }

        public void Add(ObstacleEntity obstacleEntity)
        {
            obstacleEntities.Enqueue(obstacleEntity);
        }

        public ObstacleEntity Get()
        {
            obstacleEntities.TryPeek(out ObstacleEntity obstacleEntity);
            return obstacleEntity;
        }

        public ObstacleEntity Retrieve()
        {
            obstacleEntities.TryDequeue(out ObstacleEntity obstacleEntity);
            return obstacleEntity;
        }
    }
}
