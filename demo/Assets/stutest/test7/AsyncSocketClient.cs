using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Assets.stutest.test7
{
    public class AsyncSocketClient : BaseSocket
    {
        private Socket clientSocket; // �ͻ���socket
        private Action<string> msgCallback; // ��Ϣ�ص�
        private byte[] readBuff; // �յ���Ϣ�Ļ���

        public AsyncSocketClient(Action<string> callback)
        {
            msgCallback = callback;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            clientSocket.BeginConnect(endPoint, OnConnect, clientSocket); // ���ӷ�����
        }

        public override void OnConnect(IAsyncResult ar)
        { // ���Ϸ�����ʱ, �ص��˷���
            clientSocket.EndConnect(ar);
            readBuff = new byte[1024];
            BeginReceive();
        }

        public override void OnReceive(IAsyncResult ar)
        { // �յ���Ϣʱ, �ص��˷���
            Socket workingSocket = ar.AsyncState as Socket;
            int count = workingSocket.EndReceive(ar);
            string msg = Encoding.UTF8.GetString(readBuff, 0, count);
            msgCallback("�ͷ�������Ϣ: " + msg);
            Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
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
                readBuff, // ��Ϣ����
                0, readBuff.Length, // ��Ϣ���յ���ʼ���Լ�����
                SocketFlags.None, // ��־
                OnReceive, // ���յ���Ϣ�Ļص�
                clientSocket // ״̬
            );
        }

        ~AsyncSocketClient()
        {
            clientSocket.Close();
        }
    }
}