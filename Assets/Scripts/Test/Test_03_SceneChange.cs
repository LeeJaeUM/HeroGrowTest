using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Test_03_SceneChange : Singleton<Test_03_SceneChange>
{
    PlayerInput playerInput;
    public int a = 0;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }


    public void ChangeToTitle()
    {
        SceneManager.LoadScene("01_Title");
    }    
    public void ChangeToLobby()
    {
        SceneManager.LoadScene("02_Lobby");
    }


    void OnTest1(InputValue inputValue)
    {
        a++;
        if (inputValue.isPressed)
        {
            print("플레이어로 누름1");

        }
        // SwitchActionMap("Test");
    }


    void OnT1(InputValue inputValue)
    {
        a++;
        if (inputValue.isPressed)
        {
            print("플레이어로 누름1");

        }
        // SwitchActionMap("Test");
        ChangeToTitle();
    }


    void OnT2(InputValue inputValue)
    {
        a--;
        print("UI로 누름1");
        //SwitchActionMap("TestUI");

        ChangeToLobby();
    }

    void OnT3(InputValue inputValue) {  a++; }
    void OnTest5()
    {
        a++;
    }

    void OnMove(InputValue inputValue)
    {
        print($"이동벡터 X값 : {inputValue.Get<Vector2>().x}, Y값 : {inputValue.Get<Vector2>().y}");
    }

    // 액션 맵을 전환하는 메서드
    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

}
