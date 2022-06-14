namespace BeatThis.Game.ControlActions
{
    public class SingleTapAction : BaseControlAction
    {
        public SingleTapAction(IControllerable controller) : base(controller) { }
        public override void CallControllerAction()
        {
            Controller.Attack();
        }
    }
}
