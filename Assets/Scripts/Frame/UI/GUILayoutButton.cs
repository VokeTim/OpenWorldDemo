using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    public class GUILayoutButton : GUILayoutBase
    {
        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
        }

        public override void DrawGUIElement()
        {
            GUILayout.Button(xmlNode.InnerXml);
        }
    }
}