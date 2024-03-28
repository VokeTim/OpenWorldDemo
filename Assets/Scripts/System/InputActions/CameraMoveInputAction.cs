namespace OpenWorld.System.InputSystem
{
    public class CameraMoveInputAction : BaseInputAction
    {
        public CameraMoveInputAction() 
        {
            InputActionImpl = new CameraMoveInputActionImpl();
        }
    }
}