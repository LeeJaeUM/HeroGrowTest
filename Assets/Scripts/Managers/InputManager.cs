using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput playerInput;

    public static event Action<Vector2> OnMoveAction;
    public static event Action OnClick;

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
        print($"이동벡터 X값 : {inputValue.Get<Vector2>().x}, Y값 : {inputValue.Get<Vector2>().y}");
        OnMoveAction?.Invoke(inputValue.Get<Vector2>());
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
