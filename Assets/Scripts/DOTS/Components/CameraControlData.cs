using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    public struct CameraControlData : IComponentData
    {
        public bool xAxisInvert;

        public bool yAxisInvert;
    }
}