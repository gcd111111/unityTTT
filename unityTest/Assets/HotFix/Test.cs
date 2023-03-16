using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix//这里就是我们要给访问的命名空间
{
    public class Test
    {
        #region 函数

        public Test()
        {
            Debug.Log("我是无参构造函数");
        }

        public Test(string text)
        {
            Debug.Log($"我是有参构造函数string text：   {text}");
        }

        public static void 无参函数()
        {
            Debug.Log("我是静态无参函数无返回函数");
        }

        public static void 有一参数函数(string text)
        {
            Debug.Log("我是静态有一个string参数函数无返回函数：   " + text);
        }

        public static void 有多参函数(string text1, string text2)
        {
            Debug.Log($"我是静态有多个参数无返回函数" +
                      $"string  text1：   {text1}   string text2:   {text2}");
        }

        public static void 多个不同参数类型无返回函数(string text, int m)
        {
            Debug.Log($"我是静态有多个不同参数类型无返回函数 " +
                      $"  string text：   {text}    int m:   {m}");
        }

        public static void Log()
        {
            Debug.Log("无参无返回Log函数");
        }

        public static void Log(string text)
        {
            Debug.Log($"有一个string参数无返回Log函数 text：   {text}");
        }

        public static void Log(string text, int m)
        {
            Debug.Log($"有一个string参数一个int参乎上无返回Log函数 text：   {text}      m:     {m}");
        }

        public static int 无参函数有返回值()
        {
            Debug.Log("我是静态无参函数有返回函数");
            return 1;
        }

        public static int 有一参数函数有返回(string text)
        {
            Debug.Log("我是静态有一个string参数函数有返回函数：   " + text);
            return 2;
        }

        public static int 有多参函数有返回(string text1, string text2)
        {
            Debug.Log($"我是静态有多个参数有返回函数" +
                      $"string  text1：   {text1}   string text2:   {text2}");
            return 3;
        }

        public static int 多个不同参数类型无返回函数有返回(string text, int m)
        {
            Debug.Log($"我是静态有多个不同参数类型有返回函数 " +
                      $"  string text：   {text}    int m:   {m}");
            return 4;
        }

        public void 动态无参()
        {
            Debug.Log("我是动态无参无返回函数");
        }

        public void 动态有一参函数(string text)
        {
            Debug.Log("我是动态有一参数函数  string text:     " + text);
        }

        public int 动态无参有返回值()
        {
            Debug.Log("我是动态无参有返回函数");
            return 1;
        }

        public int 动态有一参函数有返回值(string text)
        {
            Debug.Log("我是动态有一参数有返回值函数  string text:     " + text);
            return 2;
        }

        #endregion

        #region 字段变量

        private int id = 5000;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        #endregion

        #region 泛型函数

        public void 泛型函数<T>(T t)
        {
            Debug.Log($"我是泛型函数参数是：{t}");
        }


        #endregion

        #region UnityAction委托调用

        public void ButtonClick()
        {
            Button button = GameObject.Find("Canvas/Test").GetComponent<Button>();
            button.onClick.AddListener(OnClike);//这里的注册添加的是UnityAction委托类型
        }

        private void OnClike()
        {
            Debug.Log("点击了Test按钮");
        }


        #endregion

        #region 其他委托delegate Func Action

        public delegate void Delegate委托();
        public Action<int> action委托;
        public Func<int, int> func委托;

        public void 注册delegate委托()
        {
            Debug.Log("使用了delegate委托");
        }
        public void 注册Action委托(int n)
        {
            Debug.Log($"使用了Action委托,参数数n:   {n}");
        }
        public int 注册Func委托(int m)
        {
            Debug.Log($"使用了func委托,参数数m：{m}");
            return m;
        }

        public void 调用这些委托()
        {
            //首先给这些委托进行注册
            Delegate委托 delegate委托 = 注册delegate委托;
            action委托 = 注册Action委托;
            func委托 = 注册Func委托;


            //调用这些委托
            delegate委托();
            action委托(985);
            int m = func委托(985211);
            Debug.Log(m);
        }


        #endregion
    }
}

