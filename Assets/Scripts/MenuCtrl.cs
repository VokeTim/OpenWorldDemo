using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld.UI
{
    public class MenuCtrl : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenuComponent;

        // 开启主菜单事件
        public Action OpenMainMenuAction;

        // 关闭主菜单事件
        public Action CloseMainMenuAction;

        private void Start()
        {
            InitMenuCtrl();
        }

        /// <summary>
        /// 初始化菜单控制
        /// </summary>
        private void InitMenuCtrl()
        {
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                playerData.isOpenMainMenu = false;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
            OpenMainMenuAction += OpenMainMenuDisplay;
            CloseMainMenuAction += CloseMainMenuDisplay;
            OpenMainMenuAction += InitCurrentPositionInScreen;
            CloseMainMenuAction += InitCurrentPositionInScreen;
        }

        /// <summary>
        /// 关闭主菜单展示
        /// </summary>
        public void CloseMainMenuDisplay()
        {
            // 隐藏鼠标
            Cursor.visible = false;
            // 关闭主菜单显示
            mainMenuComponent.SetActive(false);
            // 开启攻击输入
            GameManager.Instance.systemControl.actions.FindAction("Attack").Enable();
        }

        /// <summary>
        /// 打开菜单展示
        /// </summary>
        public void OpenMainMenuDisplay()
        {
            Cursor.visible = true;
            // 开启主菜单显示
            mainMenuComponent.SetActive(true);
            // 关闭攻击输入
            GameManager.Instance.systemControl.actions.FindAction("Attack").Disable();
        }

        public void InitCurrentPositionInScreen() 
        {
            var mouseInitx = Screen.width / 2;
            var mouseInity = Screen.height / 2;
            Mouse.current.WarpCursorPosition(new Vector2(mouseInitx, mouseInity));
        }
    }
}