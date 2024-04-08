using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttribute : Attribute
{
    public string Value { get; private set; }

    public TestAttribute(string str) 
    {
        Value = str;
    }
}
