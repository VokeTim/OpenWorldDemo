using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(OpenWorldGroup))]
    [BurstCompile]
    public partial struct PlayerMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.EntityManager.AddComponent<PlayerMoveInputData>(state.SystemHandle);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        //[BurstCompile]  
        public void OnUpdate(ref SystemState state) 
        {
            SystemAPI.SetComponent(state.SystemHandle, new PlayerMoveInputData
            {
                AxisX = GameManager.Instance.GetMoveAction().ReadValue<Vector2>().x,
                AxisY = GameManager.Instance.GetMoveAction().ReadValue<Vector2>().y
            });
            float deltatime = SystemAPI.Time.DeltaTime;
            var playerInputData = state.EntityManager.GetComponentData<PlayerMoveInputData>(state.SystemHandle);
            Vector3 moveDir = new Vector3(playerInputData.AxisX, 0, playerInputData.AxisY);
            foreach (MovingAspect movingAspect in SystemAPI.Query<MovingAspect>())
            {
                movingAspect.InputActionsMove(deltatime, moveDir);
                GameManager.Instance.FollowTarget = (Vector3)movingAspect.GetLocalPosition();
            }        
        }
    }
}
