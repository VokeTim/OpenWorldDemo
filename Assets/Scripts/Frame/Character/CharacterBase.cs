using UnityEngine;

namespace OpenWorld.Framework.StateMachine
{
    public class CharacterBase : MonoBehaviour, IStateMachineOwner
    {
        [SerializeField] 
        protected ModelBase model;

        [SerializeField]
        protected CharacterController characterController;

        public CharacterController CharacterController { get { return characterController; } }

        public ModelBase Model { get => model; }

        public Transform ModelTransform => Model.transform;

        public StateMachine stateMachine { get; protected set; }

        public float gravity = -9.8f;

        public virtual void Init() 
        {
            stateMachine = new StateMachine();
            stateMachine.Init(this);
        }

        #region 动画播放
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

        /// <summary>
        /// 检查是否落地
        /// </summary>
        /// <returns></returns>
        public bool CheckLandingTools(float currentdistance) 
        {
            bool rs = false;
            float distanceMin = characterController.height / 2 + characterController.radius - characterController.skinWidth;
            // 浮点数比较可能会出现预期外的结果所以需要进行差值运算
            //TODO: 添加一个工具类完善浮点数的比较
            rs = Mathf.Abs(distanceMin - currentdistance) < 0.00001f;
            return rs;
        }
    }
}