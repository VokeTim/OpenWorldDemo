using OpenWorld.System;
using OpenWorld.System.UI;
using System;
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
        private Action updateAction;
        private Action lateUpdateAction;
        private Action fixedUpdateAction;

        [HideInInspector]
        public SystemControl systemControl;

        [HideInInspector]
        public UISystem UISystem;     

        public float PlayerVelocity; 

        public bool IsShowMenu = false;

        public IsDisplayWindow DisplayWindow { get; private set; } 

        private void Awake()
        {
            Init();
            systemControl = new SystemControl();
            systemControl.InitInputSystem();
            DisplayWindow = IsDisplayWindow.None;
        }

        private void OnEnable()
        {
            systemControl.actions.Enable();
        }

        private void Start()
        {
            // 防止非输入状态下触发输入法 
            Input.imeCompositionMode = IMECompositionMode.Auto;
        }

        private void Update()
        {
            updateAction?.Invoke();
        }

        private void LateUpdate()
        {
            lateUpdateAction?.Invoke();
        }

        private void FixedUpdate()
        {
            fixedUpdateAction?.Invoke();
        }

        private void OnDisable()
        {
            systemControl.actions.Disable();
        }

        public void AddUpdateListener(Action action) 
        {
            updateAction += action;
        }

        public void RemoveUpdateListener(Action action)
        {
            updateAction -= action;
        }

        public void AddLateUpdateListener(Action action) 
        {
            lateUpdateAction += action;
        }

        public void RemoveLateUpdateListener(Action action) 
        {
            lateUpdateAction -= action;
        }

        public void AddFixedUpdateListener(Action action) 
        {
            fixedUpdateAction += action;
        }

        public void RemoveFixedUpdateListener(Action action) 
        {
            fixedUpdateAction -= action;
        }
    }
}
