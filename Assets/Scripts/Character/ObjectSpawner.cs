using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Bullet ������
    public Transform objectSpawnPoint;  // Bullet�� ������ ��ġ
    public Transform target;  // �÷��̾� Transform

    void Start()
    {
        FindPlayer();
    }

    // �Ѿ��� �����ϴ� �Լ�
    public virtual void SpawnObject()
    {
        if (objectPrefab != null && objectSpawnPoint != null)
        {
            Instantiate(objectPrefab, objectSpawnPoint.position, objectSpawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }

    public void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player �±׸� ���� ������Ʈ�� ã�� �� �����ϴ�!");
        }
    }
}
