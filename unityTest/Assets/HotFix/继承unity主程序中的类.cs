using System.Collections;
using System.Collections.Generic;
using Unity.Model;
using UnityEngine;

namespace HotFix
{
    public class 继承unity主程序中的类 : UIBase
    {
        public override int MyID => 985211;

        public override void HandleEvent(int id)
        {
            Debug.Log("现在是调用了重写的HandleEvent方法参数t是：" + id);
        }

        public override void Open(string text)
        {
            Debug.Log($"现在是调用了重写的Open方法参数text：{text}");
        }
    }
}

