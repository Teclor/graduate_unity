namespace BeatThis.Game.Obstacles
{
    public class ObstacleEntity
    {
        private float time;
        private int lane;
        private IObstacle obstacleObject;

        public ObstacleEntity(float time, int lane, IObstacle obstacleObject)
        {
            this.time = time;
            this.lane = lane;
            this.obstacleObject = obstacleObject;
        }

        public float GetTime()
        {
            return time;
        }

        public int GetLane()
        {
            return lane;
        }

        public IObstacle GetObstacle()
        {
            return obstacleObject;
        }
    }
}
