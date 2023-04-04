//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class playController : MonoBehaviour
//{
//    // private CharacterController character;
//    public static float moveSpeed = 4f;
//    private Animator anim;
//    private void Start()
//    {
//        //character = GetComponent<CharacterController>();
//        anim=GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        //Move();
//        move();
//        shooting();
//    }
//    //ÒÆ¶¯
//    private void move()
//    {
//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            transform.position +=new Vector3 (0,0,moveSpeed * Time.deltaTime);
//            anim.SetBool("isRun", true);
//        }
//            anim.SetBool("isRun", true);
//    }
//    //Éä»÷
//    private void shooting()
//    {
//        //
//        if (Input.GetMouseButtonDown(0))
//        {
//            anim.SetBool("isShoot", true);
//        }
//    }
//    private void animPlay()
//    {
//        if()


//    }
//}

using UnityEngine;

public class playController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lookSensitivity = 3.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    public GameObject bulletPrefab;
    private Transform bulletSpawn;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalRotation = 0.0f;
    private float verticalVelocity = 0.0f;
    public Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        bulletSpawn = transform.GetChild(3);
        anim = GetComponent<Animator>();

    }

private void Update()
    {
        move();
        jump();
        shoot();
        view();
    }
    private void move()
    {
        // ÒÆ¶¯¿ØÖÆ
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirectionForward = transform.forward * vertical;
        moveDirection = moveDirectionForward .normalized * moveSpeed;
        if (vertical != 0)
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", true);
        }

    }
    private void jump()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = 0.0f;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            }
        }
        verticalVelocity += gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }
    private void shoot()
    {
        // Éä»÷¿ØÖÆ
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bulletSpawn.forward * 1000.0f);
        }
    }
    private void view()
    {
        // Êó±ê¿ØÖÆ
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -30f, 30f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}