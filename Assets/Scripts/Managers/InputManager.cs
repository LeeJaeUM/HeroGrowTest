using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public event Action<Vector2> OnMoveAction;
    public event Action OnClickAction;

    private void Awake()
    {;  
        playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        GameManager.Instance.StateManager.OnGameStateChanged += HandleGameStateChanged;  // 상태 변경 이벤트 등록
    }
    private void OnDisable()
    {
        GameManager.Instance.StateManager.OnGameStateChanged -= HandleGameStateChanged;  // 이벤트 해제
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
        print("클릭함");
        OnClickAction?.Invoke();
    }

    #region StateChange
    private void HandleGameStateChanged(GameState newState)
    {
        // 상태에 따라 UI를 변경하는 로직
        switch (newState)
        {
            case GameState.MainMenu:
            case GameState.Paused:
            case GameState.RewardSelect:
            case GameState.GameOver:
                SwitchActionMapToUI();
                break;
            case GameState.InGame:
                SwitchActionMapToPlayer();
                break;
            default:
                print("현재 없는 state 상태다");
                break;
        }
    }


    //ActionMap 변경
    public void SwitchActionMapToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Debug.Log("Player 액션맵으로 변경");
    }

    public void SwitchActionMapToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");
        Debug.Log("UI 액션맵으로 변경");
    }
    #endregion



}
