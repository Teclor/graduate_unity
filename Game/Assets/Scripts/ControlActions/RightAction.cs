namespace BeatThis.Game.ControlActions
{
    public class RightAction : BaseControlAction
    {
        public RightAction(IControllerable controller) : base(controller) { }
        public override void CallControllerAction()
        {
            Controller.Right();
        }
    }
}