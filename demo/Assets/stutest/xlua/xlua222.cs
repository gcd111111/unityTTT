
//------------------------------ͨ�� delegate ӳ�� function
//using System;
//using UnityEngine;
//using XLua;

//public class xlua222 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    [CSharpCallLua] // ��Ҫ���� public, ���ҵ�� Generate Code
//    public delegate int MyFunc1(int arg1, int arg2);
//    [CSharpCallLua] // ��Ҫ���� public, ���ҵ�� Generate Code
//    public delegate int MyFunc2(int arg1, int arg2, out int resOut);
//    [CSharpCallLua] // ��Ҫ���� public, ���ҵ�� Generate Code
//    public delegate int MyFunc3(int arg1, int arg2, ref int resRef);

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '05/LuaScript'");
//        TestAccessFunc1();
//        TestAccessFunc2();
//        TestAccessFunc3();
//        TestAccessFunc4();
//    }

//    private void TestAccessFunc1()
//    { // �����޲κ���
//        Action func1 = luaEnv.Global.Get<Action>("func1");
//        func1(); // LUA: func1
//    }

//    private void TestAccessFunc2()
//    { // �����вκ���
//        Action<string> func2 = luaEnv.Global.Get<Action<string>>("func2");
//        func2("xxx"); // LUA: func2, arg=xxx
//    }

//    private void TestAccessFunc3()
//    { // �����з���ֵ����
//        MyFunc1 func3 = luaEnv.Global.Get<MyFunc1>("func3");
//        Debug.Log(func3(2, 3)); // 6
//    }

//    private void TestAccessFunc4()
//    { // �����ж෵��ֵ����
//        MyFunc1 func41 = luaEnv.Global.Get<MyFunc1>("func4");
//        Debug.Log(func41(2, 3)); // 5

//        int res, resOut;
//        MyFunc2 func42 = luaEnv.Global.Get<MyFunc2>("func4");
//        res = func42(2, 3, out resOut);
//        Debug.Log("res=" + res + ", resOut=" + resOut); // res=5, resOut=-1

//        int ans, resRef = 0;
//        MyFunc3 func43 = luaEnv.Global.Get<MyFunc3>("func4");
//        ans = func43(2, 3, ref resRef);
//        Debug.Log("ans=" + ans + ", resRef=" + resRef); // res=5, resRef=-1
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//------------------------ͨ��LuaFunctionӳ��function
//using UnityEngine;
//using XLua;

//public class xlua222 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '05/LuaScript'");
//        TestAccessFunc1();
//        TestAccessFunc2();
//        TestAccessFunc3();
//        TestAccessFunc4();
//    }

//    private void TestAccessFunc1()
//    { // �����޲κ���
//        LuaFunction func1 = luaEnv.Global.Get<LuaFunction>("func1");
//        func1.Call(); // LUA: func1
//    }

//    private void TestAccessFunc2()
//    { // �����вκ���
//        LuaFunction func2 = luaEnv.Global.Get<LuaFunction>("func2");
//        func2.Call("xxx"); // LUA: func2, arg=xxx
//    }

//    private void TestAccessFunc3()
//    { // �����з���ֵ����
//        LuaFunction func3 = luaEnv.Global.Get<LuaFunction>("func3");
//        object[] res = func3.Call(2, 3);
//        Debug.Log(res[0]); // 6
//    }

//    private void TestAccessFunc4()
//    { // �����ж෵��ֵ����
//        LuaFunction func4 = luaEnv.Global.Get<LuaFunction>("func4");
//        object[] res = func4.Call(2, 3);
//        Debug.Log("res1=" + res[0] + ", res2=" + res[1]); // res1=5, res2=-1
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//Lua �д��� GameObject ����ȡ��������
//using UnityEngine;
//using XLua;

//public class xlua222 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '06/LuaScript'");
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}


//-------------------------Lua �з��� C# �Զ�����
//using UnityEngine;
//using XLua;

//public class xlua222 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Awake()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '07/LuaScript'");
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}

//[LuaCallCSharp] // ��Ҫ��� Generate Code
//class Person
//{
//    public string name;
//    public int age;

//    public Person(string name, int age)
//    {
//        this.name = name;
//        this.age = age;
//    }

//    public void Run()
//    {
//        Debug.Log("run");
//    }

//    public void Eat(string fruit)
//    {
//        Debug.Log("eat " + fruit);
//    }

//    public override string ToString()
//    {
//        return "name=" + name + ", age=" + age;
//    }
//}

//-------------------Lua Hook MonoBehaviour �������ڷ���
//using System;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using XLua;

//public class xlua222 : MonoBehaviour
//{
//    private LuaEnv luaEnv;
//    private Dictionary<string, Action> func;

//    private void Awake()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '08/LuaScript'");
//        GetFunc();
//        CallFunc("awake");
//    }

//    private void OnEnable()
//    {
//        CallFunc("onEnable");
//    }

//    private void Start()
//    {
//        CallFunc("start");
//    }

//    private void Update()
//    {
//        CallFunc("update");
//    }

//    private void OnDisable()
//    {
//        CallFunc("onDisable");
//    }

//    private void OnDestroy()
//    {
//        CallFunc("onDestroy");
//    }

//    private void GetFunc()
//    {
//        func = new Dictionary<string, Action>();
//        AddFunc("awake");
//        AddFunc("onEnable");
//        AddFunc("start");
//        AddFunc("update");
//        AddFunc("onDisable");
//        AddFunc("onDestroy");
//    }

//    private void AddFunc(string funcName)
//    {
//        Action fun = luaEnv.Global.Get<Action>(funcName);
//        if (fun != null)
//        {
//            func.Add(funcName, fun);
//        }
//    }

//    private void CallFunc(string funcName)
//    {
//        if (func.ContainsKey(funcName))
//        {
//            Action fun = func[funcName];
//            fun();
//        }
//    }

//    private void OnApplicationQuit()
//    {
//        func.Clear();
//        func = null;
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//-------------------------------gpt�Ż�
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XLua;

public class xlua222 : MonoBehaviour
{
    private LuaEnv luaEnv;
    private Dictionary<string, Action> func;

    private void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require '08/LuaScript'");
        func = new Dictionary<string, Action>();
        AddFunc("awake", func);
        AddFunc("onEnable", func);
        AddFunc("start", func);
        AddFunc("update", func);
        AddFunc("onDisable", func);
        AddFunc("onDestroy", func);
        CallFunc("awake");
    }

    private void OnEnable()
    {
        CallFunc("onEnable");
    }

    private void Start()
    {
        CallFunc("start");
    }

    private void Update()
    {
        CallFunc("update");
    }

    private void OnDisable()
    {
        CallFunc("onDisable");
    }

    private void OnDestroy()
    {
        CallFunc("onDestroy");
        func = null;
        luaEnv?.Dispose();
        luaEnv = null;
    }

    private void AddFunc<T>(string funcName, Dictionary<string, T> dict) where T : class
    {
        T fun = luaEnv.Global.Get<T>(funcName);
        if (fun != null)
        {
            dict.Add(funcName, fun);
        }
    }
    private void OnApplicationQuit()
    {
        func = null;
        func?.Clear();
        if (luaEnv != null)
        {
            luaEnv.Dispose();
            luaEnv = null;
        }
    }
    //private void CallFunc(string funcName)
    //{
    //    if (func.TryGetValue(funcName, out Action fun))
    //    {
    //        fun?.Invoke();
    //    }
    //}
    
    //�Ż���������������������
    private void CallFunc(string funcName)
    {
        if (func != null && func.TryGetValue(funcName, out Action fun))
        {
            fun?.Invoke();
        }
    }
}
