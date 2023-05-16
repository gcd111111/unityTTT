using System;
using UnityEngine;

public class SceneController1 : MonoBehaviour
{
    private EventDetector eventDetector; // ����¼������
    public Action camChangedHandler; // ����ı䴦����
    private Transform cam; // ���
    private float nearPlan; // ��ƽ��
    private Vector3 preMousePos; // ��һ֡���������

    private void Awake()
    {
        cam = Camera.main.transform;
        nearPlan = Camera.main.nearClipPlane;
        eventDetector = cam.GetComponent<EventDetector>();
    }

    private void Update()
    { // ���³���(Ctrl+Scroll: ���ų���, Ctrl+Drag: ƽ�Ƴ���, Alt+Drag: ��ת����)
        if (eventDetector.HasCtrlScrollEvent())
        { // ���ų���
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
            { // �ƶ�����
                MoveScene(offset);
            }
            else if (eventDetector.EventType() == MyEventType.AltDrag)
            { // ��ת����
                RotateScene(offset);
            }
            preMousePos = Input.mousePosition;
        }
    }

    private void ScaleScene(float scroll)
    { // ���ų���
        cam.position += cam.forward * scroll;
        camChangedHandler?.Invoke();
    }

    private void MoveScene(Vector3 offset)
    { // ƽ�Ƴ���
        cam.position -= (cam.right * offset.x / 100 + cam.up * offset.y / 100);
        camChangedHandler?.Invoke();
    }

    private void RotateScene(Vector3 offset)
    { // ��ת����
        Vector3 rotateCenter = GetRotateCenter(0);
        cam.RotateAround(rotateCenter, Vector3.up, offset.x / 3); // ˮƽ��ק����
        cam.LookAt(rotateCenter);
        cam.RotateAround(rotateCenter, -cam.right, offset.y / 5); // ��ֱ��ק����
        camChangedHandler?.Invoke();
    }

    private Vector3 GetRotateCenter(float planeY)
    { // ��ȡ��ת����
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