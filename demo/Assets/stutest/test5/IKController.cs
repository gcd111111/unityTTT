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
        // 设置IK权重
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        // 设置IK位置
        animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        // 设置眼睛的IK权重
        animator.SetLookAtWeight(1);
        // 设置眼睛的IK位置
        animator.SetLookAtPosition(target.position);
    }
}