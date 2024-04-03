using JetBrains.Annotations;
using OpenWorld.Config.UI;
using OpenWorld.Config.UI.Style;
using OpenWorld.System.UISystem;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace OpenWorld.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public UISetting MainMenuConfig;

        public List<StyleConfig> styleConfigs;

        private List<UIElementInfo> elementInfos = new List<UIElementInfo>();

        public float LabelHeight = 35;

        public int LableFontSize = 25;

        private string xmlPath = Application.dataPath + "/Res/UI/MainMenu.xml";

        public static Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // 灰色背景，半透明

        private void Start()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            XmlNodeList nodeList = xml.SelectNodes("Root/node");
            foreach (XmlElement node in nodeList) 
            {
                UIElementInfo elementInfo = new UIElementInfo();
                string id = node.GetAttribute("id");
                string styleConfigName = node.GetAttribute("style");
                List<StyleConfig> styleConfigByName = styleConfigs.Where(style => style.styleName == styleConfigName).ToList();
                string type = node.GetAttribute("type");
                elementInfo.elementID = int.Parse(id);
                elementInfo.type = type;
                elementInfo.styleConfigs = styleConfigByName;
                elementInfos.Add(elementInfo);
                XmlNodeList labelList = node.GetElementsByTagName("label");
                //Debug.Log(id+" node have style:"+styleConfigName+", type:"+type);
                foreach (XmlElement label in labelList)
                {
                    string content = label.InnerText;
                    string style = label.GetAttribute("style");
                    //Debug.Log("label content:" + content+", style name:"+style);
                }
            }
        }

        private void OnGUI()
        {
            //TODO: 开启菜单时禁用移动和视角变化且显示鼠标，关闭菜单时启用移动和视角变化且隐藏鼠标
            //if (GameManager.Instance.IsShowMenu)
            //{
            //    GUI.Box(new Rect(10, 10, 500, 490), "Main Menu");
            //}

            foreach (UIElementInfo elementInfo in elementInfos) 
            {
                StyleConfig styleConfig = elementInfo.styleConfigs.FirstOrDefault();
                Rect elementRect = new Rect(styleConfig.postionOnScreen.x, styleConfig.postionOnScreen.y, styleConfig.width, styleConfig.height);
                GUIStyle styleInfo = new GUIStyle();
                styleInfo.normal.background = CreateTexture2DColor(defaultColor);
                styleInfo.normal.textColor = styleConfig.fontColor;
                styleInfo.alignment = styleConfig.textAlign;
                GUILayout.Window(elementInfo.elementID, elementRect, WindowFunc, new GUIContent(), styleInfo, GUILayout.Width(styleConfig.width), GUILayout.Height(styleConfig.height));
            }

            //Rect mainMenuRect = new Rect(MainMenuConfig.PositionX, MainMenuConfig.PositionY, MainMenuConfig.Wdith, MainMenuConfig.Height);
            //GUIStyle windowStyle = new GUIStyle();
            //windowStyle.border = new RectOffset(50, 50, 50, 50);
            //windowStyle.normal.textColor = Color.black;
            // 设置背景颜色
            //Color bgColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // 灰色背景，半透明
            //windowStyle.normal.background = CreateTexture2DColor(bgColor);
            //GUILayout.Window(0, mainMenuRect, WindowFunc, new GUIContent(), windowStyle,GUILayout.Width(MainMenuConfig.Wdith),GUILayout.Height(MainMenuConfig.Height));
        }

        private void WindowFunc(int id)
        {
            GUIStyle titleStyle = new GUIStyle();
            titleStyle.normal.background = CreateTexture2DColor(Color.blue);
            titleStyle.normal.textColor = Color.white;
            titleStyle.alignment = TextAnchor.MiddleCenter;
            titleStyle.fontSize = LableFontSize;
            GUILayout.Label("主菜单", titleStyle, GUILayout.Height(LabelHeight));
            GUILayout.Button("CloseButton", GUILayout.Width(100), GUILayout.Height(100));
        }

        public Texture2D CreateTexture2DColor(Color color, int width = 1, int height = 1, int x = 0, int y = 0) 
        {
            Texture2D texture2D = new Texture2D(width, height); // 创建一个1x1的纹理
            texture2D.SetPixel(x, y, color); // 设置纹理的颜色
            texture2D.Apply(); // 应用颜色更改
            return texture2D;
        }
    }
}