using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    public float radius = 5f;   // ������ (5 ������ ����)
    public int addAngle = 10;   // ���� ���� �� �ϳ��� ������ ����
    public int skipAngle = 0;   // ���� ���� �� ��� �� ����
    public int skipCount = 3;   // ���� ���� �� �̾ ��� ����

    public override void SpawnObject()
    {
        if (target != null)
        {
            // 0���� 360�� ������ ���� ���� ����
            float randomAngle = Random.Range(0f, 360f);

            // ���� ������ �������� ��ȯ
            float radians = randomAngle * Mathf.Deg2Rad;

            // ���� �ѷ����� ���� ��ġ ���
            float x = target.position.x + Mathf.Cos(radians) * radius;
            float z = target.position.z + Mathf.Sin(radians) * radius;

            // Y���� �÷��̾�� �����ϰ� ����
            Vector3 spawnPosition = new Vector3(x, target.position.y, z);

            // ������Ʈ ����
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Player is not assigned.");
        }
    }
    public void SpawnEnclosingCircle()
    {
        if (target != null)
        {
            for (int i = 0; i < 360; i += addAngle)
            {
                // ���� ������ �������� ��ȯ
                float radians = i * Mathf.Deg2Rad;

                // ���� �ѷ����� ��ġ ���
                float x = target.position.x + Mathf.Cos(radians) * radius;
                float z = target.position.z + Mathf.Sin(radians) * radius;

                // Y���� �÷��̾�� �����ϰ� ����
                Vector3 spawnPosition = new Vector3(x, target.position.y, z);

                // ������Ʈ ����
                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    public void SpawnEnclosingCircle_RandomMinus()
    {
        if (target != null)
        {
            // �ǳʶ� �ݺ� Ƚ���� �������� ���� 
            int excludeCount = Random.Range(1, 360 / addAngle);

            skipAngle = excludeCount * addAngle;

            for (int i = 0; i < 360; i += addAngle)
            {
                // �ǳʶ� Ƚ���� �����ϴ� ����
                if (i >= skipAngle && i < skipAngle + addAngle * skipCount) continue;

                // ���� ������ �������� ��ȯ
                float radians = i * Mathf.Deg2Rad;

                // ���� �ѷ����� ��ġ ���
                float x = target.position.x + Mathf.Cos(radians) * radius;
                float z = target.position.z + Mathf.Sin(radians) * radius;

                // Y���� �÷��̾�� �����ϰ� ����
                Vector3 spawnPosition = new Vector3(x, target.position.y, z);

                // ������Ʈ ����
                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    /*
     *  ���� ���� ���� ���� �������� ��ġ�� ����
     *  �� ���� ���Ͽ� ���� ����
             if (target != null)
        {
            // �÷��̾ �������� ������ 5�� ���� �ѷ����� ���� ��ġ ���
            Vector3 randomDirection = Random.insideUnitCircle * radius; // ���� �ѷ����� ������ ��
            TestVec3 = randomDirection;
            Vector3 spawnPosition = new Vector3(target.position.x + randomDirection.x, target.position.y, target.position.z + randomDirection.y);

            // ������Ʈ ����
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Player is not assigned.");
        }
     */
}
