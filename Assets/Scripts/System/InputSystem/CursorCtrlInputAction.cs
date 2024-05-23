using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{

    //[InputSystemLoadOperation("CursorCtrl")]
    public class CursorCtrlInputAction : BaseInputAction
    {

        public override InputAction SetInputAction(InputActionMap actionMap, string actionName)
        {
            InputAction CursorCtrlInputAction = actionMap.AddAction(actionName);
            CursorCtrlInputAction.AddBinding("<Keyboard>/t");
            CursorCtrlInputAction.performed += OnKeyCodeDown;
            return CursorCtrlInputAction;
        }

        private void OnKeyCodeDown(InputAction.CallbackContext context)
        {
            if (Cursor.visible)
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