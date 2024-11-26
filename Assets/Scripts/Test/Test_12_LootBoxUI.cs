using UnityEngine;
using UnityEngine.InputSystem;

public class Test_12_LootBoxUI : TestBase
{
    public LootBoxUI lootBoxReward;
    //protected override void OnTest1(InputAction.CallbackContext context)
    //{
    //    GameManager.Instance.StateChange_InGame();
    //}
    //protected override void OnTest2(InputAction.CallbackContext context)
    //{
    //    GameManager.Instance.StateChange_RewardSelect();
    //}
    //protected override void OnTest3(InputAction.CallbackContext context)
    //{
    //    GameManager.Instance.StateChange_ResumeInGame();
    //}
    //protected override void OnTest4(InputAction.CallbackContext context)
    //{
    //    GameManager.Instance.StateChange_Paused();
    //}
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        lootBoxReward.AssignRandomValues();
    }
    protected override void OnTest6(InputAction.CallbackContext context)
    {
        base.OnTest6(context);
    }
    protected override void OnTest7(InputAction.CallbackContext context)
    {
        base.OnTest7(context);
    }
    protected override void OnTest8(InputAction.CallbackContext context)
    {
        base.OnTest8(context);
    }
    protected override void OnTest9(InputAction.CallbackContext context)
    {
        base.OnTest9(context);
    }
    protected override void OnTest10(InputAction.CallbackContext context)
    {
        base.OnTest10(context);
    }
}

