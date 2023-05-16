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
    //---------------碰撞器回调
    //// 碰撞开始
    //void OnCollisionEnter(Collision other)
    //// 碰撞过程中，每帧调用一次
    //void OnCollisionStay(Collision other)
    //// 碰撞结束
    //void OnCollisionExit(Collision other)

    //// 碰撞对象的碰撞体组件
    //Collider collider = collision.collider;
    //// 碰撞点信息
    //ContactPoint[] contactPoint = collision.contacts;
    //Vector3 point = contactPoint[0].point;
    //// 碰撞点处当前物体的碰撞体组件(当前物体有多层子对象时, 可以获取具体碰撞的子对象)
    //Collider thisCollider = contactPoint[0].thisCollider;
    //// 碰撞点处对方物体的碰撞体组件
    //Collider otherCollider = contactPoint[0].otherCollider;

    //----------------触发器回调
    // 触发开始
    //void OnTriggerEnter(Collider other)
    //// 触发过程中，每帧调用一次
    //void void OnTriggerStay(Collider other)
    //// 触发结束
    //void OnTriggerExit(Collider other)

    //// 获取碰撞体的MeshRenderer组件
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