using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    readonly int Scene_Title_Hash = Animator.StringToHash("01_Title");
    readonly int Scene_Lobby_Hash = Animator.StringToHash("02_Lobby");
    readonly int Scene_Ingame_Hash = Animator.StringToHash("03_InGame");

    [SerializeField]
    private GameState _currentState;
    public GameState CurrentState
    {
        get => _currentState;
        private set
        {
            if (_currentState != value)
            {
                _currentState = value;
                OnGameStateChanged?.Invoke(_currentState);  // 상태가 변경될 때마다 이벤트 호출
            }
        }

    }
    public event Action<GameState> OnGameStateChanged;

    public float playTime { get; private set; }
    private bool isGameActive;

    private void Awake()
    {
        CurrentState = GameState.MainMenu;  // 초기 상태는 메인 메뉴
    }
    private void Update()
    {
        // 게임이 진행 중이라면 플레이 시간을 측정
        if (isGameActive && _currentState == GameState.InGame)
        {
            playTime += Time.deltaTime;
        }
    }
    // 게임 시작
    public void StateChange_InGame()
    {
        Debug.Log("Game Started");
        CurrentState = GameState.InGame;

        // 게임 시간 측정 시작
        isGameActive = true;
    }   // 게임 종료
    public void StateChange_Gameover()
    {
        Debug.Log("Game Over");
        CurrentState = GameState.GameOver;

        // 게임이 끝난 후 처리 로직 (점수 저장 등)
        SaveGameData();

        // 게임 종료 후 메인 메뉴로 이동
    }

    // 게임 일시정지
    public void StateChange_Paused()
    {
        CurrentState = GameState.Paused;
        isGameActive = false;  // 게임을 일시정지 상태로 만듦
        Time.timeScale = 0;  // 게임 시간을 멈춤 (물리적 시간도 멈춤)
        Debug.Log("Game Paused");
    }

    // 게임 일시정지
    public void StateChange_RewardSelect()
    {
        CurrentState = GameState.RewardSelect;
        isGameActive = false;  // 게임을 일시정지 상태로 만듦
        Time.timeScale = 0;  // 게임 시간을 멈춤 (물리적 시간도 멈춤)
        Debug.Log("RewardSelect!! ");
    }

    // 게임 재개
    public void StateChange_ResumeInGame()
    {
        CurrentState = GameState.InGame;
        isGameActive = true;
        Time.timeScale = 1;  // 게임 시간 다시 흐르게 함
        Debug.Log("Game Resumed");
    }

    // 게임 데이터를 저장하는 메서드 (예시)
    private void SaveGameData()
    {
        // 예를 들어, 게임의 점수나 진행 상황을 저장
        PlayerPrefs.SetFloat("LastPlayTime", playTime);
        Debug.Log($"Game data saved: Play time - {playTime} seconds");
    }

    // 게임 상태 출력 (디버그용)
    public void PrintGameState()
    {
        Debug.Log($"Current Game State: {_currentState}");
    }

    #region SceneMove_StateVersion
    public void ChangeToTitle()
    {
        SceneManager.LoadScene(Scene_Title_Hash);
    }
    public void ChangeToLobby()
    {
        SceneManager.LoadScene(Scene_Lobby_Hash);
    }
    #endregion


}
