using Unity.Entities;

namespace OpenWorld.DOTS.PlayerControl
{
    public struct PlayerMoveInputData : IComponentData
    {
        public float AxisX;
        public float AxisY;
    }
}
