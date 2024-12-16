using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    public float lifeTime = 5f;  // Bullet's lifetime before it's destroyed
    public float damageAmount = 10.0f;
    public bool isEnemyBullet = true;
    private void OnDisable()
    {
        // 비활성화 될 때 풀로 되돌립니다.
        if (BulletPool.Instance != null)
        {
            BulletPool.Instance.ReturnToPool(this);
        }
    }

    public void Initialize(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(direction);
        StartCoroutine(InitialCo());
    }

    //private void Start()
    //{
    //    // Destroy the bullet after lifeTime seconds
    //    Destroy(gameObject, lifeTime);
        
    //}

    private void Update()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어의 총알이 적과 충돌한 경우
        if (!isEnemyBullet)
        {
            if (other.TryGetComponent<EnemyManager>(out EnemyManager enemy))
            {
                enemy.DecreaseEnemyHealth(damageAmount);
                Debug.Log("Enemy hit! Health reduced by " + damageAmount);
                Destroy(gameObject);
            }
        }
        else if (isEnemyBullet)
        {
            if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
            {
                // Call the DecreasePlayerHealth function on the PlayerManager
                playerManager.DecreasePlayerHealth(damageAmount);
                Debug.Log("Player hit! Health reduced by " + damageAmount);
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator InitialCo()
    {
        yield return new WaitForSeconds(lifeTime);
        OnDisable();
    }
}