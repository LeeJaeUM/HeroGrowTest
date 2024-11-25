using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damageAmount = 10f;
    public float dropItemHeight = 0.9f;

    [SerializeField]
    CharacterHP characterHP;
    public GameObject dropCoin;

    private void Start()
    {
        characterHP = GetComponent<CharacterHP>();
        characterHP.onDead += DeadEnemy;
    }

    private void OnDisable()
    {
        characterHP.onDead -= DeadEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out PlayerManager playerManager))
        {
            // Call the DecreasePlayerHealth function on the PlayerManager
            playerManager.DecreasePlayerHealth(damageAmount);
            Debug.Log("Player hit! Health reduced by " + damageAmount);
        }
    }

    public void IncreaseEnemyHealth(float amount)
    {
        if (characterHP != null)
        {
            characterHP.IncreaseHP(amount);
        }
    }
    public void DecreaseEnemyHealth(float amount)
    {
        if (characterHP != null)
        {
            characterHP.DecreaseHP(amount);
        }
    }

    public void DeadEnemy()
    {
        // 적의 현재 위치를 얻어옴
        Vector3 enemyPosition = new Vector3(transform.position.x, dropItemHeight, transform.position.z);

        // 적의 위치에 코인을 생성
        Instantiate(dropCoin, enemyPosition, Quaternion.identity);

        // 적 오브젝트 파괴
        Destroy(gameObject);
    }
}
