using OpenWorld.UI.Tools;
using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    public class GUILayoutLabel : GUILayoutBase
    {
        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
        }

        public override void DrawGUIElement()
        {
            GUILayout.Label(xmlNode.InnerText);
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                XMLTools.TraverseNodes(child);
            }
        }
    }
}