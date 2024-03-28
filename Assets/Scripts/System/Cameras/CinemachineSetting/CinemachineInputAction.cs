using Cinemachine;
using UnityEngine;

namespace OpenWorld.System
{
    public class CinemachineInputAction : MonoBehaviour, AxisState.IInputAxisProvider
    {
        // ��x��ȡ��
        public bool xAxisInvert = false;

        // ��y��ȡ��
        public bool yAxisInvert = false;

        public float GetAxisValue(int axis)
        {
            if (!Cursor.visible)
            {
                if (axis == 0)
                {
                    float rs = xAxisInvert ? -GameManager.CameraMoveInput.x : GameManager.CameraMoveInput.x;
                    return rs;
                }
                if (axis == 1)
                {
                    float rs = yAxisInvert ? -GameManager.CameraMoveInput.y : GameManager.CameraMoveInput.y;
                    return rs;
                }
            }
            return 0;
        }
    }
}