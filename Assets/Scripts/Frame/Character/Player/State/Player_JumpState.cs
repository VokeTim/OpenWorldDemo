using UnityEngine;

namespace OpenWorld.Framework.Character.Player
{
    public class Player_JumpState : PlayerStateBase
    {
        private Vector3 jumpStartPosition = Vector3.zero;

        public override void Enter()
        {
            player.PlayAnimation("JumpUp");
            jumpStartPosition = player.transform.position;
        }

        public override void Update()
        {     
            Vector3 currentPostion = player.transform.position;
            float distance = currentPostion.y - jumpStartPosition.y;
            //Debug.Log("Distance of Ground:" + distance);
            if (distance < player.JumpMaxHight)
            {
                // ��δ�������߶ȼ�������
                Vector3 jumpDir = new Vector3(player.jumpMoveDir.x, player.JumpSpeed * Time.deltaTime, player.jumpMoveDir.z);
                player.CharacterController.Move(jumpDir);
            }
            else 
            {
                // �ѵ�����Ծ����������߶Ƚ����������״̬
                player.ChangeState(PlayerState.AirDown);
            }
        }

        public override void Exit()
        {
            jumpStartPosition = Vector3.zero;
        }
    }
}