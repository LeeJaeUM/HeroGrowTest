using UnityEngine;

public class IdleState : FSMSingleton<IdleState>, IState<EnemyBase>
{
    public void Enter(EnemyBase entity)
    {
        Debug.Log("Entering Idle State");
        entity.animController.SetIsMoveParameter(false);
    }

    public void Execute(EnemyBase entity)
    {
       // Debug.Log("Executing Idle State");
        if(entity.isDeath)
            entity.ChangeState(DieState.Instance);

        if (entity.target != null)
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }

    public void Exit(EnemyBase entity)
    {
        Debug.Log("Exiting Idle State");
    }
}

public class ChaseState : FSMSingleton<ChaseState>,IState<EnemyBase>
{
    public void Enter(EnemyBase entity)
    {
        Debug.Log("Entering Move State");
        entity.animController.SetIsMoveParameter(true);
    }

    public void Execute(EnemyBase entity)
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

    public void Exit(EnemyBase entity)
    {
        Debug.Log("Exiting Move State");
        entity.animController.SetIsMoveParameter(false);
    }
}

public class PatternMoveState : FSMSingleton<PatternMoveState>, IState<EnemyBase>
{
    public void Enter(EnemyBase entity)
    {
        entity.PatternMoveEnter();
        Debug.Log("Entering PatternMoveState");
    }

    public void Execute(EnemyBase entity)
    {
        entity.PatternMove();
        //특수무브가 끝나면 Chase로 변경
        if (entity.IsAttackable())
        {
            entity.ChangeState(AttackState.Instance);
        }
        if (!entity.IsPatternMoveable())
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }

    public void Exit(EnemyBase entity)
    {
        entity.PatternMoveExit();   
    }
}

public class AttackState : FSMSingleton<AttackState>, IState<EnemyBase>
{
    public void Enter(EnemyBase entity)
    {
        Debug.Log("Entering Attack State");
        entity.AttackEnter();
    }

    public void Execute(EnemyBase entity)
    {
       // Debug.Log("Executing Attack State");

        entity.AttackingAction();

        if (entity.isDeath)
            entity.ChangeState(DieState.Instance);


        //현재 단순계산기능 - 공격거리보다 멀어지면 move로 변경
        //
        if (entity.IsChaseable())
        {
            entity.ChangeState(ChaseState.Instance);
        }
        if (entity.IsPatternMoveable())
        {
            entity.ChangeState(PatternMoveState.Instance);
        }
    }

    public void Exit(EnemyBase entity)
    {
        Debug.Log("Exiting Attack State");
        entity.AttackExit();
    }
}

public class DieState : FSMSingleton<DieState>, IState<EnemyBase>
{
    public void Enter(EnemyBase entity)
    {
        Debug.Log("Entering Die State");
        entity.Death();
    }

    public void Execute(EnemyBase entity)
    {
        Debug.Log("Executing Die State");
    }

    public void Exit(EnemyBase entity)
    {
        Debug.Log("Exiting Die State");
    }
}
