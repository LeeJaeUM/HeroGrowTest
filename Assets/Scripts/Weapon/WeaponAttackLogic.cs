using UnityEngine;

public class WeaponAttackLogic : MonoBehaviour
{
    private WeaponData weaponData;

    private void Start()
    {
        weaponData = GetComponent<WeaponData>();
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
