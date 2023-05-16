using UnityEngine;

public class ActionController : MonoBehaviour
{
    private Animator animator;
    private Vector3 oldPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        oldPos = transform.position;
    }

    private void Update()
    {
        int status = GetAnimationState();
        animator.SetInteger("Status", status);
        oldPos = transform.position;
    }

    private int GetAnimationState()
    {
        if (Input.GetMouseButton(0))
        { // ����������, �����λ�ñ���
            Vector3 targetPos = GetTargetPos();
            if (targetPos == null || GetDistance(targetPos) < 0.5f)
            {
                transform.position = oldPos; // ԭ��̤��
                return 1;
            }
            transform.LookAt(targetPos); // ת��Ŀ��λ��
            return 1;
        }
        return 0;
    }

    private Vector3 GetTargetPos()
    { // ��ȡĿ��λ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo);
        return hitInfo.point;
    }

    private float GetDistance(Vector3 targetPos)
    {
        return Vector3.Distance(transform.position, targetPos);
    }
}