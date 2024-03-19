namespace OpenWorld
{
    public class MoveInputAction : BaseInputAction
    {
        public override IInitAction IinitAction()
        {
            return new MoveInputActionImpl();
        }
    }
}