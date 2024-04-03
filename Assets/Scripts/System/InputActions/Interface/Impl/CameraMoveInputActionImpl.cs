using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class CameraMoveInputActionImpl : BaseInputActionImpl, IInputAction
    {

        public CameraMoveInputActionImpl() 
        {
            Init();
        }

        public T GetReadValue<T>() where T : struct
        {
            return action.ReadValue<T>();
        }

        public void Init()
        {
            action = new InputAction(binding: "<Mouse>/delta");
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