using BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AudioClip：音频片段
        //Mute：静音
        //Play On Awake：游戏开始时播放声音
        //Loop：是否循环播放
        //Volume：音量
        //Spatial Blend：2D、3D 声音调节
        //Min Distance：3D 声音最小距离
        //Max Distance：3D 声音最大距离
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
//// 加载音频片段
//AudioClip audioClip = (AudioClip)Resources.Load("Audio/Footstep01");
//// 获取AudioSource组件
//AudioSource audioSource = GetComponent<AudioSource>();
//// 绑定音频片段
//audioSource.clip = audioClip;
//// 播放音频（选其中一种方式）
//audioSource.Play();
//// 此方式播放音频, Unity3D会在transform.position处创建一个空游戏对象, 播放完音频后自动销毁该游戏对象
//AudioSource.PlayClipAtPoint(audioClip, transform.position);

//using UnityEngine;
 
//public class AudioController : MonoBehaviour
//{
//    private PlayerController player;
//    private AudioSource audioSource;

//    private void Awake()
//    {
//        audioSource = GetComponent<AudioSource>();
//        player = GameObject.Find("Player").GetComponent<PlayerController>();
//    }

//    private void Update()
//    {
//        if (player.isMoving)
//        {
//            PlayAudio();
//        }
//    }

//    private void PlayAudio()
//    {
//        if (!audioSource.isPlaying)
//        {
//            audioSource.Play();
//        }
//    }
//}

//using UnityEngine;
 
//public class PlayerController : MonoBehaviour
//{
//    public bool isMoving = false;

//    private void Update()
//    {
//        isMoving = Move();
//    }

//    private bool Move()
//    {
//        float hor = Input.GetAxis("Horizontal");
//        float ver = Input.GetAxis("Vertical");
//        if (Mathf.Abs(hor) > 0.1f || Mathf.Abs(ver) > 0.1f)
//        {
//            Vector3 dire = new Vector3(hor, 0, ver) * Time.deltaTime * 10;
//            transform.position += dire;
//            return true;
//        }
//        return false;
//    }
//}