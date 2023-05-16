using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{ // ��ѡ����
    private EventDetector eventDetector; // ����¼������
    private List<Transform> targets; // ѡ�е���Ϸ����
    private List<Transform> loseFocus; // ʧ������Ϸ����
    private RaycastHit hit; // ��ײ��Ϣ

    private void Awake()
    {
        targets = new List<Transform>();
        loseFocus = new List<Transform>();
        eventDetector = Camera.main.GetComponent<EventDetector>();
        GameObject.Find("Work").GetComponent<SlideSelect>().targetsChangedHandler += SetTargets;
    }

    private void Update()
    {
        if (eventDetector.EventType() == MyEventType.ClickUp || eventDetector.EventType() == MyEventType.CtrlClickUp)
        {
            Transform hitTrans = GetHitTrans();
            if (hitTrans == null || hitTrans.gameObject.layer == LayerMask.NameToLayer("Plane"))
            { // δѡ�������㵽����, ȫ��ȡ��ѡ��
                targets.ForEach(obj => loseFocus.Add(obj));
                targets.Clear();
            }
            else if (eventDetector.EventType() == MyEventType.CtrlClickUp)
            {
                if (targets.Contains(hitTrans))
                { // Ctrl�ظ�ѡ��, ȡ��ѡ��
                    loseFocus.Add(hitTrans);
                    targets.Remove(hitTrans);
                }
                else
                { // Ctrl׷��ѡ��
                    targets.Add(hitTrans);
                }
            }
            else
            { // ��ѡ
                targets.ForEach(trans => loseFocus.Add(trans));
                loseFocus.Remove(hitTrans);
                targets.Clear();
                targets.Add(hitTrans);
            }
            UpdateSelectColor();
            RectPainter.DrawRect(targets);
        }
    }

    private void UpdateSelectColor()
    { // ����ѡ�е�������ɫ
        foreach (var item in loseFocus)
        {
            item.GetComponent<Renderer>().material.color = Color.gray;
        }
        foreach (var item in targets)
        {
            item.GetComponent<Renderer>().material.color = Color.red;
        }
        loseFocus.Clear();
    }

    private void SetTargets(List<Transform> targets)
    { // ��ѡʱ����
        this.targets.ForEach(trans => loseFocus.Add(trans));
        if (targets == null)
        {
            this.targets.Clear();
        }
        else
        {
            this.targets = targets;
            this.targets.ForEach(trans => loseFocus.Remove(trans));
        }
        UpdateSelectColor();
    }

    private Transform GetHitTrans()
    { // ��ȡ��Ļ������ײ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform;
        }
        return null;
    }
}