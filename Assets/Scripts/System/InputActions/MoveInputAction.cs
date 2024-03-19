namespace OpenWorld
{
    public class MoveInputAction : BaseInputAction
    {
        public override IActionInput IinitAction()
        {
            return new MoveInputActionImpl();
        }
    }
}