using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld
{
    public class PlayerController : MonoBehaviour
    {
        public float velocity;

        public Animator animator;

        private float moveSpeed;

        public float GetMoveSpeed { get { return moveSpeed; } }

        private void Awake()
        {
            moveSpeed = 5.0f;
            animator.SetFloat("velocity", 0);
        }

        private void Start()
        {
            SetPlayerMoveSpeed();
        }

        private void Update()
        {
            UpdatePositionAndStatusByECS();
        }

        /// <summary>
        /// 查询PlayerData的数据并赋值
        /// </summary>
        private void SetPlayerMoveSpeed() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                playerData.moveSpeed = moveSpeed;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }

        /// <summary>
        /// 根据ECS中的数据更新移动和动画
        /// </summary>
        private void UpdatePositionAndStatusByECS() 
        {
            Transform playertransform = GetComponent<Transform>();
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                playertransform.position += moveDir;
                animator.SetFloat("velocity", (float) playerData.moveVelocity);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}
