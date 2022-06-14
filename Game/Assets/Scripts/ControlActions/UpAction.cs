namespace BeatThis.Game.ControlActions
{
    public class UpAction : BaseControlAction
    {
        public UpAction(IControllerable controller) : base(controller) { }
        public override void CallControllerAction()
        {
            Controller.Up();
        }
    }
}
