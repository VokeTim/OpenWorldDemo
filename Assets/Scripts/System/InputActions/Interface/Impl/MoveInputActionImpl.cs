using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class MoveInputActionImpl : BaseInputActionImpl, IInputAction
    {

        public MoveInputActionImpl() 
        {
            Init();
        }

        public InputAction GetInputAction()
        {
            return action;
        }

        public void Init()
        {
            action = new InputAction();
            action.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        }

        public void OnDisabled()
        {
            action.Disable();
        }

        public void OnEnabled()
        {
            action.Enable();
        }
    }
}