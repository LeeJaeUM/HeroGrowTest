using System.Collections;
using UnityEngine;

public class Enemy_Range : EnemyBase
{
    BulletSpawner bulletSpawner;
    public float rotationSpeed = 18f;
    public float rotationTime = 0.4f;
    public float noRunDistance = 2f;
    private float bulletDelay = 0.2f;


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
        agent.ResetPath();
    }
    private IEnumerator DelayedBulletSpawn()
    {
        yield return new WaitForSeconds(bulletDelay);
        bulletSpawner.SpawnObject();
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

    //public override void PatternMoveEnter()
    //{
    //    base.PatternMoveEnter();
    //    isPatternMoving = true;
    //}

    #region IsFunction

    public override bool IsPatternMoveable()
    {
        bool result = false;
        if (GetDistanceToPlayer() < attackDistance - noRunDistance)
        {
            canPatternMove = true;
        }
        else
        {
            canPatternMove = false;
        }
        result = canPatternMove;
        return result;
    }
    #endregion

}
