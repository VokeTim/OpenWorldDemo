using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld.Framework.Character.Player
{
    public class Player_IdleState : PlayerStateBase
    {
        public override void Enter()
        {
            // 播放待机动画
            player.PlayAnimation("Idle");
        }

        public override void Update()
        {
            UpdateWithECS();
            //检测玩家移动
            if (player.isMoving) 
            {
                player.ChangeState(PlayerState.Move);
            }        
            player.CharacterController.Move(new Vector3(0, player.gravity * Time.deltaTime, 0));      
            //TODO: 考虑由常态装换到下落状态判断（例如：角色移动到一个高低差较大的区域然后从高处落下）
            if (player.needJump) 
            {
                player.ChangeState(PlayerState.Jump);
            }
        }

        private void UpdateWithECS() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                player.needJump = playerData.needJump;
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                if (moveDir.x != 0 || moveDir.z != 0)
                {
                    player.isMoving = true;
                }
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}