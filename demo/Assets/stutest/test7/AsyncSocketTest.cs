using UnityEngine;
namespace Assets.stutest.test7
{
    public class AsyncSocketTest : MonoBehaviour
    {
        private BaseSocket socket; // 客户端/服务端socket
        private string sendText; // 发送的消息
        private string receiveText; // 接收的消息
        private bool isSideInited = false; // 是否已初始化端测
        private string sideTag = null; // 端测标记, 服务端/客户端

        private void Awake()
        {
            Application.runInBackground = true; // 支持后台运行
        }

        private void OnGUI()
        {
            InitSide();
            initSideView();
        }

        private void InitSide()
        { // 初始化端测
            if (!isSideInited)
            {
                CreateServer();
                CreateClient();
            }
        }

        private void CreateServer()
        { // 创建服务器
            if (GUILayout.Button("创建服务器"))
            {
                socket = new AsyncSocketServer((msg) =>
                {
                    receiveText += msg + "\n";
                });
                sideTag = "服务端";
                isSideInited = true;
            }
        }

        private void CreateClient()
        { // 创建客户端
            if (GUILayout.Button("创建客户端"))
            {
                socket = new AsyncSocketClient((msg) =>
                {
                    receiveText += msg + "\n";
                });
                sideTag = "客户端";
                isSideInited = true;
            }
        }

        private void initSideView()
        { // 初始化端测界面
            if (isSideInited)
            {
                GUILayout.Label(sideTag);
                sendText = GUILayout.TextField(sendText);
                if (GUILayout.Button("发送"))
                {
                    socket.Send(sendText);
                }
                GUILayout.Label("接收到的消息: ");
                GUILayout.Label(receiveText);
            }
        }
    }
}