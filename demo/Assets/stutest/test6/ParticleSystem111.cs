using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleSystem111: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//-------------各种模块
//Particle System：初始化模块
//Emission：发射模块
//Shape：发射器形状模块
//Velocity over Lifetime：生命周期内速度变化模块
//Limit Velocity over Lifetime：生命周期内速度约束模块
//Inherit Velocity：继承父对象的速度，粒子速度会受到其父对象移动的影响
//Force over Lifetime：生命周期内受力变化模块
//Color over Lifetime：生命周期内颜色变化模块
//Color by Speed：颜色受速度的影响模块
//Size over Lifetime：生命周期内粒子大小变化模块
//Size by Speed：粒子大小受速度影响模块
//Rotation over Lifetime：生命周期内方向变化模块
//Rotation by Speed：方向受速度影响模块
//External Forces：粒子受外力影响模块
//Noise：粒子受到随机噪声影响模块
//Collision：碰撞模块
//Triggers：触发器模块，如粒子雨，使粒子不会达到屋内
//Sub Emitters：子发射器模块，多个粒子系统并行或串行发射粒子
//Texture Sheet Animation：纹理层动画模块，可以控制将一张图片分割成多个部分，每次将其中的一个部分取出作为粒子贴图
//Lights：光照模块
//Trails：拖尾模块，可以给粒子添加拖尾效果
//Custom Data：自定义模块，为粒子自定义数据
//Renderer：渲染模块，可以设置渲染材质球、拖尾材质球等
