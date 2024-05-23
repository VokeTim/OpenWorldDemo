using OpenWorld.DOTS.Commponent;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace OpenWorld.DOTS.System
{
    [BurstCompile]
    public partial struct PlayerDataCtrlSystem : ISystem
    {

        [BurstCompile]
        public void OnCreate(ref SystemState state) 
        {
            //Debug.Log("DOTS System Loaded!");
        }

        public void OnUpdate(ref SystemState state) 
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            // 角色移动输入
            Vector2 moveDir = GameManager.Instance.systemControl.actions.FindAction("Movement").ReadValue<Vector2>();
            // 相机移动输入
            Vector2 CameraMoveInput = GameManager.Instance.systemControl.actions.FindAction("CursorMoveCtrl").ReadValue<Vector2>();
            foreach (var entity in SystemAPI.Query<RefRW<PlayerCtrlData>>()) 
            {
                float3 characterMoveDir = new float3(moveDir.x, 0, moveDir.y) * ((float)entity.ValueRO.moveSpeed) * deltaTime;
                entity.ValueRW.moveDir = characterMoveDir;
                float magnitude=Vector3.Magnitude(new float3(moveDir.x, 0, moveDir.y) * (float)entity.ValueRO.moveSpeed);
                entity.ValueRW.moveVelocity = magnitude;
                float2 cameraMoveDir = new float2(CameraMoveInput.x, CameraMoveInput.y);
                entity.ValueRW.cameraMoveInput = cameraMoveDir;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            //TODO: 运行结束后删除组件再移除实体
            //Debug.Log("DestroyAction!!");
        }
    }
}