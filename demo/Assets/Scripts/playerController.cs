using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    [SerializeField] private float lookSensitivity = 3.0f; // ��ʽ����˽�б���
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
        Move(); // ����ĸ��Ϊ��д
        Jump(); // ����ĸ��Ϊ��д
        View(); // ����ĸ��Ϊ��д
        Attack();
    }

    private void Move()
    {
        // �ƶ�����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirectionForward = transform.forward * vertical;
        Vector3 moveDirectionSideway = transform.right * horizontal;
        moveDirection = (moveDirectionForward + moveDirectionSideway).normalized * moveSpeed;
        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0) // ʹ��Abs�����ж��Ƿ��ƶ����������false negative�����
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

    private void Jump() // ����ĸ��Ϊ��д
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

    private void View() // ����ĸ��Ϊ��д
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
            // �����Ѿ��������
            anim.SetBool("isAttack", false);
            anim.SetBool("isIdle", true);
        }
        //float delayTime = 1f; // �ӳ�ʱ��
        //delayTime -= Time.deltaTime;
        //if (delayTime <= 0)
        //{
        //    ������ִ���ӳٺ�Ĳ���
        //}
    }
}
//IEnumerator DelayedAction(float delayTime)
//{
//    yield return new WaitForSeconds(delayTime);
//    // ������ִ���ӳٺ�Ĳ���
//}


