


//1 简述
//        UGUI 回调函数主要指鼠标进入、离开、点下、点击中、抬起、开始拖拽、拖拽中、拖拽结束 UI 控件触发的回调。使用 UGUI 回调函数时，需要引入 UnityEngine.EventSystems 命名空间。

//        1） 回调函数

//回调函数	接口	说明
//void OnPointerEnter(PointerEventData eventData)

//IPointerEnterHandler

//鼠标进入
//void OnPointerExit(PointerEventData eventData)

//IPointerExitHandler

//鼠标离开
//void OnPointerDown(PointerEventData eventData)

//IPointerDownHandler

//鼠标点下
//void OnPointerUp(PointerEventData eventData)

//IPointerUpHandler

//鼠标抬起
//void OnPointerClick(PointerEventData eventData)

//IPointerClickHandler

//鼠标单击
//void OnBeginDrag(PointerEventData eventData)

//IBeginDragHandler

//鼠标开始拖拽
//void OnDrag(PointerEventData eventData)

//IDragHandler

//鼠标拖拽中
//void OnEndDrag(PointerEventData eventData)

//IEndDragHandler

//鼠标结束拖拽
//        注意：OnPointerClick 方法在 OnPointerUp 方法之后执行；如果在拖拽过程中停下了，但是鼠标左键仍未抬起，OnDrag 方法不会执行。

//        2）前提条件

//当前 UI 对象必须至少有 1 个基础组件（Text、Image、RawImage）
//基础 UI 组件中必须勾选 Raycast Target
//代码引入 UnityEngine.EventSystems 命名空间
//        3）使用方法
using UnityEngine;
using UnityEngine.EventSystems;

public class EventController : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerClickHandler,
        IPointerUpHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}