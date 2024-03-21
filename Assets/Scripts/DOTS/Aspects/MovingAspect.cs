using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.DOTS.PlayerControl
{
    public readonly partial struct MovingAspect : IAspect
    {
        private readonly RefRO<PlayerData> playerData;

        private readonly RefRW<LocalTransform> transform;

        public void Move(float deltaTime) 
        {
            InputAction moveAction = GameManager.Instance.GetMoveAction();
            Vector2 moveDir = moveAction.ReadValue<Vector2>();
            transform.ValueRW.Position += new float3(moveDir.x, 0, moveDir.y) * playerData.ValueRO.moveSpeed * deltaTime;
        }
    }
}