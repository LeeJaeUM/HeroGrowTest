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
            // 플레이어를 향하는 방향 벡터 계산 (Y축은 고정)
            direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

            // 즉시 회전할 방향으로 설정
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void SpawnObject()
    {
        if (objectPrefab != null && objectSpawnPoint != null)
        {
            //생성될 총알의 방향 지정
            Quaternion rotation = Quaternion.LookRotation(direction);

            // 오브젝트를 바라보는 방향으로 생성
            Instantiate(objectPrefab, objectSpawnPoint.position, rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }

    //// 플레이어를 향하는 방향 벡터 계산
    //Vector3 direction = (target.position - transform.position).normalized;
    //// 회전할 방향 계산
    //Quaternion lookRotation = Quaternion.LookRotation(direction);
    //// 스포너를 플레이어 방향으로 회전
    //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

}
