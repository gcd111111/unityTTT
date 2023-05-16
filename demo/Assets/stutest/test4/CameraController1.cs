using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    private Transform player; // ���
    private Vector3 relaPlayerPos; // ������������ϵ�е�λ��
    private float targetDistance = 15f; // ����������ǰ����λ��

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
    { // �����������
        Vector3 target = player.position + player.forward * targetDistance;
        transform.position = transformVecter(relaPlayerPos, player.position, player.right, player.up, player.forward);
        transform.rotation = Quaternion.LookRotation(target - transform.position);
    }

    // ����originΪԭ��, locX, locY, locZ Ϊ������ı�������ϵ�е����� vec ����������ϵ�ж�Ӧ������
    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
    {
        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
    }
}