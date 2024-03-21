using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private InputAction moveAction;
        private InputAction attackAction;

        public InputAction GetMoveAction() { return moveAction; }

        private void Awake()
        {
            base.Awake();
            SystemControl systemControl = new SystemControl();
            systemControl.InitMoveAction(ref moveAction);
            systemControl.InitAttackAction(ref attackAction);
        }

        private void OnEnable()
        {
            moveAction.Enable();
            attackAction.Enable();
        }

        private void OnDisable()
        {
            moveAction.Disable();
            attackAction.Disable();
        }
    }
}