using OpenWorld.DOTS.Commponent;
using Unity.Burst;
using Unity.Collections;
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
                //float magnitude=Vector3.Magnitude(new float3(moveDir.x, 0, moveDir.y) * (float)entity.ValueRO.moveSpeed);
                float xAxisMove = entity.ValueRO.xAxisInvert ? -CameraMoveInput.x : CameraMoveInput.x;
                float yAxisMove = entity.ValueRO.yAxisInvert ? -CameraMoveInput.y : CameraMoveInput.y;
                float2 cameraMoveDir = new float2(xAxisMove, yAxisMove) * (float)entity.ValueRO.mouseSensitivity;
                entity.ValueRW.cameraMoveInput = cameraMoveDir;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            // 运行结束后删除组件再移除实体
            //Debug.Log("DestroyAction!!");
            var queryBuilder = new EntityQueryBuilder(Allocator.Temp).WithAll<PlayerCtrlData>();
            EntityQuery entityQuery = state.GetEntityQuery(queryBuilder);
            var rsArray = entityQuery.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < rsArray.Length; i++)
            {
                state.EntityManager.DestroyEntity(rsArray[i]); 
            }
            rsArray.Dispose();
        }
    }
}