namespace OpenWorld.System.InputSystem
{
    public class MoveInputAction : BaseInputAction
    {
        public MoveInputAction() 
        {
            InputActionImpl = new MoveInputActionImpl();
        }
    }
}