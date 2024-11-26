using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject pauseMenuUI;
    public GameObject rewardSelecUI;
    public GameObject gameoverUI;

    protected override void Awake()
    {
        base.Awake();  // 부모 클래스의 Awake() 호출

    }
    private void Start()
    {        
        // UI 초기화
        ShowMainMenu();
        GameManager.OnGameStateChanged += HandleGameStateChanged;  // 상태 변경 이벤트 등록
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;  // 이벤트 해제
    }

    private void HandleGameStateChanged(GameState newState)
    {
        HideAllUI();
        // 상태에 따라 UI를 변경하는 로직
        switch (newState)
        {
            case GameState.MainMenu:
                ShowMainMenu();
                break;
            case GameState.InGame:
                ShowInGame();
                break;
            case GameState.Paused:
                ShowPauseMenu();
                break;
            case GameState.RewardSelect:
                ShowRewardSelect();
                break;
            case GameState.GameOver:
                ShowGameover();
                break;
            default:
                print("현재 없는 UI 상태다");
                break;
        }
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
    }

    public void ShowInGame()
    {
        inGameUI.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void ShowRewardSelect()
    {
        rewardSelecUI.SetActive(true);
    }

    public void ShowGameover()
    {
        gameoverUI.SetActive(true);
    }

    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

}
