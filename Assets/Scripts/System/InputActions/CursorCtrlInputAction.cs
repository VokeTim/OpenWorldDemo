namespace OpenWorld.System.InputSystem
{
    public class CursorCtrlInputAction : BaseInputAction
    {
        public CursorCtrlInputAction() 
        {
            InputActionImpl = new CursorCtrlInputActionImpl();
        }
    }
}