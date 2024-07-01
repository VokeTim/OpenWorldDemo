using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

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
            //�������ƶ�
            //TODO: ���߼�����С��0.2ʱֹͣ��������
            player.CharacterController.Move(new Vector3(0, player.gravity * Time.deltaTime, 0));
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
                player.needJump = playerData.needJump;
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}