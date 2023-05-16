using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{ // 点选物体
    private EventDetector eventDetector; // 鼠标事件检测器
    private List<Transform> targets; // 选中的游戏对象
    private List<Transform> loseFocus; // 失焦的游戏对象
    private RaycastHit hit; // 碰撞信息

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
            { // 未选中物体或点到地面, 全部取消选中
                targets.ForEach(obj => loseFocus.Add(obj));
                targets.Clear();
            }
            else if (eventDetector.EventType() == MyEventType.CtrlClickUp)
            {
                if (targets.Contains(hitTrans))
                { // Ctrl重复选中, 取消选中
                    loseFocus.Add(hitTrans);
                    targets.Remove(hitTrans);
                }
                else
                { // Ctrl追加选中
                    targets.Add(hitTrans);
                }
            }
            else
            { // 单选
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
    { // 更新选中的物体颜色
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
    { // 框选时触发
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
    { // 获取屏幕射线碰撞的物体
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform;
        }
        return null;
    }
}