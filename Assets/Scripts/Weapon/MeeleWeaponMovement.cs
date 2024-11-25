using UnityEngine;

public class MeeleWeaponMovement : WeaponMovement
{
    public float orbitRadius = 2f;
    public float orbitSpeed = 5f;
    private float currentAngle = 0f; // 현재 각도 (라디안 단위)

    void Update()
    {
        // 현재 각도 업데이트
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle %= 2 * Mathf.PI; // 각도를 0 ~ 2π로 제한

        // 새로운 위치 계산
        float x = Mathf.Cos(currentAngle) * orbitRadius;
        float z = Mathf.Sin(currentAngle) * orbitRadius;

        transform.position = new Vector3(player.position.x + x, player.position.y, player.position.z + z);

        // 무기가 플레이어의 반대 방향을 바라보게 설정
        Vector3 directionToPlayer = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-directionToPlayer); // 플레이어의 반대 방향을 바라봄
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyManager>(out EnemyManager enemy))
        {
            enemy.DecreaseEnemyHealth(weaponData.damage);
            Debug.Log("Enemy hit! Health reduced by " + weaponData.damage);
        }
    }
}
