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
        gameManager.StartGame();
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        base.OnTest2(context);
        gameManager.EndGame();
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        gameManager.PauseGame();
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        gameManager.ResumeGame();
    }
}
