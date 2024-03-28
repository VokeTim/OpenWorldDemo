using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public interface IInputAction
    {
        public void Init();

        public void OnEnabled();

        public void OnDisabled();

        public InputAction GetInputAction();
    }
}