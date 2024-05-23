using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public abstract class BaseInputAction
    {
        public abstract InputAction SetInputAction(InputActionMap actionMap, string actionName);
    }
}