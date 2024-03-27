using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class CameraMoveInputActionImpl : IActionInput
    {
        public void Init(ref InputAction action)
        {
            action = new InputAction(binding: "<Mouse>/delta");
        }
    }
}