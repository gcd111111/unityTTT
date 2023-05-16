


//1 ����
//        UGUI �ص�������Ҫָ�����롢�뿪�����¡�����С�̧�𡢿�ʼ��ק����ק�С���ק���� UI �ؼ������Ļص���ʹ�� UGUI �ص�����ʱ����Ҫ���� UnityEngine.EventSystems �����ռ䡣

//        1�� �ص�����

//�ص�����	�ӿ�	˵��
//void OnPointerEnter(PointerEventData eventData)

//IPointerEnterHandler

//������
//void OnPointerExit(PointerEventData eventData)

//IPointerExitHandler

//����뿪
//void OnPointerDown(PointerEventData eventData)

//IPointerDownHandler

//������
//void OnPointerUp(PointerEventData eventData)

//IPointerUpHandler

//���̧��
//void OnPointerClick(PointerEventData eventData)

//IPointerClickHandler

//��굥��
//void OnBeginDrag(PointerEventData eventData)

//IBeginDragHandler

//��꿪ʼ��ק
//void OnDrag(PointerEventData eventData)

//IDragHandler

//�����ק��
//void OnEndDrag(PointerEventData eventData)

//IEndDragHandler

//��������ק
//        ע�⣺OnPointerClick ������ OnPointerUp ����֮��ִ�У��������ק������ͣ���ˣ�������������δ̧��OnDrag ��������ִ�С�

//        2��ǰ������

//��ǰ UI ������������� 1 �����������Text��Image��RawImage��
//���� UI ����б��빴ѡ Raycast Target
//�������� UnityEngine.EventSystems �����ռ�
//        3��ʹ�÷���
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