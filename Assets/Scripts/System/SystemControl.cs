using OpenWorld.System.InputSystem;
using System.Collections.Generic;
using System.Linq;

namespace OpenWorld.System
{
    public class SystemControl
    {
        private BaseInputAction actions;

        private List<BaseInputAction> inputActions = new List<BaseInputAction>();

        /// <summary>
        /// 初始化InputSystem的所有InputAction
        /// </summary>
        public void InitInputSystem() 
        {
            actions = new PlayerMoveInputAction();
            inputActions.Add(actions);
            actions = new AttackInputAction();
            inputActions.Add(actions);
            actions = new CameraMoveInputAction();
            inputActions.Add(actions);
            actions = new CursorCtrlInputAction();
            inputActions.Add(actions);
        }

        /// <summary>
        /// 开启所有InputSystem中的所有InputAction
        /// </summary>
        public void OnEnabledAllInputActions() 
        {
            foreach (BaseInputAction action in inputActions) 
            {
                action.InputActionImpl.OnEnabled();
            }
        }

        /// <summary>
        /// 关闭所有InputSystem中的所有InputAction
        /// </summary>
        public void OnDisabledAllInputActions() 
        {
            foreach (BaseInputAction action in inputActions) 
            {
                action.InputActionImpl.OnDisabled();
            }
        }

        /// <summary>
        /// 检索InputSystem中的某个类型的InputAction的集合
        /// </summary>
        /// <typeparam name="T">InputAction的类型</typeparam>
        /// <returns>InputAction的集合</returns>
        public IEnumerable<BaseInputAction> SearchInputAction<T>() where T : BaseInputAction
        {
            if (inputActions == null || inputActions.Count == 0) return null;
            return inputActions.OfType<T>();
        }
    }
}