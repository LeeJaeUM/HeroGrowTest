using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] allWeapons; // 모든 무기 데이터
    public GameObject[] equippedWeapons = new GameObject[6]; // 장착된 무기
    [SerializeField]
    private bool[] weaponEquipped; // 무기 장착 여부 (allWeapons 크기와 동일)
    public int[] equippedWeaponsLevel = new int[6];

    public event Action<int> OnWeaponLevelUp;

    private void Awake()
    {
        weaponEquipped = new bool[allWeapons.Length];
    }

    public bool AddWeapon(int weaponID)
    {
        if (weaponID < 0 || weaponID >= allWeapons.Length)
        {
            Debug.LogWarning("Invalid weapon index.");
            return false;
        }

        if (weaponEquipped[weaponID])
        {
            LevelUpWeapon(weaponID);
            return false;
        }

        // 빈 슬롯에 무기 추가
        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            if (equippedWeapons[i] == null)
            {
                equippedWeapons[i] = allWeapons[weaponID];
                weaponEquipped[weaponID] = true;     

                GameObject weaponInstance = Instantiate(equippedWeapons[i]);
                weaponInstance.transform.SetParent(transform);

                Debug.Log($"Weapon {weaponID} added.");
                return true;
            }
        }

        Debug.LogWarning("No empty slot available.");
        return false;
    }

    private void LevelUpWeapon(int weaponID)
    {
        equippedWeaponsLevel[weaponID]++;
        OnWeaponLevelUp?.Invoke(weaponID);
        Debug.Log($"Weapon {weaponID} leveled up to level {equippedWeaponsLevel[weaponID]}.");
    }


    //public void AddWeapon(int _weaponID)
    //{
    //    // 이미 획득한 무기가 있는지 고유 번호로 확인
    //    //Weapon existingWeapon = ingameWeapons.Find(w =>w.weaponID == weaponID);
    //    Weapon existingWeapon = null;

    //    for(int i = 0; i < ingameWeapons.Length; i++)
    //    {
    //        if(ingameWeapons[i].TryGetComponent<Weapon>(out existingWeapon))
    //        {

    //        }
    //    }
    //}
    //public List<Weapon> GetWeapons()
    //{
    //    return ingameWeapons;
    //}
}


/*
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
}*/