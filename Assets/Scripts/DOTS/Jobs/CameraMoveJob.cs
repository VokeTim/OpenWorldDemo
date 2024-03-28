using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    partial struct CameraMoveJob : IJobEntity
    {
        void Execute(CameraControlData cameraControlData) 
        {
            Vector2 cameraMoveCtrl = GameManager.Instance.GetCameraMoveAction();
            float x = cameraControlData.xAxisInvert ? -cameraMoveCtrl.x : cameraMoveCtrl.x;
            float y = cameraControlData.yAxisInvert ? -cameraMoveCtrl.y : cameraMoveCtrl.y;
            GameManager.Instance.CameraMoveInput = new Vector2(x, y);
        }
    }
}