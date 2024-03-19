using UnityEngine.InputSystem;

namespace OpenWorld
{
    public interface IInitAction
    {
        public void Init(ref InputAction action);
    }
}