using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //// origin: ���, direction: ����
    //public Ray(Vector3 origin, Vector3 direction);
    //// ��Ļ����: �����λ��Ϊ���, ���ƽ�������λ�÷���Ͷ�������
    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //----------------��������
    // ray: �����������, hitInfo: ��ײ�����Ϣ, maxDistance: ���߷������Զ����, �����Ƿ�����ײ, ֻ����һ����ײ����
    //public static bool Raycast(Ray ray)
    //public static bool Raycast(Ray ray, out RaycastHit hitInfo)
    //public static bool Raycast(Ray ray, float maxDistance)
    //public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
    //// ���������̷�Χ��������ײ
    //public static RaycastHit[] RaycastAll(Ray ray)
    //public static RaycastHit[] RaycastAll(Ray ray, float maxDistance)

    //------------------��������
    // start: �������, dir: ���߷���, color: ������ɫ
    //public static void DrawRay(Vector3 start, Vector3 dir)
    //public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    //// start: �߶����, end: �߶��յ�, color: �߶���ɫ
    //public static void DrawLine(Vector3 start, Vector3 end)
    //public static void DrawLine(Vector3 start, Vector3 end, Color color)

    //------------------������ײ���
    // ���������巶Χ���Ƿ�����ײ��
    //public static bool CheckBox(Vector3 center, Vector3 halfExtents)
    //public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layermask)
    //// �������巶Χ���Ƿ�����ײ��
    //public static bool CheckSphere(Vector3 position, float radius)
    //public static bool CheckSphere(Vector3 position, float radius, int layerMask)
    //// ���齺���巶Χ���Ƿ�����ײ��
    //public static bool CheckCapsule(Vector3 start, Vector3 end, float radius)
    //public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layermask)

    //--------------------Ͷ������
    // Ͷ��������
    //public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction)
    //public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask)
    //public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction)
    //public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layermask)
    //// Ͷ������
    //public static bool SphereCast(Ray ray, float radius)
    //public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo)
    //public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static RaycastHit[] SphereCastAll(Ray ray, float radius)
    //public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask)
    //public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction)
    //public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask)
    //// Ͷ�佺����
    //public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    //public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    //public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layermask)
}
