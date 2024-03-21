namespace OpenWorld.System.InputSystem
{
    public class AttackInputAction : BaseInputAction
    {
        public override IActionInput IinitAction()
        {
            return new AttackInputActionImpl();
        }
    }
}