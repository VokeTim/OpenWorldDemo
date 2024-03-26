using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    public class PlayerControlAuthoring : MonoBehaviour
    {
        public float moveSpeed = 5.0f;

        public class PlayerControlDataBaker : Baker<PlayerControlAuthoring>
        {
            public override void Bake(PlayerControlAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                var PlayerMoveSpeedData = new PlayerData
                {
                    moveSpeed = authoring.moveSpeed
                };
                AddComponent(entity, PlayerMoveSpeedData);
            }
        }
    }
}