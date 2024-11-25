using UnityEngine;
using UnityEngine.InputSystem;

public class Test_05_GameManager_State : TestBase
{
    GameManager gameManager;

    protected override void OnEnable()
    {
        base.OnEnable();
        gameManager = GameManager.Instance;
    }
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        gameManager.StateChange_InGame();
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        base.OnTest2(context);
        gameManager.StateChange_Gameover();
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        gameManager.StateChange_Paused();
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        gameManager.StateChange_ResumeInGame();
    }
}
