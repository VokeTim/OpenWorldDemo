using Unity.Burst;
using Unity.Entities;

namespace OpenWorld.DOTS.PlayerControl
{
    //[RequireMatchingQueriesForUpdate]
    //[UpdateInGroup(typeof(OpenWorldGroup))]
    [BurstCompile]
    public partial struct MoveSpeedGroup : ISystem
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
            foreach (MovingAspect movingAspect in SystemAPI.Query<MovingAspect>()) 
            {
                movingAspect.Move(deltatime);
            }
        }
    }
}
