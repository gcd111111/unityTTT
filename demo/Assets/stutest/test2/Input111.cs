using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void InputShow()
    {
        //// 按住按键
        //public static bool GetKey(KeyCode key)
        //// 按下按键
        //public static bool GetKeyDown(KeyCode key)
        //// 抬起按键
        //public static bool GetKeyUp(KeyCode key)

        //-----------------KeyCode取值
        //A~Z
        //F1~F15
        //// 键盘顶部的数字
        //Alpha0~Alpha9
        //Left、RightArrow、UpArrow、DownArrow
        //LeftCtrl、LeftShift、LeftAlt、LeftWindows、RightCtrl、RightShift、RightAlt、RightWindows
        //        Tab、Space、Backspace、Return
        //        // 加号、减号、星号、斜杠、反斜杠、左括号、右括号、小于号、大于号、等于号、上尖号
        //Plus、Minus、Asterisk、Slash、Backslash、LeftBracket、RightBracket、Less、Greater、Equals、Caret
        //        // 逗号、点号、问号、分号、冒号、单引号、反引号、双引号、感叹号
        //Comma、Period、Question、Semicolon、Colon、Quote、BackQuote、DoubleQuote、Exclaim
        //// @符号、$符号、&符号、下划线
        //At、Dollar、Ampersand、Underscore
        //Insert、Delete、Home、End、PageUp、PageDown、Print
        //CapsLock、Numlock、ScrollLock
        //        Keypad0~Keypad9、KeypadPeriod
        //KeypadPlus、KeypadMinus、KeypadMultiply、KeypadDivide
        //KeypadEquals、KeypadEnter
        //// 鼠标左键、鼠标右键、鼠标中间
        //Mouse0、Mouse1、Mouse2

        //---------------鼠标输入
        //// 按住鼠标
        //public static bool GetMouseButton(int button)
        //// 按下鼠标
        //public static bool GetMouseButtonDown(int button)
        //// 抬起鼠标
        //public static bool GetMouseButtonUp(int button)
        //// 鼠标坐标
        //Vector3 position = Input.mousePosition

        //----------------虚拟轴与按键，需要设置
        // 按左右箭头或A、D键，hor在-1~1之间变化
        //float hor = Input.GetAxis("Horizontal");
        //// 按上下箭头或W、S键，hor在-1~1之间变化
        //float ver = Input.GetAxis("Vertical");
        //// 获取鼠标在水平方向上的移动
        //float mouseX = Input.GetAxis("Mouse X");
        //// 获取鼠标在竖直方向上的移动
        //float mouseY = Input.GetAxis("Mouse Y");
        //// 获取滚轮信息, 上滑为正, 下滑为负
        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //// 按住虚拟按键
        //public static bool GetButton(string buttonName)
        //// 按下虚拟按键
        //public static bool GetButtonDown(string buttonName)
        //// 抬起虚拟按键
        //public static bool GetButtonUp(string buttonName)
        //// 按以上配置，按住Q键或鼠标左键返回true，表示开火了
        //bool fire = Input.GetButton("Fire");

      
    }
    //-----------------鼠标回调方法
    private void OnMouseEnter()
    { // 鼠标进入碰撞体时回调
        Debug.Log("OnMouseEnter");
    }

    private void OnMouseOver()
    { // 鼠标悬浮在碰撞体上回调
        Debug.Log("OnMouseOver");
    }

    private void OnMouseExit()
    { // 鼠标离开碰撞体时回调
        Debug.Log("OnMouseExit");
    }

    private void OnMouseDown()
    { // 鼠标在碰撞体上按下了左键时回调
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp()
    { // 鼠标在碰撞体上按下了左键, 并且抬起时回调(此时不一定悬浮在碰撞体上)
        Debug.Log("OnMouseUp");
    }

    private void OnMouseUpAsButton()
    { // 鼠标按下和抬起都在同一个碰撞体上, 并且抬起了鼠标左键时回调
        Debug.Log("OnMouseUpAsButton");
    }

    private void OnMouseDrag()
    { // 鼠标在碰撞体上按下, 并拖拽时回调(拖拽过程中不一定悬浮在碰撞体上)
        Debug.Log("OnMouseDrag");
    }


}
