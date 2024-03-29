using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class MoveInputActionImpl : IActionInput
    {
        public void Init(ref InputAction action)
        {
            action = new InputAction();
            action.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        }
    }
}