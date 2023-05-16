using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private Transform player; // 玩家
    private float height = 12; // 相机离地面的高度
    private bool isFullscreen = false; // 小地图相机是否全屏
    private Rect minViewport; // 小地图视口位置和大小（相对值）
    private Rect FullViewport; // 全屏时视口位置和大小（相对值）

    private void Start()
    {
        player = GameObject.Find("Player/Top").transform;
        minViewport = GetComponent<Camera>().rect;
        FullViewport = new Rect(0, 0, 1, 1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsClickMinimap())
        {
            if (isFullscreen)
            {
                GetComponent<Camera>().rect = minViewport;
            }
            else
            {
                GetComponent<Camera>().rect = FullViewport;
            }
            isFullscreen = !isFullscreen;
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = player.position;
        transform.position = new Vector3(pos.x, height, pos.z);
    }

    public bool IsClickMinimap()
    { // 是否单击到小地图区域
        Vector3 pos = Input.mousePosition;
        if (isFullscreen)
        {
            return true;
        }
        if (pos.x / Screen.width > minViewport.xMin && pos.y / Screen.height > minViewport.yMin)
        {
            return true;
        }
        return false;
    }
}