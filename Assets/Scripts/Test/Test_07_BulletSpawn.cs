using UnityEngine;
using UnityEngine.InputSystem;

public class Test_07_BulletSpawn : TestBase
{
    public ObjectSpawner bulletSpawner;
    public EnemySpawner enemySpawner;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        bulletSpawner.SpawnObject();
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        enemySpawner.SpawnObject();
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        enemySpawner.SpawnEnclosingCircle();
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        enemySpawner.SpawnEnclosingCircle_RandomMinus();
    }
}
