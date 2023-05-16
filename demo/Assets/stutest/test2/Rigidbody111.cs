using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Mass：物体的质量（默认以千克为单位）
        //Drag：物体受到的空气阻力大小
        //Angular Drag：物体旋转时，受到的旋转阻力大小转
        //Use Gravity：如果启用，物体将受到重力的影响
        //Is Kinematic：如果启用，物体将不会由物理引擎驱动，只能由其 Transform 组件操作
        //Interpolate：物体运动位置的插值器
        //Collision Detection：碰撞检测类型，当看到物体由于运动太快而穿墙时，可以增强碰撞检测频率，选择 Continuous 选项
        //Constraints：对刚体运动和旋转的限制，限制物体运动时在某个坐标轴上的分量保持不变
        //velocity：物体运动矢量速度
        //angularVelocity：物体运动角速度

        //// 刚体受到的推力
        //public void AddForce(Vector3 force);
        //// 刚体受到的爆炸力，explosionForce：爆炸力大小，explosionPosition：爆炸点，explosionRadius：爆炸半径
        //public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
