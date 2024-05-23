using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    public enum WindowType 
    {
        IconAndTitle,
        IconAndNoTitle
    }


    public class GUILayoutWindow : GUILayoutBase
    {
        public int windowID;

        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
        }

        public override void DrawGUIElement()
        {
            //TODO: 动态创建WindowID 开启的窗口不只一个的情况处理
            windowID = 0;
            string position = XMLTools.GetXmlNodeAttributeValueByItemName(xmlNode, "rect");
            Rect windowRect = new Rect(UIDefaultStyleConstance.WindowDefaultPositionOnScreenX, UIDefaultStyleConstance.WindowDefaultPositionOnScreenY, UIDefaultStyleConstance.WindowDefaultWdith, UIDefaultStyleConstance.WindowDefaultHeight);
            GUIStyle defaultStyle = GUI.skin.GetStyle("WindowStyle");
            GUILayout.Window(windowID, windowRect, OnWindow, new GUIContent(), defaultStyle);
        }

        private void OnWindow(int id)
        {
            GUILayout.Button("Button");
            foreach (XmlNode child in xmlNode.ChildNodes) 
            {
                XMLTools.TraverseNodes(child);
            }
        }
    }
}