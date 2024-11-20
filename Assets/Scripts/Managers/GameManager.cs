using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    MainMenu,
    InGame,
    Paused,
    GameOver
}
public class GameManager : Singleton<GameManager>
{
    readonly int Scene_Title_Hash = Animator.StringToHash("01_Title");
    readonly int Scene_Main_Hash = Animator.StringToHash("02_Lobby");
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
                ////���°� �ٲ�� ���� ���¿� ���� ����
                //switch (_currentState)
                //{
                //    case GameState.MainMenu:
                //        break;
                //    case GameState.InGame:
                //        break;
                //    case GameState.Paused:
                //        break;
                //    case GameState.GameOver:
                //        break;
                //}
                //_currentState = value;
                ////���°� �ٲ� �� ���¿� ���� ����
                //switch (_currentState)
                //{
                //    case GameState.MainMenu:
                //        break;
                //    case GameState.InGame:
                //        break;
                //    case GameState.Paused:
                //        break;
                //    case GameState.GameOver:
                //        break;
                //}
                _currentState = value;
                OnGameStateChanged?.Invoke(_currentState);  // ���°� ����� ������ �̺�Ʈ ȣ��
            }
        }

    }
    public static event Action<GameState> OnGameStateChanged;

    public float playTime { get; private set; }
    private bool isGameActive;
    private Coroutine playTimeCoroutine;

    protected override void Awake()
    {
        base.Awake();  // �̱��� �ʱ�ȭ
        CurrentState = GameState.MainMenu;  // �ʱ� ���´� ���� �޴�
    }
    private void Update()
    {
        // ������ ���� ���̶�� �÷��� �ð��� ����
        if (isGameActive && _currentState == GameState.InGame)
        {
            playTime += Time.deltaTime;
        }
    }
    // ���� ����
    public void StartGame()
    {
        Debug.Log("Game Started");
        CurrentState = GameState.InGame;

        // ���� �ð� ���� ����
        isGameActive = true;
        playTimeCoroutine = StartCoroutine(TrackPlayTime());
    }   // ���� ����
    public void EndGame()
    {
        Debug.Log("Game Over");
        CurrentState = GameState.GameOver;

        // ������ ���� �� ó�� ���� (���� ���� ��)
        SaveGameData();

        // ���� ���� �� ���� �޴��� �̵�
    }

    // ���� �Ͻ�����
    public void PauseGame()
    {
        CurrentState = GameState.Paused;
        isGameActive = false;  // ������ �Ͻ����� ���·� ����
        Time.timeScale = 0;  // ���� �ð��� ���� (������ �ð��� ����)
        Debug.Log("Game Paused");
    }

    // ���� �簳
    public void ResumeGame()
    {
        if (_currentState == GameState.Paused)
        {
            CurrentState = GameState.InGame;
            isGameActive = true;
            Time.timeScale = 1;  // ���� �ð� �ٽ� �帣�� ��
            Debug.Log("Game Resumed");
        }
    }

    // �� �ε� ó��
    //private void LoadScene(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //}

    // ���� �����͸� �����ϴ� �޼��� (����)
    private void SaveGameData()
    {
        // ���� ���, ������ ������ ���� ��Ȳ�� ����
        PlayerPrefs.SetFloat("LastPlayTime", playTime);
        Debug.Log($"Game data saved: Play time - {playTime} seconds");
    }

    // �÷��� �ð� ���� �ڷ�ƾ
    private IEnumerator TrackPlayTime()
    {
        while (_currentState == GameState.InGame)
        {
            // �÷��� �ð� ������Ʈ (1�ʸ���)
            yield return new WaitForSeconds(1);
            Debug.Log($"Play time: {playTime} seconds");
        }
    }

    // ���� ���� ��� (����׿�)
    public void PrintGameState()
    {
        Debug.Log($"Current Game State: {_currentState}");
    }

    #region SceneMove_StateVersion
    public void ChangeToTitle()
    {
        SceneManager.LoadScene("01_Title");
    }
    public void ChangeToLobby()
    {
        SceneManager.LoadScene("02_Lobby");
    }
    #endregion


}
