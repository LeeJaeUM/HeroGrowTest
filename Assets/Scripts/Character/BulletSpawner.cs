using UnityEngine;

public class BulletSpawner : ObjectSpawner
{
    Vector3 direction = Vector3.zero;

    private void OnEnable()
    {
        objectSpawnPoint = gameObject.transform.GetChild(0).transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // �÷��̾ ���ϴ� ���� ���� ��� (Y���� ����)
            direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

            // ��� ȸ���� �������� ����
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void SpawnObject()
    {
        if (objectPrefab != null && objectSpawnPoint != null)
        {
            //������ �Ѿ��� ���� ����
            Quaternion rotation = Quaternion.LookRotation(direction);

            // ������Ʈ�� �ٶ󺸴� �������� ����
            Instantiate(objectPrefab, objectSpawnPoint.position, rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }

    //// �÷��̾ ���ϴ� ���� ���� ���
    //Vector3 direction = (target.position - transform.position).normalized;
    //// ȸ���� ���� ���
    //Quaternion lookRotation = Quaternion.LookRotation(direction);
    //// �����ʸ� �÷��̾� �������� ȸ��
    //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

}
