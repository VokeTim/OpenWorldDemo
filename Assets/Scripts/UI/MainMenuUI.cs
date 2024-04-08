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
            UIConstansConfig.MainMenuConfig = MainMenuConfig;
        }

        private void OnGUI()
        {
            //TODO: �����˵�ʱ�����ƶ����ӽǱ仯����ʾ��꣬�رղ˵�ʱ�����ƶ����ӽǱ仯���������
            //if (GameManager.Instance.IsShowMenu)
            //{
            //    GUI.Box(new Rect(10, 10, 500, 490), "Main Menu");
            //}
            XMLTools.TraverseNodes(xml.DocumentElement);
        }
    }
}