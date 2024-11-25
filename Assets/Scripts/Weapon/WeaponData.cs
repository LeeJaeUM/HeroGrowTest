using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public string weaponName;    
    public int weaponID;         // 고유 번호 (예: 1 = 단검, 2 = 레이저, 3 = 활)
    [SerializeField]
    private int currentLevel = 1;
    public int CurrentLevel
    {
        get => currentLevel;
        private set => currentLevel = value;
    }

    public int maxLevel = 5;     
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
            CurrentLevel++;
        }
    }

}
