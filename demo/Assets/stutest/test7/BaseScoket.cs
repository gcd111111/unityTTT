using System;

namespace Assets.stutest.test7
{
    public abstract class BaseSocket
    {
        public virtual void OnAccept(IAsyncResult ar) { } // 服务端接收到连接的回调函数
        public virtual void OnConnect(IAsyncResult ar) { } // 客户端连接上服务端的回调函数
        public abstract void OnReceive(IAsyncResult ar); // 接收到消息的回调函数
        public abstract void Send(string msg); // 发送消息
    }
}