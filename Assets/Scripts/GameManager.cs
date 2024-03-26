using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private InputAction moveAction;
        private InputAction attackAction;
        private Vector3 followTarget;
        public Vector3 FollowTarget { get { return followTarget; } set { followTarget = value; } }
        private Vector3 offset;

        public InputAction GetMoveAction() { return moveAction; }

        private void Awake()
        {
            Init();
            SystemControl systemControl = new SystemControl();
            systemControl.InitMoveAction(ref moveAction);
            systemControl.InitAttackAction(ref attackAction);
        }

        private void OnEnable()
        {
            moveAction.Enable();
            attackAction.Enable();
        }

        private void Start()
        {
            followTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
            offset = Camera.main.transform.position - followTarget;
        }

        private void LateUpdate()
        {
            Camera.main.transform.position = followTarget + offset;
        }

        private void OnDisable()
        {
            moveAction.Disable();
            attackAction.Disable();
        }
    }
}