using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MainMenuUI : MonoBehaviour
    {

        #region xml����
        private string xmlPath = Application.dataPath + "/Res/UI/MainMenu.xml";
        private XmlDocument xml;
        #endregion

        public static Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // ��ɫ��������͸��

        private void Start()
        {
            // �������˵��������ļ�
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