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

//---------------------全屏切换/恢复
//using System.Runtime.InteropServices;
//using UnityEngine;

//public class WindowController : MonoBehaviour
//{
//    [DllImport("user32.dll", SetLastError = true)]
//    private static extern int GetSystemMetrics(int nIndex);
//    private const int SM_CXSCREEN = 0; // 主屏幕分辨率宽度
//    private const int SM_CYSCREEN = 1; // 主屏幕分辨率高度
//    private const int SM_CYCAPTION = 4; // 标题栏高度
//    private const int SM_CXFULLSCREEN = 16; // 最大化窗口宽度(减去任务栏)
//    private const int SM_CYFULLSCREEN = 17; // 最大化窗口高度(减去任务栏)
//    private const float INIT_WINDOW_RATE = 0.8f; // 初始窗口比例
//    private int screenWidth; // 屏幕宽度
//    private int screenHeight; // 屏幕高度
//    private int windowWidth; // 窗口宽度
//    private int windowHeight; // 窗口高度

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

//------------退出游戏
//if (Input.GetKeyDown(KeyCode.Q))
//{
//    Application.Quit(); //退出游戏
//}
//// 设置支持后台运行
//Application.runInBackground = true;

//-------------截屏
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
//        { // 全屏与恢复
//            fullScreen = !fullScreen;
//            Screen.fullScreen = fullScreen;
//        }
//        if (Input.GetKeyDown(KeyCode.Q))
//        { // 退出游戏
//            Application.Quit();
//        }
//    }

//    private void OnClickJump()
//    { // 切换场景
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
//        { // 全屏与恢复
//            fullScreen = !fullScreen;
//            Screen.fullScreen = fullScreen;
//        }
//        if (Input.GetKeyDown(KeyCode.Q))
//        { // 退出游戏
//            Application.Quit();
//        }
//    }

//    private void OnClickJump()
//    { // 切换场景
//        SceneManager.LoadScene("Scene1");
//        // SceneManager.LoadSceneAsync("Scene1");
//    }
//}