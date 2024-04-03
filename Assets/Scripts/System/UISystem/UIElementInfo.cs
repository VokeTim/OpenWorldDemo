using OpenWorld.Config.UI.Style;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.System.UISystem
{
    public class UIElementInfo
    {
        public int elementID;
        //TODO: type属性后期需要拓展，跟换为枚举类
        public string type;
        public List<StyleConfig> styleConfigs;
    }
}