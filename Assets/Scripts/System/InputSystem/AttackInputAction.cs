using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    [InputSystemLoadOperation("Attack")]
    public class AttackInputAction : BaseInputAction
    {
        public override InputAction SetInputAction(InputActionMap actionMap, string actionName)
        {
            InputAction attackCtrlInputAction=actionMap.AddAction(actionName);
            attackCtrlInputAction.AddBinding("<Mouse>/leftButton");
            attackCtrlInputAction.performed += OnAttack;
            return attackCtrlInputAction;
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
            }
            //TODO: 添加攻击动画以及效果
            Debug.Log("attack!");
        }
    }
}