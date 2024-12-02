using UnityEngine;

public class EnemyStateHandler_Range : EnemyStateHandler, IAction
{
    BulletSpawner bulletSpawner;
    public float rotationSpeed = 18f;
    public float rotationTime = 0.4f;
    public bool canAttackRotate = true;

    protected override void Awake()
    {
        base.Awake();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    public override void Move()
    {
        agent.SetDestination(target.position); // 플레이어의 위치로 이동
    }
    public override void Attack()
    {
        Debug.Log($"meele에서 공격 작동함!!_-----------__--!");
        animController.AttackAnim();
    }

    public override bool IsAttackable()
    {
        Debug.Log($"meele에서 공격가능한지 체크 함");
        bool result = agent.remainingDistance < attackDistance;
        return result;
    }
    public void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

}
