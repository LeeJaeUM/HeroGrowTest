using UnityEngine;

public class EnemySpawner : ObjectSpawner
{
    [Header("Spawn EnclosingCircle")]
    public float radius = 5f;   // 반지름 (5 단위로 설정)
    public int addAngle = 10;   // 원형 생성 시 하나당 생성할 각도

    [Header("skip Instantiate")]
    public int skipAngle = 0;   // 원형 생성 시 비워 둘 각도
    public int skipCount = 3;   // 원형 생성 시 이어서 비울 갯수

    public override void SpawnObject()
    {
        if (target != null)
        {
            // 0에서 360도 사이의 랜덤 각도 생성
            float randomAngle = Random.Range(0f, 360f);

            // 랜덤 각도를 라디안으로 변환
            float radians = randomAngle * Mathf.Deg2Rad;

            // 원의 둘레에서 랜덤 위치 계산
            float x = target.position.x + Mathf.Cos(radians) * radius;
            float z = target.position.z + Mathf.Sin(radians) * radius;

            // Y축은 플레이어와 동일하게 설정
            Vector3 spawnPosition = new Vector3(x, target.position.y, z);

            // 오브젝트 생성
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
                // 랜덤 각도를 라디안으로 변환
                float radians = i * Mathf.Deg2Rad;

                // 원의 둘레에서 위치 계산
                float x = target.position.x + Mathf.Cos(radians) * radius;
                float z = target.position.z + Mathf.Sin(radians) * radius;

                // Y축은 플레이어와 동일하게 설정
                Vector3 spawnPosition = new Vector3(x, target.position.y, z);

                // 오브젝트 생성
                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    public void SpawnEnclosingCircle_RandomRemove()
    {
        if (target != null)
        {
            // 건너뛸 반복 횟수를 랜덤으로 결정 
            int excludeCount = Random.Range(1, 360 / addAngle);

            skipAngle = excludeCount * addAngle;

            for (int i = 0; i < 360; i += addAngle)
            {
                // 건너뛸 횟수를 추적하는 변수
                if (i >= skipAngle && i < skipAngle + addAngle * skipCount) continue;

                // 랜덤 각도를 라디안으로 변환
                float radians = i * Mathf.Deg2Rad;

                // 원의 둘레에서 위치 계산
                float x = target.position.x + Mathf.Cos(radians) * radius;
                float z = target.position.z + Mathf.Sin(radians) * radius;

                // Y축은 플레이어와 동일하게 설정
                Vector3 spawnPosition = new Vector3(x, target.position.y, z);

                // 오브젝트 생성
                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    /*
     *  원형 범위 내에 전부 랜덤으로 위치를 고른다
     *  즉 보스 패턴에 쓰기 좋다
             if (target != null)
        {
            // 플레이어를 기준으로 반지름 5인 원의 둘레에서 랜덤 위치 계산
            Vector3 randomDirection = Random.insideUnitCircle * radius; // 원의 둘레에서 랜덤한 점
            TestVec3 = randomDirection;
            Vector3 spawnPosition = new Vector3(target.position.x + randomDirection.x, target.position.y, target.position.z + randomDirection.y);

            // 오브젝트 생성
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Player is not assigned.");
        }
     */
}
