using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject pauseMenuUI;

    protected override void Awake()
    {
        base.Awake();  // 부모 클래스의 Awake() 호출
        // UI 초기화
        ShowMainMenu();
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;  // 상태 변경 이벤트 등록
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;  // 이벤트 해제
    }

    private void HandleGameStateChanged(GameState newState)
    {
        // 상태에 따라 UI를 변경하는 로직
        switch (newState)
        {
            case GameState.MainMenu:
                ShowMainMenu();
                break;
            case GameState.InGame:
                ShowInGameUI();
                break;
            case GameState.Paused:
                ShowPauseMenu();
                break;
            case GameState.GameOver:
                //ShowGameOverScreen();
                break;
        }
    }

    public void ShowMainMenu()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowInGameUI()
    {
        HideAllUI();
        inGameUI.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        HideAllUI();
        pauseMenuUI.SetActive(true);
    }

    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    // UI 관련 추가 메소드들...
}
