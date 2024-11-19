using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Test_01_Scene : TestBase
{
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        print("´©¸§");
        ChangeToGameScene();
    }
}
