namespace OpenWorld.System.InputSystem
{
    public class CameraMoveInputAction : BaseInputAction
    {
        public override IActionInput IinitAction()
        {
            return new CameraMoveInputActionImpl();
        }
    }
}