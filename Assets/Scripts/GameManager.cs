using OpenWorld.System;
using OpenWorld.UI;
using System;
using UnityEngine;

namespace OpenWorld
{
    public class GameManager : SingleMono<GameManager>
    {
        private Action updateAction;
        private Action lateUpdateAction;
        private Action fixedUpdateAction;

        [HideInInspector]
        public SystemControl systemControl;

        [SerializeField]
        private GameObject menuCtrl;

        [HideInInspector]
        public MenuCtrl menuCtrlComponent;

        public float PlayerVelocity; 

        public bool IsShowMenu = false;


        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            systemControl.actions.Enable();
        }

        protected override void Init()
        {
            base.Init();
            systemControl = new SystemControl();
            systemControl.InitControlSystem();
            menuCtrlComponent = menuCtrl.GetComponent<MenuCtrl>();
            menuCtrlComponent.CloseMainMenuDisplay();
            // IMECompositionMode:
            // Auto 当有一个输入框被选中时才会启动输入法
            // On 无论何时都会启用输入法
            // Off 无论何时都不会启用输入法
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
