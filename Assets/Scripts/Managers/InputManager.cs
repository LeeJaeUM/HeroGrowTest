using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput playerInput;

    protected override void Awake()
    {
        base.Awake();  // 부모 클래스의 Awake() 호출
        playerInput = GetComponent<PlayerInput>();
    }

    public void SwitchToPlayerControls()
    {
        playerInput.SwitchCurrentActionMap("Player");
    }

    public void SwitchToUIControls()
    {
        playerInput.SwitchCurrentActionMap("UI");
    }

}
