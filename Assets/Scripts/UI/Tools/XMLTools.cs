using OpenWorld.Framework.UI;
using System;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace OpenWorld.UI.Tools
{
    public static class XMLTools
    {
        public static Dictionary<string, Func<GUILayoutBase>> mFactoriesForGUILayout = new Dictionary<string, Func<GUILayoutBase>>()
        {
            {"Root",()=>new GUILayoutWindow()},
            {"layout",()=>new GUILayoutArea() },
            {"label",()=>new GUILayoutLabel() },
            {"input",()=>new GUILayoutInput()},
            {"button",()=>new GUILayoutButton()}
        };

        /// <summary>
        /// �������нڵ�
        /// </summary>
        /// <param name="xmlNode">xml�ڵ�</param>
        public static void TraverseNodes(XmlNode xmlNode) 
        {
            // ���ı��ڵ�����
            if (!XmlNodeTypeIsText(xmlNode))
            {
                GUILayoutBase layoutBase = default;
                Func<GUILayoutBase> factory = default;
                if (mFactoriesForGUILayout.TryGetValue(xmlNode.Name, out factory)) 
                {
                    layoutBase = factory();
                    layoutBase.InitGUILayout(xmlNode);
                    layoutBase.DrawGUIElement();
                }
            }
        }

        public static bool XmlNodeTypeIsText(XmlNode xmlNode) 
        {
            return xmlNode.NodeType == XmlNodeType.Text;
        }
    }
}