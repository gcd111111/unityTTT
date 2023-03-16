using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Model;
using UnityEngine;

public class UIBaseAdapter : CrossBindingAdaptor//����һ���ӿڣ�����Ҫʵ������ķ�������
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(UIBase);//����Ĳ�����д�������֣��ĸ��౻�ȸ����ʼۼ̳о����ĸ���
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


    class Adapter : UIBase, CrossBindingAdaptorType//�̳л��࣬�ڼ̳�����ӿڣ���д����ķ�������ʵ�ֽӿڷ�����һ��Ҫ��һ���޲ι��캯�����������������һ��AppDomain��ILTyoeInstance�Ĺ��캯��
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
        //���������Ƕ��ǰ�������Ľ���


        //���濪ʼ�������䷽�����ֶ�

        bool mGetMyIDGot = false;//����һ����ʶδ  ��ʶ�Ƿ��Ѿ��������ȸ���ķ���get_xxx
        IMethod mGetMyID;//�����ȡ���ķ���
        bool isGetMyIDInvoking = false;//�ж��Ƿ����и÷���
        public override int MyID
        {
            get
            {
                if (mGetMyIDGot == false)
                {
                    //�ֶλ�ȡ�Ļ����Ǹ�������һ����ȡget__xxx����
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
        object[] parame1 = new object[1];//�����б�
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

