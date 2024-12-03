using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyControllerBase : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    protected Transform target; // 플레이어의 트랜스폼

    public float attackDelay = 2f;
    public float curAttackDelay = 0;
    public bool isAttacking = false;
    public bool isDeath = false;

    protected int isMove_Hash = Animator.StringToHash("isMove");
    protected int Attack_Hash = Animator.StringToHash("Attack");
    protected int Death_Hash = Animator.StringToHash("Death");

    protected NavMeshAgent agent;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = moveSpeed;
    }

    private void OnEnable()
    {
        if(agent != null)
            agent.speed = moveSpeed;
        isDeath = false;
    }

    protected virtual void Start()
    {
        SetTarget();
    }

    protected virtual void Update()
    {
        if(!isDeath)
            Move();
    }

    protected abstract void Move();
 

    protected void SetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }
    protected virtual void Attack()
    {
        Debug.Log("attackTry");
        if (!isAttacking)
            StartCoroutine(StartAttack());
    }

    protected virtual IEnumerator StartAttack()
    {
        isAttacking = true;
        animator.SetTrigger(Attack_Hash);
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    public void Death()
    {
        animator.SetTrigger(Death_Hash);
        agent.ResetPath();
        agent.speed = 0;
        isDeath = true;
    }

}
