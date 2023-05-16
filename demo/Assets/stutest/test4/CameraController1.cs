using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    private Transform player; // 玩家
    private Vector3 relaPlayerPos; // 相机在玩家坐标系中的位置
    private float targetDistance = 15f; // 相机看向玩家前方的位置

    private void Start()
    {
        relaPlayerPos = new Vector3(0, 4, -8);
        player = GameObject.Find("Player/Top").transform;
    }

    private void LateUpdate()
    {
        CompCameraPos();
    }

    private void CompCameraPos()
    { // 计算相机坐标
        Vector3 target = player.position + player.forward * targetDistance;
        transform.position = transformVecter(relaPlayerPos, player.position, player.right, player.up, player.forward);
        transform.rotation = Quaternion.LookRotation(target - transform.position);
    }

    // 求以origin为原点, locX, locY, locZ 为坐标轴的本地坐标系中的向量 vec 在世界坐标系中对应的向量
    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
    {
        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
    }
}