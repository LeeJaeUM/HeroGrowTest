using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EnemyStateHandler : FSM<EnemyStateHandler>
{
    public float moveSpeed = 3.0f;
    public Transform target; // 플레이어의 트랜스폼

    public float attackDelay = 2f;
    public float curAttackDelay = 0;
    public float attackDistance = 0.5f;
    public bool isDeath = false;
    public bool isChase = true;
    public bool canAttack = false;
    public bool canPatternMove = false;


    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public EnemyAnimationController animController;

    protected virtual void Awake()
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

    protected virtual void Initialize()
    {
        animController = GetComponent<EnemyAnimationController>();
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = moveSpeed;
    }

    // 행동에 따른 메서드 추가
    public abstract void Move();
    public virtual void Attack()
    {
        animController.AttackAnim();
    }
    public abstract bool IsAttackable();

    public virtual void AttackingAction() 
    {
        curAttackDelay += Time.deltaTime;
        if (curAttackDelay > attackDelay)
        {
            Attack();
            curAttackDelay = 0;
        }
    }

    public virtual bool IsChaseable() { return false; }

    public virtual bool IsPatternMoveable() {  return false; }

    public virtual void PatternMove() { }

    public float GetDistanceToPlayer()
    {
        Vector3 directionToPlayer = GetDirectionToPlayer();

        float distanceToPlayer = directionToPlayer.magnitude;
        float result = distanceToPlayer;

        return result;
    }
    public Vector3 GetDirectionToPlayer()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        directionToPlayer.y = 0; // 높이 차이는 무시
        return directionToPlayer;
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
        //isDeath = true;
        animController.DeathAnim();
        agent.ResetPath();
        agent.speed = 0;
    }


}
