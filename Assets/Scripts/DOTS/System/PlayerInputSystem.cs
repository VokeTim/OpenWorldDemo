using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(OpenWorldGroup))]
    [BurstCompile]
    public partial struct PlayerInputSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        //[BurstCompile]  
        public void OnUpdate(ref SystemState state) 
        {
            float deltatime = SystemAPI.Time.DeltaTime;
            var PlayerMoveInputjob = new PlayerInputMoveJob
            {
                deltaTime = deltatime,
            };
            PlayerMoveInputjob.Schedule();
            var CameraCtrlJob = new CameraMoveJob();
            CameraCtrlJob.Schedule();
        }
    }
}
