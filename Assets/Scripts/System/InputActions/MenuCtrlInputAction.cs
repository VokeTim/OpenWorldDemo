using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.System.InputSystem
{
    public class MenuCtrlInputAction : BaseInputAction
    {
        public MenuCtrlInputAction() 
        {
            InputActionImpl = new MenuInputActionImpl();
        }
    }
}