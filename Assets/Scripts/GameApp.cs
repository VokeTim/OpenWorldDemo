using System;
using System.Reflection;
using UnityEngine;

public class MyTest
{
    public int age;
    public int sex;
    public string name;

    public void test()
    {
        Debug.Log("test");
    }

    public int test2()
    {
        Debug.Log("test3");
        return 1;
    }

    public int test3(int age,int sex,string name)
    {
        this.age = age;
        this.sex = sex;
        this.name = name;
        return -123;
    }
}

public class GameApp : MonoBehaviour
{
    public int number = 1;
    public int level = 2;

    private void Start()
    {
        //1. 获取MyTest的类型描述
        Type t = Type.GetType("MyTest");
        //2. 利用描述对象实例，构建出一个对象出来
        var instance=Activator.CreateInstance(t);
        //3. 利用我们存放的数据成员信息给它们设置值
        //instance+(偏移+大小)
        FieldInfo[] fields = t.GetFields();

        FieldInfo ageInfo = t.GetField("age");
        // 对象实例，ageInfo，偏移+大小
        ageInfo.SetValue(instance, 17);
        Debug.Log("MyTest age:"+(instance as MyTest).age);

        //调用成员函数
        //获取MethodInfo
        MethodInfo m = t.GetMethod("test3");
        System.Object[] funParams = new System.Object[3];
        funParams[0] = 37;
        funParams[1] = 1;
        funParams[2] = "blake";
        System.Object ret = m.Invoke(instance, funParams);
        Debug.Log("getInfo:" + ret);
    }
}
