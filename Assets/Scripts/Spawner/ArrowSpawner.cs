using UnityEngine;

public class ArrowSpawner : BulletSpawner
{
    public float spreadAngle = 10f; // 화살의 퍼짐 각도
    [SerializeField]
    WeaponData weaponData;

    private void Awake()
    {
        weaponData = GetComponent<WeaponData>();
    }

    public override void SpawnObject()
    {
        if (objectPrefab != null)
        {
            int arrowCount = Mathf.Clamp(weaponData.CurrentLevel, 1, weaponData.maxLevel); // 레벨에 따라 발사 개수 결정

            for (int i = 0; i < arrowCount; i++)
            {
                // 각 화살의 방향 계산 (왼쪽부터 오른쪽으로 퍼지도록 설정)
                Quaternion rotation = Quaternion.LookRotation(direction);
                float angleOffset = spreadAngle * (i - (arrowCount - 1) / 2f);
                Quaternion spreadRotation = rotation * Quaternion.Euler(0f, angleOffset, 0f);

                // 오브젝트를 생성
                Instantiate(objectPrefab, transform.position, spreadRotation);
            }
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Spawn Point is not assigned.");
        }
    }
}
