using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene111 : MonoBehaviour
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

//---------------------ȫ���л�/�ָ�
//using System.Runtime.InteropServices;
//using UnityEngine;

//public class WindowController : MonoBehaviour
//{
//    [DllImport("user32.dll", SetLastError = true)]
//    private static extern int GetSystemMetrics(int nIndex);
//    private const int SM_CXSCREEN = 0; // ����Ļ�ֱ��ʿ��
//    private const int SM_CYSCREEN = 1; // ����Ļ�ֱ��ʸ߶�
//    private const int SM_CYCAPTION = 4; // �������߶�
//    private const int SM_CXFULLSCREEN = 16; // ��󻯴��ڿ��(��ȥ������)
//    private const int SM_CYFULLSCREEN = 17; // ��󻯴��ڸ߶�(��ȥ������)
//    private const float INIT_WINDOW_RATE = 0.8f; // ��ʼ���ڱ���
//    private int screenWidth; // ��Ļ���
//    private int screenHeight; // ��Ļ�߶�
//    private int windowWidth; // ���ڿ��
//    private int windowHeight; // ���ڸ߶�

//    private void Awake()
//    {
//        screenWidth = GetSystemMetrics(SM_CXSCREEN);
//        screenHeight = GetSystemMetrics(SM_CYSCREEN);
//        windowWidth = (int)(screenWidth * INIT_WINDOW_RATE);
//        windowHeight = (int)(screenHeight * INIT_WINDOW_RATE);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (!Screen.fullScreen)
//            {
//                windowWidth = Screen.width;
//                windowHeight = Screen.height;
//                Screen.SetResolution(screenWidth, screenHeight, true);
//            }
//            else
//            {
//                Screen.SetResolution(windowWidth, windowHeight, false);
//            }
//        }
//    }
//}

//------------�˳���Ϸ
//if (Input.GetKeyDown(KeyCode.Q))
//{
//    Application.Quit(); //�˳���Ϸ
//}
//// ����֧�ֺ�̨����
//Application.runInBackground = true;

//-------------����
//ScreenCapture.CaptureScreenshot("Assets/Screenshot.png");

//--------------------scene1
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
 
//public class SceneController1 : MonoBehaviour
//{
//    private bool fullScreen = true;

//    private void Start()
//    {
//        Button jumpBtn = transform.GetComponent<Button>();
//        jumpBtn.onClick.AddListener(OnClickJump);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        { // ȫ����ָ�
//            fullScreen = !fullScreen;
//            Screen.fullScreen = fullScreen;
//        }
//        if (Input.GetKeyDown(KeyCode.Q))
//        { // �˳���Ϸ
//            Application.Quit();
//        }
//    }

//    private void OnClickJump()
//    { // �л�����
//        SceneManager.LoadScene("Scene2");
//        // SceneManager.LoadSceneAsync("Scene2");
//    }
//}

//---------------scene2
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
 
//public class SceneController2 : MonoBehaviour
//{
//    private bool fullScreen = true;

//    private void Start()
//    {
//        Button jumpBtn = transform.GetComponent<Button>();
//        jumpBtn.onClick.AddListener(OnClickJump);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        { // ȫ����ָ�
//            fullScreen = !fullScreen;
//            Screen.fullScreen = fullScreen;
//        }
//        if (Input.GetKeyDown(KeyCode.Q))
//        { // �˳���Ϸ
//            Application.Quit();
//        }
//    }

//    private void OnClickJump()
//    { // �л�����
//        SceneManager.LoadScene("Scene1");
//        // SceneManager.LoadSceneAsync("Scene1");
//    }
//}