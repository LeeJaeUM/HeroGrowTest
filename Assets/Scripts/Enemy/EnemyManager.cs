using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damageAmount = 10f;
    public float dropItemHeight = 0.9f;

    [SerializeField]
    CharacterHP characterHP;
    public GameObject dropCoin;

    private void Awake()
    {
        characterHP = GetComponent<CharacterHP>();
    }

    private void OnEnable()
    {
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
        // ���� ���� ��ġ�� ����
        Vector3 enemyPosition = new Vector3(transform.position.x, dropItemHeight, transform.position.z);

        // ���� ��ġ�� ������ ����
        Instantiate(dropCoin, enemyPosition, Quaternion.identity);

        // �� ������Ʈ �ı�
        Destroy(gameObject);
    }
}
