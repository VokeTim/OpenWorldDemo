using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld.Framework.Character.Player
{
    public class Player_MoveState : PlayerStateBase
    {
        public override void Enter()
        {
            player.PlayAnimation("MoveMotionTree");
        }

        public override void Update()
        {
            UpdateWithECS();
            if (!player.isMoving) 
            {
                player.ChangeState(PlayerState.Idle);
            }
            //ÒÆ¶¯Ê±ÌøÔ¾       
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
                player.jumpMoveDir = playerData.moveDir;
                player.needJump = playerData.needJump;
                Vector3 moveDir = new Vector3(playerData.moveDir.x, 0, playerData.moveDir.z);
                if (moveDir.x != 0 || moveDir.z != 0)
                {
                    player.isMoving = true;
                }
                //playertransform.position += moveDir;
                player.CharacterController.Move(moveDir);
                player.Model.Animator.SetFloat("MoveX", playerData.moveDir.x);
                player.Model.Animator.SetFloat("MoveY", playerData.moveDir.z);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}