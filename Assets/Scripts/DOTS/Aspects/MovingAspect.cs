using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    public readonly partial struct MovingAspect : IAspect
    {
        private readonly RefRO<PlayerData> playerData;

        private readonly RefRW<LocalTransform> transform;

        public void InputActionsMove(float deltaTime, Vector3 moveDir) 
        {
            transform.ValueRW.Position += (float3) moveDir * playerData.ValueRO.moveSpeed * deltaTime;
        }
    }
}