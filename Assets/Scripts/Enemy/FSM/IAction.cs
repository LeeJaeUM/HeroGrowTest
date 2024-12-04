public interface IAction
{
    public void Move();
    public void Attack();
    public bool IsAttackable();

    public bool IsChaseable();

    public bool IsPatternMoveable();
}