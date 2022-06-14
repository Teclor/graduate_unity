namespace BeatThis.Game.ControlActions
{
    public class LeftAction : BaseControlAction
    {
        public LeftAction(IControllerable controller) : base(controller) { }

        public override void CallControllerAction()
        {
            Controller.Left();
        }
    }
}