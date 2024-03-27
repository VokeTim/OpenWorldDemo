using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class CursorCtrlInputActionImpl : IActionInput
    {
        public void Init(ref InputAction action)
        {
            action = new InputAction();
            action.AddBinding("<Keyboard>/t");
            action.performed += OnKeyCodeDown;
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