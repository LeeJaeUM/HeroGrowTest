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
    private GameState _currentState;
    public GameState CurrentState
    {
        get => _currentState;
        private set
        {
            if (_currentState != value)
            {
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
        if (_currentState == GameState.MainMenu || _currentState == GameState.GameOver)
        {
            Debug.Log("Game Started");
            CurrentState = GameState.InGame;

            // �� ��ȯ (���� ������ �̵�)
            LoadScene("GameScene");

            // ���� �ð� ���� ����
            isGameActive = true;
            playTimeCoroutine = StartCoroutine(TrackPlayTime());
        }
    }   // ���� ����
    public void EndGame()
    {
        if (_currentState == GameState.InGame)
        {
            Debug.Log("Game Over");
            CurrentState = GameState.GameOver;

            // ������ ���� �� ó�� ���� (���� ���� ��)
            SaveGameData();

            // ���� ���� �� ���� �޴��� �̵�
            LoadScene("MainMenu");
        }
    }

    // ���� �Ͻ�����
    public void PauseGame()
    {
        if (_currentState == GameState.InGame)
        {
            CurrentState = GameState.Paused;
            isGameActive = false;  // ������ �Ͻ����� ���·� ����
            Time.timeScale = 0;  // ���� �ð��� ���� (������ �ð��� ����)
            Debug.Log("Game Paused");
        }
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
    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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

    public void ChangeToTitle()
    {
        SceneManager.LoadScene("01_Title");
    }
    public void ChangeToLobby()
    {
        SceneManager.LoadScene("02_Lobby");
    }

}
