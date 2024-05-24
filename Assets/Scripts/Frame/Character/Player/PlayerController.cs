using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using OpenWorld.Framework.Character.Player;
using OpenWorld.Framework.StateMachine;
using UnityEngine;

namespace OpenWorld.Framework.Character
{
    public class PlayerController : CharacterBase
    {
        public float velocity;

        public Animator animator;

        private float moveSpeed;

        private float mouseSensitivity;

        private void Awake()
        {
            moveSpeed = 5.0f;
            mouseSensitivity = 1;
        }

        private void Start()
        {
            Init();
            // Ĭ�Ͻ���״̬����״̬
            ChangeState(PlayerState.Idle);
        }

        private void Update()
        {
            //UpdatePositionAndStatusByECS();
        }

        public override void Init()
        {
            base.Init();
            SetPlayerMoveSpeed();
        }

        #region ״̬������
        private PlayerState currentState;

        public void ChangeState(PlayerState playerState, bool reCurrentState = false) 
        {
            currentState = playerState;
            switch (playerState) 
            {
                case PlayerState.Idle: stateMachine.ChangeState<Player_IdleState>(reCurrentState); break;
                case PlayerState.Move: stateMachine.ChangeState<Player_MoveState>(reCurrentState); break;
                default: break;
            }
        }
        #endregion

        #region DOTS����ģ��
        /// <summary>
        /// ��ѯPlayerData�����ݲ���ֵ
        /// </summary>
        public void SetPlayerMoveSpeed() 
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
        /// ����ECS�е����ݸ����ƶ��Ͷ���
        /// </summary>
        public void UpdatePositionAndStatusByECS() 
        {
            Transform playertransform = GetComponent<Transform>();
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                playertransform.position += moveDir;
                //animator.SetFloat("velocity", (float) playerData.moveVelocity);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }

        /// <summary>
        /// ������ҿ��ƽ�ɫ���ƶ�����
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
