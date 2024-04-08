using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    public class GUILayoutInput : GUILayoutBase
    {
        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
        }

        public override void DrawGUIElement()
        {
            GUILayout.TextField("");
        }
    }
}