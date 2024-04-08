using OpenWorld.System;
using OpenWorld.System.InputSystem;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld
{
    // 是否展示窗口
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
                    // 开启移动输入               
                    foreach (BaseInputAction moveAction in moveInputActions) 
                    {
                        moveAction.InputActionImpl.OnEnabled();
                    }
                    // 开启视角移动输入                
                    foreach (BaseInputAction cameraCtrlAction in cameraCtrlInputAction) 
                    {
                        cameraCtrlAction.InputActionImpl.OnEnabled();
                    }
                    // 开启攻击输入
                    foreach (BaseInputAction attackCtrlAction in attackCtrlInputAction) 
                    {
                        attackCtrlAction.InputActionImpl.OnEnabled();
                    }
                    // 隐藏鼠标
                    Cursor.visible = false;
                    break;
                case IsDisplayWindow.Block:
                    // 关闭移动输入
                    foreach (BaseInputAction moveAction in moveInputActions)
                    {
                        moveAction.InputActionImpl.OnDisabled();
                    }
                    // 关闭视角移动输入
                    foreach (BaseInputAction cameraCtrlAction in cameraCtrlInputAction)
                    {
                        cameraCtrlAction.InputActionImpl.OnDisabled();
                    }
                    // 关闭攻击输入
                    foreach (BaseInputAction attackCtrlAction in attackCtrlInputAction)
                    {
                        attackCtrlAction.InputActionImpl.OnDisabled();
                    }
                    // 显示鼠标
                    //TODO: 将鼠标位置重置到游戏画面正中央
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
