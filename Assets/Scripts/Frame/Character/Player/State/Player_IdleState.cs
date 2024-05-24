namespace OpenWorld.Framework.Character.Player
{
    public class Player_IdleState : PlayerStateBase
    {
        public override void Enter()
        {
            // ²¥·Å´ý»ú¶¯»­
            player.PlayAnimation("Idle");
        }

        public override void Update()
        {
            if (player.PlayerMoveInputListener()) 
            {
                player.ChangeState(PlayerState.Move);
            }
        }
    }
}