using UnityEngine;
using UnityEngine.InputSystem;

public class Test_13_InGameDataUI : TestBase
{
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateChange_InGame();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        UIManager.Instance.AcquireItem(ItemType.Coin, 10);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        UIManager.Instance.AddKillCount();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
    }
}
