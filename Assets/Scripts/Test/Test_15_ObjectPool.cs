using UnityEngine;
using UnityEngine.InputSystem;

public class Test_15_ObjectPool : TestBase
{
    public BulletPool bulletPool;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Bullet bullet = bulletPool.GetBullet();
        bullet.Initialize(transform.position, transform.forward * 10f);

    }
}
