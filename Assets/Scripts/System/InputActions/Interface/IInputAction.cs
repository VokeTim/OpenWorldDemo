using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public interface IInputAction
    {
        public void Init();

        public void OnEnabled();

        public void OnDisabled();

        /// <summary>
        /// 根据数据类型读取InputAction的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>T</returns>
        public T GetReadValue<T>() where T : struct;
    }
}