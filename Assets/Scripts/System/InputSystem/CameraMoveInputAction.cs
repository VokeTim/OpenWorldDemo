using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    [InputSystemLoadOperation("CursorMoveCtrl")]
    public class CameraMoveInputAction : BaseInputAction
    {
        public override InputAction SetInputAction(InputActionMap actionMap, string actionName)
        {
            InputAction CameraMoveInputAction = actionMap.AddAction(actionName, InputActionType.Value, "<Mouse>/delta");
            return CameraMoveInputAction;
        }
    }
}