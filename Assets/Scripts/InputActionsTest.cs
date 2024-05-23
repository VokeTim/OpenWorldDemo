using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputActionsTest : MonoBehaviour
{
    private void Awake()
    {
        InputActionMap actionMap = new InputActionMap("InputActionTest");
        InputAction action1 = actionMap.AddAction("test1",InputActionType.Button, "<Keyboard>/space");
        InputAction action2 = actionMap.AddAction("test2",InputActionType.Button, "<Keyboard>/J");
        action1.performed += TestInterAction;
        action2.performed += Test1;
        actionMap.Enable();
        for (int i = 0; i < actionMap.actions.Count; i++) 
        {
            string name = actionMap.actions[i].name;
            Debug.Log(name);
        }
        var rs=actionMap.FindAction("test2");
        rs.Disable();
    }

    private void Test1(InputAction.CallbackContext context)
    {
        Debug.Log("456");
    }

    private void TestInterAction(InputAction.CallbackContext context)
    {
        Debug.Log("123");
    }
}
