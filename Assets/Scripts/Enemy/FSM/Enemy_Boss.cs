using UnityEngine;

public class Enemy_Boss : EnemyBase
{
    EnemyAttackPatternController atkPattertnController;
    protected override void Awake()
    {
        base.Awake();
        atkPattertnController = GetComponent<EnemyAttackPatternController>();
    }

    public override bool IsChaseable()
    {
        return base.IsChaseable();
    }

    public override bool IsPatternMoveable()
    {
        return atkPattertnController.CheckPatternMoveable();
    }

    public override bool IsAttackable()
    {
        return atkPattertnController.CheckAttackable();
    }

    public override void AttackingAction()
    {
        //attack관련 delay들 atkPattertnController로 이동
        agent.ResetPath();
    }

    public override void AttackEnter()
    {
        int maxPatternNum = atkPattertnController.maxPatternIndex + 1;
        int random = UnityEngine.Random.Range(0, maxPatternNum);
        atkPattertnController.SettingPattern(random);
    }

    public override void PatternMove()
    {
        DashAttack();
    }

    public override void PatternMoveEnter()
    {
        base.PatternMoveEnter();
        SetDashAttackPoint();
    }

    public void SetDashAttackPoint()
    {
        // 플레이어의 방향을 구합니다.
        Vector3 directionToPlayer = GetDirectionToPlayer();

        // 현재 오브젝트의 위치에서 뒤쪽으로 이동한 지점을 계산합니다.
        Vector3 arrivalPoint = transform.position + directionToPlayer.normalized *
            atkPattertnController.dashDistance;

        agent.SetDestination(arrivalPoint);

        moveSpeed = atkPattertnController.dashSpeed;
    }

    public void DashAttack()
    {

    }
    public void LazerAttack()
    {

    }
}
