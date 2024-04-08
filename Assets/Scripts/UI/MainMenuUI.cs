using OpenWorld.Config.UI;
using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MainMenuUI : MonoBehaviour
    {

        public UIStyleConfig MainMenuConfig;

        public float LabelHeight = 35;

        public int LableFontSize = 25;

        #region UICtrlData
         int WindowId = 0;
        #endregion

        #region xml控制
        private string xmlPath = Application.dataPath + "/Res/UI/MainMenu.xml";
        private XmlDocument xml;
        #endregion

        public static Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // 灰色背景，半透明

        private void Start()
        {
            // 加载主菜单的配置文件
            xml = new XmlDocument();
            xml.Load(xmlPath);
            UIConstansConfig.MainMenuConfig = MainMenuConfig;
        }

        private void OnGUI()
        {
            //TODO: 开启菜单时禁用移动和视角变化且显示鼠标，关闭菜单时启用移动和视角变化且隐藏鼠标
            //if (GameManager.Instance.IsShowMenu)
            //{
            //    GUI.Box(new Rect(10, 10, 500, 490), "Main Menu");
            //}
            XMLTools.TraverseNodes(xml.DocumentElement);
        }
    }
}