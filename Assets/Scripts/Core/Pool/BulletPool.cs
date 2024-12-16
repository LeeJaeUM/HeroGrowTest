using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }
    public Bullet bulletPrefab;
    public int initialPoolSize = 20;
    private ObjectPool<Bullet> pool;

    private void Awake()
    {
        Instance = this;
        pool = new ObjectPool<Bullet>(bulletPrefab, initialPoolSize);
    }

    public Bullet GetBullet()
    {
        return pool.Get();
    }

    public void ReturnToPool(Bullet bullet)
    {
        pool.ReturnToPool(bullet);
    }
}