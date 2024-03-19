namespace OpenWorld
{
    public class AttackInputAction : BaseInputAction
    {
        public override IInitAction IinitAction()
        {
            return new AttackInputActionImpl();
        }
    }
}