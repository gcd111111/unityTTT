//using UnityEngine;

//public class SceneController : MonoBehaviour
//{
//    private Texture2D[] cursorTextures; // �����ʽ: ��ͷ��С�֡��۾�
//    private Transform cam; // ���
//    private float nearPlan; // ��ƽ��
//    private Vector3 preMousePos; // ��һ֡���������
//    private int cursorStatus = 0; // �����ʽ״̬
//    private bool isDraging = false; // �Ƿ�����ק��

//    private void Awake()
//    {
//        string[] mouseIconPath = new string[] { "MouseIcon/0_arrow", "MouseIcon/1_hand", "MouseIcon/2_eye" };
//        cursorTextures = new Texture2D[mouseIconPath.Length];
//        for (int i = 0; i < mouseIconPath.Length; i++)
//        {
//            cursorTextures[i] = Resources.Load<Texture2D>(mouseIconPath[i]);
//        }
//        cam = Camera.main.transform;
//        Vector3 angle = cam.eulerAngles;
//        cam.eulerAngles = new Vector3(angle.x, angle.y, 0); // ʹcamp.rightָ��ˮƽ����
//        nearPlan = Camera.main.nearClipPlane;
//    }

//    private void Update()
//    {
//        cursorStatus = GetCursorStatus();
//        // ���������ʽ, �ڶ���������ʾ�����λ����ͼ���е�λ��, zero��ʾ���Ͻ�
//        Cursor.SetCursor(cursorTextures[cursorStatus], Vector2.zero, CursorMode.Auto);
//        UpdateScene(); // ���³���(Ctrl+Scroll: ���ų���, Ctrl+Drag: ƽ�Ƴ���, Alt+Drag: ��ת����)
//    }

//    private int GetCursorStatus()
//    { // ��ȡ���״̬(0: ��ͷ, 1: С��, 2: �۾�)
//        if (isDraging)
//        {
//            return cursorStatus;
//        }
//        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftControl))
//        {
//            return 1;
//        }
//        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt))
//        {
//            return 2;
//        }
//        return 0;
//    }

//    private void UpdateScene()
//    { // ���³���(Ctrl+Scroll: ���ų���, Ctrl+Drag: ƽ�Ƴ���, Alt+Drag: ��ת����)
//        float scroll = Input.GetAxis("Mouse ScrollWheel");
//        if (!isDraging && cursorStatus == 1 && Mathf.Abs(scroll) > 0)
//        { // ���ų���
//            ScaleScene(scroll);
//        }
//        else if (Input.GetMouseButtonDown(0))
//        {
//            preMousePos = Input.mousePosition;
//            isDraging = true;
//        }
//        else if (Input.GetMouseButtonUp(0))
//        {
//            isDraging = false;
//        }
//        else if (Input.GetMouseButton(0))
//        {
//            Vector3 offset = Input.mousePosition - preMousePos;
//            if (cursorStatus == 1)
//            { // �ƶ�����
//                MoveScene(offset);
//            }
//            else if (cursorStatus == 2)
//            { // ��ת����
//                RotateScene(offset);
//            }
//            preMousePos = Input.mousePosition;
//        }
//    }

//    private void ScaleScene(float scroll)
//    { // ���ų���
//        cam.position += cam.forward * scroll;
//    }

//    private void MoveScene(Vector3 offset)
//    { // ƽ�Ƴ���
//        cam.position -= (cam.right * offset.x / 100 + cam.up * offset.y / 100);
//    }

//    private void RotateScene(Vector3 offset)
//    { // ��ת����
//        Vector3 rotateCenter = GetRotateCenter(0);
//        cam.RotateAround(rotateCenter, Vector3.up, offset.x / 3); // ˮƽ��ק����
//        cam.LookAt(rotateCenter);
//        cam.RotateAround(rotateCenter, -cam.right, offset.y / 5); // ��ֱ��ק����
//    }

//    private Vector3 GetRotateCenter(float planeY)
//    { // ��ȡ��ת����
//        if (Mathf.Abs(cam.forward.y) < float.Epsilon || Mathf.Abs(cam.position.y) < float.Epsilon)
//        {
//            return cam.position + cam.forward * (nearPlan + 1 / nearPlan);
//        }
//        float t = (planeY - cam.position.y) / cam.forward.y;
//        float x = cam.position.x + t * cam.forward.x;
//        float z = cam.position.z + t * cam.forward.z;
//        return new Vector3(x, planeY, z);
//    }
//}

//----------------------�Ż�
using UnityEngine;
 
public class SceneController : MonoBehaviour
{
    private const float MAX_HALF_EDGE_X = 5f; // ��ͼx�᷽���߳�
    private const float MAX_HALF_EDGE_Z = 5f; // ��ͼz�᷽���߳�
    private Texture2D[] cursorTextures; // �����ʽ: ��ͷ��С�֡��۾�
    private Transform cam; // ���
    private float planeY = 0f; // ����߶�
    private Vector3 rotateCenter; // ��ת����
    private Vector3 focusCenter; // ����ڵ����ϵĽ�������
    private bool isFocusInMap; // ��������Ƿ��ڵ�ͼ��
    private Vector3 preMousePos; // ��һ֡���������
    private int cursorStatus = 0; // �����ʽ״̬
    private bool isDraging = false; // �Ƿ�����ק��

