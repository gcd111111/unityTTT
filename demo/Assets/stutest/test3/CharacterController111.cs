using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Slope Limit���������Ƕ�
        //Step Offset���������߶�
        //Skin Width��Ƥ�����
        //Min Move Distance����С�ƶ�����
        //Center��Radius��Height����ɫ���ڼ����ײ�Ľ��������ġ��뾶����
        //˵����CharacterController �̳� Collider����������ײ����һ�������塣
        // CharacterController �п��ƽ�ɫ�ƶ��ķ������£�

        //public CollisionFlags Move(Vector3 motion)
        //public bool SimpleMove(Vector3 speed)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//using UnityEngine;
 
//public class PlayerController : MonoBehaviour
//{
//    private CharacterController character;
//    private float speedRate = 4f;

//    private void Start()
//    {
//        character = GetComponent<CharacterController>();
//    }

//    private void Update()
//    {
//        float hor = Input.GetAxis("Horizontal");
//        float ver = Input.GetAxis("Vertical");
//        Vector3 speed = new Vector3(hor, 0, ver) * speedRate;
//        character.SimpleMove(speed);
//    }
//}