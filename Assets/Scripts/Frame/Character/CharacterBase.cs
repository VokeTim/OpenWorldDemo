using UnityEngine;

namespace OpenWorld.Framework.StateMachine
{
    public class CharacterBase : MonoBehaviour, IStateMachineOwner
    {
        [SerializeField] protected ModelBase model;

        public ModelBase Model { get => model; }

        public Transform ModelTransform => Model.transform;

        public StateMachine stateMachine { get; protected set; }

        public virtual void Init() 
        {
            stateMachine = new StateMachine();
            stateMachine.Init(this);
        }

        #region ¶¯»­²¥·Å
        private string currentAnimationName;

        public void PlayAnimation(string animationName, bool reState = true, float fixedTransitionDuration = 0.25f) 
        {
            if (currentAnimationName == animationName && !reState) 
            {
                return;
            }

            currentAnimationName = animationName;
            model.Animator.CrossFadeInFixedTime(animationName, fixedTransitionDuration);
        }
        #endregion
    }
}