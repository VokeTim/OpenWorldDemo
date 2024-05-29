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
            systemControl = new SystemControl();
            systemControl.InitInputSystem();
            menuCtrlComponent=menuCtrl.GetComponent<MenuCtrl>();
            menuCtrlComponent.CloseMainMenuDisplay();
        }

        private void OnEnable()
        {
            systemControl.actions.Enable();
        }

        private void Start()
        {
            //TODO: 添加可控接口控制，比如在选中某个输入框或者打开聊天框的时候能够开启输入法
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
