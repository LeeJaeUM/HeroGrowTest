using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Bullet 프리팹
    public Transform objectSpawnPoint;  // Bullet이 생성될 위치
    public Transform target;  // 플레이어 Transform

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }
    private void Update()
    {
        if (target != null)
        {
            // 플레이어를 향하는 방향 벡터 계산 (Y축은 고정)
            Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

            // 즉시 회전할 방향으로 설정
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    //// 플레이어를 향하는 방향 벡터 계산
    //Vector3 direction = (target.position - transform.position).normalized;
    //// 회전할 방향 계산
    //Quaternion lookRotation = Quaternion.LookRotation(direction);
    //// 스포너를 플레이어 방향으로 회전
    //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

    // 총알을 생성하는 함수
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
