using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine;

public class Scoket222 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//-------------����������
//using System;
 
//public abstract class BaseSocket
//{
//    public virtual void OnAccept(IAsyncResult ar) { } // ����˽��յ����ӵĻص�����
//    public virtual void OnConnect(IAsyncResult ar) { } // �ͻ��������Ϸ���˵Ļص�����
//    public abstract void OnReceive(IAsyncResult ar); // ���յ���Ϣ�Ļص�����
//    public abstract void Send(string msg); // ������Ϣ
//}

//-----------------�����
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
 
//public class AsyncSocketServer : BaseSocket
//{
//    private Socket serverSocket; // �����ͨѶ����socket, ����������ĵ绰����ת�Ӹ��ͷ�
//    private Socket kefuScoket; // �ͷ�socket, ������ͻ�һ��һͨѶ
//    private Action<string> msgCallback; // ��Ϣ�ص�
//    private byte[] readBuff; // �յ���Ϣ�Ļ���

//    public AsyncSocketServer(Action<string> callback)
//    {
//        msgCallback = callback;
//        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);
//        serverSocket.Bind(endPoint); // ��ip�Ͷ˿�
//        serverSocket.Listen(1); // �����绰����, �������ͷ�����, �����0�������޸��ͷ�
//        serverSocket.BeginAccept(OnAccept, serverSocket); // �ӵ绰, ����ͷ��Ϳͻ�����һ��һͨ��, �յ��绰�ͻ�ص�OnAccept����
//    }

//    public override void OnAccept(IAsyncResult ar)
//    { // �пͻ�������ʱ, �ص��˷���
//        kefuScoket = serverSocket.EndAccept(ar);
//        msgCallback("�ͷ��ı��ض˿���: " + kefuScoket.LocalEndPoint.ToString());
//        msgCallback("�ͻ���Զ�̶˿���: " + kefuScoket.RemoteEndPoint.ToString());
//        readBuff = new byte[1024];
//        BeginReceive();
//        serverSocket.BeginAccept(OnAccept, serverSocket);
//    }

//    public override void OnReceive(IAsyncResult ar)
//    { // �յ���Ϣʱ, �ص��˷���
//        int count = serverSocket.EndReceive(ar);
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("�ͻ�������Ϣ: " + msg);
//        Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
//        BeginReceive();
//    }

//    public override void Send(string msg)
//    {
//        byte[] buffer = Encoding.UTF8.GetBytes(msg);
//        kefuScoket.Send(buffer);
//    }

//    private void BeginReceive()
//    {
//        kefuScoket.BeginReceive(
//            readBuff, // ��Ϣ����
//            0, readBuff.Length, // ��Ϣ���յ���ʼ���Լ�����
//            SocketFlags.None, // ��־
//            OnReceive, // ���յ���Ϣ�Ļص�
//            serverSocket // ״̬
//        );
//    }

//    ~AsyncSocketServer()
//    {
//        kefuScoket.Close();
//        serverSocket.Close();
//    }
//}

//--------------�ͻ���
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
 
//public class AsyncSocketClient : BaseSocket
//{
//    private Socket clientSocket; // �ͻ���socket
//    private Action<string> msgCallback; // ��Ϣ�ص�
//    private byte[] readBuff; // �յ���Ϣ�Ļ���

//    public AsyncSocketClient(Action<string> callback)
//    {
//        msgCallback = callback;
//        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
//        clientSocket.BeginConnect(endPoint, OnConnect, clientSocket); // ���ӷ�����
//    }

//    public override void OnConnect(IAsyncResult ar)
//    { // ���Ϸ�����ʱ, �ص��˷���
//        clientSocket.EndConnect(ar);
//        readBuff = new byte[1024];
//        BeginReceive();
//    }

//    public override void OnReceive(IAsyncResult ar)
//    { // �յ���Ϣʱ, �ص��˷���
//        Socket workingSocket = ar.AsyncState as Socket;
//        int count = workingSocket.EndReceive(ar);
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("�ͷ�������Ϣ: " + msg);
//        Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
//        BeginReceive();
//    }

//    public override void Send(string msg)
//    {
//        byte[] buffer = Encoding.UTF8.GetBytes(msg);
//        clientSocket.Send(buffer);
//    }

//    private void BeginReceive()
//    {
//        clientSocket.BeginReceive(
//            readBuff, // ��Ϣ����
//            0, readBuff.Length, // ��Ϣ���յ���ʼ���Լ�����
//            SocketFlags.None, // ��־
//            OnReceive, // ���յ���Ϣ�Ļص�
//            clientSocket // ״̬
//        );
//    }

//    ~AsyncSocketClient()
//    {
//        clientSocket.Close();
//    }
//}

//--------------------������
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;

//public class AsyncSocketClient : BaseSocket
//{
//    private Socket clientSocket; // �ͻ���socket
//    private Action<string> msgCallback; // ��Ϣ�ص�
//    private byte[] readBuff; // �յ���Ϣ�Ļ���

//    public AsyncSocketClient(Action<string> callback)
//    {
//        msgCallback = callback;
//        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
//        clientSocket.BeginConnect(endPoint, OnConnect, clientSocket); // ���ӷ�����
//    }

//    public override void OnConnect(IAsyncResult ar)
//    { // ���Ϸ�����ʱ, �ص��˷���
//        clientSocket.EndConnect(ar);
//        readBuff = new byte[1024];
//        BeginReceive();
//    }

//    public override void OnReceive(IAsyncResult ar)
//    { // �յ���Ϣʱ, �ص��˷���
//        Socket workingSocket = ar.AsyncState as Socket;
//        int count = workingSocket.EndReceive(ar);
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("�ͷ�������Ϣ: " + msg);
//        Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
//        BeginReceive();
//    }

//    public override void Send(string msg)
//    {
//        byte[] buffer = Encoding.UTF8.GetBytes(msg);
//        clientSocket.Send(buffer);
//    }

//    private void BeginReceive()
//    {
//        clientSocket.BeginReceive(
//            readBuff, // ��Ϣ����
//            0, readBuff.Length, // ��Ϣ���յ���ʼ���Լ�����
//            SocketFlags.None, // ��־
//            OnReceive, // ���յ���Ϣ�Ļص�
//            clientSocket // ״̬
//        );
//    }

//    ~AsyncSocketClient()
//    {
//        clientSocket.Close();
//    }
//}