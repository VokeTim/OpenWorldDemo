using UnityEngine.InputSystem;

namespace OpenWorld
{
    public interface IActionInput
    {
        public void Init(ref InputAction action);
    }
}