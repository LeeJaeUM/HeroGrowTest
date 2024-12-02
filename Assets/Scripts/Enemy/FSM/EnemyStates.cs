using UnityEngine;

public class IdleState : IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Idle State");
        entity.animController.SetIsMoveParameter(false);
    }

    public void Execute(EnemyStateHandler entity)
    {
       // Debug.Log("Executing Idle State");
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
        entity.animController.SetIsMoveParameter(true);
    }

    public void Execute(EnemyStateHandler entity)
    {
       // Debug.Log("Executing Move State");
        entity.Move(); 
        
        if (entity.isDeath)
            entity.ChangeState(new DieState());

        if (!entity.IsAttackable())
        {
            entity.animController.SetIsMoveParameter(true);
        }
        else
        {
            entity.animController.SetIsMoveParameter(false); // 이동 중이 아닐 때 애니메이션 설정
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
        entity.animController.SetIsMoveParameter(false);
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
       // Debug.Log("Executing Attack State");

        if (entity.isDeath)
            entity.ChangeState(new DieState());

        entity.curAttackDelay += Time.deltaTime;
        if(entity.curAttackDelay > entity.attackDelay)
        {
            entity.Attack();
            entity.curAttackDelay = 0;
        }

        if (entity.GetDistanceToPlayer() > entity.attackDistance)
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
