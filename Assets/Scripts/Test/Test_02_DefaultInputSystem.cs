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

    // 액션 맵을 전환하는 메서드
    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

    //액션맵 변경 확인
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        print("누름1");
        SwitchActionMap("Player");
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        print("누름2");
        SwitchActionMap("UI");
    }

    void OnMove(InputValue inputValue)
    {
        print($"이동벡터 X값 : {inputValue.Get<Vector2>().x}, Y값 : {inputValue.Get<Vector2>().y}");
    }

    void OnClick(InputValue inputValue)
    {
        if(inputValue.isPressed)
        {
            print("UI맵에서 클릭함");
        }
        else
        {
            print("UI맵에서 클릭 뗌");
        }
    }

    void OnPoint(InputValue inputValue)
    {
       // print($"마우스 포인터 X값 : {inputValue.Get<Vector2>().x}, Y값 : {inputValue.Get<Vector2>().y}");
    }
}
