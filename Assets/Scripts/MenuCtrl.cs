using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MenuCtrl : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenuComponent;

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
        }

        /// <summary>
        /// 关闭主菜单展示
        /// </summary>
        public void CloseMainMenuDisplay()
        {
            mainMenuComponent.SetActive(false);
        }

        /// <summary>
        /// 打开菜单展示
        /// </summary>
        public void OpenMainMenuDisplay()
        {
            mainMenuComponent.SetActive(true);
        }
    }
}