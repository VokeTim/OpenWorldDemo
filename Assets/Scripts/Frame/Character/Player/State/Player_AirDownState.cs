using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld.Framework.Character.Player
{
    public class Player_AirDownState : PlayerStateBase
    {
        public override void Enter()
        {
            player.PlayAnimation("AirDown");
        }

        public override void Update()
        {
            if (player.CharacterController.isGrounded)
            {
                // 已经接触到地面
                player.ChangeState(PlayerState.Idle);
                UpdateWithECS();
            }
            else 
            {
                // 没有接触到地面继续下落
                Vector3 offset = new Vector3(player.jumpMoveDir.x, player.gravity * Time.deltaTime, player.jumpMoveDir.z);
                player.CharacterController.Move(offset);
            }
        }

        public override void Exit()
        {
            player.jumpMoveDir = Vector3.zero;
        }

        private void UpdateWithECS() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                // 跳跃结束，修改需要跳跃的标识
                playerData.needJump = false;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}