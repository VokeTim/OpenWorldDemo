namespace OpenWorld
{
    public class MoveInputActionDev : BaseInputAction
    {
        public override IInitAction IinitAction()
        {
            return new MoveInputActionImpl();
        }
    }
}