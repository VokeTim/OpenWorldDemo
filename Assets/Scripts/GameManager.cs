using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private InputAction moveAction;
        private InputAction attackAction;
        private InputAction cameraMoveAction;
        private InputAction cursorCtrlInputAction;

        public static Vector2 CameraMoveInput;

        public InputAction GetMoveAction() { return moveAction; }

        private void Awake()
        {
            Init();
            CameraMoveInput = Vector2.zero;
            SystemControl systemControl = new SystemControl();
            systemControl.InitMoveAction(ref moveAction);
            systemControl.InitAttackAction(ref attackAction);
            systemControl.InitCameraMoveInputAction(ref cameraMoveAction);
            systemControl.InitCursorCtrlInputAction(ref cursorCtrlInputAction);
        }

        private void OnEnable()
        {
            moveAction.Enable();
            attackAction.Enable();
            cameraMoveAction.Enable();
            cursorCtrlInputAction.Enable();
        }

        private void Start()
        {
            //Cursor.visible = false;
        }

        private void Update()
        {
            CameraMoveInput = cameraMoveAction.ReadValue<Vector2>();
            //CameraMoveInput = Mouse.current.delta.ReadValue();
            //TODO: 将按T箭显示或者隐藏鼠标以InputSystem的方式实现
            //if (Input.GetKeyDown(KeyCode.T)) 
            //{
            //    if (Cursor.visible)
            //    {
            //        Cursor.visible = false;
            //    }
            //    else 
            //    {
            //        Cursor.visible = true;
            //    }
            //}
        }

        private void LateUpdate()
        {
            
        }

        private void OnDisable()
        {
            moveAction.Disable();
            attackAction.Disable();
            cameraMoveAction.Disable();
            cursorCtrlInputAction.Disable();
        }

    }
}
