
//---------------------λ�ø���
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    private Transform player; // ���
//    private Vector3 dir; // ��ʼ�����Ŀ��̹�˵ķ�������

//    void Start()
//    {
//        player = GameObject.Find("Tank").transform;
//        dir = player.position - transform.position;
//    }

//    void LateUpdate()
//    {
//        transform.position = player.position - dir;
//    }
//}

//---------------λ������̬����
using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    private Transform player; // ���
    private Vector3 dir; // ��ʼ�����Ŀ��̹�˵ķ�������

    void Start()
    {
        player = GameObject.Find("Tank").transform;
        dir = player.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = transformVecter(-dir, player.position, player.right, player.up, player.forward);
        transform.rotation = Quaternion.LookRotation(player.position - transform.position);
    }

    // ����originΪԭ��, locX, locY, locZ Ϊ������ı�������ϵ�е����� vec ����������ϵ�ж�Ӧ������
    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
    {
        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
    }
}