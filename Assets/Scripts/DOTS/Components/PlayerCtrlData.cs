using Unity.Entities;
using Unity.Mathematics;

namespace OpenWorld.DOTS.Commponent
{
    public struct PlayerCtrlData : IComponentData
    {
        // �ƶ��ٶ�
        public double moveSpeed;

        // �˶�����
        public double moveVelocity;

        // �ƶ�����
        public float3 moveDir;

        // ���x�ᷴ���ƶ�
        public bool xAxisInvert;

        // ���y�ᷴ���ƶ�
        public bool yAxisInvert;

        // ����ƶ�����
        public float2 cameraMoveInput;
    }
}
