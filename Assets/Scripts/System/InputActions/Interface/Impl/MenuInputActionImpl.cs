using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class MenuInputActionImpl : BaseInputActionImpl, IInputAction
    {
        public MenuInputActionImpl() 
        {
            Init();
        }

        public T GetReadValue<T>() where T : struct
        {
            return action.ReadValue<T>();
        }

        public void Init()
        {
            action = new InputAction();
            action.AddBinding("<Keyboard>/escape");
            action.performed += OnKeyboard;
        }

        public void OnDisabled()
        {
            action.Disable();
        }

        public void OnEnabled()
        {
            action.Enable();
        }

        private void OnKeyboard(InputAction.CallbackContext context)
        {
            //TODO: 开启和关闭的功能细化 开启后显示鼠标禁用移动输入和视角输入 关闭后隐藏鼠标启用移动输入和视角输入
            Cursor.visible = !Cursor.visible;
            GameManager.Instance.IsShowMenu = !GameManager.Instance.IsShowMenu;
        }
    }
}