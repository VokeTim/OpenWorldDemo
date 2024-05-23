using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    public class MenuCtrlInputAction : BaseInputAction
    {
        public override InputAction SetInputAction(InputActionMap actionMap, string actionName)
        {
            InputAction menuInputAction=actionMap.AddAction(actionName);
            menuInputAction.AddBinding("<Keyboard>/escape");
            menuInputAction.performed += OnButtonClick;
            return menuInputAction;
        }

        private void OnButtonClick(InputAction.CallbackContext context)
        {
            // ��������ʾ�������ƶ�������ӽ����� �رպ�������������ƶ�������ӽ�����
            var currentState = GameManager.Instance.DisplayWindow;
            if (currentState == IsDisplayWindow.None)
            {
                //TODO: ��ȡ����ʾ��ʱ����Ҫ���ȡ��ѡ��Ч���Ĺ��ܣ����磺ѡ��һ�������
                //GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.Block);
            }
            else
            {
                //GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.None);
            }
        }
    }
}