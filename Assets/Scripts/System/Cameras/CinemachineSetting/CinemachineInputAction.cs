using Cinemachine;
using UnityEngine;

namespace OpenWorld.System
{
    public class CinemachineInputAction : MonoBehaviour, AxisState.IInputAxisProvider
    {
        public float GetAxisValue(int axis)
        {
            if (!Cursor.visible)
            {
                if (axis == 0)
                {
                    return GameManager.CameraMoveInput.x;
                }
                if (axis == 1)
                {
                    return GameManager.CameraMoveInput.y;
                }
            }
            return 0;
        }
    }
}