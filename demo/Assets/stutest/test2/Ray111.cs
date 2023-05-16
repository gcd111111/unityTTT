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
    //// origin: 起点, direction: 方向
    //public Ray(Vector3 origin, Vector3 direction);
    //// 屏幕射线: 以相机位置为起点, 向近平面上鼠标位置方向投射的射线
    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //----------------发射射线
    // ray: 待发射的射线, hitInfo: 碰撞检测信息, maxDistance: 射线发射的最远距离, 返回是否发生碰撞, 只检测第一个碰撞对象
    //public static bool Raycast(Ray ray)
    //public static bool Raycast(Ray ray, out RaycastHit hitInfo)
    //public static bool Raycast(Ray ray, float maxDistance)
    //public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
    //// 检查射线射程范围内所有碰撞
    //public static RaycastHit[] RaycastAll(Ray ray)
    //public static RaycastHit[] RaycastAll(Ray ray, float maxDistance)

    //------------------调试射线
    // start: 射线起点, dir: 射线方向, color: 射线颜色
    //public static void DrawRay(Vector3 start, Vector3 dir)
    //public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    //// start: 线段起点, end: 线段终点, color: 线段颜色
    //public static void DrawLine(Vector3 start, Vector3 end)
    //public static void DrawLine(Vector3 start, Vector3 end, Color color)

    //------------------区域碰撞检测
    // 检验立方体范围内是否有碰撞体
    //public static bool CheckBox(Vector3 center, Vector3 halfExtents)
    //public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layermask)
    //// 检验球体范围内是否有碰撞体
    //public static bool CheckSphere(Vector3 position, float radius)
    //public static bool CheckSphere(Vector3 position, float radius, int layerMask)
    //// 检验胶囊体范围内是否有碰撞体
    //public static bool CheckCapsule(Vector3 start, Vector3 end, float radius)
    //public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layermask)

    //--------------------投射物体
    // 投射立方体
    //public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction)
    //public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask)
    //public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction)
    //public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layermask)
    //// 投射球体
    //public static bool SphereCast(Ray ray, float radius)
    //public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo)
    //public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static RaycastHit[] SphereCastAll(Ray ray, float radius)
    //public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask)
    //public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction)
    //public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask)
    //// 投射胶囊体
    //public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    //public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    //public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    //public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layermask)
}
