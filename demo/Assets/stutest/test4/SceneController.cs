//using UnityEngine;

//public class SceneController : MonoBehaviour
//{
//    private Texture2D[] cursorTextures; // 鼠标样式: 箭头、小手、眼睛
//    private Transform cam; // 相机
//    private float nearPlan; // 近平面
//    private Vector3 preMousePos; // 上一帧的鼠标坐标
//    private int cursorStatus = 0; // 鼠标样式状态
//    private bool isDraging = false; // 是否在拖拽中

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
//        cam.eulerAngles = new Vector3(angle.x, angle.y, 0); // 使camp.right指向水平方向
//        nearPlan = Camera.main.nearClipPlane;
//    }

//    private void Update()
//    {
//        cursorStatus = GetCursorStatus();
//        // 更新鼠标样式, 第二个参数表示鼠标点击位置在图标中的位置, zero表示左上角
//        Cursor.SetCursor(cursorTextures[cursorStatus], Vector2.zero, CursorMode.Auto);
//        UpdateScene(); // 更新场景(Ctrl+Scroll: 缩放场景, Ctrl+Drag: 平移场景, Alt+Drag: 旋转场景)
//    }

//    private int GetCursorStatus()
//    { // 获取鼠标状态(0: 箭头, 1: 小手, 2: 眼睛)
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
//    { // 更新场景(Ctrl+Scroll: 缩放场景, Ctrl+Drag: 平移场景, Alt+Drag: 旋转场景)
//        float scroll = Input.GetAxis("Mouse ScrollWheel");
//        if (!isDraging && cursorStatus == 1 && Mathf.Abs(scroll) > 0)
//        { // 缩放场景
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
//            { // 移动场景
//                MoveScene(offset);
//            }
//            else if (cursorStatus == 2)
//            { // 旋转场景
//                RotateScene(offset);
//            }
//            preMousePos = Input.mousePosition;
//        }
//    }

//    private void ScaleScene(float scroll)
//    { // 缩放场景
//        cam.position += cam.forward * scroll;
//    }

//    private void MoveScene(Vector3 offset)
//    { // 平移场景
//        cam.position -= (cam.right * offset.x / 100 + cam.up * offset.y / 100);
//    }

//    private void RotateScene(Vector3 offset)
//    { // 旋转场景
//        Vector3 rotateCenter = GetRotateCenter(0);
//        cam.RotateAround(rotateCenter, Vector3.up, offset.x / 3); // 水平拖拽分量
//        cam.LookAt(rotateCenter);
//        cam.RotateAround(rotateCenter, -cam.right, offset.y / 5); // 竖直拖拽分量
//    }

//    private Vector3 GetRotateCenter(float planeY)
//    { // 获取旋转中心
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

//----------------------优化
using UnityEngine;
 
public class SceneController : MonoBehaviour
{
    private const float MAX_HALF_EDGE_X = 5f; // 地图x轴方向半边长
    private const float MAX_HALF_EDGE_Z = 5f; // 地图z轴方向半边长
    private Texture2D[] cursorTextures; // 鼠标样式: 箭头、小手、眼睛
    private Transform cam; // 相机
    private float planeY = 0f; // 地面高度
    private Vector3 rotateCenter; // 旋转中心
    private Vector3 focusCenter; // 相机在地面上的焦点中心
    private bool isFocusInMap; // 相机焦点是否在地图里
    private Vector3 preMousePos; // 上一帧的鼠标坐标
    private int cursorStatus = 0; // 鼠标样式状态
    private bool isDraging = false; // 是否在拖拽中

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
        cam.eulerAngles = new Vector3(angle.x, angle.y, 0); // 使camp.right指向水平方向
        rotateCenter = new Vector3(0, planeY, 0);
        focusCenter = new Vector3(0, planeY, 0);
    }

    private void Update()
    {
        cursorStatus = GetCursorStatus();
        // 更新鼠标样式, 第二个参数表示鼠标点击位置在图标中的位置, zero表示左上角
        Cursor.SetCursor(cursorTextures[cursorStatus], Vector2.zero, CursorMode.Auto);
        UpdateScene(); // 更新场景(Ctrl+Scroll: 缩放场景, Ctrl+Drag: 平移场景, Alt+Drag: 旋转场景)
    }

    private int GetCursorStatus()
    { // 获取鼠标状态(0: 箭头, 1: 小手, 2: 眼睛)
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
    { // 更新场景(Ctrl+Scroll: 缩放场景, Ctrl+Drag: 平移场景, Alt+Drag: 旋转场景)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (!isDraging && cursorStatus == 1 && Mathf.Abs(scroll) > 0)
        { // 缩放场景
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
            { // 移动场景
                MoveScene(offset);
            }
            else if (cursorStatus == 2)
            { // 旋转场景
                RotateScene(offset);
            }
            preMousePos = Input.mousePosition;
        }
    }

    private void ScaleScene(float scroll)
    { // 缩放场景
        cam.position += cam.forward * scroll;
    }

    private void MoveScene(Vector3 offset)
    { // 平移场景
        Vector3 horVec = Vector3.ProjectOnPlane(cam.right, Vector3.up).normalized;
        Vector3 verVec = Vector3.ProjectOnPlane(cam.up, Vector3.up).normalized;
        cam.position -= (horVec * offset.x / 100 + verVec * offset.y / 100);
    }

    private void RotateScene(Vector3 offset)
    { // 旋转场景
        float hor = offset.x / 3;
        float ver = -offset.y / 5;
        cam.RotateAround(rotateCenter, Vector3.up, hor); // 相机绕旋转中心水平旋转
        cam.RotateAround(rotateCenter, cam.right, ver); // 相机绕旋转中心竖直旋转
        // 由于transform.RotateAround方法中已经进行了物体姿态调整, 因此以下语句是多余的
        // cam.RotateAround(cam.position, Vector3.up, hor); // 相机自转, 使其朝向旋转中心
        // cam.RotateAround(cam.position, cam.right, ver); // 相机自转, 使其朝向旋转中心
    }

    private void UpdateRotateCenter()
    { // 更新旋转中心
        UpdateFocusStatus();
        if (!isFocusInMap)
        {
            return;
        }
        rotateCenter.x = Mathf.Clamp(focusCenter.x, -MAX_HALF_EDGE_X, MAX_HALF_EDGE_X);
        rotateCenter.z = Mathf.Clamp(focusCenter.z, -MAX_HALF_EDGE_Z, MAX_HALF_EDGE_Z);
    }

    private void UpdateFocusStatus()
    { // 更新焦点状态
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
        { // 相机在地面以上并且朝天, 或在地面以下并且朝下
            isFocusInMap = false;
            return;
        }
        float t = (planeY - cam.position.y) / vec2.y;
        focusCenter.x = cam.position.x + t * vec2.x;
        focusCenter.z = cam.position.z + t * vec2.z;
        if (Mathf.Abs(focusCenter.x) > MAX_HALF_EDGE_X || Mathf.Abs(focusCenter.z) > MAX_HALF_EDGE_Z)
        { // 相机焦点不在地图区域内
            isFocusInMap = false;
        }
    }
}