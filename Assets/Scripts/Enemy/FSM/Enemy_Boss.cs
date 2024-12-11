using System.Collections;
using UnityEngine;

public class Enemy_Boss : EnemyBase
{
    public int curPatternIndex = 0;
    public int maxPatternIndex = 2;

    public float dashDistance = 10f;
    public float dashSpeed = 8f;
    public float rotationDuration = 0.1f;
    public float lateTime = 1f;

    public float lineSpawnDistance = 4f;

    Vector3 arrivalPoint = Vector3.zero;

    public GameObject dangerLine = null;


    protected override void Awake()
    {
        base.Awake();
        SetRandomPattern();
    }

    protected override void Update()
    {
        base.Update();
        curAttackDelay += Time.deltaTime;
    }

    public override void ChaseEnter()
    {
        base.ChaseEnter();

        //이동속도 초기화
        curMoveSpeed = defaultMoveSpeed;
        agent.speed = defaultMoveSpeed;

        agent.SetDestination(target.position);
        SetRandomPattern();
    }

    public override bool IsChaseable()
    {
        //공격중이 아닐 때 공격거리를 벗어나면 chaseState로 변경
        bool result = false;
        if(!isAttacking) //&& GetDistanceToPlayer() >= attackDistance)
        {
            result = true;
        }
        canChase = result;
        return result;
    }

    public override bool IsAttackable()
    {
        bool result = false;
        if (curAttackDelay > attackDelay && GetDistanceToPlayer() < attackDistance)
        {
            curAttackDelay = 0;
            result = true;
        }

        return result;
        //return CheckAttackable();
    }
    public override void AttackEnter()
    {
        agent.ResetPath();
        //공격 시작 시 공격 범위를 지정된 패턴으로 변경
        isAttacking = true;
        switch (curPatternIndex)
        {
            case 0:
                SetDashAttackPoint();
                break;
            case 1:
                break;

        }
    }
    public override void AttackingAction()
    {
        //attack관련 delay들 atkPattertnController로 이동
        switch (curPatternIndex)
        {
            case 0:
                if(curAttackDelay >= lateTime)
                {
                    agent.SetDestination(arrivalPoint);
                }
                    break;
            case 1:
                break;

        }
        if (curAttackDelay > attackDelay)
        {
            isAttacking = false;
        }
    }

    #region AttackPatternSettingFunctions-----------------------=============------------------@@@

    private void SetRandomPattern()
    {
        int random = UnityEngine.Random.Range(0, maxPatternIndex + 1);
        SettingPattern(random);
    }

    //switch문은 밖에서 조절가능하도록 변경해야함
    private void SettingPattern(int index)
    {
        curPatternIndex = index;
        switch (index)
        {
            case 0:
                SetPatternParmeters(3f, 6f);
                break;
            case 1:
                SetPatternParmeters(4f, 12f);
                break;
        }
        curAttackDelay = 0;
    }

    private void SetPatternParmeters(float _atkDelay, float _atkDistance)
    {
        attackDelay = _atkDelay;
        attackDistance = _atkDistance;

    }

    #endregion
    public void SpawnDangerLine()
    {
        if (dangerLine != null && target != null)
        {
            Vector3 spawnPosition = transform.position + transform.forward * lineSpawnDistance; // 방향으로 1만큼 이동한 위치 계산
            Quaternion spawnRotation = transform.rotation;

            Instantiate(dangerLine, spawnPosition, spawnRotation);
        }
        else
        {
            Debug.LogWarning("dangerLine 또는 target 변수가 설정되지 않았습니다.");
        }
    }

    #region DashAttack

    public void SetDashAttackPoint()
    {
        StartCoroutine(RotateTowards());

        // 현재 오브젝트의 위치에서 뒤쪽으로 이동한 지점을 계산합니다.
        arrivalPoint = transform.position +
            GetDirectionToPlayer().normalized * dashDistance;

        //이동속도 변경
        curMoveSpeed = dashSpeed;
        agent.speed = dashSpeed;
    }
    private IEnumerator RotateTowards()
    {
        Quaternion initialRotation = transform.rotation;
        Vector3 directionToPlayer = GetDirectionToPlayer();
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 마지막으로 정확하게 목표 방향으로 회전시킵니다.
        transform.rotation = targetRotation;

        //그리고 범위 표시
        SpawnDangerLine();
    }
    #endregion
}
