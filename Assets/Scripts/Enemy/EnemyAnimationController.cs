using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private int isMove_Hash = Animator.StringToHash("isMove");
    private int Attack_Hash = Animator.StringToHash("Attack");
    private int Death_Hash = Animator.StringToHash("Death");

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackAnim()
    {
        animator.SetTrigger(Attack_Hash);
    }

    public void DeathAnim()
    {
        animator.SetTrigger(Death_Hash);
    }

    public void SetIsMoveParameter(bool tr)
    {
        animator.SetBool(isMove_Hash, tr);
    }
}
