using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private List<Weapon> weaponEncyclopedia = new List<Weapon>();    
    [SerializeField]
    private List<Weapon> ingameWeapons = new List<Weapon>();
    private int maxWeaponSlots = 6;

    public void AddWeapon(Weapon weapon)
    {
        // 이미 획득한 무기가 있는지 고유 번호로 확인
        Weapon existingWeapon = ingameWeapons.Find(w => w.weaponID == weapon.weaponID);

        if (existingWeapon != null)
        {
            // 무기 업그레이드
            if (existingWeapon.UpgradeWeapon())
            {
                Debug.Log($"{weapon.weaponName} 업그레이드! 현재 레벨: {existingWeapon.currentLevel}");
            }
            else
            {
                Debug.Log($"{weapon.weaponName}은 최대 레벨에 도달했습니다.");
            }
        }
        else
        {
            // 새로운 무기를 추가
            if (ingameWeapons.Count < maxWeaponSlots)
            {
                ingameWeapons.Add(weapon);

                // prefab 인스턴스화
                GameObject weaponInstance = Instantiate(weapon.prefab);

                // WeaponManager의 자식으로 설정
                weaponInstance.transform.SetParent(transform);
                Debug.Log($"{weapon.weaponName} 획득!");
            }
            else
            {
                Debug.Log("더 이상 무기를 추가할 수 없습니다.");
            }
        }
    }

    public List<Weapon> GetWeapons()
    {
        return ingameWeapons;
    }
}