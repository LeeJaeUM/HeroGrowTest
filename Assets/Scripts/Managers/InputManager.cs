using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput playerInput;

    public event Action<Vector2> OnMoveAction;
    public event Action OnClickAction;

    protected override void Awake()
    {
        base.Awake();  
        playerInput = GetComponent<PlayerInput>();

    }
    private void OnEnable()
    {
        SwitchToPlayerControls();
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    void OnMove(InputValue inputValue)
    {
        OnMoveAction?.Invoke(inputValue.Get<Vector2>());
    }

    void OnClick(InputValue inputValue)
    {
        print("Å¬¸¯ÇÔ");
        OnClickAction?.Invoke();
    }

    void OnTest1(InputValue inputValue)
    {
        print("Test1_ SwitchToPlayerControls");
        SwitchToPlayerControls();
    }
    void OnTest2(InputValue inputValue)
    {
        print("Test2_SwitchToUIControls(");
        SwitchToUIControls();
    }
    void OnTestUI1(InputValue inputValue)
    {
        print("Testui1_ SwitchToPlayerControls");
        SwitchToPlayerControls();
    }
    void OnTestUI2(InputValue inputValue)
    {
        print("Testui2_SwitchToUIControls(");
        SwitchToUIControls();
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
