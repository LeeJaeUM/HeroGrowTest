using UnityEngine;

public class CoinItem : ItemBase
{
    protected override void Initialize()
    {
        amount = 5;
    }

    protected override void ApplyEffect(PlayerManager playerManager)
    {
        systemManager.AcquireItem(ItemType.Coin, amount);
    }
}
