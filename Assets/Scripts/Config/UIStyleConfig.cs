using UnityEngine;

namespace OpenWorld.Config.UI
{
    [CreateAssetMenu(menuName = "Config/UIStyleConfig")]
    public class UIStyleConfig : ScriptableObject
    {
        public float PositionX = 0;

        public float PositionY = 0;

        public float Wdith = 0;

        public float Height = 0;

        public Color NormalBackgroundColor;

        public Texture2D NormalBackgroundImg;

        public Texture2D WindowCloseIcon;

        public float WindowCloseIconWidth = 0;

        public float WindowCloseIconHeight = 0;

        public int fontSize = 15;
    }
}
