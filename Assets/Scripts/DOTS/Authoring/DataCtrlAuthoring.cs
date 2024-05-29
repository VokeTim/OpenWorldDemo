using OpenWorld.DOTS.Commponent;
using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.Authoring
{

    public class DataCtrlAuthoring : MonoBehaviour
    {
        public class DataCtrlBaker : Baker<DataCtrlAuthoring>
        {
            public override void Bake(DataCtrlAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                var DataCtrl = new PlayerCtrlData
                {
                    moveSpeed = 0,
                    moveDir = new Unity.Mathematics.float3(0, 0, 0),
                    xAxisInvert = false,
                    yAxisInvert = false,
                    cameraMoveInput = new Unity.Mathematics.float2(0, 0),
                    mouseSensitivity = 1,
                    isOpenMainMenu = false
                };
                AddComponent(entity, DataCtrl);
            }
        }
    }
}