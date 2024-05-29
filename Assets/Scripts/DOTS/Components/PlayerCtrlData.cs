using Unity.Entities;
using Unity.Mathematics;

namespace OpenWorld.DOTS.Commponent
{
    public struct PlayerCtrlData : IComponentData
    {
        // 移动速度
        public double moveSpeed;

        // 移动方向
        public float3 moveDir;

        // 相机x轴反向移动
        public bool xAxisInvert;

        // 相机y轴反向移动
        public bool yAxisInvert;

        // 相机移动输入
        public float2 cameraMoveInput;

        // 鼠标灵敏度
        public double mouseSensitivity;

        public bool isOpenMainMenu;
    }
}
