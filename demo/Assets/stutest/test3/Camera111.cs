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
        //Clear Flags������������ɫ��Skybox����պУ���Solid Color����ɫ����Depth Only������ȣ����л�Ч������Don't Clear������Ⱦ����
        //Background��������ɫ���� Clear Flags Ϊ Skybox �� Solid Color ʱ������ Background��
        //Culling Mask���޳��ڱΣ�ѡ�������Ҫ���ƵĶ���㣻
        //Projection��ͶӰ��ʽ��Perspective��͸��ͶӰ����Orthographic������ͶӰ����
        //Field of View�������Ұ��Χ��Ĭ�� 60�㣬��Ұ��ΧԽ���ܿ���������Խ�࣬����������ԽС��
        //Clipping Planes���ü�ƽ�棬��׶���н�ƽ���Զƽ���λ�ã�
        //Viewport Rect���ӿ�����Ļ�е�λ�úʹ�С�����ֵ��������Ļ���½�Ϊԭ�㣻
        //Depth����Ⱦͼ����ȣ��������������Ⱦͼ�����ʾ˳��
        //Rendering Path����Ⱦ·�������ڵ�����Ⱦ���ܣ������� Stats ��鿴���ܣ�
        //Target Texture�����������洢��һ������ͼƬ��RenderTexture���С�
        //���䣺���� Target Texture ���ԣ�����ʹ�� RawImage ��ʾ�������Ⱦ�� RenderTexture��ʵ�ִ�����߿��С��ͼ���˱�����Ч���� 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//using UnityEngine;
 
//public class MainCameraController : MonoBehaviour
//{
//    private Transform player; // ���
//    private Vector3 relaPlayerPos; // ������������ϵ�е�λ��
//    private float targetDistance = 15f; // ����������ǰ����λ��

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
//    { // �����������
//        Vector3 target = player.position + player.forward * targetDistance;
//        transform.position = transformVecter(relaPlayerPos, player.position, player.right, player.up, player.forward);
//        transform.rotation = Quaternion.LookRotation(target - transform.position);
//    }

//    // ����originΪԭ��, locX, locY, locZ Ϊ������ı�������ϵ�е����� vec ����������ϵ�ж�Ӧ������
//    private Vector3 transformVecter(Vector3 vec, Vector3 origin, Vector3 locX, Vector3 locY, Vector3 locZ)
//    {
//        return vec.x * locX + vec.y * locY + vec.z * locZ + origin;
//    }
//}

//using UnityEngine;
 
//public class MinimapController : MonoBehaviour
//{
//    private Transform player; // ���
//    private float height = 12; // ��������ĸ߶�
//    private bool isFullscreen = false; // С��ͼ����Ƿ�ȫ��
//    private Rect minViewport; // С��ͼ�ӿ�λ�úʹ�С�����ֵ��
//    private Rect FullViewport; // ȫ��ʱ�ӿ�λ�úʹ�С�����ֵ��

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
//    { // �Ƿ񵥻���С��ͼ����
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

