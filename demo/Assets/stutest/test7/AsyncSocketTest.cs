using UnityEngine;
namespace Assets.stutest.test7
{
    public class AsyncSocketTest : MonoBehaviour
    {
        private BaseSocket socket; // �ͻ���/�����socket
        private string sendText; // ���͵���Ϣ
        private string receiveText; // ���յ���Ϣ
        private bool isSideInited = false; // �Ƿ��ѳ�ʼ���˲�
        private string sideTag = null; // �˲���, �����/�ͻ���

        private void Awake()
        {
            Application.runInBackground = true; // ֧�ֺ�̨����
        }

        private void OnGUI()
        {
            InitSide();
            initSideView();
        }

        private void InitSide()
        { // ��ʼ���˲�
            if (!isSideInited)
            {
                CreateServer();
                CreateClient();
            }
        }

        private void CreateServer()
        { // ����������
            if (GUILayout.Button("����������"))
            {
                socket = new AsyncSocketServer((msg) =>
                {
                    receiveText += msg + "\n";
                });
                sideTag = "�����";
                isSideInited = true;
            }
        }

        private void CreateClient()
        { // �����ͻ���
            if (GUILayout.Button("�����ͻ���"))
            {
                socket = new AsyncSocketClient((msg) =>
                {
                    receiveText += msg + "\n";
                });
                sideTag = "�ͻ���";
                isSideInited = true;
            }
        }

        private void initSideView()
        { // ��ʼ���˲����
            if (isSideInited)
            {
                GUILayout.Label(sideTag);
                sendText = GUILayout.TextField(sendText);
                if (GUILayout.Button("����"))
                {
                    socket.Send(sendText);
                }
                GUILayout.Label("���յ�����Ϣ: ");
                GUILayout.Label(receiveText);
            }
        }
    }
}