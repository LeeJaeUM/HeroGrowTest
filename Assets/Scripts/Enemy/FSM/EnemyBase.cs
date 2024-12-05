using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyBase : FSM<EnemyBase>, IAction
{
    public float defaultMoveSpeed = 3.0f;
    public float curMoveSpeed = 3.0f;
    public Transform target; // 플레이어의 트랜스폼

    public float attackDelay = 2f;
    public float curAttackDelay = 0;
    public float attackDistance = 0.5f;
    public bool isDeath = false;
    public bool canChase = true;
    public bool canAttack = false;
    public bool canPatternMove = false;
    public bool isPatternMoving = false;
    public bool isAttacking = false;
    public bool isTargetToPlayer = true;
    
    public float TESTDIS = 0;


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
            agent.speed = curMoveSpeed;
        isDeath = false;
    }

    private void Start()
    {
        SetTarget();
        InitState(this, new IdleState());
    }

    protected virtual void Update()
    {
        FSMUpdate();
        TESTDIS = GetDistanceToPlayer();
    }

    protected virtual void Initialize()
    {
        animController = GetComponent<EnemyAnimationController>();
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        agent.speed = curMoveSpeed;
    }

    // 행동에 따른 메서드 추가
    public virtual void Move()
    {
        agent.SetDestination(target.position);
    }
    public virtual void Attack()
    {
        animController.AttackAnim();
    }
    public virtual void AttackingAction()
    {
        curAttackDelay += Time.deltaTime;
        if (curAttackDelay > attackDelay)
        {
            Attack();
            curAttackDelay = 0;
        }
    }


    public virtual bool IsAttackable()
    {
        bool result = GetDistanceToPlayer() < attackDistance;
        canAttack = result;
        return result;
    }

    public virtual bool IsChaseable()
    {
        bool result = GetDistanceToPlayer() >= attackDistance;
        canChase = result;
        return result;
    }
    public virtual bool IsPatternMoveable() { return false; }

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

    public virtual void SetTarget()
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
    public virtual void AttackEnter() { }

    public virtual void AttackExit() { }
    public virtual void PatternMoveEnter()
    {
        animController.SetIsMoveParameter(true);
        isTargetToPlayer = false;
        SetTarget();
    }

    public virtual void PatternMoveExit()
    {
        animController.SetIsMoveParameter(false);
        isTargetToPlayer = true;
    }

    public virtual void ChaseEnter()
    {
       animController.SetIsMoveParameter(true);
    }
    public virtual void ChaseExit()
    {
        animController.SetIsMoveParameter(false);
    }
}
