using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject pauseMenuUI;
    public GameObject rewardSelecUI;
    public GameObject gameoverUI;

    [Header("Scripts")]
    public LootBoxUI lootBoxUI;

    private void Start()
    {
        lootBoxUI = GetComponentInChildren<LootBoxUI>();

        // UI 초기화
        ShowMainMenu();
       
    }
    private void OnEnable()
    {
        GameManager.Instance.StateManager.OnGameStateChanged += HandleGameStateChanged;  // 상태 변경 이벤트 등록
    }

    private void OnDisable()
    {
        GameManager.Instance.StateManager.OnGameStateChanged -= HandleGameStateChanged;  // 이벤트 해제
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
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowInGame()
    {
        HideAllUI();
        inGameUI.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void ShowRewardSelect()
    {
        rewardSelecUI.SetActive(true);
        lootBoxUI.AssignRandomValues();
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
        rewardSelecUI.SetActive(false);
        gameoverUI.SetActive(false);
    }

}
