public class StateMachine<T> where T : class
{
    private T ownerEntity;
    private State<T> curState;

    public void Setup(T owner, State<T> entryState)
    {
        ownerEntity = owner;
        curState = null;

        //entryState상태로 변경
        ChangeState(entryState);
    }

    public void Execute()
    {
        if (curState != null)
        {
            curState.Excute(ownerEntity);
        }

    }

    public void ChangeState(State<T> newState)
    {
        if (newState == null)
            return;
        if (curState != null)
        {
            curState.Exit(ownerEntity);
        }

        curState = newState;
        curState.Enter(ownerEntity);
    }
}
