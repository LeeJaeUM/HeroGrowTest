using System.Collections;
using UnityEngine;

public class EnemyStateHandler_Range : EnemyStateHandler, IAction
{
    BulletSpawner bulletSpawner;
    public float rotationSpeed = 18f;
    public float rotationTime = 0.4f;
    public float noRunDistance = 2f;
    private float bulletDelay = 0.2f;

    public float TESTDIS = 0;

    protected override void Awake()
    {
        base.Awake();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    public override void Move()
    {
        if (isMoveToPlayer)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            //도망칠 때는 공격 쿨타임 돌아감
            RunAwayFromPlayer();
        }
    }
    public override void Attack()
    {
        animController.AttackAnim();
        StartCoroutine(DelayedBulletSpawn());
    }

    public override bool IsAttackable()
    {
        bool result = false;

        float distanceDifference = attackDistance - GetDistanceToPlayer();
        TESTDIS = distanceDifference;
        if (distanceDifference <= 0)    //멀때
        {
            isMoveToPlayer = true;
            result = false;
        }
        else if (distanceDifference <= noRunDistance)    //공격범위내
        {
            Debug.Log("공격가능거리임");
            isMoveToPlayer = true;
            result = true;
            agent.ResetPath();
        }
        else
        {
            isMoveToPlayer = false;     //너무 가까울때
            result = false;
        }

        return result;
    }

    public override void AttackingAction()
    {
        RotateTowards(target.position);
    }

    public void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void RunAwayFromPlayer()
    {
        curAttackDelay += Time.deltaTime;
        Vector3 awayPosition = target.position - GetDirectionToPlayer().normalized * attackDistance * 2;
        agent.SetDestination(awayPosition);
    }

    private IEnumerator DelayedBulletSpawn()
    {
        yield return new WaitForSeconds(bulletDelay);
        bulletSpawner.SpawnObject();
    }

}
