using Unity.Entities;
using UnityEngine;

namespace OpenWorld.DOTS.PlayerControl
{
    partial struct PlayerInputMoveJob : IJobEntity
    {
        public float deltaTime;

        void Execute(MovingAspect movingAspect) 
        {
            Vector2 playerInput = GameManager.Instance.GetMoveAction().ReadValue<Vector2>();
            Vector3 moveDir = new Vector3(playerInput.x, 0, playerInput.y);
            movingAspect.InputActionsMove(deltaTime, moveDir);
        }
    }
}