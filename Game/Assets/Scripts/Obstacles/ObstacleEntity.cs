namespace BeatThis.Game.Obstacles
{
    public class ObstacleEntity
    {
        private float time;
        private int line;
        private IObstacle obstacleObject;

        public ObstacleEntity(float time, int line, IObstacle obstacleObject)
        {
            this.time = time;
            this.line = line;
            this.obstacleObject = obstacleObject;
        }

        public float GetTime()
        {
            return time;
        }

        public int GetLine()
        {
            return line;
        }

        public IObstacle GetObstacle()
        {
            return obstacleObject;
        }
    }
}
