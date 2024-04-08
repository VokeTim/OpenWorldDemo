using OpenWorld.Config.UI;
using UnityEngine;

namespace OpenWorld.UI
{
    public static class UIConstansConfig
    {
        public static UIStyleConfig MainMenuConfig;

        // 默认颜色
        public static Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // 灰色背景，半透明

        // 创建一个Texture2D
        public static Texture2D CreateTexture2DColor(Color color, int width = 1, int height = 1, int x = 0, int y = 0)
        {
            Texture2D texture2D = new Texture2D(width, height); // 创建一个1x1的纹理
            texture2D.SetPixel(x, y, color); // 设置纹理的颜色
            texture2D.Apply(); // 应用颜色更改
            return texture2D;
        }
    }
}