using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_11_AddWeapon : TestBase
{
    public WeaponManager weaponManager;
    public int index = 0;

    [SerializeField]
    private List<Weapon> weaponEncyclopedia = new List<Weapon>();
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        weaponManager.AddWeapon(weaponEncyclopedia[index]);
    }
}
