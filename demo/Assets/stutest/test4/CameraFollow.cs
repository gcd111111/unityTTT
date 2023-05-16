
//---------------------位置跟随
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    private Transform player; // 玩家
//    private Vector3 dir; // 初始相机到目标坦克的方向向量

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

//---------------位置与姿态跟随
using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    private Transform player; // 玩家
    private Vector3 dir; // 初始相机到目标坦克的方向向量

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

    // 求以origin为原点, locX, locY, locZ 为坐标轴的本地坐标系中的向量 vec 在世界坐标系中对应的向量
    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
    {
        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
    }
}