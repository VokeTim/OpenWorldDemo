namespace OpenWorld.Framework.Character.Player
{
    public class Player_MoveState : PlayerStateBase
    {
        public override void Enter()
        {
            player.PlayAnimation("Move");
        }

        public override void Update()
        {
            if (!player.PlayerMoveInputListener()) 
            {
                player.ChangeState(PlayerState.Idle);
            }
            player.UpdatePositionAndStatusByECS();
        }
    }
}