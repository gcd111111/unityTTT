using BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AudioClip����ƵƬ��
        //Mute������
        //Play On Awake����Ϸ��ʼʱ��������
        //Loop���Ƿ�ѭ������
        //Volume������
        //Spatial Blend��2D��3D ��������
        //Min Distance��3D ������С����
        //Max Distance��3D ����������
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
//// ������ƵƬ��
//AudioClip audioClip = (AudioClip)Resources.Load("Audio/Footstep01");
//// ��ȡAudioSource���
//AudioSource audioSource = GetComponent<AudioSource>();
//// ����ƵƬ��
//audioSource.clip = audioClip;
//// ������Ƶ��ѡ����һ�ַ�ʽ��
//audioSource.Play();
//// �˷�ʽ������Ƶ, Unity3D����transform.position������һ������Ϸ����, ��������Ƶ���Զ����ٸ���Ϸ����
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