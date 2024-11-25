using UnityEngine;

public class RangedAttackLogic : WeaponAttackLogic
{
    private void Update()
    {
        transform.position = player.position;
    }
}
