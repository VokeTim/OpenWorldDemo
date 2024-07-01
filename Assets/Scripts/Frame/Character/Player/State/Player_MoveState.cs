using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;

namespace OpenWorld.Framework.Character.Player
{
    public class Player_MoveState : PlayerStateBase
    {
        public override void Enter()
        {
            //player.PlayAnimation("Move");
            player.PlayAnimation("MoveMotionTree");
        }

        public override void Update()
        {
            if (!player.PlayerMoveInputListener()) 
            {
                player.ChangeState(PlayerState.Idle);
            }
            player.UpdatePositionAndStatusByECS();
            //ÒÆ¶¯Ê±ÌøÔ¾
            UpdateWithECS();
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
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}