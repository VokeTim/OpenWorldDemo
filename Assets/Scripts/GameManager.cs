using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private InputAction moveAction;
        private InputAction attackAction;
        private InputAction cameraMoveAction;

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
        }

        private void OnEnable()
        {
            moveAction.Enable();
            attackAction.Enable();
            cameraMoveAction.Enable();
        }

        private void Start()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            //CameraMoveInput = cameraMoveAction.ReadValue<Vector2>();
            CameraMoveInput = Mouse.current.delta.ReadValue();
        }

        private void LateUpdate()
        {
            
        }

        private void OnDisable()
        {
            moveAction.Disable();
            attackAction.Disable();
            cameraMoveAction.Disable();
        }
    }
}
