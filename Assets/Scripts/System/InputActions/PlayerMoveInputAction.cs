namespace OpenWorld.System.InputSystem
{
    public class PlayerMoveInputAction : BaseInputAction
    {
        public PlayerMoveInputAction() 
        {
            InputActionImpl = new MoveInputActionImpl();
        }
    }
}