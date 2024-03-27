namespace OpenWorld.System.InputSystem
{
    public class CursorCtrlInputAction : BaseInputAction
    {
        public override IActionInput IinitAction()
        {
            return new CursorCtrlInputActionImpl();
        }
    }
}