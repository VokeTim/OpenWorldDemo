using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine.InputSystem;

namespace OpenWorld.System.InputSystem
{
    [InputSystemLoadOperation("MenuCtrlInput")]
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
            bool menuOpenState = getMenuOpenState();
            if (menuOpenState)
            {
                // 菜单开启状态是打开 -> 关闭菜单
                closeMenuOpenState();
            }
            else 
            {
                // 菜单开启状态是关闭 -> 显示菜单
                openMenuOpenState();
            }
        }

        /// <summary>
        /// 在DOTS中获取菜单开启的状态
        /// </summary>
        /// <returns>bool (true：菜单开启，false：菜单关闭)</returns>
        private bool getMenuOpenState() 
        {
            bool menuOpenState = false;
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                menuOpenState = playerData.isOpenMainMenu;
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
            return menuOpenState;
        }

        /// <summary>
        /// 关闭菜单并修改与菜单相关的数据
        /// </summary>
        private void closeMenuOpenState() 
        {
            GameManager.Instance.menuCtrlComponent.CloseMainMenuAction?.Invoke();
            // 修改DOTS中的数据
            SwitchDotsCtrlData(false);
        }

        /// <summary>
        /// 打开菜单并修改与菜单相关的数据
        /// </summary>
        private void openMenuOpenState() 
        {
            GameManager.Instance.menuCtrlComponent.OpenMainMenuAction?.Invoke();
            // 修改DOTS中的数据
            SwitchDotsCtrlData(true);
        }

        /// <summary>
        /// 切换DOTS中的菜单控制数据
        /// </summary>
        /// <param name="switchFlag">切换数据</param>
        private void SwitchDotsCtrlData(bool switchFlag) 
        {
            // 修改DOTS中的数据
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                playerData.isOpenMainMenu = switchFlag;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}