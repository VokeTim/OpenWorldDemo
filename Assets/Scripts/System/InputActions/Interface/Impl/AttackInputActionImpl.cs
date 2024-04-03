using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class AttackInputActionImpl : BaseInputActionImpl, IInputAction
    {

        public AttackInputActionImpl() 
        {
            Init();
        }

        public T GetReadValue<T>() where T : struct
        {
            return action.ReadValue<T>();
        }

        public void Init()
        {
            action = new InputAction();
            action.AddBinding("<Mouse>/leftButton");
            action.performed += OnAttack;
        }

        public void OnDisabled()
        {
            action.Disable();
        }

        public void OnEnabled()
        {
            action.Enable();
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            if (Cursor.visible) 
            {
                Cursor.visible = false;
            }
            Debug.Log("attack!");
        }
    }
}