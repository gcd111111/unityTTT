using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix//�����������Ҫ�����ʵ������ռ�
{
    public class Test
    {
        #region ����

        public Test()
        {
            Debug.Log("�����޲ι��캯��");
        }

        public Test(string text)
        {
            Debug.Log($"�����вι��캯��string text��   {text}");
        }

        public static void �޲κ���()
        {
            Debug.Log("���Ǿ�̬�޲κ����޷��غ���");
        }

        public static void ��һ��������(string text)
        {
            Debug.Log("���Ǿ�̬��һ��string���������޷��غ�����   " + text);
        }

        public static void �ж�κ���(string text1, string text2)
        {
            Debug.Log($"���Ǿ�̬�ж�������޷��غ���" +
                      $"string  text1��   {text1}   string text2:   {text2}");
        }

        public static void �����ͬ���������޷��غ���(string text, int m)
        {
            Debug.Log($"���Ǿ�̬�ж����ͬ���������޷��غ��� " +
                      $"  string text��   {text}    int m:   {m}");
        }

        public static void Log()
        {
            Debug.Log("�޲��޷���Log����");
        }

        public static void Log(string text)
        {
            Debug.Log($"��һ��string�����޷���Log���� text��   {text}");
        }

        public static void Log(string text, int m)
        {
            Debug.Log($"��һ��string����һ��int�κ����޷���Log���� text��   {text}      m:     {m}");
        }

        public static int �޲κ����з���ֵ()
        {
            Debug.Log("���Ǿ�̬�޲κ����з��غ���");
            return 1;
        }

        public static int ��һ���������з���(string text)
        {
            Debug.Log("���Ǿ�̬��һ��string���������з��غ�����   " + text);
            return 2;
        }

        public static int �ж�κ����з���(string text1, string text2)
        {
            Debug.Log($"���Ǿ�̬�ж�������з��غ���" +
                      $"string  text1��   {text1}   string text2:   {text2}");
            return 3;
        }

        public static int �����ͬ���������޷��غ����з���(string text, int m)
        {
            Debug.Log($"���Ǿ�̬�ж����ͬ���������з��غ��� " +
                      $"  string text��   {text}    int m:   {m}");
            return 4;
        }

        public void ��̬�޲�()
        {
            Debug.Log("���Ƕ�̬�޲��޷��غ���");
        }

        public void ��̬��һ�κ���(string text)
        {
            Debug.Log("���Ƕ�̬��һ��������  string text:     " + text);
        }

        public int ��̬�޲��з���ֵ()
        {
            Debug.Log("���Ƕ�̬�޲��з��غ���");
            return 1;
        }

        public int ��̬��һ�κ����з���ֵ(string text)
        {
            Debug.Log("���Ƕ�̬��һ�����з���ֵ����  string text:     " + text);
            return 2;
        }

        #endregion

        #region �ֶα���

        private int id = 5000;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        #endregion

        #region ���ͺ���

        public void ���ͺ���<T>(T t)
        {
            Debug.Log($"���Ƿ��ͺ��������ǣ�{t}");
        }


        #endregion

        #region UnityActionί�е���

        public void ButtonClick()
        {
            Button button = GameObject.Find("Canvas/Test").GetComponent<Button>();
            button.onClick.AddListener(OnClike);//�����ע����ӵ���UnityActionί������
        }

        private void OnClike()
        {
            Debug.Log("�����Test��ť");
        }


        #endregion

        #region ����ί��delegate Func Action

        public delegate void Delegateί��();
        public Action<int> actionί��;
        public Func<int, int> funcί��;

        public void ע��delegateί��()
        {
            Debug.Log("ʹ����delegateί��");
        }
        public void ע��Actionί��(int n)
        {
            Debug.Log($"ʹ����Actionί��,������n:   {n}");
        }
        public int ע��Funcί��(int m)
        {
            Debug.Log($"ʹ����funcί��,������m��{m}");
            return m;
        }

        public void ������Щί��()
        {
            //���ȸ���Щί�н���ע��
            Delegateί�� delegateί�� = ע��delegateί��;
            actionί�� = ע��Actionί��;
            funcί�� = ע��Funcί��;


            //������Щί��
            delegateί��();
            actionί��(985);
            int m = funcί��(985211);
            Debug.Log(m);
        }


        #endregion
    }
}

