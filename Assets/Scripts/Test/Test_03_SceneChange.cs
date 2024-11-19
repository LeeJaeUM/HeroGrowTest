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
            print("�÷��̾�� ����1");

        }
        // SwitchActionMap("Test");
    }


    void OnT1(InputValue inputValue)
    {
        a++;
        if (inputValue.isPressed)
        {
            print("�÷��̾�� ����1");

        }
        // SwitchActionMap("Test");
        ChangeToTitle();
    }


    void OnT2(InputValue inputValue)
    {
        a--;
        print("UI�� ����1");
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
        print($"�̵����� X�� : {inputValue.Get<Vector2>().x}, Y�� : {inputValue.Get<Vector2>().y}");
    }

    // �׼� ���� ��ȯ�ϴ� �޼���
    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

}
