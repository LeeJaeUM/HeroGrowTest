using System.Collections;
using UnityEngine;

public class RangeEnemyController : EnemyControllerBase
{
    public float attackDistance = 6f;
    BulletSpawner bulletSpawner;
    public float rotationSpeed = 18f;
    public float rotationTime = 0.4f;
    public bool canAttackRotate = true;

    public float TESTDISTANCE = 0f;


    protected override void Start()
    {
        base.Start();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    protected override void Update()
    {
        if (!isDeath)
        {
            Move();
            if (isAttacking && canAttackRotate)
                RotateTowards(target.position);
        }
    }
    protected override void Move()
    {
        //if (target != null)
        //{
            float distanceDifference = GetDistanceToPlayer();

            if (distanceDifference <= 0)
            {
                agent.SetDestination(target.position);
                animator.SetBool(isMove_Hash, true); // 이동 중일 때 애니메이션 설정
            }
            else if (distanceDifference <= 1.5f)
            {
                agent.ResetPath();
                animator.SetBool(isMove_Hash, false);
                Attack();
            }
            else
            {
                Vector3 awayPosition = target.position - GetDirectionToPlayer().normalized * attackDistance;
                agent.SetDestination(awayPosition);
                animator.SetBool(isMove_Hash, true); // 가까워졌을 때도 이동 중 애니메이션 설정
                Attack();
            }
        //}
        //else
        //{
        //    animator.SetBool(isMove_Hash, false); // 목표가 없을 때 애니메이션 설정
        //}
    }

    bool IsAttackable()
    {

        return false;
    }


    protected override IEnumerator StartAttack()
    {
        isAttacking = true;
        animator.SetTrigger(Attack_Hash);
        yield return new WaitForSeconds(rotationTime / 2);
        bulletSpawner.SpawnObject();
        yield return new WaitForSeconds(rotationTime / 2);
        canAttackRotate = false;
        yield return new WaitForSeconds(attackDelay - rotationTime);
        isAttacking = false;
        canAttackRotate = true;
    }
    private void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public virtual float GetDistanceToPlayer()
    {
        Vector3 directionToPlayer = GetDirectionToPlayer();

        float distanceToPlayer = directionToPlayer.magnitude;
        float result = attackDistance - distanceToPlayer;

        return result;
    }

    public Vector3 GetDirectionToPlayer()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        directionToPlayer.y = 0; // 높이 차이는 무시
        return directionToPlayer;
    }
}
