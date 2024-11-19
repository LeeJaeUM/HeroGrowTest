using UnityEngine;
using UnityEngine.InputSystem;

public class Test_02_DefaultInputSystem : TestBase
{
    public PlayerInput playerInput;
   // Vector2 pointerVec = new Vector2();

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // �׼� ���� ��ȯ�ϴ� �޼���
    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

    //�׼Ǹ� ���� Ȯ��
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        print("����1");
        SwitchActionMap("Player");
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        print("����2");
        SwitchActionMap("UI");
    }

    void OnMove(InputValue inputValue)
    {
        print($"�̵����� X�� : {inputValue.Get<Vector2>().x}, Y�� : {inputValue.Get<Vector2>().y}");
    }

    void OnClick(InputValue inputValue)
    {
        if(inputValue.isPressed)
        {
            print("UI�ʿ��� Ŭ����");
        }
        else
        {
            print("UI�ʿ��� Ŭ�� ��");
        }
    }

    void OnPoint(InputValue inputValue)
    {
       // print($"���콺 ������ X�� : {inputValue.Get<Vector2>().x}, Y�� : {inputValue.Get<Vector2>().y}");
    }
}
