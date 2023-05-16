using System;
using UnityEngine;

public class SceneController1 : MonoBehaviour
{
    private EventDetector eventDetector; // 鼠标事件检测器
    public Action camChangedHandler; // 相机改变处理器
    private Transform cam; // 相机
    private float nearPlan; // 近平面
    private Vector3 preMousePos; // 上一帧的鼠标坐标

    private void Awake()
    {
        cam = Camera.main.transform;
        nearPlan = Camera.main.nearClipPlane;
        eventDetector = cam.GetComponent<EventDetector>();
    }

    private void Update()
    { // 更新场景(Ctrl+Scroll: 缩放场景, Ctrl+Drag: 平移场景, Alt+Drag: 旋转场景)
        if (eventDetector.HasCtrlScrollEvent())
        { // 缩放场景
            ScaleScene(eventDetector.Scroll());
        }
        else if (eventDetector.IsBeginDrag())
        {
            preMousePos = Input.mousePosition;
        }
        else if (eventDetector.HasDragEvent())
        {
            Vector3 offset = Input.mousePosition - preMousePos;
            if (eventDetector.EventType() == MyEventType.CtrlDrag)
            { // 移动场景
                MoveScene(offset);
            }
            else if (eventDetector.EventType() == MyEventType.AltDrag)
            { // 旋转场景
                RotateScene(offset);
            }
            preMousePos = Input.mousePosition;
        }
    }

    private void ScaleScene(float scroll)
    { // 缩放场景
        cam.position += cam.forward * scroll;
        camChangedHandler?.Invoke();
    }

    private void MoveScene(Vector3 offset)
    { // 平移场景
        cam.position -= (cam.right * offset.x / 100 + cam.up * offset.y / 100);
        camChangedHandler?.Invoke();
    }

    private void RotateScene(Vector3 offset)
    { // 旋转场景
        Vector3 rotateCenter = GetRotateCenter(0);
        cam.RotateAround(rotateCenter, Vector3.up, offset.x / 3); // 水平拖拽分量
        cam.LookAt(rotateCenter);
        cam.RotateAround(rotateCenter, -cam.right, offset.y / 5); // 竖直拖拽分量
        camChangedHandler?.Invoke();
    }

    private Vector3 GetRotateCenter(float planeY)
    { // 获取旋转中心
        if (Mathf.Abs(cam.forward.y) < Vector3.kEpsilon || Mathf.Abs(cam.position.y) < float.Epsilon)
        {
            return cam.position + cam.forward * (nearPlan + 1 / nearPlan);
        }
        float t = (planeY - cam.position.y) / cam.forward.y;
        float x = cam.position.x + t * cam.forward.x;
        float z = cam.position.z + t * cam.forward.z;
        return new Vector3(x, planeY, z);
    }
}