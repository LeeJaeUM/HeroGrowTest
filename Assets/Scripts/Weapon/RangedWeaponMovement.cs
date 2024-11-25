using UnityEngine;

public class RangedWeaponMovement : WeaponMovement
{
    private void Update()
    {
        transform.position = player.position;
    }
}
