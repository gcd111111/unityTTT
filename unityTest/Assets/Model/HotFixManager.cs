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

        public GameObject code;//codeԤ���壬�����ϴ���Unity.HotFix.dll��Unity.HotFix.pdb�ļ�
    //private const string codeDir = "Assets/Res/Code/";//���ɵ�dll��pdb�ļ��д�ŵ�λ��
    //private const string hotfixDll = "Unity.HotFix.dll";//�����ļ�������
    //private const string hotfixPdb = "Unity.HotFix.pdb";//�����ļ�������
    private MemoryStream dllStream;
        private MemoryStream pdbStream;

        private AppDomain appDomain;//ȫ�ֱ���������ʹ��ʱ�õ���ģʽ��HotManager���ɵ���

        private string namespaceName = "HotFix";//���Ǽ����ȸ��½ű��������ռ�����
        private string className = "Test";//�����������
        private string name = "";//�����ļ�������
                                 // Start is called before the first frame update
        void Start()
        {
            name = namespaceName + "." + className;
            Load();
            �ȸ��¼��غ���();
    }

    // ///param
    /////path���ļ���·��  
    /////suffix����׺��ʽ�� ��bmp��txt  
    /////fileList:�ļ������  
    /////isSubcatalog:true�������ļ��У����򲻱���  
    //public void getFiles(string path, string suffix,ref byte[] cd)
    //{
    //    string filename;
    //    DirectoryInfo dir = new DirectoryInfo(path);
    //    FileInfo[] file = dir.GetFiles();
    //    DirectoryInfo[] dii = dir.GetDirectories();//����������ļ���ʱ��Ҫʹ��  
    //    foreach (FileInfo f in file)
    //    {
    //        filename = f.FullName;//�õ����ļ�������·��
    //        if (filename.EndsWith(suffix))//�ж��ļ���׺������ȡָ����ʽ���ļ�ȫ·��������fileList  
    //        {
    //            cd = filename;
    //            print(filename);
    //        }
    //    }
    //    return;
    //}
    /// <summary>
    /// ת�ɶ������ļ����
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
    /// ��ȡ�ļ���������ָ����չ�����ļ���Ϣ
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
        //1.��ȡ������bytes�ļ�
        CodeReference cr = code.GetComponent<CodeReference>();
        byte[] assBytes = cr.hotfixDll.bytes;
        byte[] pdbBytes = cr.hotfixPdb.bytes;

        //byte[] assBytes = AuthGetFileData(codeDir + hotfixDll);
        //byte[] pdbBytes = AuthGetFileData(codeDir + hotfixPdb);

#if ILRuntime
        //2.��ILRuntimeģʽ�� ���������ļ����ص��ڴ�������
        dllStream = new MemoryStream(assBytes);
        pdbStream = new MemoryStream(pdbBytes);

        //3.����AppDomain���� ͨ������LoadAssembly�����м���
        appDomain = new AppDomain();
            appDomain.LoadAssembly(dllStream, pdbStream, new PdbReaderProvider());
            ί��������();
            ����̳�������ע��();
            CLR�ض��򷽷�();
            Debug.Log("ILRuntimeģʽ���سɹ�");
#else
       Assembly.Load(assBytes,pdbBytes);
