using UnityEngine;

public class IKController : MonoBehaviour
{
    public Transform target;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // ����IKȨ��
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        // ����IKλ��
        animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        // �����۾���IKȨ��
        animator.SetLookAtWeight(1);
        // �����۾���IKλ��
        animator.SetLookAtPosition(target.position);
    }
}