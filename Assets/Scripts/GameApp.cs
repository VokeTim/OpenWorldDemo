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
        //1. ��ȡMyTest����������
        Type t = Type.GetType("MyTest");
        //2. ������������ʵ����������һ���������
        var instance=Activator.CreateInstance(t);
        //3. �������Ǵ�ŵ����ݳ�Ա��Ϣ����������ֵ
        //instance+(ƫ��+��С)
        FieldInfo[] fields = t.GetFields();

        FieldInfo ageInfo = t.GetField("age");
        // ����ʵ����ageInfo��ƫ��+��С
        ageInfo.SetValue(instance, 17);
        Debug.Log("MyTest age:"+(instance as MyTest).age);

        //���ó�Ա����
        //��ȡMethodInfo
        MethodInfo m = t.GetMethod("test3");
        System.Object[] funParams = new System.Object[3];
        funParams[0] = 37;
        funParams[1] = 1;
        funParams[2] = "blake";
        System.Object ret = m.Invoke(instance, funParams);
        Debug.Log("getInfo:" + ret);
    }
}
