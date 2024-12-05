public interface IAction
{
    public void Move();
    public void Attack();
    public bool IsAttackable();

    public bool IsChaseable();

    public bool IsPatternMoveable();

    public void AttackEnter();
    public void AttackExit();

    public void PatternMoveEnter();
    public void PatternMoveExit();

    public void ChaseEnter();
    public void ChaseExit();
}