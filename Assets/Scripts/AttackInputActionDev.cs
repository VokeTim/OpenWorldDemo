public class AttackInputActionDev : BaseInputAction
{
    public override IInitAction IinitAction()
    {
        return new AttackInputAction();
    }
}
