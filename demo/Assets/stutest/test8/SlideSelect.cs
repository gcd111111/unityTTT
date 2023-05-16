using System;
using System.Collections.Generic;
using UnityEngine;

public class SlideSelect : MonoBehaviour
{ // ������ѡ����
    public Action<List<Transform>> targetsChangedHandler; // ��ѡĿ��ı�ʱ�Ĵ�����
    private EventDetector eventDetector; // ����¼������
    private RectTransform slideTrans; // ����ѡ��
    private Vector3 preMousePos; // ��껬��ǰ��λ��
    private Transform work; // ��Ҫ����Ƿ񱻿�ѡ�����������
    private List<Transform> targets; // ��ѡ��Ŀ�����

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
    { // ���ƻ���ѡ��
        float minX = Mathf.Min(Input.mousePosition.x, preMousePos.x);
        float minY = Mathf.Min(Input.mousePosition.y, preMousePos.y);
        slideTrans.position = new Vector3(minX, minY, 0);
        Vector3 delta = Input.mousePosition - preMousePos;
        slideTrans.sizeDelta = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));
    }

    private void ClearRect()
    { // �������ѡ��
        slideTrans.sizeDelta = Vector2.zero;
    }
}