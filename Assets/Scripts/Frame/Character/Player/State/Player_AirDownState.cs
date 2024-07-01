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
                // �Ѿ��Ӵ�������
                player.ChangeState(PlayerState.Idle);
                UpdateWithECS();
            }
            else 
            {
                // û�нӴ��������������
                Vector3 offset = new Vector3(0, player.gravity * Time.deltaTime, 0);
                player.CharacterController.Move(offset);
            }
        }

        private void UpdateWithECS() 
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                // ��Ծ�������޸���Ҫ��Ծ�ı�ʶ
                playerData.needJump = false;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}