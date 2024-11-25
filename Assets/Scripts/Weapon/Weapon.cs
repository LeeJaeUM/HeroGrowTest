using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;    // 무기 이름
    public int weaponID;         // 고유 번호 (예: 1 = 단검, 2 = 레이저, 3 = 활)
    public int currentLevel = 1; // 현재 레벨 (초기값 1)
    public int maxLevel = 5;     // 최대 레벨
    public int damage = 5;

    private WeaponManager weaponManager;

    private void Start()
    {
        weaponManager = transform.GetComponentInParent<WeaponManager>();
    }

    public bool UpgradeWeapon()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            return true;
        }
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyManager>(out EnemyManager enemy))
        {
            enemy.DecreaseEnemyHealth(damage);
            Debug.Log("Enemy hit! Health reduced by " + damage);
        }
    }
}
