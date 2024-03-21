using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private InputAction moveAction;

        public InputAction getMoveAction() { return moveAction; }

        protected override void Init()
        {
            base.Init();
            SystemControl systemControl = new SystemControl();
            systemControl.InitMoveAction(ref moveAction);
        }

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            moveAction.Enable();
        }

        private void OnDisable()
        {
            moveAction.Disable();
        }
    }
}