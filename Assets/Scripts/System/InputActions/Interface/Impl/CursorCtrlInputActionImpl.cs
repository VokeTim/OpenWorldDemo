using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class CursorCtrlInputActionImpl : BaseInputActionImpl, IInputAction
    {

        public CursorCtrlInputActionImpl() 
        {
            Init();
        }

        public T GetReadValue<T>() where T : struct
        {
            return action.ReadValue<T>();
        }

        public void Init()
        {
            action = new InputAction();
            action.AddBinding("<Keyboard>/t");
            action.performed += OnKeyCodeDown;
        }

        public void OnDisabled()
        {
            action.Disable();
        }

        public void OnEnabled()
        {
            action.Enable();
        }

        private void OnKeyCodeDown(InputAction.CallbackContext context)
        {
            if(Cursor.visible)
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }
        }
    }
}