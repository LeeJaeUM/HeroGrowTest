using System;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
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
            case ItemType.Heart:
                break;
        }
    }
}
