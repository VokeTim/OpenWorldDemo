using OpenWorld.UI.Tools;
using System;
using System.Xml;
using UnityEngine;

namespace OpenWorld.Framework.UI
{
    public class GUILayoutWindow : GUILayoutBase
    {
        public int windowID;

        public override void InitGUILayout(XmlNode xmlNode)
        {
            base.InitGUILayout(xmlNode);
        }

        public override void DrawGUIElement()
        {
            //TODO: ¶¯Ì¬´´½¨WindowID
            windowID = 0;
            GUILayout.Window(windowID, new Rect(550, 160, 700, 700), OnWindow, new GUIContent(), GUILayout.Width(800), GUILayout.Height(735));
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