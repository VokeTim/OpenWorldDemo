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