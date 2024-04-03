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
            //TODO: �����͹رյĹ���ϸ�� ��������ʾ�������ƶ�������ӽ����� �رպ�������������ƶ�������ӽ�����
            Cursor.visible = !Cursor.visible;
            GameManager.Instance.IsShowMenu = !GameManager.Instance.IsShowMenu;
        }
    }
}