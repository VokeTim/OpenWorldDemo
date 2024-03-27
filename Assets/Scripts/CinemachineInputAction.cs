using Cinemachine;
using OpenWorld;
using UnityEngine;

public class CinemachineInputAction : MonoBehaviour, AxisState.IInputAxisProvider
{
    public float GetAxisValue(int axis)
    {
        if (axis == 0)
        {
            return GameManager.CameraMoveInput.x;
        }
        if (axis == 1) 
        {
            return GameManager.CameraMoveInput.y;
        }
        return 0;
    }
}
