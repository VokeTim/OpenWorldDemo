using OpenWorld.UI;
using UnityEditor;
using UnityEngine;

namespace OpenWorld.System.UI
{
    public class UISystem
    {
        // Init GUISkin 
        public GUISkin skin { get; private set; }

        public UISystem() 
        {
            //skin = new GUISkin();
            #region 初始化并创建一个GUISkin文件
            skin = ScriptableObject.CreateInstance<GUISkin>();
            AssetDatabase.CreateAsset(skin, "Assets/Res/OPenWorldGUISkin.guiskin");
            AssetDatabase.SaveAssets();
            #endregion
            GUIStyle[] Defaultstyles;
            GUIStyle WindowDefaultStyle = new GUIStyle();
            WindowDefaultStyle.name = "WindowStyle";
            WindowDefaultStyle.normal.background = UIConstansConfig.CreateTexture2DColor(UIConstansConfig.defaultColor);
            Defaultstyles = new GUIStyle[] { WindowDefaultStyle };
            skin.customStyles = Defaultstyles;
        }

        public void LoadGUISkin() 
        {
            GUI.skin = skin;
        }
    }
}