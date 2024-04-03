using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public interface IInputAction
    {
        public void Init();

        public void OnEnabled();

        public void OnDisabled();

        /// <summary>
        /// �����������Ͷ�ȡInputAction������
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <returns>T</returns>
        public T GetReadValue<T>() where T : struct;
    }
}