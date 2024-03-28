using OpenWorld.System;
using OpenWorld.System.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        [HideInInspector]
        public SystemControl systemControl;

        public Vector2 CameraMoveInput;

        public GameObject PlayerController;

        public Vector3 PlayerMove;

        public bool IsShowMenu = false;

        public InputAction GetPlayerMoveAction() 
        {
            InputAction playerInputAction = null;
            IEnumerable<BaseInputAction> moveInputActions = systemControl.SearchInputAction<PlayerMoveInputAction>();
            foreach (BaseInputAction action in moveInputActions) 
            {
                playerInputAction = action.InputActionImpl.GetInputAction();
            }
            return playerInputAction; 
        }

        public InputAction GetMenuCtrlInputAction() 
        {
            InputAction menuCtrlInputAction = null;
            IEnumerable<BaseInputAction> menuCtrlInputActions = systemControl.SearchInputAction<MenuCtrlInputAction>();
            foreach (BaseInputAction action in menuCtrlInputActions) 
            {
                menuCtrlInputAction = action.InputActionImpl.GetInputAction();
            }
            return menuCtrlInputAction;
        }

        public Vector2 GetCameraMoveAction() 
        { 
            IEnumerable<BaseInputAction> cameraCtrlInputAction = systemControl.SearchInputAction<CameraMoveInputAction>();
            foreach (BaseInputAction action in cameraCtrlInputAction) 
            {
                CameraMoveInput = action.InputActionImpl.GetInputAction().ReadValue<Vector2>();
            }
            return CameraMoveInput;
        }

        private void Awake()
        {
            Init();
            CameraMoveInput = Vector2.zero;
            systemControl = new SystemControl();
            systemControl.InitInputSystem();
        }

        private void OnEnable()
        {
            systemControl.OnEnabledAllInputActions();
        }

        private void Start()
        {
            //Cursor.visible = false;
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
