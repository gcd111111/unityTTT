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
        //// ��ס����
        //public static bool GetKey(KeyCode key)
        //// ���°���
        //public static bool GetKeyDown(KeyCode key)
        //// ̧�𰴼�
        //public static bool GetKeyUp(KeyCode key)

        //-----------------KeyCodeȡֵ
        //A~Z
        //F1~F15
        //// ���̶���������
        //Alpha0~Alpha9
        //Left��RightArrow��UpArrow��DownArrow
        //LeftCtrl��LeftShift��LeftAlt��LeftWindows��RightCtrl��RightShift��RightAlt��RightWindows
        //        Tab��Space��Backspace��Return
        //        // �Ӻš����š��Ǻš�б�ܡ���б�ܡ������š������š�С�ںš����ںš����ںš��ϼ��
        //Plus��Minus��Asterisk��Slash��Backslash��LeftBracket��RightBracket��Less��Greater��Equals��Caret
        //        // ���š���š��ʺš��ֺš�ð�š������š������š�˫���š���̾��
        //Comma��Period��Question��Semicolon��Colon��Quote��BackQuote��DoubleQuote��Exclaim
        //// @���š�$���š�&���š��»���
        //At��Dollar��Ampersand��Underscore
        //Insert��Delete��Home��End��PageUp��PageDown��Print
        //CapsLock��Numlock��ScrollLock
        //        Keypad0~Keypad9��KeypadPeriod
        //KeypadPlus��KeypadMinus��KeypadMultiply��KeypadDivide
        //KeypadEquals��KeypadEnter
        //// ������������Ҽ�������м�
        //Mouse0��Mouse1��Mouse2

        //---------------�������
        //// ��ס���
        //public static bool GetMouseButton(int button)
        //// �������
        //public static bool GetMouseButtonDown(int button)
        //// ̧�����
        //public static bool GetMouseButtonUp(int button)
        //// �������
        //Vector3 position = Input.mousePosition

        //----------------�������밴������Ҫ����
        // �����Ҽ�ͷ��A��D����hor��-1~1֮��仯
        //float hor = Input.GetAxis("Horizontal");
        //// �����¼�ͷ��W��S����hor��-1~1֮��仯
        //float ver = Input.GetAxis("Vertical");
        //// ��ȡ�����ˮƽ�����ϵ��ƶ�
        //float mouseX = Input.GetAxis("Mouse X");
        //// ��ȡ�������ֱ�����ϵ��ƶ�
        //float mouseY = Input.GetAxis("Mouse Y");
        //// ��ȡ������Ϣ, �ϻ�Ϊ��, �»�Ϊ��
        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //// ��ס���ⰴ��
        //public static bool GetButton(string buttonName)
        //// �������ⰴ��
        //public static bool GetButtonDown(string buttonName)
        //// ̧�����ⰴ��
        //public static bool GetButtonUp(string buttonName)
        //// ���������ã���סQ��������������true����ʾ������
        //bool fire = Input.GetButton("Fire");

      
    }
    //-----------------���ص�����
    private void OnMouseEnter()
    { // ��������ײ��ʱ�ص�
        Debug.Log("OnMouseEnter");
    }

    private void OnMouseOver()
    { // �����������ײ���ϻص�
        Debug.Log("OnMouseOver");
    }

    private void OnMouseExit()
    { // ����뿪��ײ��ʱ�ص�
        Debug.Log("OnMouseExit");
    }

    private void OnMouseDown()
    { // �������ײ���ϰ��������ʱ�ص�
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp()
    { // �������ײ���ϰ��������, ����̧��ʱ�ص�(��ʱ��һ����������ײ����)
        Debug.Log("OnMouseUp");
    }

    private void OnMouseUpAsButton()
    { // ��갴�º�̧����ͬһ����ײ����, ����̧����������ʱ�ص�
        Debug.Log("OnMouseUpAsButton");
    }

    private void OnMouseDrag()
    { // �������ײ���ϰ���, ����קʱ�ص�(��ק�����в�һ����������ײ����)
        Debug.Log("OnMouseDrag");
    }


}
