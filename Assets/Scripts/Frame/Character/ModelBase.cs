using UnityEngine;

namespace OpenWorld.Framework.StateMachine
{
    public class ModelBase : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        public Animator Animator { get => animator; }
    }
}