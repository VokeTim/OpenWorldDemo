using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    // 布局类型选择
    public enum GUILayoutAreaType 
    {
        horizontal, // 横向布局
        vertical, // 纵向布局
        custom // 自定义
    }

    public class GUILayoutArea : GUILayoutBase
    {
        private GUILayoutAreaType layoutType;

        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
            string typeValue = xmlNode.Attributes.GetNamedItem("type").Value;
            switch (typeValue) 
            {
                case "horizontal": layoutType = GUILayoutAreaType.horizontal; break;
                case "vertical": layoutType = GUILayoutAreaType.vertical; break;
                default:layoutType = GUILayoutAreaType.custom;break;
            }
        }

        public override void DrawGUIElement()
        {
            if (layoutType == GUILayoutAreaType.horizontal)
            {
                GUILayout.BeginHorizontal();
                foreach (XmlNode xmlNode in xmlNode.ChildNodes)
                {
                    XMLTools.TraverseNodes(xmlNode);
                }
                GUILayout.EndHorizontal();
            }
            else if (layoutType == GUILayoutAreaType.vertical)
            {
                GUILayout.BeginVertical();
                foreach (XmlNode xmlNode in xmlNode.ChildNodes)
                {
                    XMLTools.TraverseNodes(xmlNode);
                }
                GUILayout.EndVertical();
            }
            else 
            {
                GUILayout.BeginArea(new Rect(0, 0, 50, 50));
                foreach (XmlNode xmlNode in xmlNode.ChildNodes)
                {
                    XMLTools.TraverseNodes(xmlNode);
                }
                GUILayout.EndVertical();
            }
        }
    }
}
