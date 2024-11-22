using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private float coinCount = 10;
    [SerializeField]
    private int lootBoxCount = 0;
    
    UIManager uiManager;

    public void AcquireItem(ItemType itemType, int amount)
    {
        switch (itemType)
        {
            case ItemType.Coin:
                Debug.Log("coin 획득");
                coinCount += amount;
                break;
            case ItemType.LootBox:
                Debug.Log("lootBox 획득");
                lootBoxCount+= amount;
                break;
        }

    }
}
