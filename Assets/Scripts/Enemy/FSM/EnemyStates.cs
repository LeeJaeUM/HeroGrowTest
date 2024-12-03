using UnityEngine;

public class IdleState : FSMSingleton<IdleState>, IState<EnemyStateHandler>
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
            entity.ChangeState(DieState.Instance);

        if (entity.target != null)
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Idle State");
    }
}

public class ChaseState : FSMSingleton<ChaseState>,IState<EnemyStateHandler>
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
            entity.ChangeState(DieState.Instance);

        if (entity.IsAttackable())
        {
            entity.ChangeState(AttackState.Instance);
        }

        if (entity.IsPatternMoveable())
        {
            entity.ChangeState(PatternMoveState.Instance);
        }

        //플레이어 소멸
        if (entity.target == null)
        {
            entity.ChangeState(IdleState.Instance);
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Move State");
        entity.animController.SetIsMoveParameter(false);
    }
}

public class PatternMoveState : FSMSingleton<PatternMoveState>, IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        entity.animController.SetIsMoveParameter(true);
        Debug.Log("Entering PatternMoveState");
    }

    public void Execute(EnemyStateHandler entity)
    {
        entity.PatternMove();
        //특수무브가 끝나면 Chase로 변경
        if (!entity.IsPatternMoveable())
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        entity.animController.SetIsMoveParameter(false);
    }
}

public class AttackState : FSMSingleton<AttackState>, IState<EnemyStateHandler>
{
    public void Enter(EnemyStateHandler entity)
    {
        Debug.Log("Entering Attack State");
    }

    public void Execute(EnemyStateHandler entity)
    {
       // Debug.Log("Executing Attack State");

        entity.AttackingAction();

        if (entity.isDeath)
            entity.ChangeState(DieState.Instance);


        //현재 단순계산기능 - 공격거리보다 멀어지면 move로 변경
        //
        if (!entity.IsAttackable())
        {
            entity.ChangeState(ChaseState.Instance);
        }
        if (entity.IsPatternMoveable())
        {
            entity.ChangeState(PatternMoveState.Instance);
        }
    }

    public void Exit(EnemyStateHandler entity)
    {
        Debug.Log("Exiting Attack State");
    }
}

public class DieState : FSMSingleton<DieState>, IState<EnemyStateHandler>
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
