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
            // 开启后显示鼠标禁用移动输入和视角输入 关闭后隐藏鼠标启用移动输入和视角输入
            var currentState = GameManager.Instance.DisplayWindow;
            if (currentState == IsDisplayWindow.None)
            {
                //TODO: 在取消显示的时候需要添加取消选中效果的功能（例如：选中一个输入框）
                //GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.Block);
            }
            else
            {
                //GameManager.Instance.SetIsDisplayWindow(IsDisplayWindow.None);
            }
        }
    }
}