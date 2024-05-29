using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using UnityEngine;

namespace OpenWorld.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        public void OnCloseButtonClick()
        {
            GameManager.Instance.menuCtrlComponent.CloseMainMenuAction?.Invoke();
            // 修改DOTS中的数据
            var entityArray = DOTSUtils.QueryEntitiesArrInGameObject<PlayerCtrlData>();
            foreach (var entity in entityArray)
            {
                var playerData = DOTSUtils.entityManager.GetComponentData<PlayerCtrlData>(entity);
                playerData.isOpenMainMenu = false;
                DOTSUtils.entityManager.SetComponentData(entity, playerData);
            }
            DOTSUtils.DisposeEntitiesArray(entityArray);
        }
    }
}