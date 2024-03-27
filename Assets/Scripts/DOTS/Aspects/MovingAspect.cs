using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    public readonly partial struct MovingAspect : IAspect
    {
        private readonly RefRO<PlayerData> playerData;

        public void InputActionsMove(float deltaTime, Vector3 moveDir) 
        {
            PlayerController.moveDir = moveDir * deltaTime * playerData.ValueRO.moveSpeed;
        }

    }
}