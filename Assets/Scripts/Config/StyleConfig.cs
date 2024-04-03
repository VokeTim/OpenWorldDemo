using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.Config.UI.Style
{

    [CreateAssetMenu(menuName = "Config/UIStyleConfig")]
    public class StyleConfig : ScriptableObject
    {
        // 样式名称
        public string styleName;
        // 元素宽度
        public float width;
        // 元素高度
        public float height;
        // 在屏幕中的位置（2D）
        public Vector2 postionOnScreen;
        // 元素中文字的颜色
        public Color fontColor;
        // 元素中文字的大小
        public int fontSize;
        // 元素中文字的对齐方式
        public TextAnchor textAlign;
    }
}