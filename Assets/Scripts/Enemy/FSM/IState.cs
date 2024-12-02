public interface IState<T>
{
    public void Enter(T entity);
    public  void Execute(T entity);
    public  void Exit(T entity);
}
