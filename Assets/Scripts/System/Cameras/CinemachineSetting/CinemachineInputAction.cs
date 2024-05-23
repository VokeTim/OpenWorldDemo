using Cinemachine;
using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
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
            Vector2 axisInput = Vector2.zero;
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var cameraControlData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                axisInput = cameraControlData.cameraMoveInput;
            }
            entityArray.Dispose();
            Debug.Log(axisInput);
            if (!Cursor.visible)
            {
                if (axis == 0)
                {
                    return axisInput.x;
                }
                if (axis == 1)
                {
                    return axisInput.y;
                }
            }
            return 0;
        }

        private void Start()
        {
            SetCimachineAxisInvert(xAxisInvert, yAxisInvert);
        }

        private void SetCimachineAxisInvert(bool xAxisInvert, bool yAxisInvert)
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var cameraControlData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                cameraControlData.xAxisInvert = xAxisInvert;
                cameraControlData.yAxisInvert = yAxisInvert;
                DOTSUtils.entityManager.SetComponentData(entity, cameraControlData);
            }
            entityArray.Dispose();
        }
    }
}