using System;

namespace OpenWorld.System
{
    public class InputSystemLoadOperationAttribute : Attribute
    {
        public string InputActionName;

        public InputSystemLoadOperationAttribute(string InputActionName)
        {
            this.InputActionName = InputActionName;
        }
    }
}