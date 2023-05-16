using UnityEngine;

public class EventDetector : MonoBehaviour
{ // 事件检测器
    private MyEventType eventType = MyEventType.None; // 事件类型
    private MyEventType lastEventType = MyEventType.None; // 上次事件类型
    private float scroll; // 滑轮滑动刻度
    private bool detecting; // 事件检测中
    private Vector3 clickDownMousePos; // 鼠标按下时的坐标
    private const float dragThreshold = 1; // 识别为拖拽的鼠标偏移

    private void Update()
    {
        detecting = true;
        DetectMouseEvent();
        DetectScrollEvent();
        UpgradeMouseEvent();
        detecting = false;
        lastEventType = eventType;
    }

    private void DetectMouseEvent()
    { // 检测鼠标事件
        if (Input.GetMouseButtonDown(0))
        { // Click Down
            eventType = MyEventType.ClickDown;
            clickDownMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (IsDragEvent(eventType))
            { // End Drag
                eventType = MyEventType.EndDrag;
            }
            else
            { // Click Up
                eventType = MyEventType.ClickUp;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (IsDragEvent(eventType))
            { // Drag
                eventType = MyEventType.Drag;
            }
            else if (Vector3.Distance(clickDownMousePos, Input.mousePosition) > dragThreshold)
            { // Begin Drag
                eventType = MyEventType.BeginDrag;
            }
            else
            { // Click
                eventType = MyEventType.Click;
            }
        }
        else
        {
            eventType = MyEventType.None;
        }
    }

    private void DetectScrollEvent()
    { // 检测滑轮事件
        if (eventType != MyEventType.None
            && (!IsBeginEvent(eventType) || lastEventType != MyEventType.None && !IsScrollEvent(lastEventType)))
        {
            scroll = 0;
            return;
        }
        float temScroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) < float.Epsilon && Mathf.Abs(temScroll) > float.Epsilon)
        { // Begin Scroll
            eventType = MyEventType.BeginScroll;
            scroll = temScroll;
        }
        else if (Mathf.Abs(scroll) > float.Epsilon && Mathf.Abs(temScroll) < float.Epsilon)
        { // End Scroll
            eventType = MyEventType.EndScroll;
            scroll = temScroll;
        }
        else if (Mathf.Abs(temScroll) > float.Epsilon)
        { // Scroll
            eventType = MyEventType.Scroll;
            scroll = temScroll;
        }
        else
        {
            scroll = 0;
        }
    }

    private void UpgradeMouseEvent()
    { // 升级鼠标事件(关联键盘事件)
        if (eventType == MyEventType.None)
        {
            return;
        }
        if (IsBeginEvent(eventType))
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                AddKeyType("Ctrl");
            }
            else if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            {
                AddKeyType("Alt");
            }
        }
        else
        {
            ContinueKeyType(); // 保持按键事件
        }
    }

    public MyEventType EventType()
    { // 事件类型
        if (detecting)
        {
            return lastEventType;
        }
        return eventType;
    }

    public bool HasClickEvent()
    { // 是否有点击事件
        MyEventType type = EventType();
        return IsClickEvent(type);
    }

    public bool HasDragEvent()
    { // 是否有拖拽事件
        MyEventType type = EventType();
        return IsDragEvent(type);
    }

    public bool HasScrollEvent()
    { // 是否有滑轮事件
        MyEventType type = EventType();
        return IsScrollEvent(type);
    }

    public bool HasCtrlScrollEvent()
    { // 是否有Ctrl滑轮事件
        MyEventType type = EventType();
        return type >= MyEventType.BeginCtrlScroll && type <= MyEventType.EndCtrlScroll;
    }

    public bool IsBeginDrag()
    { // 是否是开始拖拽类型事件
        MyEventType type = EventType();
        return type == MyEventType.BeginDrag || type == MyEventType.BeginCtrlDrag || type == MyEventType.BeginAltDrag;
    }

    public float Scroll()
    { // 鼠标滑轮滑动刻度
        if (HasScrollEvent())
        {
            return scroll;
        }
        return 0;
    }

    private bool IsClickEvent(MyEventType type)
    { // 是否是点击事件
        return type >= MyEventType.ClickDown && type <= MyEventType.CtrlClickUp;
    }

    private bool IsDragEvent(MyEventType type)
    { // 是否是拖拽事件
        return type >= MyEventType.BeginDrag && type <= MyEventType.EndAltDrag;
    }

    private bool IsScrollEvent(MyEventType type)
    { // 是否是滑轮事件
        return type >= MyEventType.BeginScroll && type <= MyEventType.EndCtrlScroll;
    }

    private bool IsBeginEvent(MyEventType type)
    { // 是否是开始类型事件
        return type == MyEventType.ClickDown
            || type == MyEventType.BeginDrag
            || type == MyEventType.BeginCtrlDrag
            || type == MyEventType.BeginAltDrag
            || type == MyEventType.BeginScroll
            || type == MyEventType.BeginCtrlScroll;
    }

    private bool HasCtrlKey(MyEventType type)
    { // 是否有Ctrl按键事件
        return type >= MyEventType.CtrlClickDown && type <= MyEventType.CtrlClickUp
            || type >= MyEventType.BeginCtrlDrag && type <= MyEventType.EndCtrlDrag
            || type >= MyEventType.BeginCtrlScroll && type <= MyEventType.EndCtrlScroll;
    }

    private bool HasAltKey(MyEventType type)
    { // 是否有Alt按键事件
        return type >= MyEventType.BeginAltDrag && type <= MyEventType.EndAltDrag;
    }

    private void ContinueKeyType()
    { // 保持按键事件
        if (HasCtrlKey(lastEventType))
        {
            AddKeyType("Ctrl");
        }
        else if (HasAltKey(lastEventType))
        {
            AddKeyType("Alt");
        }
    }

    private void AddKeyType(string key)
    { // 添加按键事件
        if ("Ctrl".Equals(key))
        {
            if (eventType == MyEventType.ClickDown)
            { // 点击事件
                eventType = MyEventType.CtrlClickDown;
            }
            else if (eventType == MyEventType.Click)
            {
                eventType = MyEventType.CtrlClick;
            }
            else if (eventType == MyEventType.ClickUp)
            {
                eventType = MyEventType.CtrlClickUp;
            }
            else if (eventType == MyEventType.BeginDrag)
            { // 拖拽事件
                eventType = MyEventType.BeginCtrlDrag;
            }
            else if (eventType == MyEventType.Drag)
            {
                eventType = MyEventType.CtrlDrag;
            }
            else if (eventType == MyEventType.EndDrag)
            {
                eventType = MyEventType.EndCtrlDrag;
            }
            else if (eventType == MyEventType.BeginScroll)
            { // 滑轮事件
                eventType = MyEventType.BeginCtrlScroll;
            }
            else if (eventType == MyEventType.Scroll)
            {
                eventType = MyEventType.CtrlScroll;
            }
            else if (eventType == MyEventType.EndScroll)
            {
                eventType = MyEventType.EndCtrlScroll;
            }
        }
        else if ("Alt".Equals(key))
        {
            if (eventType == MyEventType.BeginDrag)
            { // 拖拽事件
                eventType = MyEventType.BeginAltDrag;
            }
            else if (eventType == MyEventType.Drag)
            {
                eventType = MyEventType.AltDrag;
            }
            else if (eventType == MyEventType.EndDrag)
            {
                eventType = MyEventType.EndAltDrag;
            }
        }
    }
}

public enum MyEventType
{ // 事件类型
    None = 0,
    ClickDown = 1,
    Click = 2,
    ClickUp = 3,
    CtrlClickDown = 4,
    CtrlClick = 5,
    CtrlClickUp = 6,
    BeginDrag = 10,
    Drag = 11,
    EndDrag = 12,
    BeginCtrlDrag = 13,
    CtrlDrag = 14,
    EndCtrlDrag = 15,
    BeginAltDrag = 16,
    AltDrag = 17,
    EndAltDrag = 18,
    BeginScroll = 20,
    Scroll = 21,
    EndScroll = 22,
    BeginCtrlScroll = 23,
    CtrlScroll = 24,
    EndCtrlScroll = 25
}