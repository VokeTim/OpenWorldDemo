using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    [InputSystemLoadOperation("Movement")]
    public class PlayerMoveInputAction : BaseInputAction
    {

        public override InputAction SetInputAction(InputActionMap actionMap, string actionName)
        {
            InputAction movementInputAction = actionMap.AddAction(actionName);
            movementInputAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
            return movementInputAction;
        }
    }
}