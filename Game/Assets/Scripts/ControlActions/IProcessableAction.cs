namespace BeatThis.Game.ControlActions
{
    public interface IProcessableAction : IControlAction
    {
        public bool IsProcessing();

        public void StartProcessing();

        public void FinishProcessing();
    }
}
