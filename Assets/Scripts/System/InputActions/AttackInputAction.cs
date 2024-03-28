namespace OpenWorld.System.InputSystem
{
    public class AttackInputAction : BaseInputAction
    {
        public AttackInputAction() 
        {
            InputActionImpl = new AttackInputActionImpl();
        }
    }
}