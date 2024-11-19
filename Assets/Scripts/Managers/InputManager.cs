using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerInput playerInput;

    protected override void Awake()
    {
        base.Awake();  // �θ� Ŭ������ Awake() ȣ��
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
