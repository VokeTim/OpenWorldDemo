using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MainMenuUI : MonoBehaviour
    {

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
        }

        private void OnGUI()
        {
            //GameManager.Instance.UISystem.LoadGUISkin();
            //if (GameManager.Instance.DisplayWindow == IsDisplayWindow.Block)
            //{
            //    XMLTools.TraverseNodes(xml.DocumentElement);
            //}
        }
    }
}