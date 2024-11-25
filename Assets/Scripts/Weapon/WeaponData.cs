using UnityEngine;

public class WeaponData : MonoBehaviour
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
        weaponManager.OnWeaponLevelUp += UpgradeWeapon;
    }

    public void UpgradeWeapon(int _weaponID)
    {
        if (weaponID != _weaponID)
            return;

        if (currentLevel < maxLevel)
        {
            currentLevel++;
        }
    }

}
