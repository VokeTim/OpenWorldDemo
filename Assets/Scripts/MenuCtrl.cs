using OpenWorld.DOTS.Commponent;
using OpenWorld.DOTS.Utils;
using System;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MenuCtrl : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenuComponent;

        // �������˵��¼�
        public Action OpenMainMenuAction;

        // �ر����˵��¼�
        public Action CloseMainMenuAction;

        private void Start()
        {
            InitMenuCtrl();
        }

        /// <summary>
        /// ��ʼ���˵�����
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
        }

        /// <summary>
        /// �ر����˵�չʾ
        /// </summary>
        public void CloseMainMenuDisplay()
        {
            // �ر����˵���ʾ
            mainMenuComponent.SetActive(false);
            // ������������
            GameManager.Instance.systemControl.actions.FindAction("Attack").Enable();
        }

        /// <summary>
        /// �򿪲˵�չʾ
        /// </summary>
        public void OpenMainMenuDisplay()
        {
            // �������˵���ʾ
            mainMenuComponent.SetActive(true);
            // �رչ�������
            GameManager.Instance.systemControl.actions.FindAction("Attack").Disable();
        }
    }
}