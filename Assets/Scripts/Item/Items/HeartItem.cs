using UnityEngine;
public class HeartItem : ItemBase
{
    protected override void Initialize()
    {
        amount = 20;
    }

    protected override void ApplyEffect(PlayerManager playerManager)
    {
        playerManager.AcquireItem_Heart(amount);
    }
}
