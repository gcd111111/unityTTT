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
//Scoket基本操作接口
public interface BaseSocket
{
    void Listening(); // 监听连接, 监听消息
    void Receive(); // 接收到消息
    void Send(string msg); // 发送消息
}

//------------------服务端
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
 
//public class SyncSocketServer : BaseSocket
//{
//    private Socket serverSocket; // 服务端通讯主机socket, 监听打进来的电话，并转接给客服
//    private Socket kefuScoket; // 客服socket, 负责与客户一对一通讯
//    private Action<string> msgCallback; // 消息回调
//    private byte[] readBuff; // 收到消息的缓存

//    public SyncSocketServer(Action<string> callback)
//    {
//        msgCallback = callback;
//        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);
//        serverSocket.Bind(endPoint); // 绑定ip和端口
//        new Thread(() => {
//            Listening();
//        }).Start();
//    }

//    public void Listening()
//    {
//        serverSocket.Listen(1); // 监听电话连接, 设置最大客服人数, 如果是0就是无限个客服
//        kefuScoket = serverSocket.Accept(); // 接电话, 分配客服和客户进行一对一通信, 没有电话打进来就会一直阻塞
//        msgCallback("客服的本地端口是: " + kefuScoket.LocalEndPoint.ToString());
//        msgCallback("客户的远程端口是: " + kefuScoket.RemoteEndPoint.ToString());
//        readBuff = new byte[1024];
//        while (true)
//        {
//            Receive();
//        }
//    }

//    public void Receive()
//    {
//        Array.Clear(readBuff, 0, readBuff.Length); // 清空缓存
//        int count = kefuScoket.Receive(readBuff); // 收到消息, 并存放在缓冲区, 没有消息就会一直阻塞
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("客户端发来消息: " + msg);
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

//-----------------客服端
//using System;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
 
//public class SyncSocketClient : BaseSocket
//{
//    private Socket clientSocket; // 客户端socket
//    private Action<string> msgCallback; // 消息回调
//    private byte[] readBuff; // 收到消息的缓存

//    public SyncSocketClient(Action<string> callback)
//    {
//        msgCallback = callback;
//        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        new Thread(() => {
//            clientSocket.Connect("127.0.0.1", 12345); //连接服务器, 未连接上就会一直阻塞
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
//        Array.Clear(readBuff, 0, readBuff.Length); // 清空缓存
//        int count = clientSocket.Receive(readBuff); // 收到消息, 并存放在缓冲区, 没有消息就会一直阻塞
//        string msg = Encoding.UTF8.GetString(readBuff, 0, count);
//        msgCallback("客服发来消息: " + msg);
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

//----------------测试类
//using UnityEngine;
 
//public class SyncSocketTest : MonoBehaviour
//{
//    private BaseSocket socket; // 客户端/服务端socket
//    private string sendText; // 发送的消息
//    private string receiveText; // 接收的消息
//    private bool isSideInited = false; // 是否已初始化端测
//    private string sideTag = null; // 端测标记, 服务端/客户端

//    private void Awake()
//    {
//        Application.runInBackground = true; // 支持后台运行
//    }

//    private void OnGUI()
//    {
//        InitSide();
//        initSideView();
//    }

//    private void InitSide()
//    { // 初始化端测
//        if (!isSideInited)
//        {
//            CreateServer();
//            CreateClient();
//        }
//    }

//    private void CreateServer()
//    { // 创建服务器
//        if (GUILayout.Button("创建服务器"))
//        {
//            socket = new SyncSocketServer((msg) => {
//                receiveText += msg + "\n";
//            });
//            sideTag = "服务端";
//            isSideInited = true;
//        }
//    }

//    private void CreateClient()
//    { // 创建客户端
//        if (GUILayout.Button("创建客户端"))
//        {
//            socket = new SyncSocketClient((msg) => {
//                receiveText += msg + "\n";
//            });
//            sideTag = "客户端";
//            isSideInited = true;
//        }
//    }

//    private void initSideView()
//    { // 初始化端测界面
//        if (isSideInited)
//        {
//            GUILayout.Label(sideTag);
//            sendText = GUILayout.TextField(sendText);
//            if (GUILayout.Button("发送"))
//            {
//                socket.Send(sendText);
//            }
//            GUILayout.Label("接收到的消息: ");
//            GUILayout.Label(receiveText);
//        }
//    }
//}