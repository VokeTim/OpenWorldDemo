public class MoveInputActionDev : BaseInputAction
{
    public override IInitAction IinitAction()
    {
        return new MoveInputAction();
    }
}
