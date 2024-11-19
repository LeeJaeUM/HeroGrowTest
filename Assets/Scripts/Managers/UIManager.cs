using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject pauseMenuUI;

    protected override void Awake()
    {
        base.Awake();  // �θ� Ŭ������ Awake() ȣ��
        // UI �ʱ�ȭ
        ShowMainMenu();
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;  // ���� ���� �̺�Ʈ ���
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;  // �̺�Ʈ ����
    }

    private void HandleGameStateChanged(GameState newState)
    {
        // ���¿� ���� UI�� �����ϴ� ����
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

    // UI ���� �߰� �޼ҵ��...
}
