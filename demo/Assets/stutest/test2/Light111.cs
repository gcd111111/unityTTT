using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.XR;

public class Light111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Type：灯光类型，主要有：Directional（平行光）、Spot（聚光灯）、Point（点灯光）、Area（区域光）
        //Color：光源颜色
        //Mode：渲染模式，取值有：Realtime（实时渲染）、Baked（灯光渲染只计算一次）
        //Intensity：光照强度
        //Shadow Type：阴影类型，取值有：No Shadows（无阴影）、Hard Shadows（软阴影）、Soft Shadows（硬阴影）
        //Render Mode：渲染模式，取值有：Auto（自动的）、Important（重要的，渲染光照较精细）、Not Important（不重要的，渲染光照较简陋）
        //Culling Mask：进行层剔除，哪些游戏对象需要渲染灯光
        //补充：Spot 有 Range 和 Angle 2 个属性，Range 表示聚光灯的深度范围（光锥的高度），Angle 表示聚光灯的照射角度（光锥的锥角）。
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
