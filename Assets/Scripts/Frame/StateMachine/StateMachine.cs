using System;
using System.Collections.Generic;

namespace OpenWorld.Framework.StateMachine
{
    public interface IStateMachineOwner { }

    /// <summary>
    /// 状态机类
    /// </summary>
    public class StateMachine
    {
        private IStateMachineOwner owner;

        private Dictionary<Type, StateBase> statDic = new Dictionary<Type, StateBase>();

        private StateBase currentState;

        public Type CurrentStateType { get => currentState.GetType(); }

        public bool HasState { get => currentState != null; }

        public StateBase CurrentState { get => currentState; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="owner"></param>
        public void Init(IStateMachineOwner owner) 
        {
            this.owner = owner;
        }

        public bool ChangeState<T>(bool reCurrentState = false) where T : StateBase, new() 
        {
            // 状态一致并且不需要刷新状态，则不许要进行切换
            if (HasState && CurrentStateType == typeof(T) && !reCurrentState) return false;

            // 退出当前状态
            if (currentState != null) 
            {
                currentState.Exit();
                GameManager.Instance.RemoveUpdateListener(currentState.Update);
                GameManager.Instance.RemoveLateUpdateListener(currentState.LateUpdate);
                GameManager.Instance.RemoveFixedUpdateListener(currentState.FixedUpdate);
            }

            currentState = GetState<T>();
            currentState.Enter();
            GameManager.Instance.AddUpdateListener(currentState.Update);
            GameManager.Instance.AddLateUpdateListener(currentState.LateUpdate);
            GameManager.Instance.AddFixedUpdateListener(currentState.FixedUpdate);
            return false;
        }

        private StateBase GetState<T>() where T : StateBase, new() 
        {
            Type type = typeof(T);
            // 如果字典中缓存不存在
            if (!statDic.TryGetValue(type, out StateBase state)) 
            {
                state = new T();
                state.Init(owner);
                statDic.Add(type, state);
            }

            return state;
        }

        /// <summary>
        /// 停止工作，释放资源
        /// </summary>
        public void Stop() 
        {
            currentState.Exit();
            GameManager.Instance.RemoveUpdateListener(currentState.Update);
            GameManager.Instance.RemoveLateUpdateListener(currentState.LateUpdate);
            GameManager.Instance.RemoveFixedUpdateListener(currentState.FixedUpdate);
            currentState = null;

            foreach (var item in statDic.Values) 
            {
                item.Uninit();
            }
            statDic.Clear();
        }
    }
}