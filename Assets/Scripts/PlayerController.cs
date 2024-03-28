using UnityEngine;

namespace OpenWorld
{
    public class PlayerController : MonoBehaviour
    {
        private float moveSpeed;

        public float GetMoveSpeed { get { return moveSpeed; } }

        private void Awake()
        {
            moveSpeed = 5.0f;
        }
    }
}
