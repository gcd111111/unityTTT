using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Transform11 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��ǰ��Ϸ����
        Debug.Log(this.transform);
        Debug.Log(gameObject.transform);
        Debug.Log(GetComponent<Transform>());
        Debug.Log(gameObject.GetComponent<Transform>());

        //��ȡ������Ϸ����
        Debug.Log(GameObject.Find("Cube").transform);
        Debug.Log(GameObject.FindGameObjectWithTag("Sun").transform);
        Debug.Log(GameObject.Find("Cube").transform.Find("Capsule"));
    }

    void Update()
    {
        
    }
    private void TestTransform()
    {
        //----------------��ȡ��ǰ�������Ϸ�����transform���
        //this.transform;
        //gameObject.tramsform;
        //GetComponent<Transform>();
        //gameObject.GetComponent<Transform>();

        //----------------��ȡ������Ϸ�������Ϸ�����transform���
        //GameObject.Find("name").transform
        //GameObject.FindGameObjectWithTag("tag").transform
        //transform.FindChild("name");

        //----------------transform������
        // ��Ϸ����
        //gameObject
        //// name �� tag
        //name��tag
        //// ��Ϸ�����λ��
        //position��localPosition
        //// ��Ϸ�������ת��
        //eulerAngles��localEulerAngles��rotation��localRotation
        //// ��Ϸ��������ű�
        //localScale
        //// ��Ϸ������ҷ����Ϸ���ǰ��
        //right��up��forward
        //// �㼶���
        //root��parent��hierarchyCount��childCount
        //// ����͵ƹ�
        //camera��light
        //// ��Ϸ������������
        //animation��audio��collider��renderer��rigidbody

        //----------------  ˵����rotation ������һ����Ԫ����Quaternion�����󣬿���ͨ�����·�ʽ������ת��Ϊ Quaternion��
        //Vector3 forward = new Vector3(1, 1, 1);
        //Quaternion quaternion = Quaternion.LookRotation(forward);

        //-------------------transform�еķ���
        // ƽ��
        //Translate(Vector3 translation)
        //// ��eulerAngles����ת����ת�Ƕȵ���eulerAngles��ģ��
        //Rotate(Vector3 eulerAngles)
        //// �ƹ�point���axis������ṫתangle��
        //RotateAround(Vector3 point, Vector3 axis, float angle)
        //// �ƹ�point���axis������ṫתangle�ȣ�����ϵ���ñ�������ϵ��
        //RotateAroundLocal(Vector3 point, Vector3 axis, float angle)
        //// ����transform�����λ��
        //LookAt(transform)
        //// ��ȡ�������
        //GetType()
        //// ��ȡ����Ϸ�����Transform��������ܻ�ȡ���������
        //FindChild("name")
        //// ��ȡ����Ϸ�����Transform��������Ի�ȡ���������
        //Find("name")
        //// ͨ��������ȡ����Ϸ�����Transform��������ܻ�ȡ���������
        //GetChild(index)
        //// ��ȡ��Ϸ������Ӷ������
        //GetChildCount()
        //// ��ȡ�������
        //GetComponent<T>
        //// ������Ϸ�����л�ȡ���
        //GetComponentsInChildren<T>()
    }

}
