using UnityEngine;

public class IdleState : IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Idle State");
        entity.animator.SetBool(entity.isMove_Hash, false);
    }

    public void Execute(EnemyStateHandler entity)
    {
        Debug.Log("Executing Idle State");
        if(entity.isDeath)
            entity.ChangeState(new DieState());

        if (entity.target != null)
        {
            entity.ChangeState(new MoveState());
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Idle State");
    }
}

public class MoveState : IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Move State");
        entity.animator.SetBool(entity.isMove_Hash, true);
    }

    public void Execute(EnemyStateHandler entity)
    {
        Debug.Log("Executing Move State");
        entity.Move(); 
        
        if (entity.isDeath)
            entity.ChangeState(new DieState());

        if (entity.agent.remainingDistance > entity.attackDistance)
        {
            entity.animator.SetBool(entity.isMove_Hash, true);
        }
        else
        {
            entity.animator.SetBool(entity.isMove_Hash, false); // 이동 중이 아닐 때 애니메이션 설정
            entity.ChangeState(new AttackState());
        }

        if (entity.target == null)
        {
            entity.ChangeState(new IdleState());
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Move State");
        entity.animator.SetBool(entity.isMove_Hash, false);
    }
}

public class AttackState : IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Attack State");
        entity.Attack();
        entity.curAttackDelay = 0;
    }

    public void Execute(EnemyStateHandler entity)
    {
        Debug.Log("Executing Attack State");

        if (entity.isDeath)
            entity.ChangeState(new DieState());

        Vector3 directionToPlayer = entity.target.position - entity.transform.position;
        directionToPlayer.y = 0; // 높이 차이는 무시

        float distanceToPlayer = directionToPlayer.magnitude;

        entity.curAttackDelay += Time.deltaTime;
        if(entity.curAttackDelay > entity.attackDelay)
        {
            entity.Attack();
            entity.curAttackDelay = 0;
        }

        if (distanceToPlayer > entity.attackDistance)
        {
            entity.ChangeState(new MoveState());
        }

    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Attack State");
    }
}

public class DieState : IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Die State");
        entity.Death();
    }

    public void Execute(EnemyStateHandler entity)
    {
        Debug.Log("Executing Die State");
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Die State");
    }
}
