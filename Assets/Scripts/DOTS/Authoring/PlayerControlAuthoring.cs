using OpenWorld.System;
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
                CinemachineInputAction customCinemachineCtrlInput = GameObject.FindGameObjectWithTag("CinemachineCamera").GetComponent<CinemachineInputAction>();
                var CameraCtrlData = new CameraControlData
                {
                    xAxisInvert = customCinemachineCtrlInput.xAxisInvert,
                    yAxisInvert = customCinemachineCtrlInput.yAxisInvert
                };
                AddComponent(entity, PlayerMoveSpeedData);
                AddComponent(entity, CameraCtrlData);
            }
        }
    }
}