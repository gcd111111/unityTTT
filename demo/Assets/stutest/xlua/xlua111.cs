//using UnityEngine;
//using XLua;

//public class xlua111: MonoBehaviour
//{
//    private void Start()
//    {
//        LuaEnv luaEnv = new LuaEnv();
//        string luaStr = @"print('Hello World')
//            CS.UnityEngine.Debug.Log('Hello World')";
//        luaEnv.DoString(luaStr);
//        luaEnv.Dispose();
//    }
//}

//------------Resources.load加载资源
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private void Start()
//    {
//        LuaEnv luaEnv = new LuaEnv();
//        TextAsset textAsset = Resources.Load<TextAsset>("02/LuaScript.lua");
//        luaEnv.DoString(textAsset.text);
//        luaEnv.Dispose();
//    }
//}

//------------------内置loder加载
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private void Start()
//    {
//        LuaEnv luaEnv = new LuaEnv();
//        luaEnv.DoString("require '02/LuaScript'");
//        luaEnv.Dispose();
//    }
//}
////-------------------通过自定义loader加载
//using UnityEngine;
//using XLua;
//using System.IO;
//using System.Text;

//public class xlua111 : MonoBehaviour
//{
//    private void Start()
//    {
//        LuaEnv luaEnv = new LuaEnv();
//        luaEnv.AddLoader(MyLoader);
//        luaEnv.DoString("require '02/LuaScript'");
//        luaEnv.Dispose();
//    }

//    private byte[] MyLoader(ref string filePath)
//    {
//        string path = Application.dataPath + "/Resources/" + filePath + ".lua.txt";
//        string txt = File.ReadAllText(path);
//        return Encoding.UTF8.GetBytes(txt);
//    }
//}

//--------------加载lua里的变量
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '03/LuaScript'");
//        TestAccessVar();
//    }

//    private void TestAccessVar()
//    {
//        bool a = luaEnv.Global.Get<bool>("a");
//        int b = luaEnv.Global.Get<int>("b");
//        float c = luaEnv.Global.Get<float>("c");
//        string d = luaEnv.Global.Get<string>("d");
//        Debug.Log("a=" + a + ", b=" + b + ", c=" + c + ", d=" + d); // a=True, b=10, c=7.8, d=xxx
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//---------------------通过自定义类映射table
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '04/LuaScript'");
//        TestAccessTable();
//    }

//    private void TestAccessTable()
//    {
//        Student stu = luaEnv.Global.Get<Student>("stu");
//        Debug.Log("name=" + stu.name + ", age=" + stu.age); // name=zhangsan, age=23
//        stu.name = "lisi";
//        luaEnv.DoString("print(stu.name)"); // LUA: zhangsan
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}

//class Student
//{
//    public string name;
//    public int age;
//}
//---------------------通过自定义接口映射table
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '04/LuaScript'");
//        TestAccessTable();
//    }

//    private void TestAccessTable()
//    {
//        IStudent stu = luaEnv.Global.Get<IStudent>("stu");
//        Debug.Log("name=" + stu.name + ", age=" + stu.age); // name=zhangsan, age=23
//        stu.name = "lisi";
//        luaEnv.DoString("print(stu.name)"); // LUA: lisi
//        stu.study("program"); // LUA: subject=program
//        stu.raiseHand("right"); // LUA: hand=right
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}

//[CSharpCallLua]
//public interface IStudent
//{
//    public string name { get; set; }
//    public int age { get; set; }
//    public void study(string subject);
//    public void raiseHand(string hand);
//}
//---------------------通过Dictionary映射table
//using System.Collections.Generic;
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '04/LuaScript'");
//        TestAccessTable();
//    }

//    private void TestAccessTable()
//    {
//        Dictionary<string, object> stu = luaEnv.Global.Get<Dictionary<string, object>>("stu");
//        Debug.Log("name=" + stu["name"] + ", age=" + stu["age"]); // name=zhangsan, age=23
//        stu["name"] = "lisi";
//        luaEnv.DoString("print(stu.name)"); // LUA: zhangsan
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//------------------通过list映射table
//using System.Collections.Generic;
//using UnityEngine;
//using XLua;

//public class xlua111 : MonoBehaviour
//{
//    private LuaEnv luaEnv;

//    private void Start()
//    {
//        luaEnv = new LuaEnv();
//        luaEnv.DoString("require '04/LuaScript'");
//        TestAccessTable();
//    }

//    private void TestAccessTable()
//    {
//        List<object> list = luaEnv.Global.Get<List<object>>("stu");
//        string str = "";
//        foreach (var item in list)
//        {
//            str += item + ", ";
//        }
//        Debug.Log(str); // math, 2, True, 
//    }

//    private void OnApplicationQuit()
//    {
//        luaEnv.Dispose();
//        luaEnv = null;
//    }
//}
//--------------------通过Luatable映射table
using UnityEngine;
using XLua;

public class xlua111 : MonoBehaviour
{
    private LuaEnv luaEnv;

    private void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require '04/LuaScript'");
        TestAccessTable();
    }

    private void TestAccessTable()
    {
        LuaTable table = luaEnv.Global.Get<LuaTable>("stu");
        Debug.Log("name=" + table.Get<string>("name") + ", age=" + table.Get<int>("age")); // name=zhangsan, age=23
        table.Set<string, string>("name", "lisi");
        luaEnv.DoString("print(stu.name)"); // LUA: lisi
        table.Dispose();
    }

    private void OnApplicationQuit()
    {
        luaEnv.Dispose();
        luaEnv = null;
    }
}

