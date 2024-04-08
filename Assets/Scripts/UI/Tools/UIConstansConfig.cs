using OpenWorld.Config.UI;
using UnityEngine;

namespace OpenWorld.UI
{
    public static class UIConstansConfig
    {
        public static UIStyleConfig MainMenuConfig;

        // Ĭ����ɫ
        public static Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 0.3f); // ��ɫ��������͸��

        // ����һ��Texture2D
        public static Texture2D CreateTexture2DColor(Color color, int width = 1, int height = 1, int x = 0, int y = 0)
        {
            Texture2D texture2D = new Texture2D(width, height); // ����һ��1x1������
            texture2D.SetPixel(x, y, color); // �����������ɫ
            texture2D.Apply(); // Ӧ����ɫ����
            return texture2D;
        }
    }
}