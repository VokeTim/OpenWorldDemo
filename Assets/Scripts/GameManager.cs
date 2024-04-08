using OpenWorld.System;
using OpenWorld.System.InputSystem;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld
{
    // �Ƿ�չʾ����
    public enum IsDisplayWindow
    {
        None,
        Block
    }

    public class GameManager : SingleMono<GameManager>
    {
        [HideInInspector]
        public SystemControl systemControl;

        public Vector2 CameraMoveInput;

        public GameObject PlayerController;

        public Vector3 PlayerMove;

        public bool IsShowMenu = false;

        public IsDisplayWindow DisplayWindow { get; private set; } 

        public Vector2 GetPlayerMoveDir() 
        {
            Vector2 moveDir = Vector2.zero;
            IEnumerable<BaseInputAction> moveInputActions = systemControl.SearchInputAction<PlayerMoveInputAction>();
            foreach (BaseInputAction action in moveInputActions)
            {
                moveDir = action.InputActionImpl.GetReadValue<Vector2>();
            }
            return moveDir;
        }

        public Vector2 GetCameraMoveAction() 
        { 
            IEnumerable<BaseInputAction> cameraCtrlInputAction = systemControl.SearchInputAction<CameraMoveInputAction>();
            foreach (BaseInputAction action in cameraCtrlInputAction) 
            {
                CameraMoveInput = action.InputActionImpl.GetReadValue<Vector2>();
            }
            return CameraMoveInput;
        }

        public void SetIsDisplayWindow(IsDisplayWindow isDisplayWindow) 
        {
            DisplayWindow = isDisplayWindow;
            IEnumerable<BaseInputAction> moveInputActions = systemControl.SearchInputAction<PlayerMoveInputAction>();
            IEnumerable<BaseInputAction> cameraCtrlInputAction = systemControl.SearchInputAction<CameraMoveInputAction>();
            IEnumerable<BaseInputAction> attackCtrlInputAction = systemControl.SearchInputAction<AttackInputAction>();
            switch (DisplayWindow) 
            {
                case IsDisplayWindow.None:
                    // �����ƶ�����               
                    foreach (BaseInputAction moveAction in moveInputActions) 
                    {
                        moveAction.InputActionImpl.OnEnabled();
                    }
                    // �����ӽ��ƶ�����                
                    foreach (BaseInputAction cameraCtrlAction in cameraCtrlInputAction) 
                    {
                        cameraCtrlAction.InputActionImpl.OnEnabled();
                    }
                    // ������������
                    foreach (BaseInputAction attackCtrlAction in attackCtrlInputAction) 
                    {
                        attackCtrlAction.InputActionImpl.OnEnabled();
                    }
                    // �������
                    Cursor.visible = false;
                    break;
                case IsDisplayWindow.Block:
                    // �ر��ƶ�����
                    foreach (BaseInputAction moveAction in moveInputActions)
                    {
                        moveAction.InputActionImpl.OnDisabled();
                    }
                    // �ر��ӽ��ƶ�����
                    foreach (BaseInputAction cameraCtrlAction in cameraCtrlInputAction)
                    {
                        cameraCtrlAction.InputActionImpl.OnDisabled();
                    }
                    // �رչ�������
                    foreach (BaseInputAction attackCtrlAction in attackCtrlInputAction)
                    {
                        attackCtrlAction.InputActionImpl.OnDisabled();
                    }
                    // ��ʾ���
                    //TODO: �����λ�����õ���Ϸ����������
                    Cursor.visible = true;
                    break;
            }
        }

        private void Awake()
        {
            Init();
            CameraMoveInput = Vector2.zero;
            systemControl = new SystemControl();
            systemControl.InitInputSystem();
            DisplayWindow = IsDisplayWindow.None;
            SetIsDisplayWindow(IsDisplayWindow.None);
        }

        private void OnEnable()
        {
            systemControl.OnEnabledAllInputActions();
        }

        private void Start()
        {

        }

        private void Update()
        {
            PlayerController.transform.position += PlayerMove;
        }

        private void OnDisable()
        {
            systemControl.OnDisabledAllInputActions();
        }

    }
}
