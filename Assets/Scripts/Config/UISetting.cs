using UnityEngine;

namespace OpenWorld.Config.UI
{
    [CreateAssetMenu(menuName = "Config/UISettingConfig")]
    public class UISetting : ScriptableObject
    {
        public float PositionX = 0;

        public float PositionY = 0;

        public float Wdith = 0;

        public float Height = 0;
    }
}
