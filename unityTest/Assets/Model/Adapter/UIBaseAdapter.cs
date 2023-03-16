using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Model;
using UnityEngine;

public class UIBaseAdapter : CrossBindingAdaptor//这是一个接口，我们要实现里面的方法即可
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(UIBase);//这里的参数填写基类名字（哪个类被热更新问价继承就填哪个）
        }
    }

    public override Type[] BaseCLRTypes => base.BaseCLRTypes;

    public override Type AdaptorType
    {
        get { return typeof(Adapter); }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adapter(appdomain, instance);
    }


    class Adapter : UIBase, CrossBindingAdaptorType//继承基类，在继承这个接口，重写基类的方法，和实现接口方法，一定要有一个无参构造函数，下面的两个参数一个AppDomain和ILTyoeInstance的构造函数
    {
        private ILRuntime.Runtime.Enviorment.AppDomain appdomain;
        private ILTypeInstance instance;

        public Adapter()
        {

        }
        public Adapter(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance
        {
            get
            {
                return instance;
            }
        }
        //到这里我们都是按照上面的进行


        //下面开始进行适配方法和字段

        bool mGetMyIDGot = false;//定义一个标识未  标识是否已经缓存了热更里的方法get_xxx
        IMethod mGetMyID;//缓存获取到的方法
        bool isGetMyIDInvoking = false;//判断是否运行该方法
        public override int MyID
        {
            get
            {
                if (mGetMyIDGot == false)
                {
                    //字段获取的话就是根据属性一样获取get__xxx方法
                    mGetMyID = instance.Type.GetMethod("get_MyID", 0);
                    mGetMyIDGot = true;
                }

                if (mGetMyID != null && isGetMyIDInvoking == false)
                {
                    isGetMyIDInvoking = true;
                    int m = (int)appdomain.Invoke(mGetMyID, instance, null);
                    isGetMyIDInvoking = false;
                    return m;
                }
                return base.MyID;
            }
        }


        IMethod mHandleEvent;
        bool isHandleEventCalled = false;
        object[] parame1 = new object[1];//参数列表
        public override void HandleEvent(int id)
        {
            if (mHandleEvent == null)
            {
                mHandleEvent = instance.Type.GetMethod("HandleEvent", 1);
            }
            if (mHandleEvent != null)
            {
                parame1[0] = id;
                appdomain.Invoke(mHandleEvent, instance, parame1);
            }
        }


        bool mOpenGot = false;
        IMethod mOpen;
        bool isOpenCalled = false;
        object[] paream2 = new object[1];
        public override void Open(string text)
        {
            if (mOpenGot == false)
            {
                mOpen = instance.Type.GetMethod("Open", 1);
            }
            if (mOpen != null && isOpenCalled == false)
            {
                isOpenCalled = true;
                paream2[0] = text;
                appdomain.Invoke(mOpen, instance, paream2);
                isOpenCalled = false;
            }
            else
            {
                base.Open(text);
            }
        }
    }
}

