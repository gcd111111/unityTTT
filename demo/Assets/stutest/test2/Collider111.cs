using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //---------------��ײ���ص�
    //// ��ײ��ʼ
    //void OnCollisionEnter(Collision other)
    //// ��ײ�����У�ÿ֡����һ��
    //void OnCollisionStay(Collision other)
    //// ��ײ����
    //void OnCollisionExit(Collision other)

    //// ��ײ�������ײ�����
    //Collider collider = collision.collider;
    //// ��ײ����Ϣ
    //ContactPoint[] contactPoint = collision.contacts;
    //Vector3 point = contactPoint[0].point;
    //// ��ײ�㴦��ǰ�������ײ�����(��ǰ�����ж���Ӷ���ʱ, ���Ի�ȡ������ײ���Ӷ���)
    //Collider thisCollider = contactPoint[0].thisCollider;
    //// ��ײ�㴦�Է��������ײ�����
    //Collider otherCollider = contactPoint[0].otherCollider;

    //----------------�������ص�
    // ������ʼ
    //void OnTriggerEnter(Collider other)
    //// ���������У�ÿ֡����һ��
    //void void OnTriggerStay(Collider other)
    //// ��������
    //void OnTriggerExit(Collider other)

    //// ��ȡ��ײ���MeshRenderer���
    //MeshRenderer meshRenderer = collider.GetComponent<MeshRenderer>();
}

//using UnityEngine;
 
//public class ColliderController : MonoBehaviour
//{

//    private void OnCollisionEnter(Collision other)
//    {
//        other.collider.GetComponent<MeshRenderer>().material.color = Color.green;
//    }

//    private void OnCollisionStay(Collision other)
//    {
//        GetComponent<MeshRenderer>().material.color = Color.yellow;
//    }

//    private void OnCollisionExit(Collision other)
//    {
//        other.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
//    }
//}

//using UnityEngine;
 
//public class TriggerController : MonoBehaviour
//{

//    private void OnTriggerEnter(Collider other)
//    {
//        other.GetComponent<MeshRenderer>().material.color = Color.green;
//    }

//    private void OnTriggerStay(Collider other)
//    {
//        GetComponent<MeshRenderer>().material.color = Color.yellow;
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        other.GetComponent<MeshRenderer>().material.color = Color.blue;
//    }
//}