using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Model
{
    public abstract class UIBase
    {
        public virtual int MyID
        {
            get { return 100; }
        }

        public virtual void Open(string text)
        {
            Debug.Log("UIBase�е�Open����");
        }

        public abstract void HandleEvent(int id);

    }
}

