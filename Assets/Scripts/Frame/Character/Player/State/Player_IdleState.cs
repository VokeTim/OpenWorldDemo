namespace OpenWorld.Framework.Character.Player
{
    public class Player_IdleState : PlayerStateBase
    {
        public override void Enter()
        {
            // ���Ŵ�������
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