using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_11_AddWeapon : TestBase
{
    public WeaponManager weaponManager;
    //public int index = 0;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
       weaponManager.AddWeapon(0);
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        weaponManager.AddWeapon(1);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        weaponManager.AddWeapon(2);
    }
}
