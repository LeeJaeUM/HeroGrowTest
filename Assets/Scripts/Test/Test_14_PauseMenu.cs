using UnityEngine;
using UnityEngine.InputSystem;

public class Test_14_PauseMenu : TestBase
{
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateManager.StateChange_InGame();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateManager.StateChange_RewardSelect();
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        GameManager.Instance.SystemManager.AddKillCount();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        GameManager.Instance.SystemManager.AddExpCount(5);
    }

    protected override void OnTest5(InputAction.CallbackContext context)
    {
    }
    protected override void OnTest6(InputAction.CallbackContext context)
    {
    }
}
