using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;
using static UnityEngine.ParticleSystem;

public class Video111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Source����ƵԴ���ͣ��� 2 �����ͣ�Video Clip��URL��
        //Video Clip����ƵƬ�Σ�
        //Play On Awake������ʱ������Ƶ;
        //        Wait For First Frame���Ƿ��ڵ�һ֡������ɺ�Ų��ţ�ֻ���� Play On Awake ����ѡʱ�Ż���Ч��
        //Loop���Ƿ���ѭ�����ţ�
        //Playback Speed�������ٶȣ�
        //Render Mode����Ⱦģʽ����Ҫ�У�Camera Far Plane�������Զƽ���ϲ��ţ���Ҫ�󶨵��������ʱ�������嶼����Ƶǰ�棩��Came Near Plane���������ƽ���ϲ��ţ���Ҫ�󶨵��������ʱ�������嶼����Ƶ���棩��Render Texture����Ƶ��ÿһ֡����� Render Texture �ļ��У�����ʹ�� RayImage ��ʾ Render Texture��������Ƶ�Ϳ����� RayImage �в��ţ���Material Override����Ҫ�󶨵�һ�� Renderer ������ Cube �� MeshRenderer��������Ƶ�Ϳ�������������沥�ţ���
        //Renderer����Ⱦ������ Render Mode ѡ��Ϊ Material Override ʱ�Ż��д�ѡ��磺�� Hierarchy ���ڵ� Cube ������ק�� Renderer �У���Ƶ�ͻ��� Cube ���沥�ţ�
        //Audio Output Mode����Ƶ���ģʽ����Ҫ�У�None���������Ƶ����AudioSource���� AudioSource ���ţ���Direct��ֱ�ӷ��͵���Ƶ���Ӳ������

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//using UnityEngine;
//using UnityEngine.Video;
 
//public class VideoController : MonoBehaviour
//{
//    private VideoPlayer videoPlayer;

//    private void Awake()
//    {
//        videoPlayer = GetComponent<VideoPlayer>();
//        videoPlayer.isLooping = true;
//        videoPlayer.playOnAwake = false;
//        videoPlayer.clip = (VideoClip)Resources.Load("Video/Video");
//        videoPlayer.Prepare(); // ��������׼������߿�ʼ����ʱ���ٶȣ�
//    }

//    private void Start()
//    {
//        videoPlayer.Play(); // ����
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (videoPlayer.isPlaying)
//            {
//                videoPlayer.Pause(); // ��ͣ
//            }
//            else
//            {
//                videoPlayer.Play(); // ����
//            }
//        }
//    }
//}