using BeatThis.Game.Controllers;

namespace BeatThis.Game.ControlActions
{
    public abstract class BaseControlAction : IProcessableAction
    {
        protected IControllerable Controller;
        protected bool isProcessing;

        public BaseControlAction(IControllerable controller)
        {
            Controller = controller;
            isProcessing = false;
        }

        public abstract void CallControllerAction();

        public void StartProcessing()
        {
            isProcessing = true;
        }

        public void FinishProcessing()
        {
            isProcessing = false;
        }

        public bool IsProcessing()
        {
            return isProcessing;
        }
    }
}
