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

        public bool needJump;

        public Vector3 jumpMoveDir = Vector3.zero;

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
            //UpdatePositionAndStatusByECS();
            //UpdateIsGroundInByECS();
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

        /// <summary>
        /// 根据ECS中的数据更新移动和动画
        /// </summary>
        public void UpdatePositionAndStatusByECS() 
        {
            //Transform playertransform = GetComponent<Transform>();
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                //playertransform.position += moveDir;
                characterController.Move(moveDir);
                model.Animator.SetFloat("MoveX", playerData.moveDir.x);
                model.Animator.SetFloat("MoveY", playerData.moveDir.z);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }

        public void UpdateIsGroundInByECS() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }

        /// <summary>
        /// 监听玩家控制角色的移动输入
        /// </summary>
        /// <returns></returns>
        public bool PlayerMoveInputListener() 
        {
            bool playerIsMoving = false;
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                if (moveDir.x != 0 || moveDir.z != 0) 
                {
                    playerIsMoving = true;
                }
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
            return playerIsMoving;
        }
        #endregion
    }
}
