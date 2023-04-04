//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayController : MonoBehaviour
//{
//   // private CharacterController character;
//    public static float moveSpeed = 4f;
//    private void Start()
//    {
//        //character = GetComponent<CharacterController>();
//    }

//    private void Update()
//    {
//        //Move();
//        move();
//    }
//    //private void Move()
//    //{
//    //    float hor = Input.GetAxis("Horizontal");
//    //    float ver = Input.GetAxis("Vertical");
//    //    Vector3 speed = new Vector3(hor, 0, ver) * moveSpeed;
//    //    character.SimpleMove(speed);
//    //}
//    private  void move()
//    {
//        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
//        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

//        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
//        transform.position += movement;

//        if (movement != Vector3.zero)
//        {
//            transform.LookAt(transform.position + movement);
//        }
//    }
//}
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        animPlayandMove();
    }
    private void animPlayandMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * moveSpeed;
        // 使角色面朝运动方向
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        

        //// 获取水平速度，即忽略上下运动
        //float horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        //// 如果水平速度大于0.1，则将"IsRunning"参数设置为true并播放奔跑动画
        //if (horizontalVelocity > 0.1f)
        //{
        //    anim.SetBool("IsRun", true);
        //}
        //else
        //{
        //    anim.SetBool("IsRun", false);
        //}

        //// 如果垂直速度大于0.1，则将"IsJumping"参数设置为true并播放跳跃动画
        //if (Mathf.Abs( rb.velocity.y) > 0.1f)
        //{
        //    anim.SetBool("IsJumping", true);
        //}
        //else
        //{
        //    anim.SetBool("IsJumping", false);
        //}
    }

    



}