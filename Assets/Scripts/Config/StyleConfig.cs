using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.Config.UI.Style
{

    [CreateAssetMenu(menuName = "Config/UIStyleConfig")]
    public class StyleConfig : ScriptableObject
    {
        // ��ʽ����
        public string styleName;
        // Ԫ�ؿ��
        public float width;
        // Ԫ�ظ߶�
        public float height;
        // ����Ļ�е�λ�ã�2D��
        public Vector2 postionOnScreen;
        // Ԫ�������ֵ���ɫ
        public Color fontColor;
        // Ԫ�������ֵĴ�С
        public int fontSize;
        // Ԫ�������ֵĶ��뷽ʽ
        public TextAnchor textAlign;
    }
}