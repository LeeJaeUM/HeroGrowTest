using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyStateHandler : FSM<EnemyStateHandler>
{
    public float moveSpeed = 3.0f;
    public Transform target; // 플레이어의 트랜스폼

    public float attackDelay = 2f;
    public float curAttackDelay = 0;
    public float attackDistance = 0.5f;
    public bool isDeath = false;

    public float TestDIStance = 0;

    [HideInInspector]
    public int isMove_Hash = Animator.StringToHash("isMove");
    [HideInInspector]
    public int Attack_Hash = Animator.StringToHash("Attack");
    [HideInInspector]
    protected int Death_Hash = Animator.StringToHash("Death");

    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Animator animator;

    private void Awake()
    {
        Initialize();
    }
    private void OnEnable()
    {
        if (agent != null)
            agent.speed = moveSpeed;
        isDeath = false;
    }

    private void Start()
    {
        SetTarget();
        InitState(this, new IdleState());
    }

    private void Update()
    {
        FSMUpdate();
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = moveSpeed;
    }

    // 행동에 따른 메서드 추가
    public void Move()
    {
        agent.SetDestination(target.position); // 플레이어의 위치로 이동
    }

    public void Attack()
    {
        animator.SetTrigger(Attack_Hash);
    }

    public void SetTarget()
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

    //EnemyManager에서 죽음을 판정 후 실행하라고 지시하는 함수
    public void Die()
    {
        isDeath = true;
    }

    public void Death()
    {
        isDeath = true;
        animator.SetTrigger(Death_Hash);
        agent.ResetPath();
        agent.speed = 0;
    }

}
