using System.Collections;
using System.Collections.Generic;
using Unity.Model;
using UnityEngine;

namespace HotFix
{
    public class �̳�unity�������е��� : UIBase
    {
        public override int MyID => 985211;

        public override void HandleEvent(int id)
        {
            Debug.Log("�����ǵ�������д��HandleEvent��������t�ǣ�" + id);
        }

        public override void Open(string text)
        {
            Debug.Log($"�����ǵ�������д��Open��������text��{text}");
        }
    }
}

