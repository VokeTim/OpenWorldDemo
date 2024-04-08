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
            action.performed += OnButtonClick;
        }

        public void OnDisabled()
        {
            action.Disable();
        }

        public void OnEnabled()
        {
            action.Enable();
        }

        private void OnButtonClick(InputAction.CallbackContext context)
        {
            // ��������ʾ�������ƶ�������ӽ����� �رպ�������������ƶ�������ӽ�����
            var currentState = GameManager.Instance.DisplayWindow;
            if (currentState == IsDisplayWindow.None)
            {
                GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.Block);
            }
            else 
            {
                GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.None);
            }
        }
    }
}