namespace OpenWorld.Framework.StateMachine
{
    /// <summary>
    /// ״̬����
    /// </summary>
    public abstract class StateBase
    {
        /// <summary>
        /// ��ʼ��
        /// ֻ��״̬����ʱִ��һ��
        /// </summary>
        /// <param name="owner"></param>
        public virtual void Init(IStateMachineOwner owner) { }

        /// <summary>
        /// ����ʼ���������ͷ���Դ
        /// </summary>
        public virtual void Uninit() { }

        /// <summary>
        /// ״̬���룬ÿ����һ�ξ��л�һ��
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// ״̬�˳���ÿ���˳���ִ��һ��
        /// </summary>
        public virtual void Exit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void LateUpdate() { }
    }
}