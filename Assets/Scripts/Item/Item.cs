using UnityEngine;

public enum ItemType
{
    Coin,
    Heart,
    LootBox
}

public class Item : MonoBehaviour
{
    public ItemType Type;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
        {
            switch (Type)
            {
                case ItemType.Coin:
                    playerManager.AcquireItem_Coin();
                    break;
                case ItemType.Heart:
                    playerManager.AcquireItem_Heart();
                    break;
                case ItemType.LootBox:
                    playerManager.AcquireItem_LootBox();
                    break;
                default:
                    Debug.Log("아이템의 타입이 설정되지 않음");
                    break;
            }
            Destroy(gameObject);
        }
    }
}
