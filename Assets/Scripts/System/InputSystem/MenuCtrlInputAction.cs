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
            // ��������ʾ�������ƶ�������ӽ����� �رպ�������������ƶ�������ӽ�����
            bool menuOpenState = getMenuOpenState();
            if (menuOpenState)
            {
                // �˵�����״̬�Ǵ� -> �رղ˵�
                closeMenuOpenState();
            }
            else 
            {
                // �˵�����״̬�ǹر� -> ��ʾ�˵�
                openMenuOpenState();
            }
        }

        /// <summary>
        /// ��DOTS�л�ȡ�˵�������״̬
        /// </summary>
        /// <returns>bool (true���˵�������false���˵��ر�)</returns>
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
        /// �رղ˵����޸���˵���ص�����
        /// </summary>
        private void closeMenuOpenState() 
        {
            GameManager.Instance.menuCtrlComponent.CloseMainMenuAction?.Invoke();
            // �޸�DOTS�е�����
            SwitchDotsCtrlData(false);
        }

        /// <summary>
        /// �򿪲˵����޸���˵���ص�����
        /// </summary>
        private void openMenuOpenState() 
        {
            GameManager.Instance.menuCtrlComponent.OpenMainMenuAction?.Invoke();
            // �޸�DOTS�е�����
            SwitchDotsCtrlData(true);
        }

        /// <summary>
        /// �л�DOTS�еĲ˵���������
        /// </summary>
        /// <param name="switchFlag">�л�����</param>
        private void SwitchDotsCtrlData(bool switchFlag) 
        {
            // �޸�DOTS�е�����
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