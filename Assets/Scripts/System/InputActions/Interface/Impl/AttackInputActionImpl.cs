using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class AttackInputActionImpl : IActionInput
    {
        public void Init(ref InputAction action)
        {
            action = new InputAction();
            action.AddBinding("<Mouse>/leftButton");
            action.performed += OnAttack;
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