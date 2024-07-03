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
            UpdateWithECS();
            //�������ƶ�
            if (player.isMoving) 
            {
                player.ChangeState(PlayerState.Move);
            }        
            player.CharacterController.Move(new Vector3(0, player.gravity * Time.deltaTime, 0));      
            //TODO: �����ɳ�̬װ��������״̬�жϣ����磺��ɫ�ƶ���һ���ߵͲ�ϴ������Ȼ��Ӹߴ����£�
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