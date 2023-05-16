using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Assets.stutest.test7
{
    public class AsyncSocketClient : BaseSocket
    {
        private Socket clientSocket; // 客户端socket
        private Action<string> msgCallback; // 消息回调
        private byte[] readBuff; // 收到消息的缓存

        public AsyncSocketClient(Action<string> callback)
        {
            msgCallback = callback;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            clientSocket.BeginConnect(endPoint, OnConnect, clientSocket); // 连接服务器
        }

        public override void OnConnect(IAsyncResult ar)
        { // 连上服务器时, 回调此方法
            clientSocket.EndConnect(ar);
            readBuff = new byte[1024];
            BeginReceive();
        }

        public override void OnReceive(IAsyncResult ar)
        { // 收到消息时, 回调此方法
            Socket workingSocket = ar.AsyncState as Socket;
            int count = workingSocket.EndReceive(ar);
            string msg = Encoding.UTF8.GetString(readBuff, 0, count);
            msgCallback("客服发来消息: " + msg);
            Array.Clear(readBuff, 0, readBuff.Length); // 清空缓存
            BeginReceive();
        }

        public override void Send(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(buffer);
        }

        private void BeginReceive()
        {
            clientSocket.BeginReceive(
                readBuff, // 消息缓存
                0, readBuff.Length, // 消息接收的起始点以及长度
                SocketFlags.None, // 标志
                OnReceive, // 接收到消息的回调
                clientSocket // 状态
            );
        }

        ~AsyncSocketClient()
        {
            clientSocket.Close();
        }
    }
}