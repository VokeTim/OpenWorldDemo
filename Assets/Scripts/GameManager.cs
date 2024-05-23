using OpenWorld.System;
using OpenWorld.System.UI;
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
            //SetIsDisplayWindow(IsDisplayWindow.None);
            UISystem = new UISystem();
        }

        private void OnEnable()
        {
            systemControl.actions.Enable();
        }

        private void Start()
        {

        }

        private void Update()
        {
        }

        private void OnDisable()
        {
            systemControl.actions.Disable();
        }

    }
}
