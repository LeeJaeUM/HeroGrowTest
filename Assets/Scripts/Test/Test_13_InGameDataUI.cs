using UnityEngine;
using UnityEngine.InputSystem;

public class Test_13_InGameDataUI : TestBase
{
    public EnemySpawner enemySpawner;
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateManager.StateChange_InGame();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        GameManager.Instance.ItemManager.AcquireItem(ItemType.Coin, 10);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        GameManager.Instance.ItemManager.AddKillCount();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        GameManager.Instance.ItemManager.AddExpCount(5);
    }

    protected override void OnTest5(InputAction.CallbackContext context)
    {
        enemySpawner.SpawnEnclosingCircle();
    }
    protected override void OnTest6(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateManager.StateChange_RewardSelect();
    }
}
