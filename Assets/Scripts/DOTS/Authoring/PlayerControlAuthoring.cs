using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    public class PlayerControlAuthoring : MonoBehaviour
    {
        public class PlayerControlDataBaker : Baker<PlayerControlAuthoring>
        {
            public override void Bake(PlayerControlAuthoring authoring)
            {
                PlayerController playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                float movespeed = playerControler.GetMoveSpeed;
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                var PlayerMoveSpeedData = new PlayerData
                {
                    moveSpeed = movespeed
                };
                AddComponent(entity, PlayerMoveSpeedData);
            }
        }
    }
}