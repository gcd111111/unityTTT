using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Mono.Cecil.Pdb;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using Unity.Model;
using Unity.VisualScripting.YamlDotNet.Core;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Events;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

    public class HotFixManager : MonoBehaviour
    {

        public GameObject code;//code预制体，它身上带有Unity.HotFix.dll和Unity.HotFix.pdb文件
    //private const string codeDir = "Assets/Res/Code/";//生成的dll和pdb文件夹存放的位置
    //private const string hotfixDll = "Unity.HotFix.dll";//加载文件夹名称
    //private const string hotfixPdb = "Unity.HotFix.pdb";//加载文件夹名称
    private MemoryStream dllStream;
        private MemoryStream pdbStream;

        private AppDomain appDomain;//全局变量，建议使用时用单例模式将HotManager做成单例

        private string namespaceName = "HotFix";//我们加载热更新脚本的命名空间名字
        private string className = "Test";//加载类的名字
        private string name = "";//加载文件总名称
                                 // Start is called before the first frame update
        void Start()
        {
            name = namespaceName + "." + className;
            Load();
            热更新加载函数();
    }

    // ///param
    /////path：文件夹路径  
    /////suffix：后缀格式， 如bmp，txt  
    /////fileList:文件名存放  
    /////isSubcatalog:true遍历子文件夹，否则不遍历  
    //public void getFiles(string path, string suffix,ref byte[] cd)
    //{
    //    string filename;
    //    DirectoryInfo dir = new DirectoryInfo(path);
    //    FileInfo[] file = dir.GetFiles();
    //    DirectoryInfo[] dii = dir.GetDirectories();//如需遍历子文件夹时需要使用  
    //    foreach (FileInfo f in file)
    //    {
    //        filename = f.FullName;//拿到了文件的完整路径
    //        if (filename.EndsWith(suffix))//判断文件后缀，并获取指定格式的文件全路径增添至fileList  
    //        {
    //            cd = filename;
    //            print(filename);
    //        }
    //    }
    //    return;
    //}
    /// <summary>
    /// 转成二进制文件输出
    /// </summary>
    /// <param name="fileUrl"></param>
    /// <returns></returns>
    public static byte[] AuthGetFileData(string fileUrl)
    {
        FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.ReadWrite);
        byte[] buffur = new byte[fs.Length];
        fs.Read(buffur, 0, buffur.Length);
        fs.Close();
        return buffur;
    }
    /// <summary>
    /// 获取文件夹中所有指定扩展名的文件信息
    /// </summary>
    /// <param name="dirPath"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    //public static FileInfo[] GetFiles(string dirPath, string extension)
    //{
    //    FileInfo[] filesInfo = new FileInfo[] { };
    //    if (Directory.Exists(dirPath))
    //    {
    //        DirectoryInfo direction = new DirectoryInfo(dirPath);
    //        filesInfo = direction.GetFiles("*." + extension, SearchOption.AllDirectories).OrderBy(x => Convert.ToInt32(Regex.Replace(x.Name, @"[^0-9]+", ""))).ToArray();
    //    }
    //    return filesInfo;

    //}

        void Load()
        {
        //1.获取带两个bytes文件
        CodeReference cr = code.GetComponent<CodeReference>();
        byte[] assBytes = cr.hotfixDll.bytes;
        byte[] pdbBytes = cr.hotfixPdb.bytes;

        //byte[] assBytes = AuthGetFileData(codeDir + hotfixDll);
        //byte[] pdbBytes = AuthGetFileData(codeDir + hotfixPdb);

#if ILRuntime
        //2.在ILRuntime模式下 把这两个文件加载到内存流里面
        dllStream = new MemoryStream(assBytes);
        pdbStream = new MemoryStream(pdbBytes);

        //3.构造AppDomain对象 通过它的LoadAssembly来进行加载
        appDomain = new AppDomain();
            appDomain.LoadAssembly(dllStream, pdbStream, new PdbReaderProvider());
            委托适配器();
            跨域继承适配器注册();
            CLR重定向方法();
            Debug.Log("ILRuntime模式加载成功");
#else
       Assembly.Load(assBytes,pdbBytes);
#endif

        }

        void 跨域继承适配器注册()
        {
            appDomain.RegisterCrossBindingAdaptor(new UIBaseAdapter());
        }

        void 热更新加载函数()
        {


            #region 1.加载静态无返回函数

            //第一个参数：命名空间.类名
            //第二个参数：方法名
            //第三个参数：类的实例(静态函数不用写实例，动态的要添加实例参数
            //第四个参数：参数类型
            appDomain.Invoke(name, "无参函数", null, null);
            appDomain.Invoke(name, "有一参数函数", null, "gcd");
            appDomain.Invoke(name, "有多参函数", null, new string[] { "gcd", "gcd" });
            appDomain.Invoke(name, "多个不同参数类型无返回函数", null, new object[] { "gcd", 211 });

            #endregion

            #region 2.加载静态有返回函数

            object m1 = appDomain.Invoke(name, "无参函数有返回值", null, null);
            Debug.Log(m1);
            object m2 = appDomain.Invoke(name, "有一参数函数有返回", null, "gcd");
            Debug.Log(m2);
            object m3 = appDomain.Invoke(name, "有多参函数有返回", null, new string[] { "gcd", "gcd" });
            Debug.Log(m3);
            object m4 = appDomain.Invoke(name, "多个不同参数类型无返回函数有返回", null, new object[] { "gcd", 211985 });
            Debug.Log(m4);

            #endregion

            #region 3.加载动态无返回函数

            InstantiateTest();

            #endregion

            #region 4.加载重载函数

            //1.第一种和上面记载的方法一样，指定方法名，实例，参数个数，具体实现就不再重写，自己照着上面就可以了
            //2.List<IType>泛型加载参数形式找到对应的函数
            IType type1 = appDomain.LoadedTypes[name];//这里将指定类的所有类型都加载出来
            Debug.Log(type1);
            IMethod method1 = type1.GetMethod("Log", 0);
            appDomain.Invoke(method1, null, null);//这个对应的无参Log函数

            IType type2 = appDomain.LoadedTypes[name];//这里将指定类的所有类型都加载出来
            List<IType> param2 = new List<IType>();
            param2.Add(appDomain.GetType(typeof(string)));//这里对应的函数参数什么类型，有几个都这样添加进来
            IMethod method2 = type2.GetMethod("Log", param2, null);
            appDomain.Invoke(method2, null, "gcd");

            IType type3 = appDomain.LoadedTypes[name];//这里将指定类的所有类型都加载出来
            List<IType> param3 = new List<IType>();
            param3.Add(appDomain.GetType(typeof(string)));
            param3.Add(appDomain.GetType(typeof(int)));
            IMethod method3 = type2.GetMethod("Log", param3, null);
            appDomain.Invoke(method3, null, new object[] { "gcd", 211985 });


            //该形式也可和前面的函数类型进行调用，只是那样直接调用的比较方便
            #endregion

            #region 5.加载成员变量

            调用变量成员();

            #endregion

            #region 6.加载泛型函数

            调用泛型();

            #endregion

            #region 7.加载委托

            调用委托();

            #endregion

            #region 跨域继承的调用

            调用继承类函数();

            #endregion

            #region CLR重定向

            #endregion
        }

        /// <summary>
        /// 实例化类，从而达到调用动态函数
        /// </summary>
        void InstantiateTest()
        {
            ILTypeInstance test = appDomain.Instantiate(name, null);
            appDomain.Invoke(name, "动态无参", test, null);
            appDomain.Invoke(name, "动态有一参函数", test, "gcd");
            object x1 = appDomain.Invoke(name, "动态无参有返回值", test, null);
            Debug.Log(x1);
            object x2 = appDomain.Invoke(name, "动态有一参函数有返回值", test, "gcd");
            Debug.Log(x2);
        }

        /// <summary>
        /// 这个方法是调用热更新dll文件中的类的成员
        /// 注意这里的调用热更新文件变量必须是属性
        /// 采用get_Name获取和set_Name设置赋值
        /// </summary>
        void 调用变量成员()
        {
            //通过实例化，我们去访问成员变量，但是对应的成员变量是字段属性，我们还是类似调用的方法一样才能得到变量
            //get_ID  set_ID都是我们在给变量设置为属性时自动生成的
            ILTypeInstance test = appDomain.Instantiate(name);

            int id1 = (int)appDomain.Invoke(name, "get_ID", test, null);
            Debug.Log(id1);

            appDomain.Invoke(name, "set_ID", test, 985211);
            int id2 = (int)appDomain.Invoke(name, "get_ID", test, null);
            Debug.Log(id2);
        }

        /// <summary>
        /// 这个方法是调用热更新Dll文件中类的泛型方法，我们只需要给
        /// 该方法声明类型即可使用 采用appDomain.GetType(type(string....)注册
        /// </summary>
        void 调用泛型()
        {
            ILTypeInstance test = appDomain.Instantiate(name);
            appDomain.InvokeGenericMethod(name, "泛型函数",
                new IType[] { appDomain.GetType(typeof(string)) }, test, "gcd");
        }

        void 调用委托()
        {
            //注意：我们的ILRuntime只支持Action以及Func，delegate委托的使用
            //而在unity’中的委托调用是UnityAction，所以我们咋这里用ILRuntime无法直接调用该方法
            //所以我们这里就用到了我们的委托适配器，我们要在生成appDomain变量是进行注册委托适配器
            ILTypeInstance test = appDomain.Instantiate(name);
            appDomain.Invoke(name, "ButtonClick", test, null);
            appDomain.Invoke(name, "调用这些委托", test, null);
        }

        void 委托适配器()
        {
            //普通委托注册
            appDomain.DelegateManager.RegisterMethodDelegate<int>();//这是给Action类型添加委托进行适配，<>里可以写任意个参数类型，要和dll里面的匹配
            appDomain.DelegateManager.RegisterFunctionDelegate<int, int>();//这是给Action类型添加委托进行适配，<>里可以写任意个参数类型，要和dll里面的匹配

            //这里是给非Action Func 委托类型进行注册
            appDomain.DelegateManager.RegisterDelegateConvertor<UnityAction>
            (
                (act) =>
                {
                    return new UnityAction(() =>
                        ((Action)act)()
                        );
                }
                );
        }

        void 调用继承类函数()
        {
            string pName = "HotFix.继承unity主程序中的类";
            UIBase uibase = appDomain.Instantiate<UIBase>(pName);
            int id = (int)appDomain.Invoke(pName, "get_MyID", uibase, null);
            Debug.Log(id);
            appDomain.Invoke(pName, "HandleEvent", uibase, 50);
            appDomain.Invoke(pName, "Open", uibase, "gcd");
        }


        unsafe void CLR重定向方法()
        {
            MethodInfo method = typeof(Debug).GetMethod("Log", new System.Type[] { typeof(object) });
            appDomain.RegisterCLRMethodRedirection(method, DLog);
        }
        public unsafe static StackObject* DLog(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            //只有一个参数，所以返回指针就是当前栈指针ESP - 1
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            //第一个参数为ESP -1， 第二个参数为ESP - 2，以此类推
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            //获取参数message的值
            object message = StackObject.ToObject(ptr_of_this_method, __domain, __mStack);
            //需要清理堆栈
            __intp.Free(ptr_of_this_method);
            //如果参数类型是基础类型，例如int，可以直接通过int param = ptr_of_this_method->Value获取值，
            //关于具体原理和其他基础类型如何获取，请参考ILRuntime实现原理的文档。

            //通过ILRuntime的Debug接口获取调用热更DLL的堆栈
            string stackTrace = __domain.DebugService.GetStackTrace(__intp);
            Debug.Log(string.Format("{0}\n----------------\n{1}", message, stackTrace));

            return __ret;
        }
    }



