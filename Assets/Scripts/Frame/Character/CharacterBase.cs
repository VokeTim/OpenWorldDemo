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

        #region ��������
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
        /// ����Ƿ����
        /// </summary>
        /// <returns></returns>
        public bool CheckLandingTools(float currentdistance) 
        {
            bool rs = false;
            float distanceMin = characterController.height / 2 + characterController.radius - characterController.skinWidth;
            // �������ȽϿ��ܻ����Ԥ����Ľ��������Ҫ���в�ֵ����
            //TODO: ���һ�����������Ƹ������ıȽ�
            rs = Mathf.Abs(distanceMin - currentdistance) < 0.00001f;
            return rs;
        }
    }
}