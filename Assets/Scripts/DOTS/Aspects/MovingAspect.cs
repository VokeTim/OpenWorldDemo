using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.DOTS.PlayerControl
{
    public readonly partial struct MovingAspect : IAspect
    {
        private readonly RefRO<PlayerData> moveSpeed;

        private readonly RefRW<LocalTransform> transform;

        public void Move(float deltaTime) 
        {
            InputAction moveAction = GameManager.Instance.getMoveAction();
            transform.ValueRW.Position += new float3(moveAction.ReadValue<Vector2>().x, 0, moveAction.ReadValue<Vector2>().y) * moveSpeed.ValueRO.moveSpeed * deltaTime;
        }
    }
}