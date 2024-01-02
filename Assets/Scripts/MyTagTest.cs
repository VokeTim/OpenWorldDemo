using System;
using UnityEngine;

public class MyTagTest : Attribute
{
    int num = 0;
    string text;

    public MyTagTest(int num, string text)
    {
        this.num = num;
        this.text = text;

        Debug.Log("num: " + num + " ,text: " + text);
    }
}
