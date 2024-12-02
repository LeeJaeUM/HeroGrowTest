using UnityEngine;

public class FSM<T> : MonoBehaviour
{
    //---------------------------------------
    private T owner;    //	상태 소유자..
    private IState<T> currentState = null;   //	현재 상태..
    private IState<T> previousState = null;  //	이전 상태..
                                                //---------------------------------------
    public IState<T> CurrentState { get { return currentState; } }
    public IState<T> PreviousState { get { return previousState; } }
    //---------------------------------------
    //	초기 상태와 상태 소유자 설정..
    protected void InitState(T owner, IState<T> initialState)
    {
        this.owner = owner;
        ChangeState(initialState);
    }
    //---------------------------------------
    //	각 상태의 실시간 처리..
    protected void FSMUpdate() { if (currentState != null) currentState.Execute(owner); }
    //--------------------------------------- 
    //	상태 변경..
    public void ChangeState(IState<T> newState)
    {
        //	이전 상태 교체..
        previousState = currentState;

        //	이전 상태 종료!!
        if (previousState != null)
            previousState.Exit(owner);

        //	현재 상태 교체..
        currentState = newState;

        //	현재 상태 시작!!
        if (currentState != null)
            currentState.Enter(owner);

    }//	public void  ChangeState(IState<T> newState)
     //--------------------------------------- 
     //	이전 상태로 전환..
    public void RevertState()
    {
        if (previousState != null)
            ChangeState(previousState);

    }//	public void  RevertState()
     //---------------------------------------
     //	디버깅용...
     //	-	현재상태 확인..
    public override string ToString() { return currentState.ToString(); }
    //---------------------------------------

}