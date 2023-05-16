using UnityEngine;

public class EventDetector : MonoBehaviour
{ // �¼������
    private MyEventType eventType = MyEventType.None; // �¼�����
    private MyEventType lastEventType = MyEventType.None; // �ϴ��¼�����
    private float scroll; // ���ֻ����̶�
    private bool detecting; // �¼������
    private Vector3 clickDownMousePos; // ��갴��ʱ������
    private const float dragThreshold = 1; // ʶ��Ϊ��ק�����ƫ��

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
    { // �������¼�
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
    { // ��⻬���¼�
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
    { // ��������¼�(���������¼�)
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
            ContinueKeyType(); // ���ְ����¼�
        }
    }

    public MyEventType EventType()
    { // �¼�����
        if (detecting)
        {
            return lastEventType;
        }
        return eventType;
    }

    public bool HasClickEvent()
    { // �Ƿ��е���¼�
        MyEventType type = EventType();
        return IsClickEvent(type);
    }

    public bool HasDragEvent()
    { // �Ƿ�����ק�¼�
        MyEventType type = EventType();
        return IsDragEvent(type);
    }

    public bool HasScrollEvent()
    { // �Ƿ��л����¼�
        MyEventType type = EventType();
        return IsScrollEvent(type);
    }

    public bool HasCtrlScrollEvent()
    { // �Ƿ���Ctrl�����¼�
        MyEventType type = EventType();
        return type >= MyEventType.BeginCtrlScroll && type <= MyEventType.EndCtrlScroll;
    }

    public bool IsBeginDrag()
    { // �Ƿ��ǿ�ʼ��ק�����¼�
        MyEventType type = EventType();
        return type == MyEventType.BeginDrag || type == MyEventType.BeginCtrlDrag || type == MyEventType.BeginAltDrag;
    }

    public float Scroll()
    { // ��껬�ֻ����̶�
        if (HasScrollEvent())
        {
            return scroll;
        }
        return 0;
    }

    private bool IsClickEvent(MyEventType type)
    { // �Ƿ��ǵ���¼�
        return type >= MyEventType.ClickDown && type <= MyEventType.CtrlClickUp;
    }

    private bool IsDragEvent(MyEventType type)
    { // �Ƿ�����ק�¼�
        return type >= MyEventType.BeginDrag && type <= MyEventType.EndAltDrag;
    }

    private bool IsScrollEvent(MyEventType type)
    { // �Ƿ��ǻ����¼�
        return type >= MyEventType.BeginScroll && type <= MyEventType.EndCtrlScroll;
    }

    private bool IsBeginEvent(MyEventType type)
    { // �Ƿ��ǿ�ʼ�����¼�
        return type == MyEventType.ClickDown
            || type == MyEventType.BeginDrag
            || type == MyEventType.BeginCtrlDrag
            || type == MyEventType.BeginAltDrag
            || type == MyEventType.BeginScroll
            || type == MyEventType.BeginCtrlScroll;
    }

    private bool HasCtrlKey(MyEventType type)
    { // �Ƿ���Ctrl�����¼�
        return type >= MyEventType.CtrlClickDown && type <= MyEventType.CtrlClickUp
            || type >= MyEventType.BeginCtrlDrag && type <= MyEventType.EndCtrlDrag
            || type >= MyEventType.BeginCtrlScroll && type <= MyEventType.EndCtrlScroll;
    }

    private bool HasAltKey(MyEventType type)
    { // �Ƿ���Alt�����¼�
        return type >= MyEventType.BeginAltDrag && type <= MyEventType.EndAltDrag;
    }

    private void ContinueKeyType()
    { // ���ְ����¼�
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
    { // ��Ӱ����¼�
        if ("Ctrl".Equals(key))
        {
            if (eventType == MyEventType.ClickDown)
            { // ����¼�
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
            { // ��ק�¼�
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
            { // �����¼�
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
            { // ��ק�¼�
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
{ // �¼�����
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