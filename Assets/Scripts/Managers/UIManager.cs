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
    [SerializeField]
    private int coinCount = 0;
    public int CoinCount
    {
        get => coinCount;
        private set
        {
            if (coinCount != value)
            {
                coinCount = value;
                OnAddCoin?.Invoke(coinCount);
            }
        }
    }
    public event Action<int> OnAddCoin;

    [SerializeField]
    private int lootBoxCount = 0;

    private int killCount = 0;
    public int KillCount
    {
        get => killCount;
        private set
        {
            if (killCount != value)
            {
                killCount = value;
                OnAddKillCount?.Invoke(killCount);
            }

        }
    }
    public event Action<int> OnAddKillCount;

    [SerializeField]
    public int maxExp = 20;
    public float expPercent = 0f;
    private int expCount = 0;
    public int ExpCount
    {
        get => expCount;
        private set
        {
            if (expCount != value)
            {
                expCount = value;
                expPercent = (float)ExpCount / (float)maxExp;
                OnAddExp?.Invoke(expPercent);
            }
        }
    }
    public event Action<float> OnAddExp;

    UIManager uiManager;

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

    public void AddCoinCount(int _amount)
    {
        CoinCount += _amount;
    }

    public void AddKillCount()
    {
        KillCount++;
    }

    public void AddExpCount(int _amount)
    {
        ExpCount += _amount;
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
                GameManager.Instance.StateManager.StateChange_RewardSelect();
                break;
            case ItemType.Exp:
                AddExpCount(amount);
                Debug.Log("exp 획득");
                break;
        }
    }
}
