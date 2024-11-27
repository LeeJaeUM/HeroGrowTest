using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damageAmount = 10f;
    public float dropItemHeight = 0.9f;
    public int expDropPercent = 30;

    [SerializeField]
    CharacterHP characterHP;

    private void Start()
    {
        characterHP = GetComponent<CharacterHP>();
        characterHP.OnDead += DeadEnemy;
    }

    private void OnDisable()
    {
        characterHP.OnDead -= DeadEnemy;
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

        // 적의 위치에 아이템을 생성
        GameManager.Instance.ItemManager.SpawnItem(enemyPosition, ItemType.Exp);
        if(UnityEngine.Random.Range(0, 100) < expDropPercent)
            GameManager.Instance.ItemManager.SpawnItem(enemyPosition, ItemType.Coin);
        
        GameManager.Instance.SystemManager.AddKillCount();

        // 적 오브젝트 파괴
        Destroy(gameObject);
    }
}
