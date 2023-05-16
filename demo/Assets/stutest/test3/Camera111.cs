using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class Camera111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Clear Flags：设置清屏颜色，Skybox（天空盒）、Solid Color（纯色）、Depth Only（仅深度，画中画效果）、Don't Clear（不渲染）；
        //Background：清屏颜色，当 Clear Flags 为 Skybox 或 Solid Color 时，才有 Background；
        //Culling Mask：剔除遮蔽，选择相机需要绘制的对象层；
        //Projection：投影方式，Perspective（透视投影）、Orthographic（正交投影）；
        //Field of View：相机视野范围，默认 60°，视野范围越大，能看到的物体越多，看到的物体越小；
        //Clipping Planes：裁剪平面，视锥体中近平面和远平面的位置；
        //Viewport Rect：视口在屏幕中的位置和大小（相对值），以屏幕左下角为原点；
        //Depth：渲染图层深度，用于设置相机渲染图层的显示顺序；
        //Rendering Path：渲染路径，用于调整渲染性能（可以在 Stats 里查看性能）
        //Target Texture：将相机画面存储到一个纹理图片（RenderTexture）中。
        //补充：基于 Target Texture 属性，可以使用 RawImage 显示次相机渲染的 RenderTexture，实现带主题边框的小地图、八倍镜等效果。 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//using UnityEngine;
 
//public class MainCameraController : MonoBehaviour
//{
//    private Transform player; // 玩家
//    private Vector3 relaPlayerPos; // 相机在玩家坐标系中的位置
//    private float targetDistance = 15f; // 相机看向玩家前方的位置

//    private void Start()
//    {
//        relaPlayerPos = new Vector3(0, 4, -8);
//        player = GameObject.Find("Player/Top").transform;
//    }

//    private void LateUpdate()
//    {
//        CompCameraPos();
//    }

//    private void CompCameraPos()
//    { // 计算相机坐标
//        Vector3 target = player.position + player.forward * targetDistance;
//        transform.position = transformVecter(relaPlayerPos, player.position, player.right, player.up, player.forward);
//        transform.rotation = Quaternion.LookRotation(target - transform.position);
//    }

//    // 求以origin为原点, locX, locY, locZ 为坐标轴的本地坐标系中的向量 vec 在世界坐标系中对应的向量
//    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
//    {
//        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
//    }
//}

//using UnityEngine;
 
//public class MinimapController : MonoBehaviour
//{
//    private Transform player; // 玩家
//    private float height = 12; // 相机离地面的高度
//    private bool isFullscreen = false; // 小地图相机是否全屏
//    private Rect minViewport; // 小地图视口位置和大小（相对值）
//    private Rect FullViewport; // 全屏时视口位置和大小（相对值）

//    private void Start()
//    {
//        player = GameObject.Find("Player/Top").transform;
//        minViewport = GetComponent<Camera>().rect;
//        FullViewport = new Rect(0, 0, 1, 1);
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0) && IsClickMinimap())
//        {
//            if (isFullscreen)
//            {
//                GetComponent<Camera>().rect = minViewport;
//            }
//            else
//            {
//                GetComponent<Camera>().rect = FullViewport;
//            }
//            isFullscreen = !isFullscreen;
//        }
//    }

//    private void LateUpdate()
//    {
//        Vector3 pos = player.position;
//        transform.position = new Vector3(pos.x, height, pos.z);
//    }

//    public bool IsClickMinimap()
//    { // 是否单击到小地图区域
//        Vector3 pos = Input.mousePosition;
//        if (isFullscreen)
//        {
//            return true;
//        }
//        if (pos.x / Screen.width > minViewport.xMin && pos.y / Screen.height > minViewport.yMin)
//        {
//            return true;
//        }
//        return false;
//    }
//}

