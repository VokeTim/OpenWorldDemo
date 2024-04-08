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

        public T GetAttrbuteByName<T>(string name)
        {
            var attribute = xmlNode.Attributes.GetNamedItem(name);
            if (attribute != null && !string.IsNullOrEmpty(attribute.Value)) 
            {
                T result = default;
                
            }
            return default;
        }
    }
}