#endif

        }

        void ����̳�������ע��()
        {
            appDomain.RegisterCrossBindingAdaptor(new UIBaseAdapter());
        }

        void �ȸ��¼��غ���()
        {


            #region 1.���ؾ�̬�޷��غ���

            //��һ�������������ռ�.����
            //�ڶ���������������
            //���������������ʵ��(��̬��������дʵ������̬��Ҫ���ʵ������
            //���ĸ���������������
            appDomain.Invoke(name, "�޲κ���", null, null);
            appDomain.Invoke(name, "��һ��������", null, "gcd");
            appDomain.Invoke(name, "�ж�κ���", null, new string[] { "gcd", "gcd" });
            appDomain.Invoke(name, "�����ͬ���������޷��غ���", null, new object[] { "gcd", 211 });

            #endregion

            #region 2.���ؾ�̬�з��غ���

            object m1 = appDomain.Invoke(name, "�޲κ����з���ֵ", null, null);
            Debug.Log(m1);
            object m2 = appDomain.Invoke(name, "��һ���������з���", null, "gcd");
            Debug.Log(m2);
            object m3 = appDomain.Invoke(name, "�ж�κ����з���", null, new string[] { "gcd", "gcd" });
            Debug.Log(m3);
            object m4 = appDomain.Invoke(name, "�����ͬ���������޷��غ����з���", null, new object[] { "gcd", 211985 });
            Debug.Log(m4);

            #endregion

            #region 3.���ض�̬�޷��غ���

            InstantiateTest();

            #endregion

            #region 4.�������غ���

            //1.��һ�ֺ�������صķ���һ����ָ����������ʵ������������������ʵ�־Ͳ�����д���Լ���������Ϳ�����
            //2.List<IType>���ͼ��ز�����ʽ�ҵ���Ӧ�ĺ���
            IType type1 = appDomain.LoadedTypes[name];//���ｫָ������������Ͷ����س���
            Debug.Log(type1);
            IMethod method1 = type1.GetMethod("Log", 0);
            appDomain.Invoke(method1, null, null);//�����Ӧ���޲�Log����

            IType type2 = appDomain.LoadedTypes[name];//���ｫָ������������Ͷ����س���
            List<IType> param2 = new List<IType>();
            param2.Add(appDomain.GetType(typeof(string)));//�����Ӧ�ĺ�������ʲô���ͣ��м�����������ӽ���
            IMethod method2 = type2.GetMethod("Log", param2, null);
            appDomain.Invoke(method2, null, "gcd");

            IType type3 = appDomain.LoadedTypes[name];//���ｫָ������������Ͷ����س���
            List<IType> param3 = new List<IType>();
            param3.Add(appDomain.GetType(typeof(string)));
            param3.Add(appDomain.GetType(typeof(int)));
            IMethod method3 = type2.GetMethod("Log", param3, null);
            appDomain.Invoke(method3, null, new object[] { "gcd", 211985 });


            //����ʽҲ�ɺ�ǰ��ĺ������ͽ��е��ã�ֻ������ֱ�ӵ��õıȽϷ���
            #endregion

            #region 5.���س�Ա����

            ���ñ�����Ա();

            #endregion

            #region 6.���ط��ͺ���

            ���÷���();

            #endregion

            #region 7.����ί��

            ����ί��();

            #endregion

            #region ����̳еĵ���

            ���ü̳��ຯ��();

            #endregion

            #region CLR�ض���

            #endregion
        }

        /// <summary>
        /// ʵ�����࣬�Ӷ��ﵽ���ö�̬����
        /// </summary>
        void InstantiateTest()
        {
            ILTypeInstance test = appDomain.Instantiate(name, null);
            appDomain.Invoke(name, "��̬�޲�", test, null);
            appDomain.Invoke(name, "��̬��һ�κ���", test, "gcd");
            object x1 = appDomain.Invoke(name, "��̬�޲��з���ֵ", test, null);
            Debug.Log(x1);
            object x2 = appDomain.Invoke(name, "��̬��һ�κ����з���ֵ", test, "gcd");
            Debug.Log(x2);
        }

        /// <summary>
        /// ��������ǵ����ȸ���dll�ļ��е���ĳ�Ա
        /// ע������ĵ����ȸ����ļ���������������
        /// ����get_Name��ȡ��set_Name���ø�ֵ
        /// </summary>
        void ���ñ�����Ա()
        {
            //ͨ��ʵ����������ȥ���ʳ�Ա���������Ƕ�Ӧ�ĳ�Ա�������ֶ����ԣ����ǻ������Ƶ��õķ���һ�����ܵõ�����
            //get_ID  set_ID���������ڸ���������Ϊ����ʱ�Զ����ɵ�
            ILTypeInstance test = appDomain.Instantiate(name);

            int id1 = (int)appDomain.Invoke(name, "get_ID", test, null);
            Debug.Log(id1);

            appDomain.Invoke(name, "set_ID", test, 985211);
            int id2 = (int)appDomain.Invoke(name, "get_ID", test, null);
            Debug.Log(id2);
        }

        /// <summary>
        /// ��������ǵ����ȸ���Dll�ļ�����ķ��ͷ���������ֻ��Ҫ��
        /// �÷����������ͼ���ʹ�� ����appDomain.GetType(type(string....)ע��
        /// </summary>
        void ���÷���()
        {
            ILTypeInstance test = appDomain.Instantiate(name);
            appDomain.InvokeGenericMethod(name, "���ͺ���",
                new IType[] { appDomain.GetType(typeof(string)) }, test, "gcd");
        }

        void ����ί��()
        {
            //ע�⣺���ǵ�ILRuntimeֻ֧��Action�Լ�Func��delegateί�е�ʹ��
            //����unity���е�ί�е�����UnityAction����������զ������ILRuntime�޷�ֱ�ӵ��ø÷���
            //��������������õ������ǵ�ί��������������Ҫ������appDomain�����ǽ���ע��ί��������
            ILTypeInstance test = appDomain.Instantiate(name);
            appDomain.Invoke(name, "ButtonClick", test, null);
            appDomain.Invoke(name, "������Щί��", test, null);
        }

        void ί��������()
        {
            //��ͨί��ע��
            appDomain.DelegateManager.RegisterMethodDelegate<int>();//���Ǹ�Action�������ί�н������䣬<>�����д������������ͣ�Ҫ��dll�����ƥ��
            appDomain.DelegateManager.RegisterFunctionDelegate<int, int>();//���Ǹ�Action�������ί�н������䣬<>�����д������������ͣ�Ҫ��dll�����ƥ��

            //�����Ǹ���Action Func ί�����ͽ���ע��
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

        void ���ü̳��ຯ��()
        {
            string pName = "HotFix.�̳�unity�������е���";
            UIBase uibase = appDomain.Instantiate<UIBase>(pName);
            int id = (int)appDomain.Invoke(pName, "get_MyID", uibase, null);
            Debug.Log(id);
            appDomain.Invoke(pName, "HandleEvent", uibase, 50);
            appDomain.Invoke(pName, "Open", uibase, "gcd");
        }


        unsafe void CLR�ض��򷽷�()
        {
            MethodInfo method = typeof(Debug).GetMethod("Log", new System.Type[] { typeof(object) });
            appDomain.RegisterCLRMethodRedirection(method, DLog);
        }
        public unsafe static StackObject* DLog(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            //ֻ��һ�����������Է���ָ����ǵ�ǰջָ��ESP - 1
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            //��һ������ΪESP -1�� �ڶ�������ΪESP - 2���Դ�����
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            //��ȡ����message��ֵ
            object message = StackObject.ToObject(ptr_of_this_method, __domain, __mStack);
            //��Ҫ�����ջ
            __intp.Free(ptr_of_this_method);
            //������������ǻ������ͣ�����int������ֱ��ͨ��int param = ptr_of_this_method->Value��ȡֵ��
            //���ھ���ԭ�����������������λ�ȡ����ο�ILRuntimeʵ��ԭ����ĵ���

            //ͨ��ILRuntime��Debug�ӿڻ�ȡ�����ȸ�DLL�Ķ�ջ
            string stackTrace = __domain.DebugService.GetStackTrace(__intp);
            Debug.Log(string.Format("{0}\n----------------\n{1}", message, stackTrace));

            return __ret;
        }
    }



