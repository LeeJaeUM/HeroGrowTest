using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject pauseMenuUI;
    public GameObject rewardSelecUI;
    public GameObject gameoverUI;

    [Header("Scripts")]
    public LootBoxUI lootBoxUI;
    [SerializeField]
    private int coinCount = 10;
    public int CoinCount
    {
        get=> coinCount;
        private set 
        {
            if (coinCount != value)
            {
                coinCount = value; 
                OnGetCoin?.Invoke(coinCount);
            }
        }
    }
    public event Action<int> OnGetCoin;

    [SerializeField]
    private int lootBoxCount = 0;

    private int killCount = 0;
    public int KillCount 
    { 
        get => killCount;
        private set
        {
            if(killCount != value)
            {
                killCount = value;
                OnAddKillCount?.Invoke(killCount);
            }

        }
    }
    public event Action<int> OnAddKillCount;

    UIManager uiManager;

    private void Start()
    {        
        lootBoxUI = GetComponentInChildren<LootBoxUI>();

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

    public void AddCoinCount(int _amount)
    {
        CoinCount += _amount;
    }

    public void AddKillCount()
    {
        KillCount++;
    }

    public void AcquireItem(ItemType itemType, int amount)
    {
        switch (itemType)
        {
            case ItemType.Coin:
                Debug.Log("coin 획득");
                AddCoinCount(amount);
                break;
            case ItemType.LootBox:
                Debug.Log("lootBox 획득");
                lootBoxCount += amount;
                GameManager.Instance.StateChange_RewardSelect();
                break;
        }
    }
}
