using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;  // Bullet ������
    public Transform bulletSpawnPoint;  // Bullet�� ������ ��ġ
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
    public void SpawnBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }
}
