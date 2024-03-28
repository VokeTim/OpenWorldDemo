using Cinemachine;
using UnityEngine;

namespace OpenWorld.System
{
    public class CinemachineInputAction : MonoBehaviour, AxisState.IInputAxisProvider
    {
        // 在x轴取反
        public bool xAxisInvert = false;

        // 在y轴取反
        public bool yAxisInvert = false;

        public float GetAxisValue(int axis)
        {
            if (!Cursor.visible)
            {
                if (axis == 0)
                {
                    return GameManager.Instance.CameraMoveInput.x;
                }
                if (axis == 1)
                {
                    return GameManager.Instance.CameraMoveInput.y;
                }
            }
            return 0;
        }
    }
}