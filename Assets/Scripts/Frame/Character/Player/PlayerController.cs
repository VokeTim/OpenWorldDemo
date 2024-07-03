using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using OpenWorld.Framework.Character.Player;
using OpenWorld.Framework.StateMachine;
using UnityEngine;

namespace OpenWorld.Framework.Character
{
    public class PlayerController : CharacterBase
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float jumpSpeed;

        [SerializeField]
        private float jumpMaxHeight;

        [HideInInspector]
        public bool needJump;

        [HideInInspector]
        public Vector3 jumpMoveDir = Vector3.zero;

        [HideInInspector]
        public bool isMoving = false;

        public float JumpSpeed { get { return jumpSpeed; } }

        public float JumpMaxHight { get { return jumpMaxHeight; } }

        private float mouseSensitivity;

        private void Awake()
        {
            //moveSpeed = 5.0f;
            mouseSensitivity = 1;
        }

        private void Start()
        {
            Init();
            // 默认进入状态机的状态
            ChangeState(PlayerState.Idle);
            model.Animator.SetFloat("MoveX", 0);
            model.Animator.SetFloat("MoveY", 0);
        }

        private void Update()
        {
        }

        public override void Init()
        {
            base.Init();
            SetPlayerCtrlDatawithDOTS();
        }

        private void OnDestroy()
        {
            stateMachine.Stop();
        }

        #region 状态机管理
        private PlayerState currentState;

        public void ChangeState(PlayerState playerState, bool reCurrentState = false) 
        {
            currentState = playerState;
            switch (playerState) 
            {
                case PlayerState.Idle: stateMachine.ChangeState<Player_IdleState>(reCurrentState); break;
                case PlayerState.Move: stateMachine.ChangeState<Player_MoveState>(reCurrentState); break;
                case PlayerState.Jump:stateMachine.ChangeState<Player_JumpState>(reCurrentState);break;
                case PlayerState.AirDown:stateMachine.ChangeState<Player_AirDownState>(reCurrentState);break;
                default: break;
            }
        }
        #endregion

        #region DOTS管理模块
        /// <summary>
        /// 查询PlayerData的数据并赋值
        /// </summary>
        public void SetPlayerCtrlDatawithDOTS() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                playerData.moveSpeed = moveSpeed;
                playerData.mouseSensitivity = mouseSensitivity;  
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
        #endregion
    }
}
