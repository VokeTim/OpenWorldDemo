using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.InputSystem;

namespace OpenWorld.System
{
    public class SystemControl
    {

        public InputActionMap actions;

        /// <summary>
        /// ��ʼ��InputSystem������InputAction
        /// </summary>
        public void InitControlSystem()
        {
            actions = new InputActionMap();
            // ��ȡ��ǰ����
            Assembly assembly = Assembly.GetExecutingAssembly();
            // ʹ�÷����ȡ���д���InputSystemLoadOperationAttribute����
            List<Type> typesWithReflectableAttribute = assembly.GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(InputSystemLoadOperationAttribute), true).Any()).ToList();
            foreach (Type type in typesWithReflectableAttribute)
            {
                // ��ȡInputAction������
                var actionName = type.GetCustomAttribute<InputSystemLoadOperationAttribute>().InputActionName;
                // ʵ��������
                object instance = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("SetInputAction");
                methodInfo.Invoke(instance, new object[] { actions, actionName });
            }
        }

        public InputAction GetInputActionByActionName(InputActionMap actions, string InputActionName) 
        {
            InputAction action = actions.FindAction(InputActionName);
            return action;
        }
    }
}