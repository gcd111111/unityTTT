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
        //获取当前游戏物体
        Debug.Log(this.transform);
        Debug.Log(gameObject.transform);
        Debug.Log(GetComponent<Transform>());
        Debug.Log(gameObject.GetComponent<Transform>());

        //获取其他游戏物体
        Debug.Log(GameObject.Find("Cube").transform);
        Debug.Log(GameObject.FindGameObjectWithTag("Sun").transform);
        Debug.Log(GameObject.Find("Cube").transform.Find("Capsule"));
    }

    void Update()
    {
        
    }
    private void TestTransform()
    {
        //----------------获取当前物体的游戏对象的transform组件
        //this.transform;
        //gameObject.tramsform;
        //GetComponent<Transform>();
        //gameObject.GetComponent<Transform>();

        //----------------获取其他游戏物体的游戏对象的transform组件
        //GameObject.Find("name").transform
        //GameObject.FindGameObjectWithTag("tag").transform
        //transform.FindChild("name");

        //----------------transform的属性
        // 游戏对象
        //gameObject
        //// name 和 tag
        //name、tag
        //// 游戏对象的位置
        //position、localPosition
        //// 游戏对象的旋转角
        //eulerAngles、localEulerAngles、rotation、localRotation
        //// 游戏对象的缩放比
        //localScale
        //// 游戏对象的右方、上方、前方
        //right、up、forward
        //// 层级相关
        //root、parent、hierarchyCount、childCount
        //// 相机和灯光
        //camera、light
        //// 游戏对象的其他组件
        //animation、audio、collider、renderer、rigidbody

        //----------------  说明：rotation 属性是一个四元数（Quaternion）对象，可以通过如下方式将向量转换为 Quaternion：
        //Vector3 forward = new Vector3(1, 1, 1);
        //Quaternion quaternion = Quaternion.LookRotation(forward);

        //-------------------transform中的方法
        // 平移
        //Translate(Vector3 translation)
        //// 绕eulerAngles轴自转，自转角度等于eulerAngles的模长
        //Rotate(Vector3 eulerAngles)
        //// 绕过point点的axis方向的轴公转angle度
        //RotateAround(Vector3 point, Vector3 axis, float angle)
        //// 绕过point点的axis方向的轴公转angle度（坐标系采用本地坐标系）
        //RotateAroundLocal(Vector3 point, Vector3 axis, float angle)
        //// 看向transform组件的位置
        //LookAt(transform)
        //// 获取组件类型
        //GetType()
        //// 获取子游戏对象的Transform组件（不能获取孙子组件）
        //FindChild("name")
        //// 获取子游戏对象的Transform组件（可以获取孙子组件）
        //Find("name")
        //// 通过索引获取子游戏对象的Transform组件（不能获取孙子组件）
        //GetChild(index)
        //// 获取游戏对象的子对象个数
        //GetChildCount()
        //// 获取其他组件
        //GetComponent<T>
        //// 在子游戏对象中获取组件
        //GetComponentsInChildren<T>()
    }

}
