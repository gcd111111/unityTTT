using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private Transform player; // ���
    private float height = 12; // ��������ĸ߶�
    private bool isFullscreen = false; // С��ͼ����Ƿ�ȫ��
    private Rect minViewport; // С��ͼ�ӿ�λ�úʹ�С�����ֵ��
    private Rect FullViewport; // ȫ��ʱ�ӿ�λ�úʹ�С�����ֵ��

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
    { // �Ƿ񵥻���С��ͼ����
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