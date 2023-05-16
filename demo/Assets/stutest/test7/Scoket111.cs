using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

public class Scoket111 : MonoBehaviour
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
//Scoket���������ӿ�
public interface BaseSocket
{
    void Listening(); // ��������, ������Ϣ
    void Receive(); // ���յ���Ϣ
    void Send(string msg); // ������Ϣ
}

//------------------�����
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
 
//public class SyncSocketServer : BaseSocket
//{
//    private Socket serverSocket; // �����ͨѶ����socket, ����������ĵ绰����ת�Ӹ��ͷ�
//    private Socket kefuScoket; // �ͷ�socket, ������ͻ�һ��һͨѶ
//    private Action<string> msgCallback; // ��Ϣ�ص�
//    private byte[] readBuff; // �յ���Ϣ�Ļ���

//    public SyncSocketServer(Action<string> callback)
//    {
//        msgCallback = callback;
//        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);
//        serverSocket.Bind(endPoint); // ��ip�Ͷ˿�
//        new Thread(() => {
//            Listening();
//        }).Start();
//    }

//    public void Listening()
//    {
//        serverSocket.Listen(1); // �����绰����, �������ͷ�����, �����0�������޸��ͷ�
//        kefuScoket = serverSocket.Accept(); // �ӵ绰, ����ͷ��Ϳͻ�����һ��һͨ��, û�е绰������ͻ�һֱ����
//        msgCallback("�ͷ��ı��ض˿���: " + kefuScoket.LocalEndPoint.ToString());
//        msgCallback("�ͻ���Զ�̶˿���: " + kefuScoket.RemoteEndPoint.ToString());
//        readBuff = new byte[1024];
//        while (true)
//        {
//            Receive();
//        }
//    }

//    public void Receive()
//    {
//        Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
//        int count = kefuScoket.Receive(readBuff); // �յ���Ϣ, ������ڻ�����, û����Ϣ�ͻ�һֱ����
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("�ͻ��˷�����Ϣ: " + msg);
//    }

//    public void Send(string msg)
//    {
//        byte[] buffer = Encoding.UTF8.GetBytes(msg);
//        kefuScoket.Send(buffer);
//    }

//    ~SyncSocketServer()
//    {
//        kefuScoket.Close();
//        serverSocket.Close();
//    }
//}

//-----------------�ͷ���
//using System;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
 
//public class SyncSocketClient : BaseSocket
//{
//    private Socket clientSocket; // �ͻ���socket
//    private Action<string> msgCallback; // ��Ϣ�ص�
//    private byte[] readBuff; // �յ���Ϣ�Ļ���

//    public SyncSocketClient(Action<string> callback)
//    {
//        msgCallback = callback;
//        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        new Thread(() => {
//            clientSocket.Connect("127.0.0.1", 12345); //���ӷ�����, δ�����Ͼͻ�һֱ����
//            Listening();
//        }).Start();
//    }

//    public void Listening()
//    {
//        readBuff = new byte[1024];
//        while (true)
//        {
//            Receive();
//        }
//    }

//    public void Receive()
//    {
//        Array.Clear(readBuff, 0, readBuff.Length); // ��ջ���
//        int count = clientSocket.Receive(readBuff); // �յ���Ϣ, ������ڻ�����, û����Ϣ�ͻ�һֱ����
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("�ͷ�������Ϣ: " + msg);
//    }

//    public void Send(string msg)
//    {
//        byte[] buffer = Encoding.UTF8.GetBytes(msg);
//        clientSocket.Send(buffer);
//    }

//    ~SyncSocketClient()
//    {
//        clientSocket.Close();
//    }
//}

//----------------������
//using UnityEngine;
 
//public class SyncSocketTest : MonoBehaviour
//{
//    private BaseSocket socket; // �ͻ���/�����socket
//    private string sendText; // ���͵���Ϣ
//    private string receiveText; // ���յ���Ϣ
//    private bool isSideInited = false; // �Ƿ��ѳ�ʼ���˲�
//    private string sideTag = null; // �˲���, �����/�ͻ���

//    private void Awake()
//    {
//        Application.runInBackground = true; // ֧�ֺ�̨����
//    }

//    private void OnGUI()
//    {
//        InitSide();
//        initSideView();
//    }

//    private void InitSide()
//    { // ��ʼ���˲�
//        if (!isSideInited)
//        {
//            CreateServer();
//            CreateClient();
//        }
//    }

//    private void CreateServer()
//    { // ����������
//        if (GUILayout.Button("����������"))
//        {
//            socket = new SyncSocketServer((msg) => {
//                receiveText += msg + "\n";
//            });
//            sideTag = "�����";
//            isSideInited = true;
//        }
//    }

//    private void CreateClient()
//    { // �����ͻ���
//        if (GUILayout.Button("�����ͻ���"))
//        {
//            socket = new SyncSocketClient((msg) => {
//                receiveText += msg + "\n";
//            });
//            sideTag = "�ͻ���";
//            isSideInited = true;
//        }
//    }

//    private void initSideView()
//    { // ��ʼ���˲����
//        if (isSideInited)
//        {
//            GUILayout.Label(sideTag);
//            sendText = GUILayout.TextField(sendText);
//            if (GUILayout.Button("����"))
//            {
//                socket.Send(sendText);
//            }
//            GUILayout.Label("���յ�����Ϣ: ");
//            GUILayout.Label(receiveText);
//        }
//    }
//}