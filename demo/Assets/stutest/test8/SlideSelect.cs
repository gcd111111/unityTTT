using System;
using System.Collections.Generic;
using UnityEngine;

public class SlideSelect : MonoBehaviour
{ // 滑动框选物体
    public Action<List<Transform>> targetsChangedHandler; // 框选目标改变时的处理器
    private EventDetector eventDetector; // 鼠标事件检测器
    private RectTransform slideTrans; // 滑动选框
    private Vector3 preMousePos; // 鼠标滑动前的位置
    private Transform work; // 需要检测是否被框选的物体根对象
    private List<Transform> targets; // 框选的目标对象

    private void Awake()
    {
        slideTrans = GameObject.Find("Canvas/SlideBox").GetComponent<RectTransform>();
        work = GameObject.Find("Work").transform;
        eventDetector = Camera.main.GetComponent<EventDetector>();
    }

    private void Update()
    {
        if (eventDetector.EventType() == MyEventType.BeginDrag)
        {
            preMousePos = Input.mousePosition;
        }
        else if (eventDetector.EventType() == MyEventType.EndDrag)
        {
            Rect rect = slideTrans.rect;
            rect.position = slideTrans.position;
            targets = RectPainter.DrawRect(work, rect);
            targetsChangedHandler?.Invoke(targets);
            ClearRect();
        }
        else if (eventDetector.EventType() == MyEventType.Drag)
        {
            DrawRect();
        }
    }

    private void DrawRect()
    { // 绘制滑动选框
        float minX = Mathf.Min(Input.mousePosition.x, preMousePos.x);
        float minY = Mathf.Min(Input.mousePosition.y, preMousePos.y);
        slideTrans.position = new Vector3(minX, minY, 0);
        Vector3 delta = Input.mousePosition - preMousePos;
        slideTrans.sizeDelta = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));
    }

    private void ClearRect()
    { // 清除滑动选框
        slideTrans.sizeDelta = Vector2.zero;
    }
}