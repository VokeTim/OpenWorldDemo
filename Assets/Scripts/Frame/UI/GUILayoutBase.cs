using System.Xml;

namespace OpenWorld.Framework.UI
{
    /// <summary>
    /// »ù´¡GUILayout
    /// </summary>
    public abstract class GUILayoutBase
    {
        public XmlNode xmlNode;

        public abstract void DrawGUIElement();

        public virtual void InitGUILayout(XmlNode xmlNode) 
        {
            this.xmlNode = xmlNode;
        }
    }
}
