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
        agent.SetDestination(target.position);
    }

    public override void PatternMove()
    {
        curAttackDelay += Time.deltaTime;
        RunAwayFromPlayer();
    }
    public override void Attack()
    {
        animController.AttackAnim();
        StartCoroutine(DelayedBulletSpawn());
    }

    public override void AttackingAction()
    {
        base.AttackingAction(); 

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
        Vector3 awayPosition = target.position - GetDirectionToPlayer().normalized * attackDistance * 2;
        agent.SetDestination(awayPosition);
    }

    private IEnumerator DelayedBulletSpawn()
    {
        yield return new WaitForSeconds(bulletDelay);
        bulletSpawner.SpawnObject();
    }

    #region IsFunction

    public override bool IsAttackable()
    {
        bool result = false;

        float distanceDifference = attackDistance - GetDistanceToPlayer();
        TESTDIS = distanceDifference;
        if (distanceDifference <= 0)        //멀때
        {
            canAttack = false;
        }
        else if (distanceDifference <= noRunDistance)    //공격범위내
        {
            canAttack = true;
            agent.ResetPath();
        }
        else
        {
            canAttack = true;                 //너무 가까울때
        }

        result = canAttack;
        return result;
    }

    public override bool IsChaseable()
    {
        bool result = false;

        float distanceDifference = attackDistance - GetDistanceToPlayer();
        TESTDIS = distanceDifference;
        if (distanceDifference <= noRunDistance)    //멀때//공격범위내
        {
            isChase = true;
        }
        else
        {
            isChase = false;     //너무 가까울때
        }
        result = isChase;
        return result;
    }

    public override bool IsPatternMoveable()
    {
        bool result = false;
        if (!isChase && curAttackDelay < attackDelay)
            canPatternMove = true;

        result = canPatternMove;
        return result;
    }
    #endregion

}