    private void Awake()
    {
        string[] mouseIconPath = new string[] { "MouseIcon/0_arrow", "MouseIcon/1_hand", "MouseIcon/2_eye" };
        cursorTextures = new Texture2D[mouseIconPath.Length];
        for (int i = 0; i < mouseIconPath.Length; i++)
        {
            cursorTextures[i] = Resources.Load<Texture2D>(mouseIconPath[i]);
        }
        cam = Camera.main.transform;
        Vector3 angle = cam.eulerAngles;
        cam.eulerAngles = new Vector3(angle.x, angle.y, 0); // ʹcamp.rightָ��ˮƽ����
        rotateCenter = new Vector3(0, planeY, 0);
        focusCenter = new Vector3(0, planeY, 0);
    }

    private void Update()
    {
        cursorStatus = GetCursorStatus();
        // ���������ʽ, �ڶ���������ʾ�����λ����ͼ���е�λ��, zero��ʾ���Ͻ�
        Cursor.SetCursor(cursorTextures[cursorStatus], Vector2.zero, CursorMode.Auto);
        UpdateScene(); // ���³���(Ctrl+Scroll: ���ų���, Ctrl+Drag: ƽ�Ƴ���, Alt+Drag: ��ת����)
    }

    private int GetCursorStatus()
    { // ��ȡ���״̬(0: ��ͷ, 1: С��, 2: �۾�)
        if (isDraging)
        {
            return cursorStatus;
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftControl))
        {
            return 1;
        }
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt))
        {
            return 2;
        }
        return 0;
    }

    private void UpdateScene()
    { // ���³���(Ctrl+Scroll: ���ų���, Ctrl+Drag: ƽ�Ƴ���, Alt+Drag: ��ת����)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (!isDraging && cursorStatus == 1 && Mathf.Abs(scroll) > 0)
        { // ���ų���
            ScaleScene(scroll);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
            UpdateRotateCenter();
            isDraging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 offset = Input.mousePosition - preMousePos;
            if (cursorStatus == 1)
            { // �ƶ�����
                MoveScene(offset);
            }
            else if (cursorStatus == 2)
            { // ��ת����
                RotateScene(offset);
            }
            preMousePos = Input.mousePosition;
        }
    }

    private void ScaleScene(float scroll)
    { // ���ų���
        cam.position += cam.forward * scroll;
    }

    private void MoveScene(Vector3 offset)
    { // ƽ�Ƴ���
        Vector3 horVec = Vector3.ProjectOnPlane(cam.right, Vector3.up).normalized;
        Vector3 verVec = Vector3.ProjectOnPlane(cam.up, Vector3.up).normalized;
        cam.position -= (horVec * offset.x / 100 + verVec * offset.y / 100);
    }

    private void RotateScene(Vector3 offset)
    { // ��ת����
        float hor = offset.x / 3;
        float ver = -offset.y / 5;
        cam.RotateAround(rotateCenter, Vector3.up, hor); // �������ת����ˮƽ��ת
        cam.RotateAround(rotateCenter, cam.right, ver); // �������ת������ֱ��ת
        // ����transform.RotateAround�������Ѿ�������������̬����, �����������Ƕ����
        // cam.RotateAround(cam.position, Vector3.up, hor); // �����ת, ʹ�䳯����ת����
        // cam.RotateAround(cam.position, cam.right, ver); // �����ת, ʹ�䳯����ת����
    }

    private void UpdateRotateCenter()
    { // ������ת����
        UpdateFocusStatus();
        if (!isFocusInMap)
        {
            return;
        }
        rotateCenter.x = Mathf.Clamp(focusCenter.x, -MAX_HALF_EDGE_X, MAX_HALF_EDGE_X);
        rotateCenter.z = Mathf.Clamp(focusCenter.z, -MAX_HALF_EDGE_Z, MAX_HALF_EDGE_Z);
    }

    private void UpdateFocusStatus()
    { // ���½���״̬
        isFocusInMap = true;
        Vector3 vec1 = new Vector3(0, planeY - cam.position.y, 0);
        Vector3 vec2 = cam.forward;
        if (Mathf.Abs(vec1.y) < float.Epsilon || Mathf.Abs(vec2.y) < float.Epsilon)
        {
            isFocusInMap = false;
            return;
        }
        float angle = Vector3.Angle(vec1, vec2);
        if (angle >= 90)
        { // ����ڵ������ϲ��ҳ���, ���ڵ������²��ҳ���
            isFocusInMap = false;
            return;
        }
        float t = (planeY - cam.position.y) / vec2.y;
        focusCenter.x = cam.position.x + t * vec2.x;
        focusCenter.z = cam.position.z + t * vec2.z;
        if (Mathf.Abs(focusCenter.x) > MAX_HALF_EDGE_X || Mathf.Abs(focusCenter.z) > MAX_HALF_EDGE_Z)
        { // ������㲻�ڵ�ͼ������
            isFocusInMap = false;
        }
    }
}