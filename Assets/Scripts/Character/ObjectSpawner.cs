using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Bullet ������
    public Transform objectSpawnPoint;  // Bullet�� ������ ��ġ
    public Transform target;  // �÷��̾� Transform

    void Start()
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
    private void Update()
    {
        if (target != null)
        {
            // �÷��̾ ���ϴ� ���� ���� ��� (Y���� ����)
            Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

            // ��� ȸ���� �������� ����
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    //// �÷��̾ ���ϴ� ���� ���� ���
    //Vector3 direction = (target.position - transform.position).normalized;
    //// ȸ���� ���� ���
    //Quaternion lookRotation = Quaternion.LookRotation(direction);
    //// �����ʸ� �÷��̾� �������� ȸ��
    //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

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
}
