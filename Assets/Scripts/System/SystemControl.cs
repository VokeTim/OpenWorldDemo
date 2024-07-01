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
        /// 初始化InputSystem的所有InputAction
        /// </summary>
        public void InitControlSystem()
        {
            actions = new InputActionMap();
            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            // 使用反射获取所有带有InputSystemLoadOperationAttribute的类
            List<Type> typesWithReflectableAttribute = assembly.GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(InputSystemLoadOperationAttribute), true).Any()).ToList();
            foreach (Type type in typesWithReflectableAttribute)
            {
                // 获取InputAction的名称
                var actionName = type.GetCustomAttribute<InputSystemLoadOperationAttribute>().InputActionName;
                // 实例化对象
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