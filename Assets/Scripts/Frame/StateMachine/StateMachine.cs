using System;
using System.Collections.Generic;

namespace OpenWorld.Framework.StateMachine
{
    public interface IStateMachineOwner { }

    /// <summary>
    /// ״̬����
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
        /// ��ʼ��
        /// </summary>
        /// <param name="owner"></param>
        public void Init(IStateMachineOwner owner) 
        {
            this.owner = owner;
        }

        public bool ChangeState<T>(bool reCurrentState = false) where T : StateBase, new() 
        {
            // ״̬һ�²��Ҳ���Ҫˢ��״̬������Ҫ�����л�
            if (HasState && CurrentStateType == typeof(T) && !reCurrentState) return false;

            // �˳���ǰ״̬
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
            // ����ֵ��л��治����
            if (!statDic.TryGetValue(type, out StateBase state)) 
            {
                state = new T();
                state.Init(owner);
                statDic.Add(type, state);
            }

            return state;
        }

        /// <summary>
        /// ֹͣ�������ͷ���Դ
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