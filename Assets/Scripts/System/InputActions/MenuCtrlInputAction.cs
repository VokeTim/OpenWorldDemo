namespace OpenWorld.System.InputSystem
{
    public class MenuCtrlInputAction : BaseInputAction
    {
        public MenuCtrlInputAction() 
        {
            InputActionImpl = new MenuInputActionImpl();
        }
    }
}