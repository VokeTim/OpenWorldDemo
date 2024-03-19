namespace OpenWorld
{
    public class AttackInputAction : BaseInputAction
    {
        public override IActionInput IinitAction()
        {
            return new AttackInputActionImpl();
        }
    }
}