using BeatThis.Game.Controllers;

namespace BeatThis.Game.ControlActions
{
    public class DownAction : BaseControlAction
    {
        public DownAction(IControllerable controller) : base(controller) { }

        public override void CallControllerAction()
        {
            Controller.Down();
        }
    }
}
