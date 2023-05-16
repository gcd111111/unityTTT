using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Assets.stutest.test7
{
    public class AsyncSocketServer : BaseSocket
    {
        private Socket serverSocket; // 服务端通讯主机socket, 监听打进来的电话，并转接给客服
        private Socket kefuScoket; // 客服socket, 负责与客户一对一通讯
        private Action<string> msgCallback; // 消息回调
        private byte[] readBuff; // 收到消息的缓存

        public AsyncSocketServer(Action<string> callback)
        {
            msgCallback = callback;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);
            serverSocket.Bind(endPoint); // 绑定ip和端口
            serverSocket.Listen(1); // 监听电话连接, 设置最大客服人数, 如果是0就是无限个客服
            serverSocket.BeginAccept(OnAccept, serverSocket); // 接电话, 分配客服和客户进行一对一通信, 收到电话就会回调OnAccept方法
        }

        public override void OnAccept(IAsyncResult ar)
        { // 有客户连接上时, 回调此方法
            kefuScoket = serverSocket.EndAccept(ar);
            msgCallback("客服的本地端口是: " + kefuScoket.LocalEndPoint.ToString());
            msgCallback("客户的远程端口是: " + kefuScoket.RemoteEndPoint.ToString());
            readBuff = new byte[1024];
            BeginReceive();
            serverSocket.BeginAccept(OnAccept, serverSocket);
        }

        public override void OnReceive(IAsyncResult ar)
        { // 收到消息时, 回调此方法
            int count = serverSocket.EndReceive(ar);
            string msg = Encoding.UTF8.GetString(readBuff, 0, count);
            msgCallback("客户发来消息: " + msg);
            Array.Clear(readBuff, 0, readBuff.Length); // 清空缓存
            BeginReceive();
        }

        public override void Send(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            kefuScoket.Send(buffer);
        }

        private void BeginReceive()
        {
            kefuScoket.BeginReceive(
                readBuff, // 消息缓存
                0, readBuff.Length, // 消息接收的起始点以及长度
                SocketFlags.None, // 标志
                OnReceive, // 接收到消息的回调
                serverSocket // 状态
            );
        }

        ~AsyncSocketServer()
        {
            kefuScoket.Close();
            serverSocket.Close();
        }
    }
}