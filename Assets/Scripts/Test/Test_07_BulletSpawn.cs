using UnityEngine;
using UnityEngine.InputSystem;

public class Test_07_BulletSpawn : TestBase
{
    public BulletSpawner bulletSpawner;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        bulletSpawner.SpawnBullet();
    }
}
