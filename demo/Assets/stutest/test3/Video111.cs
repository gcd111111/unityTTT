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
        //Source：视频源类型，有 2 种类型：Video Clip、URL；
        //Video Clip：视频片段；
        //Play On Awake：启动时播放视频;
        //        Wait For First Frame：是否在第一帧加载完成后才播放，只有在 Play On Awake 被勾选时才会生效；
        //Loop：是否开启循环播放；
        //Playback Speed：播放速度；
        //Render Mode：渲染模式，主要有：Camera Far Plane（在相机远平面上播放，需要绑定到相机，此时其他物体都在视频前面）、Came Near Plane（在相机近平面上播放，需要绑定到相机，此时其他物体都在视频后面）、Render Texture（视频的每一帧输出到 Render Texture 文件中，可以使用 RayImage 显示 Render Texture，这样视频就可以在 RayImage 中播放）、Material Override（需要绑定到一个 Renderer 对象，如 Cube 的 MeshRenderer，这样视频就可以在立方体表面播放）；
        //Renderer：渲染器，当 Render Mode 选择为 Material Override 时才会有此选项，如：将 Hierarchy 窗口的 Cube 对象拖拽到 Renderer 中，视频就会在 Cube 表面播放；
        //Audio Output Mode：音频输出模式，主要有：None（不输出音频）、AudioSource（用 AudioSource 播放）、Direct（直接发送到音频输出硬件）。

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
//        videoPlayer.Prepare(); // 播放引擎准备（提高开始播放时的速度）
//    }

//    private void Start()
//    {
//        videoPlayer.Play(); // 播放
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (videoPlayer.isPlaying)
//            {
//                videoPlayer.Pause(); // 暂停
//            }
//            else
//            {
//                videoPlayer.Play(); // 播放
//            }
//        }
//    }
//}