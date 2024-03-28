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
        /// ��ʼ��InputSystem������InputAction
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
        /// ��������InputSystem�е�����InputAction
        /// </summary>
        public void OnEnabledAllInputActions() 
        {
            foreach (BaseInputAction action in inputActions) 
            {
                action.InputActionImpl.OnEnabled();
            }
        }

        /// <summary>
        /// �ر�����InputSystem�е�����InputAction
        /// </summary>
        public void OnDisabledAllInputActions() 
        {
            foreach (BaseInputAction action in inputActions) 
            {
                action.InputActionImpl.OnDisabled();
            }
        }

        /// <summary>
        /// ����InputSystem�е�ĳ�����͵�InputAction�ļ���
        /// </summary>
        /// <typeparam name="T">InputAction������</typeparam>
        /// <returns>InputAction�ļ���</returns>
        public IEnumerable<BaseInputAction> SearchInputAction<T>() where T : BaseInputAction
        {
            if (inputActions == null || inputActions.Count == 0) return null;
            return inputActions.OfType<T>();
        }
    }
}