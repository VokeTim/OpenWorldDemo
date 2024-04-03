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
