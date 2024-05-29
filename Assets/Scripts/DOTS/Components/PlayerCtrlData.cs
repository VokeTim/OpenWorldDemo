using Unity.Entities;
using Unity.Mathematics;

namespace OpenWorld.DOTS.Commponent
{
    public struct PlayerCtrlData : IComponentData
    {
        // �ƶ��ٶ�
        public double moveSpeed;

        // �ƶ�����
        public float3 moveDir;

        // ���x�ᷴ���ƶ�
        public bool xAxisInvert;

        // ���y�ᷴ���ƶ�
        public bool yAxisInvert;

        // ����ƶ�����
        public float2 cameraMoveInput;

        // ���������
        public double mouseSensitivity;

        public bool isOpenMainMenu;
    }
}
