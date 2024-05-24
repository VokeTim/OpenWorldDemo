namespace OpenWorld.Framework.StateMachine
{
    /// <summary>
    /// 状态基类
    /// </summary>
    public abstract class StateBase
    {
        /// <summary>
        /// 初始化
        /// 只在状态创建时执行一次
        /// </summary>
        /// <param name="owner"></param>
        public virtual void Init(IStateMachineOwner owner) { }

        /// <summary>
        /// 反初始化，用于释放资源
        /// </summary>
        public virtual void Uninit() { }

        /// <summary>
        /// 状态进入，每进入一次就切换一次
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// 状态退出，每次退出就执行一次
        /// </summary>
        public virtual void Exit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void LateUpdate() { }
    }
}