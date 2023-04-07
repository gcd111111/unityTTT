using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    [SerializeField] private float lookSensitivity = 3.0f; // 显式声明私有变量
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalRotation = 0.0f;
    private float verticalVelocity = 0.0f;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move(); // 首字母改为大写
        Jump(); // 首字母改为大写
        View(); // 首字母改为大写
        Attack();
    }

    private void Move()
    {
        // 移动控制
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirectionForward = transform.forward * vertical;
        Vector3 moveDirectionSideway = transform.right * horizontal;
        moveDirection = (moveDirectionForward + moveDirectionSideway).normalized * moveSpeed;
        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0) // 使用Abs函数判断是否移动，避免出现false negative的情况
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

    private void Jump() // 首字母改为大写
    {
        if (controller.isGrounded)
        {
            verticalVelocity = 0.0f;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpHeight;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void View() // 首字母改为大写
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * lookSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -45.0f, 45.0f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttack", true);
        }
        Animator animator = GetComponent<Animator>();
        int layerIndex = 0;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
        if (stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(layerIndex))
        {
            // 动画已经播放完成
            anim.SetBool("isAttack", false);
            anim.SetBool("isIdle", true);
        }
        //float delayTime = 1f; // 延迟时间
        //delayTime -= Time.deltaTime;
        //if (delayTime <= 0)
        //{
        //    在这里执行延迟后的操作
        //}
    }
}
//IEnumerator DelayedAction(float delayTime)
//{
//    yield return new WaitForSeconds(delayTime);
//    // 在这里执行延迟后的操作
//}


