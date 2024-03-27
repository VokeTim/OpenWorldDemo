using UnityEngine;

namespace OpenWorld
{
    public class PlayerController : MonoBehaviour
    {
        private float moveSpeed;

        public static Vector3 moveDir;

        public float GetMoveSpeed { get { return moveSpeed; } }

        private void Awake()
        {
            moveSpeed = 5.0f;
            moveDir = Vector3.zero;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            transform.position += moveDir;
        }

    }
}
