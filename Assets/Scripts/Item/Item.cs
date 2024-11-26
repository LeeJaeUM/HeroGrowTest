using UnityEngine;

public enum ItemType
{
    None,
    Coin,
    Heart,
    LootBox
}

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public int amount = 1;

    UIManager uiManager;

    private void Start()
    {
        switch (itemType)
        {
            case ItemType.Coin:
                amount = 50;
                break;
            case ItemType.Heart:
                amount = 20;
                break;
            case ItemType.LootBox:
                amount = 1;
                break;
            default:
                Debug.Log("아이템의 타입이 설정되지 않음");
                break;
        }

        uiManager = UIManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
        {
            switch (itemType)
            {
                case ItemType.Coin:
                case ItemType.LootBox:
                    uiManager.AcquireItem(itemType, amount);
                    break;
                case ItemType.Heart:
                    playerManager.AcquireItem_Heart(amount);
                    break;
                default:
                    Debug.Log("아이템의 타입이 설정되지 않음");
                    break;
            }
            Destroy(gameObject);
        }
    }
}
