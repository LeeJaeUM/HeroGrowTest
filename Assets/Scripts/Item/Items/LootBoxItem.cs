using UnityEngine;

public class LootBoxItem : ItemBase
{
    protected override void Initialize()
    {
        amount = 1;
    }

    protected override void ApplyEffect(PlayerManager playerManager)
    {
        systemManager.AcquireItem(ItemType.LootBox, amount);
    }
}