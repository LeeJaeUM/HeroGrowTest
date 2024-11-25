using System.Collections;
using UnityEngine;

public class BulletSpawner : ObjectSpawner
{
    public Transform bulletSpawnPoint;  // Bullet이 생성될 위치
    protected Vector3 direction = Vector3.zero;
    public bool isHostile = true;
    public float searchRadius = 10f; // 검색 반경 
    public LayerMask enemyLayer;    // 적이 포함된 레이어

    public float fireRate = 1f; // 발사 간격 (초 단위)
    public bool isFiring = false;

    private void OnEnable()
    {
        bulletSpawnPoint = transform.GetChild(0).transform;
        StartFiring(); // 활성화 시 발사 시작
    }

    private void OnDisable()
    {
        StopFiring(); // 비활성화 시 발사 중지
    }

    protected override void Start()
    {
        base.Start();
        if (isHostile)
            bulletSpawnPoint = gameObject.transform.GetChild(0).transform;
        else
            bulletSpawnPoint = gameObject.transform;
    }

    private void Update()
    {
        if (!isHostile)
        {
            target = FindEnemy();
        }

        if (target != null)
        {
            // 타겟을 향하는 방향 벡터 계산 (Y축은 고정)
            direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

            // 즉시 회전할 방향으로 설정
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void SpawnObject()
    {
        if (objectPrefab != null && bulletSpawnPoint != null)
        {
            //생성될 총알의 방향 지정
            Quaternion rotation = Quaternion.LookRotation(direction);

            // 오브젝트를 바라보는 방향으로 생성
            Instantiate(objectPrefab, bulletSpawnPoint.position, rotation);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }

    public Transform FindEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius, enemyLayer);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy")) // "Enemy" 태그가 붙은 객체만 확인
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.transform;
                }
            }
        }

        return closestEnemy; // 가장 가까운 적의 Transform 반환 (없으면 null)
    }
    private void OnDrawGizmosSelected()
    {
        // 반경 표시 (디버깅용)
        if (!isHostile)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, searchRadius);
        }
    }
    public void StartFiring()
    {
        if (!isFiring)
        {
            isFiring = true;
            StartCoroutine(FireCoroutine());
        }
    }

    public void StopFiring()
    {
        isFiring = false;
        StopCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            SpawnObject(); // 화살 생성
            yield return new WaitForSeconds(fireRate); // 1초 대기
        }
    }
}
//// 플레이어를 향하는 방향 벡터 계산
//Vector3 direction = (target.position - transform.position).normalized;
//// 회전할 방향 계산
//Quaternion lookRotation = Quaternion.LookRotation(direction);
//// 스포너를 플레이어 방향으로 회전
//transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
