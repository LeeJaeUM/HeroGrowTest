using UnityEngine;


public class ExpItem : ItemBase
{
    protected override void Initialize()
    {
        amount = 10;
    }

    protected override void ApplyEffect(PlayerManager playerManager)
    {
        systemManager.AcquireItem(ItemType.Exp, amount);
    }
}
