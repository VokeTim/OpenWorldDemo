using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public interface IActionInput
    {
        public void Init(ref InputAction action);
    }
}